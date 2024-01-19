using ActS.Data;
using ActS.Exceptions;
using ActS.Services;
using ActS.Views;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<IActivityService, ActivityService>()
    .AddTransient<IInputService, InputService>()
    .BuildServiceProvider();

var view = new MainView(serviceProvider.GetService<IActivityService>());
var settings = new Settings()
{
    Delay = 1000 * 60
};

for (; ; )
{
    try
    {
        view.View(settings);
    }
    catch (IncorrectValueException ex)
    {
        Console.WriteLine(ex.Message);
    }
}