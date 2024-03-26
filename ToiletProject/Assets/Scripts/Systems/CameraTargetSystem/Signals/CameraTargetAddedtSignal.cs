using Core.Interfaces;

namespace Systems
{
    public sealed class CameraTargetAddedtSignal
    {
        public ITarget Target { get; private set; }
        public CameraTargetAddedtSignal(ITarget target)
        {
            Target = target;
        }

    }
}