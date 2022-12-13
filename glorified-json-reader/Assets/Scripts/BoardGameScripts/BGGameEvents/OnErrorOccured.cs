namespace GJR
{
    public class OnErrorOccured : GameEventBase
    {
        public string ErrorMessage;

        public OnErrorOccured(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}