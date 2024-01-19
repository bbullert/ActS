using ActS.Data;

namespace ActS.Services
{
    public class ActivityService : IActivityService
    {
        //private InputService inputService = new InputService();
        private IInputService inputService;

        public ActivityService(IInputService inputService)
        {
            this.inputService = inputService;
        }

        public void Simulate(Settings settings)
        {
            for (; ;)
            {
                inputService.SimulateInput();
                Thread.Sleep(TimeSpan.FromMilliseconds(settings.Delay));
            }
        }
    }
}
