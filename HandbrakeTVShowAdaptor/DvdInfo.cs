using System;

namespace HandbrakeTVShowAdaptor
{
    public class DvdInfo
    {
        public DvdInfo(string path, string title)
        {
            Path = path;
            Title = title;
        }

        public string Path { get; private set; }
        public string Title { get; private set; }

        public override string ToString()
        {
            return Title;
        }
    }
}