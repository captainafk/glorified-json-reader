using System;
using UnityEngine;
using UniRx;

namespace GJR
{
    /// <summary>
    /// Controls the general flow of the game
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private IDisposable _d1;
        
        private void Awake()
        {
            _d1 = MessageBus.Receive<OnApplicationQuitRequested>()
                .Subscribe(ge =>
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.ExitPlaymode();
#endif
                    Application.Quit();
                });
        }

        private void OnDestroy() => _d1?.Dispose();

        /// <summary>
        /// Acts as the main entry point of the application
        /// </summary>
        private void Start()
        {
            var input = FileReader.ReadFile();
            var boardGameEnthusiast = FileReader.ParseJSON<BoardGameEnthusiast>(input);
            
            MessageBus.Publish(new OnBoardGameEnthusiastLoaded(boardGameEnthusiast));
        }
    }
}
