using ActS.Data;
using ActS.Exceptions;
using ActS.Services;

namespace ActS.Views
{


    public class MainView
    {
        //private ActivityService activityService = new ActivityService();
        private IActivityService activityService;

        public MainView(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        private string DelayInputMessage = "Delay <value: int> <unit: [null, \"ms\", \"s\", \"m\"], default = {0}>: ";

        public void View(Settings settings)
        {
            settings = Validate(settings);
            Run(settings);
        }

        private void Run(Settings settings)
        {
            Console.Clear();
            Console.WriteLine("Running...");
            activityService.Simulate(settings);
        }

        private Settings Validate(Settings settings)
        {
            Console.WriteLine(string.Format(DelayInputMessage, settings.Delay));
            settings.Delay = ValidateDelay(Console.ReadLine()) ?? settings.Delay;

            return settings;
        }

        private int? ValidateDelay(string input)
        {
            int value;
            int unit = 1;

            if (string.IsNullOrWhiteSpace(input)) return null;

            if (!int.TryParse(new String(input.Where(Char.IsDigit).ToArray()), out value))
                throw new IncorrectValueException();

            if (input.Contains("ms")) unit = 1;
            else if (input.Contains("s")) unit = 1000;
            else if (input.Contains("m")) unit = 1000 * 60;

            return value * unit;
        }
    }
}
