namespace GJR
{
    public class OnBoardGameEnthusiastLoaded : GameEventBase
    {
        public BoardGameEnthusiast BoardGameEnthusiast;

        public OnBoardGameEnthusiastLoaded(BoardGameEnthusiast boardGameEnthusiast)
        {
            BoardGameEnthusiast = boardGameEnthusiast;
        }
    }
}