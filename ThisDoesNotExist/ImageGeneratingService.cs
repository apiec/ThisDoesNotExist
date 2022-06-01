namespace ThisDoesNotExist
{
    public class ImageGeneratorRunner : BackgroundService
    {
        private readonly IImageGenerator _imageGenerator;
        private readonly IRequestTracker _requestTracker;
        private TimeSpan _timeout;
        private TimeSpan _loopDelay;

        public ImageGeneratorRunner(
            IConfiguration configuration, 
            IImageGenerator imageGenerator, 
            IRequestTracker requestTracker)
        {
            _imageGenerator = imageGenerator;
            _requestTracker = requestTracker;

            _timeout = TimeSpan.FromSeconds(configuration.GetValue<int>("TimeoutInSeconds"));
            _loopDelay = TimeSpan.FromSeconds(configuration.GetValue<int>("LoopDelayInSeconds"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var delay = Task.Delay(_loopDelay);

                if (!IsTimedOut) 
                    await _imageGenerator.Run();

                await delay;
            }
        }

        private bool IsTimedOut => DateTime.Now.Subtract(_requestTracker.TimeOfLastRequest) > _timeout;
    }
}
