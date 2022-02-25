using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    public class LightController
    {
        private ILogger _logger;

        public LightController(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsOn { get; private set; }

        public void LightUp()
        {
            IsOn = true;
            _logger.Log("Light is on.");
        }

        public void Darken()
        {
            IsOn = false;
            _logger.Log("Light is off.");
        }
    }
}
