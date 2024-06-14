namespace Event;

// 发现文件的事件的参数
public class FileFoundArgs : EventArgs
{
    public string FoundFile { get; }
    public bool CancelRequested { get; set; }

    public FileFoundArgs(string fileName)
    {
        FoundFile = fileName;
    }
}

// 搜索文件夹的进度的事件的参数
internal class SearchDirectoryArgs : EventArgs
{
    internal string CurrentSearchDirectory { get; }
    internal int TotalDirs { get; }
    internal int CompletedDirs { get; }

    internal SearchDirectoryArgs(string dir, int totalDirs, int completedDirs)
    {
        CurrentSearchDirectory = dir;
        TotalDirs = totalDirs;
        CompletedDirs = completedDirs;
    }
}

public class FileSearcher
{

    // 找到文件后的回调
    public event EventHandler<FileFoundArgs> FileFound;

    private EventHandler<SearchDirectoryArgs> directoryChanged;
    internal event EventHandler<SearchDirectoryArgs> DirectoryChanged
    {
        // 不需要写这段代码。编译器会自动为event添加这段代码
        add { directoryChanged += value; }
        remove { directoryChanged -= value; }
    }

    public void Search(string directory, string searchPattern, bool searchSubDirs = false)
    {
        if (searchSubDirs)
        {
            var allDirectories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);
            var completedDirs = 0;
            var totalDirs = allDirectories.Length + 1;
            foreach (var dir in allDirectories)
            {
                directoryChanged?.Invoke(this, new SearchDirectoryArgs(dir, totalDirs, completedDirs++));
                SearchDirectory(dir, searchPattern);
            }
            directoryChanged?.Invoke(this, new SearchDirectoryArgs(directory, totalDirs, completedDirs++));
            SearchDirectory(directory, searchPattern);
        }
        else
        {
            SearchDirectory(directory, searchPattern);
        }
    }

    private void SearchDirectory(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            var args = new FileFoundArgs(file);
            // 触发回调
            FileFound?.Invoke(this, args);
            if (args.CancelRequested)
                break;
        }
    }
}