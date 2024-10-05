namespace Front.Core.Services.BackendService;

public interface IBackendService
{
    string Call(string program, string arguments);
}