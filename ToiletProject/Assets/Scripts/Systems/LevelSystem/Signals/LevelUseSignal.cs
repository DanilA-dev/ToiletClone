using Scriptables.Levels;

namespace Systems
{
    public class LevelUseSignal
    {
        public LevelData Data { get; private set; }
        public LevelUseSignal(LevelData data)
        {
            Data = data;
        }

    }
}