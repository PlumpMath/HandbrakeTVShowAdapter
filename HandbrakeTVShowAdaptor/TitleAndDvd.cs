using System;
using HandBrake.Interop.SourceData;

namespace HandbrakeTVShowAdaptor
{
    internal class TitleAndDvd
    {
        private readonly Title title;
        private readonly DvdInfo scannedDvd;
        private readonly Chapter chapter;

        public TitleAndDvd(Title title, DvdInfo scannedDvd, Chapter chapter)
        {
            this.title = title;
            this.scannedDvd = scannedDvd;
            this.chapter = chapter;
        }

        public DvdInfo ScannedDvd
        {
            get { return scannedDvd; }
        }

        public Title Title
        {
            get { return title; }
        }

        public TimeSpan Duration
        {
            get { return chapter == null ? title.Duration : chapter.Duration; }

        }

        public Chapter Chapter
        {
            get
            {
                return chapter;
            }
        }

        public override string ToString()
        {
            var duration = chapter == null ? " (" + title.Duration.ToString(@"hh\:mm\:ss") + ")" : "/" + chapter.ChapterNumber + " (" + chapter.Duration.ToString(@"hh\:mm\:ss") + ")";
            return scannedDvd.Title + " - " + title.TitleNumber +duration;
        }
    }
}