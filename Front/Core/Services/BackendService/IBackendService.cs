namespace Front.Core.Services.BackendService;

public interface IBackendService
{
    Task<string> Call(string arguments, string program);
    string GetImageRoute(string imageName);
}