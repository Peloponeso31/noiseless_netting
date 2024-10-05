using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Front.Core.Services.BackendService;

public class BackendService : IBackendService
{
    private string workingDir = ConfigurationManager.AppSettings["working_dir"] ?? string.Empty;
    
    public async Task<string> Call(string? arguments = null, string program = "backend.py")
    {
        // Process class doc:
        // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=net-8.0
        if (workingDir == String.Empty) return null;
        
        Process process = new Process();
        process.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["working_dir"];
        process.StartInfo.FileName = "python";
        
        process.StartInfo.Arguments = program;
        if (arguments is not null) process.StartInfo.Arguments += " " + arguments;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        
        process.Start();
        var output = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();
        
        return output;
    }

    public string GetImageRoute(string imageName, string plotsDir = "\\plots")
    {
        if (workingDir == String.Empty) return string.Empty;

        return File.Exists(Path.Combine(workingDir, plotsDir + imageName)) ? 
               Path.Combine(workingDir,  plotsDir + imageName) : 
               new Uri("pack://application:,,,/Assets/Missing.png" + imageName).ToString();
    }
}