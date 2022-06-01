using System.Diagnostics;

namespace ThisDoesNotExist;
public interface IImageGenerator
{
    public Task Run();
}

public class ImageGenerator : IImageGenerator
{
    private readonly int _imgBufferSize;
    private readonly string _scriptPath;
    private readonly string _imgPath;

    private int _currentImg = 0;

    public ImageGenerator(IConfiguration configuration)
    {
        _scriptPath = configuration.GetValue<string>("ScriptPath");
        _imgBufferSize = configuration.GetValue<int>("ImageBufferSize");
        _imgPath = configuration.GetValue<string>("ImagePath");
    }

    public Task Run()
    {
        var process = Process.Start("python3", $"{_scriptPath} {_imgPath} {_currentImg}");

        _currentImg = (_currentImg + 1) % _imgBufferSize;

        return process is not null
            ? process.WaitForExitAsync()
            : Task.CompletedTask;
    }
}
