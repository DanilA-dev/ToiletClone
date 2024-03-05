using UniRx;
using UnityEngine;

namespace Systems
{
    public enum GameOverType
    {
        Lose,
        Win
    }

    public class GameOverController : MonoBehaviour
    {
        public void Init()
        {
            MessageBroker.Default.Receive<GameOverSignal>()
                .Subscribe(_ => OnGameEnd(_.Type));
        }

        private void OnGameEnd(GameOverType type)
        {
            if (type == GameOverType.Win)
            {
                //Display Win
            }
            else
            {
                //Display lose
            }
        }
    }
}