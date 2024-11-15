namespace Business.ExceptionHandling
{
    public class BusinessExceptionBase : System.Exception
    {
        public bool IsWriteToEventViewer { get; set; }
        public BusinessExceptionBase(string error, bool isWriteToEventViewer) : base(error)
        {
            IsWriteToEventViewer = isWriteToEventViewer;
        }

        public BusinessExceptionBase(string error, System.Exception inner, bool isWriteToEventViewer) : base(error, inner)
        {
            IsWriteToEventViewer = isWriteToEventViewer;
        }
    }
}
