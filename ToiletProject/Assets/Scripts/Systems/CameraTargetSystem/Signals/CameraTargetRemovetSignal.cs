using Core.Interfaces;

namespace Systems
{
    public sealed class CameraTargetRemovetSignal
    {
        public ITarget Target { get; private set; }
        public CameraTargetRemovetSignal(ITarget target)
        {
            Target = target;
        }

    }
}