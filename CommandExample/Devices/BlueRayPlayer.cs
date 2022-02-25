using CommandExample.Interfaces;

namespace CommandExample.Devices
{
    public class BlueRayPlayer
    {
        private ILogger _logger;

        public BlueRayPlayer(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsOn { get; private set; }

        public void Play()
        {
            IsOn = true;
            _logger.Log("A blue ray player has started playing.");
        }

        public void Stop() 
        {
            IsOn = false;
            _logger.Log("A blue ray player has stoped playing.");
        }
    }
}
