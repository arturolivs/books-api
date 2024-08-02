namespace books_api.Exceptions
{
    public class EntityInUseException : Exception
    {
        public EntityInUseException(string message) : base(message) { 
        }
    }

}
