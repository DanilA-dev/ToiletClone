using Data.Skins;

namespace Systems
{
    public class SkinUseSignal
    {
        public SkinData SkinData { get; private set; }
        public SkinUseSignal(SkinData skinData)
        {
            SkinData = skinData;
        }

    }
}