using UnityEngine;

namespace GJR
{
    /// <summary>
    /// Controls the general flow of the game
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            var input = FileReader.ReadFile();
            var boardGameEnthusiast = FileReader.ParseJSON<BoardGameEnthusiast>(input);
            
            MessageBus.Publish(new OnBoardGameEnthusiastLoaded(boardGameEnthusiast));
        }
    }
}
