using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UniRx;

namespace GJR
{
    /// <summary>
    /// Manages setting the text elements of UI elements
    /// </summary>
    public class GUIManager : MonoBehaviour
    {
        [Header("Showcase References")] 
        [SerializeField] private GameObject _showcase;
        [SerializeField] private BoardGameListElement _bgListElementPrefab;
        [SerializeField] private Transform _listMask;
        [SerializeField] private TextMeshProUGUI _personName;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _boardGameName;
        [SerializeField] private TextMeshProUGUI _boardGameScore;
        [SerializeField] private TextMeshProUGUI _boardGameBest;

        [Header("Popup References")]
        [SerializeField] private GameObject _popup;
        [SerializeField] private TextMeshProUGUI _popupError;
        
        [Header("Config")]
        [SerializeField] private string _boardGameNameText = "Board Game Name";
        [SerializeField] private string _boardGameScoreText = "BoardGameGeek Score";
        [SerializeField] private string _boardGameBestText = "Best Played By";
        
        private IDisposable _d1;
        private IDisposable _d2;
        
        private void Awake()
        {
            _d1 = MessageBus.Receive<OnBoardGameEnthusiastLoaded>().Subscribe(ge =>
            {
                LoadEnthusiastToUI(ge.BoardGameEnthusiast);
            });

            _d2 = MessageBus.Receive<OnErrorOccured>().Subscribe(ge =>
            {
                ShowErrorPopup(ge.ErrorMessage);
            });
        }

        private void OnDestroy()
        {
            _d1?.Dispose();
            _d2?.Dispose();
        }

        private void LoadEnthusiastToUI(BoardGameEnthusiast enthusiast)
        {
            _personName.text = enthusiast.name;
            _title.text = enthusiast.title;
            _boardGameName.text = _boardGameNameText;
            _boardGameScore.text = _boardGameScoreText;
            _boardGameBest.text = _boardGameBestText;

            for (var bgIndex = 0; bgIndex < enthusiast.boardgames.Length; bgIndex++)
            {
                var boardGame = enthusiast.boardgames[bgIndex];
                var bgListElement = Instantiate(_bgListElementPrefab, _listMask);

                bgListElement.Number.text = (bgIndex + 1).ToString();
                bgListElement.Name.text = boardGame.name;
                bgListElement.Score.text = boardGame.bggScore.ToString(CultureInfo.InvariantCulture);
                bgListElement.Best.text = boardGame.best + " people";
            }
        }

        private void ShowErrorPopup(string errorMessage)
        {
            _showcase.SetActive(false);
            _popup.SetActive(true);
            _popupError.text = errorMessage;
        }

        public void RequestApplicationQuit() => MessageBus.Publish(new OnApplicationQuitRequested());
    }
}