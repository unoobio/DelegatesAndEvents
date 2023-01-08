namespace DelegatesAndEvents.FilesSearcher
{
    internal class FileFoundEventArgs : EventArgs
    {       
        public required FileInfo FileInfo { get; init; }

        public string FileName => this.FileInfo.Name;

        public bool CancelFolderChecking { get; set; }
    }
}
