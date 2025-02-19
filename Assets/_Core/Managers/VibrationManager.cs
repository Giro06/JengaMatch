using Lofelt.NiceVibrations;

namespace Giroo.Core
{
    public class VibrationManager : IUpdateable
    {
        private float _hapticTime;

        public void Update(float deltaTime)
        {
            _hapticTime += deltaTime;
        }

        public void Haptic(HapticPatterns.PresetType hapticType, float interval = 0f)
        {
            if (_hapticTime > interval)
            {
                HapticPatterns.PlayPreset(hapticType);
                _hapticTime = 0f;
            }
        }
    }
}