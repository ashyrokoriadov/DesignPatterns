using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    public class TvSet
    {
        private ILogger _logger;

        public TvSet(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsOn { get; private set; }

        public void TurnOn()
        {
            IsOn = true;
            _logger.Log("A TV set is on.");
        }

        public void TurnOff()
        {
            IsOn = false;
            _logger.Log("A TV set is off.");
        }
    }
}
