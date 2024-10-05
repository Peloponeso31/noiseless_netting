using System.Configuration;
using System.Diagnostics;

namespace Front.Core.Services.BackendService;

public class BackendService : IBackendService
{
    public string Call(string program = "backend.py", string? arguments = null)
    {
        Process process = new Process();
        process.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["working_dir"];
        process.StartInfo.FileName = "python";
        
        process.StartInfo.Arguments = program;
        if (arguments is not null) process.StartInfo.Arguments += " " + arguments;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        
        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        
        return output;
    }
}