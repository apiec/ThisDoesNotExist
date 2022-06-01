namespace ThisDoesNotExist;

public interface IPage
{
    public string Content { get; }
}

public class MainPage : IPage
{
    private int _imgCount;
    private static readonly Random _random = new Random();

    public MainPage(IConfiguration configuration)
    {
        _imgCount = configuration.GetValue<int>("ImageBufferSize");
    }

    public string Content => @$"
        <style>
        .center {{margin: 0;
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }}
        </style>
        <body style = ""background: #0e0e0e;"">
            <div class=""center"">
                    <img src=""img/{_random.Next(_imgCount)}.png""/>
            </div>
        </body>";
}

