namespace DelegatesAndEvents.FilesSearcher
{
    internal class FilesSearcher
    {
        public delegate void FileFound(FilesSearcher sender, FileFoundEventArgs e);

        public event FileFound? OnFileFound;

        public void CheckFolder(string path)
        {
            if (this.OnFileFound == null)
                return;
            
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(path);
            this.WalkDirectoryTree(rootDirectoryInfo);
        }

        private void WalkDirectoryTree(DirectoryInfo root)
        {           
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Write(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    FileFoundEventArgs args = new FileFoundEventArgs { FileInfo = file };
                    this.OnFileFound?.Invoke(this, args);
                    if (args.CancelFolderChecking)
                        return;
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    this.WalkDirectoryTree(dirInfo);
                }
            }
        }
    }
}
