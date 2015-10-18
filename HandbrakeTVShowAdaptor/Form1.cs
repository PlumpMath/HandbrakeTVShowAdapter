using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using HandBrake.Interop;
using HandBrake.Interop.EventArgs;
using HandBrake.Interop.Model;
using HandBrake.Interop.Model.Encoding;
using HandBrake.Interop.SourceData;
using TvdbLib.Data;

namespace HandbrakeTVShowAdaptor
{
    public partial class Form1 : Form
    {
        private readonly HandBrakeInstance scanningInstance;
        private readonly BindingList<QueueItem> queue = new BindingList<QueueItem>();
        private readonly BindingList<DvdInfo> scanningQueue = new BindingList<DvdInfo>();
        private TvdbSeries downloadSeries;
        private readonly BindingList<TitleAndDvd> availableTitles = new BindingList<TitleAndDvd>();
        private readonly BindingList<TitleAndDvd> allTitles = new BindingList<TitleAndDvd>();
        private readonly BindingList<DvdInfo> availableDvds = new BindingList<DvdInfo>();
        private readonly BindingList<string> availableEpisodes = new BindingList<string>();
        private bool breakIntoChapters = false;

        public Form1(HandBrakeInstance scanningInstance)
        {
            InitializeComponent();
            this.scanningInstance = scanningInstance;
            scanningInstance.ScanCompleted += HandBrakeInstanceOnScanCompleted;
            scanningInstance.ScanProgress += HandBrakeInstanceOnScanProgress;
            queue.Clear();
            queueGrid.DataSource = queue;
            scanningInstance.EncodeProgress += HandBrakeInstanceOnEncodeProgress;
            scanningInstance.EncodeCompleted += HandBrakeInstanceOnEncodeCompleted;
            profileNameCombo.Items.Add("Normal");
            profileNameCombo.Items.Add("High");
            titlesListBox.DataSource = availableTitles;
            availableEpisodesListBox.DataSource = availableEpisodes;

            
            dvdsListBox.DataSource = availableDvds;

            FindDvdsFrom(@"H:\DVDs\");


        }

        private void FindDvdsFrom(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var subDirectories = directoryInfo.EnumerateDirectories().OrderBy(d=>d.Name);

            foreach (var subDirectory in subDirectories)
            {
                if (subDirectory.EnumerateDirectories().Any(d => d.Name == "VIDEO_TS" || d.Name == "BDMV"))
                {
                    availableDvds.Add(new DvdInfo(subDirectory.FullName, subDirectory.Name));
                }
                else
                {
                    FindDvdsFrom(subDirectory.FullName);
                }
            }
        }

        private void HandBrakeInstanceOnEncodeCompleted(object sender, EncodeCompletedEventArgs encodeCompletedEventArgs)
        {
            if (queueGrid.InvokeRequired)
            {
                queueGrid.Invoke(new Program.InvokeDelegate(() => HandBrakeInstanceOnEncodeCompleted(sender, encodeCompletedEventArgs)));
            }
            else
            {
                QueueItem encodingItem = queue.Single(q => q.ProcessingStatus == ProcessingStatus.ENCODING);
                encodingItem.Progress = "100%";
                encodingItem.ProcessingStatus = ProcessingStatus.DONE;
                if (queue.Any(i => i.ProcessingStatus == ProcessingStatus.WAITING))
                {
                    IEnumerable<QueueItem> queueItems = queue.Where(i => i.ProcessingStatus == ProcessingStatus.WAITING).Take(1);
                    StartEncode(queueItems.Single());
                }    
            }
            
        }

        private void HandBrakeInstanceOnEncodeProgress(object sender, EncodeProgressEventArgs encodeProgressEventArgs)
        {
            if (queueGrid.InvokeRequired)
            {
                queueGrid.Invoke(new Program.InvokeDelegate(() => HandBrakeInstanceOnEncodeProgress(sender, encodeProgressEventArgs)));
            }
            else
            {
                string percentComplete = Math.Round((encodeProgressEventArgs.FractionComplete * 100), 2) + "%";
                string statusString = percentComplete + " (" + encodeProgressEventArgs.AverageFrameRate + "fps)";
                queue.Single(q => q.ProcessingStatus == ProcessingStatus.ENCODING).Progress = statusString;    
            }
            
        }

        private void StartEncode(QueueItem queueItem)
        {
            queueItem.ProcessingStatus = ProcessingStatus.ENCODING;
            queueItem.Progress = "0.0%";
            var serializer = new XmlSerializer(typeof(EncodingProfile));
            EncodingProfile profile;
            string profileName = queueItem.Profile;
            using (var stream = new FileStream(profileName+".xml", FileMode.Open, FileAccess.Read))
            {
                profile = serializer.Deserialize(stream) as EncodingProfile;
            }
            profile.Quality = queueItem.CRF;
            if (deinterlaceCheckBox.Checked)
            {
                profile.Deinterlace = Deinterlace.Fast;
            }
            if (queueItem.MaxWidth != 0)
            {
                profile.MaxWidth = queueItem.MaxWidth;
            }
            try
            {
                StartEncode(queueItem, profile);    
            } catch(NullReferenceException ex)
            {
                Console.Out.WriteLine(queueItem);
                Console.Out.WriteLine(profile);
                StartEncode(queueItem,profile);
            }
            

        }

        private void StartEncode(QueueItem queueItem, EncodingProfile profile)
        {
            var encodingInstance = new HandBrakeInstance();
            encodingInstance.Initialize(1);
            encodingInstance.EncodeCompleted += HandBrakeInstanceOnEncodeCompleted;
            encodingInstance.EncodeProgress+=HandBrakeInstanceOnEncodeProgress;
            if (queueItem.SourceType == SourceType.VideoFolder)
            {
                encodingInstance.ScanCompleted += (sender, args) => encodingInstance.StartEncode(CreateEcodeJob(queueItem, profile));
                encodingInstance.StartScan(queueItem.Dvd.Path, 10, queueItem.Title.TitleNumber);

            }
            else
            {
                encodingInstance.ScanCompleted += (sender, args) =>
                {
                    var jobToStart = new EncodeJob
                    {
                        EncodingProfile = profile,
                        RangeType = VideoRangeType.All,
                        Title = 1,
                        SourcePath = queueItem.FileName.Replace("\\\\", "\\"),
                        OutputPath = queueItem.EpisodeName.Replace("\\\\","\\") + ".mp4",
                        ChosenAudioTracks = new List<int> { 1 },
                        Subtitles = new Subtitles
                        {
                            SourceSubtitles = new List<SourceSubtitle>(),
                            SrtSubtitles = new List<SrtSubtitle>()
                        }
                    };
                    encodingInstance.StartEncode(jobToStart);
                };
                encodingInstance.StartScan(queueItem.FileName.Replace("\\\\", "\\"), 10);
            }
            
        }

        private static EncodeJob CreateEcodeJob(QueueItem queueItem, EncodingProfile profile)
        {
            var encodeJob = new EncodeJob
            {
                SourceType = queueItem.SourceType,
                OutputPath = @"H:\encodes\" + queueItem.EpisodeName + ".mp4",
                ChosenAudioTracks = new List<int> {1},
                RangeType = VideoRangeType.All,
                Subtitles = new Subtitles
                {
                    SourceSubtitles = new List<SourceSubtitle>()
                    {
                        new SourceSubtitle()
                        {
                            BurnedIn =
                                true,
                            Default =
                                true,
                            Forced = true,
                            TrackNumber =
                                0
                            //Foreign Audio Scan
                        }
                    },
                    SrtSubtitles = new List<SrtSubtitle>()
                },
                EncodingProfile = profile

            };
            if (queueItem.SourceType == SourceType.VideoFolder)
            {
                encodeJob.Title = queueItem.Title.TitleNumber;
                if (queueItem.Chapter != null)
                {
                    encodeJob.ChapterStart = queueItem.Chapter.ChapterNumber;
                    encodeJob.ChapterEnd = queueItem.Chapter.ChapterNumber;
                    encodeJob.RangeType = VideoRangeType.Chapters;
                }
            }
            else
            {
                encodeJob.SourcePath = queueItem.FileName;
                encodeJob.RangeType=VideoRangeType.All;
                encodeJob.Title = 1;

            }
            return encodeJob;
        }

        private void HandBrakeInstanceOnScanProgress(object sender, ScanProgressEventArgs scanProgressEventArgs)
        {
            if (titleProgressBar.InvokeRequired)
            {
                titleProgressBar.BeginInvoke(
                    new Program.InvokeDelegate(() => UpdateTitleProgress(scanProgressEventArgs.Progress)));
            }
            else
            {
                UpdateTitleProgress(scanProgressEventArgs.Progress);
            }

        }

        private void UpdateTitleProgress(float progress)
        {
            titleProgressBar.Value = (int) (progress*100);
        }

        private void HandBrakeInstanceOnScanCompleted(object sender, EventArgs eventArgs)
        {
            if (titlesListBox.InvokeRequired)
            {
                titlesListBox.BeginInvoke(new Program.InvokeDelegate(() => HandBrakeInstanceOnScanCompleted(sender, eventArgs)));

            }
            else
            {
                var scannedDvd = scanningQueue.First();
                scanningQueue.Remove(scannedDvd);
                foreach (Title title in scanningInstance.Titles)
                {
                    if (breakIntoChapters)
                    {
                        foreach (var chapter in title.Chapters)
                        {
                            availableTitles.Add(new TitleAndDvd(title, scannedDvd, chapter));
                            allTitles.Add(new TitleAndDvd(title, scannedDvd, chapter));
                        }
                    }
                    else
                    {
                        availableTitles.Add(new TitleAndDvd(title, scannedDvd, null));
                        allTitles.Add(new TitleAndDvd(title, scannedDvd, null));
                    }
                    
                    
                }
                RemoveTitlesWithIncorrectLengths();
                titleProgressBar.Value = 100;
                if (scanningQueue.Any())
                {
                    scanningDvdName.Text = scanningQueue.First().Title;
                    scanningInstance.StartScan(scanningQueue.First().Path, 10);
                }           
            }
        }

        private void TextBox2Leave(object sender, EventArgs e)
        {
            seriesNumberComboBox.DataSource = null;
            
            var tvdbDownloader = new TvdbLib.TvdbDownloader("741D35F7764BE220");
            List<TvdbSearchResult> downloadSearchResults = tvdbDownloader.DownloadSearchResults(textBox2.Text);
            if (downloadSearchResults.Count>1)
            {
                downloadSearchResults = downloadSearchResults.Where(d => d.SeriesName == textBox2.Text).ToList();
                if (downloadSearchResults.Count > 1)
                {
                    MessageBox.Show("Too many results found");
                    return;
                }
            }
            if (downloadSearchResults.Count==0)
            {
                MessageBox.Show("No results found");
                return;
            }
            downloadSeries = tvdbDownloader.DownloadSeries(downloadSearchResults.Single().Id, TvdbLanguage.DefaultLanguage, true, false,
                                                           false);
            availableEpisodes.Clear();   
            var series = downloadSeries.Episodes.Select(ep => ep.SeasonNumber).Distinct().ToList();
            seriesNumberComboBox.DataSource = series;
            seriesNumberComboBox.Refresh();

            foreach (var tvdbEpisode in downloadSeries.Episodes)
            {

                availableEpisodes.Add(GetFileNameFromEpisode(tvdbEpisode, downloadSearchResults.Single().SeriesName));
            }
            runtimeTextBox.Text = downloadSeries.Runtime.ToString();
            RemoveTitlesWithIncorrectLengths();
        }

        private void RemoveTitlesWithIncorrectLengths()
        {
            if (downloadSeries==null)
            {
                return;
            }
            var titlesToRemove = new List<TitleAndDvd>();
            availableTitles.Clear();
            foreach (var titleAndDvd in allTitles)
            {
                availableTitles.Add(titleAndDvd);
            }
            var runtime = 0;
            
            int.TryParse(runtimeTextBox.Text, out runtime);
            if (runtime == 0)
            {
                return;
            }
            foreach (var availableTitle in availableTitles)
            {
                double durationAsPercentageOfExpectedRuntime = Math.Abs(availableTitle.Duration.TotalMinutes/runtime);
                if (durationAsPercentageOfExpectedRuntime < 0.60 || durationAsPercentageOfExpectedRuntime > 1.10)
                {
                    titlesToRemove.Add(availableTitle);
                }
            }
            foreach (var title in titlesToRemove)
            {
                availableTitles.Remove(title);
            }
        }

        private static string GetFileNameFromEpisode(TvdbEpisode tvdbEpisode, string seriesName)
        {
            string seasonAndEpisode = tvdbEpisode.SeasonNumber==0 ? "" : "S" + PadZero(tvdbEpisode.SeasonNumber) + "E" + PadZero(tvdbEpisode.EpisodeNumber) + " - ";
            return seriesName +  " - " + seasonAndEpisode + tvdbEpisode.EpisodeName;
        }

        private static string PadZero(int number)
        {
            if (number.ToString().Length<2)
            {
                return "0" + number;
            }
            return number.ToString();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            if (titlesListBox.CheckedItems.Count!=availableEpisodesListBox.CheckedItems.Count)
            {
                MessageBox.Show(@"Choose as many titles as episodes");
                return;
            }
            int i = 0;
            foreach (TitleAndDvd item in titlesListBox.CheckedItems)
            {
                string episodeName = availableEpisodesListBox.CheckedItems.Cast<string>().Skip(i).Take(1).Single();
                foreach (var fileNameChar in Path.GetInvalidFileNameChars())
                {
                    episodeName = episodeName.Replace(fileNameChar, '_');
                }
                queue.Add(new QueueItem()
                              {
                                  SeriesName = textBox2.Text,
                                  EpisodeName = episodeName,
                                  Title = item.Title,
                                  Dvd = item.ScannedDvd,
                                  SourceType = SourceType.VideoFolder,
                                  Profile =
                                      string.IsNullOrEmpty(profileNameCombo.Text) ? "Normal" : profileNameCombo.Text,
                                  CRF = int.Parse(crfComboBox.Text),
                                  Chapter = item.Chapter

                              });
                i++;
            }
        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            if(queue.Any(q=>q.ProcessingStatus!=ProcessingStatus.DONE) && !queue.Any(q=>q.ProcessingStatus==ProcessingStatus.ENCODING))
            {
                StartEncode(queue.Where(q=>q.ProcessingStatus!=ProcessingStatus.DONE).First());
            }
        }

        private void SeriesNumberComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int seriesNumber = int.Parse(seriesNumberComboBox.Text);

            availableEpisodes.Clear();
            IEnumerable<TvdbEpisode> filteredEpisodes = downloadSeries.Episodes.Where(ep => ep.SeasonNumber == seriesNumber).ToList();
            foreach (string episodeName in filteredEpisodes.Select(ep => GetFileNameFromEpisode(ep, downloadSeries.SeriesName)))
            {
                availableEpisodes.Add(episodeName);
            }
            if (availableTitles.Count == availableEpisodes.Count)
            {
                SetAllItemsChecked(availableEpisodesListBox);    
                SetAllItemsChecked(titlesListBox);    
            }
        }

        private static void SetAllItemsChecked(CheckedListBox listBox)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i,true);
            }
        }

        private void StartScanButtonClick(object sender, EventArgs e)
        {
            breakIntoChapters = false;
            StartScan();
        }

        private void StartScan()
        {
            var selectedDvds = dvdsListBox.CheckedItems.Cast<DvdInfo>();
            if (!selectedDvds.Any())
            {
                return;
            }
            availableTitles.Clear();
            allTitles.Clear();
            foreach (var selectedDvd in selectedDvds)
            {
                scanningQueue.Add(selectedDvd);
            }
            scanningDvdName.Text = scanningQueue.First().Title;
            scanningInstance.StartScan(scanningQueue.First().Path, 10);
        }

        private void RuntimeTextBoxTextChanged(object sender, EventArgs e)
        {
            RemoveTitlesWithIncorrectLengths();
        }

        private void deinterlaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void selectAllTitlesButton_Click(object sender, EventArgs e)
        {
            SetAllItemsChecked(titlesListBox); 
        }

        private void selectAllEpisodesButton_Click(object sender, EventArgs e)
        {
            SetAllItemsChecked(availableEpisodesListBox); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            DialogResult dialogResult = openFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                filesToBeShrunkListBox.Items.Clear();
                foreach (var fileName in openFileDialog1.FileNames)
                {
                    filesToBeShrunkListBox.Items.Add(fileName);
                    
                }
                SetAllItemsChecked(filesToBeShrunkListBox);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in filesToBeShrunkListBox.Items)
            {
                var fileName = (string) item;
                queue.Add(new QueueItem()
                {
                    SeriesName = textBox2.Text,
                    EpisodeName = fileName.Split('.')[0]+"_shrunk",
                    SourceType = SourceType.File,
                    Profile =
                        string.IsNullOrEmpty(profileNameCombo.Text) ? "Normal" : profileNameCombo.Text,
                    CRF = 23,
                    MaxWidth = 720,
                    FileName = fileName
                });
            }
            GoButtonClick(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            breakIntoChapters = true;
            StartScan();
        }
    }
}
