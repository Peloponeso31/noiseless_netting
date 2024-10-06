namespace Front.Core.Services.MiniSeedService;

public class MiniSeedService : IMiniSeedService
{
    private string _currentFile = string.Empty;
    
    public void SetCurrentFile(string path)
    {
        _currentFile = path;
    }

    public string GetCurrentFile()
    {
        return _currentFile;
    }
}