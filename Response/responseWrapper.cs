namespace Response
{
    public class responseWrapper<T>
    {

        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public responseWrapper() 
        { 
        
        
        
        }
        public responseWrapper(T result)
        {
           Result= result;
        }
        public responseWrapper(Exception exception)
        {
            IsError = true;
            ErrorMessage = exception?.Message;
        }

        public void Set(T result)
        {
            Result = result;
        }
        

        public void Set(Exception exception)
        {
            IsError = true;
            ErrorMessage = exception?.Message;
        }

        public void Set(string message, T result)
        {
            Message = message;
            Set(result);
        }
    }
}
