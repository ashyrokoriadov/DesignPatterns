using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    public class AirPurifier
    {
        private ILogger _logger;

        public AirPurifier(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsOn { get; private set; }

        public void Purify()
        {
            IsOn = true;
            _logger.Log("An air purifier is on.");
        }

        public void StopPurifying()
        {
            IsOn = false;
            _logger.Log("An air purifier is off.");
        }
    }
}
