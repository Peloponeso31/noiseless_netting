namespace Front.Core.Services.MiniSeedService;

public interface IMiniSeedService
{
    public void SetCurrentFile(string path);
    public string GetCurrentFile();
}