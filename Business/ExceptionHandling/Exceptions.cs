namespace Business.ExceptionHandling
{
    public class PortalValidationException : BusinessExceptionBase
    {
        public PortalValidationException(string error, bool isWriteToEventViewer = false) : base(error, isWriteToEventViewer)
        {

        }

        public PortalValidationException(string error, System.Exception inner, bool isWriteToEventViewer = false) : base(error, inner, isWriteToEventViewer)
        {

        }
    }
    public class AuthorizationException : BusinessExceptionBase
    {
        public AuthorizationException(string error, bool isWriteToEventViewer = false) : base(error, isWriteToEventViewer)
        {

        }

        public AuthorizationException(string error, Exception inner, bool isWriteToEventViewer = false) : base(error, inner, isWriteToEventViewer)
        {

        }
    }

    public class ForbiddenException : BusinessExceptionBase
    {
        public ForbiddenException(string error, bool isWriteToEventViewer = false) : base(error, isWriteToEventViewer)
        {

        }

        public ForbiddenException(string error, Exception inner, bool isWriteToEventViewer = false) : base(error, inner, isWriteToEventViewer)
        {

        }
    }
}
