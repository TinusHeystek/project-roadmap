using Microsoft.Extensions.Options;
using ProjectRoadmap.Shared.IOptions.Sample;

namespace ProjectRoadmap.Shared.IOptions.BackgroundServices;

public class OptionsBackgroundService : BackgroundService
{
    private SampleSettings _sampleSettings;
    private SampleAnnotationSettings _sampleAnnotationSettings;

    public OptionsBackgroundService(
        IOptionsMonitor<SampleSettings> optionsMonitorSampleSettings,
        IOptionsMonitor<SampleAnnotationSettings> optionsMonitorSampleAnnotationSettings)
    {
        optionsMonitorSampleSettings.OnChange(o => _sampleSettings = o);
        _sampleSettings = optionsMonitorSampleSettings.CurrentValue;
        
        optionsMonitorSampleAnnotationSettings.OnChange(o => _sampleAnnotationSettings = o);
        _sampleAnnotationSettings = optionsMonitorSampleAnnotationSettings.CurrentValue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var counter = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("SampleSettings[{0}]: {1}", counter++, _sampleSettings.StringField);
            Console.WriteLine("SampleAnnotationSettings[{0}]: {1}", counter++, _sampleAnnotationSettings.StringField);
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}