namespace GJR
{
    public class BoardGameEnthusiast
    {
        public string title;
        public string name;
        public string email;
        public BoardGame[] boardgames;

        public override string ToString()
        {
            return name + " loves playing " + boardgames[0].name + ".";
        }
    }
}
