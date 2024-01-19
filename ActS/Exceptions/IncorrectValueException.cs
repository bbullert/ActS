namespace ActS.Exceptions
{
    public class IncorrectValueException : Exception
    {
        public IncorrectValueException() : base("Incorrect value, must contain intiger.")
        {
        }
    }
}
