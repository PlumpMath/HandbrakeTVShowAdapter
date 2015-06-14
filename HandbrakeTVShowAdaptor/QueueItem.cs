using System;
using System.ComponentModel;
using HandBrake.Interop.Model;
using HandBrake.Interop.SourceData;

namespace HandbrakeTVShowAdaptor
{
    public class QueueItem : INotifyPropertyChanged
    {
        private string seriesName;
        private string episodeName;
        private ProcessingStatus processingStatus = ProcessingStatus.WAITING;
        private string progress;
        private Title title;
        private string profile;
        private int crf;
        private DvdInfo dvd;

        public string SeriesName
        {
            get {
                return seriesName;
            }
            set {
                seriesName = value;
            }
        }
        
        public string Profile
        {
            get {
                return profile;
            }
            set {
                profile = value;
            }
        }
        
        public int CRF
        {
            get {
                return crf;
            }
            set {
                crf = value;
            }
        }

        public string EpisodeName
        {
            get {
                return episodeName;
            }
            set {
                episodeName = value;
            }
        }

        public ProcessingStatus ProcessingStatus
        {
            get { return processingStatus; } set
            {
                if (processingStatus!=value)
                {
                    processingStatus = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("ProcessingStatus"));
                }
            }
        }

        public string Progress
        {
            get {
                return progress;
            }
            set {

                if (progress != value)
                {
                    progress = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("Progress"));
                }
            }
        }

        public Title Title
        {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public DvdInfo Dvd
        {
            get {
                return dvd;
            }
            set {
                dvd = value;
            }
        }

        public SourceType SourceType { get; set; }
        public int MaxWidth { get; set; }
        public string FileName { get; set; }
        public Chapter Chapter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}