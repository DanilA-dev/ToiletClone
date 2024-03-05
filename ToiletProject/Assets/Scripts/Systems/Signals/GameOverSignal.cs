namespace Systems
{
    public class GameOverSignal
    {
        public GameOverType Type { get; private set; }
        
        public GameOverSignal(GameOverType type)
        {
            Type = type;
        }
    }
}