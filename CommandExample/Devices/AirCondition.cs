using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    public class AirCondition
    {
        private ILogger _logger;

        public AirCondition(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsOn { get; private set; }

        public void HeatUp()
        {
            IsOn = true;
            _logger.Log("An air condition heats air up.");
        }

        public void CoolOff()
        {
            IsOn = false;
            _logger.Log("An air condition cools air off.");
        }
    }
}
