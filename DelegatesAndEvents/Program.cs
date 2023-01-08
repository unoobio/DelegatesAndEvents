// See https://aka.ms/new-console-template for more information

using DelegatesAndEvents.FilesSearcher;
using DelegatesAndEvents.MaxExtension;

FilesSearcher filesSearcher = new();
List<FileInfo> foundedFiles = new();
filesSearcher.OnFileFound += (sender, e) =>
{
    Console.WriteLine(Path.Combine(new DirectoryInfo(e.FileInfo.FullName).Parent?.Name ?? string.Empty, e.FileName));
    foundedFiles.Add(e.FileInfo);
    if (e.FileName == "CancelFolderCheckingFile.txt")
    {
        e.CancelFolderChecking = true;
        Console.WriteLine("Folder checking canceled!");
    }
};

filesSearcher.CheckFolder(Path.Combine(Environment.CurrentDirectory, "TestFolderWithFiles"));

FileInfo? fileWithMaxLength = foundedFiles.GetMax(fileInfo => fileInfo.Length);
if (fileWithMaxLength != null)
    Console.WriteLine($"""File with max length "{fileWithMaxLength.FullName}".""");
else
    Console.WriteLine("Files not found.");
