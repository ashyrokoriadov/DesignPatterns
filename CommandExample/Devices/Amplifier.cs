using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    public class Amplifier
    {
        private ILogger _logger;

        public Amplifier(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsOn { get; private set; }

        public void PlugIn()
        {
            IsOn = true;
            _logger.Log("An amplifier is plugged in.");
        }

        public void PlugOut()
        {
            IsOn = false;
            _logger.Log("An amplifier is plugged off.");
        }
    }
}
