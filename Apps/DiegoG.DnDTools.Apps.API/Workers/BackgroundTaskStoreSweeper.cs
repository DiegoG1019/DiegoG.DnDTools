namespace DiegoG.DnDTools.Apps.API.Workers;

public class BackgroundTaskStoreSweeper(ILogger<BackgroundTaskStoreSweeper> logger) : BackgroundService
{
    private readonly ILogger<BackgroundTaskStoreSweeper> logger = logger ?? throw new ArgumentNullException(nameof(logger));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested is false)
        {
            await BackgroundTaskStore.Sweep(logger, stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
