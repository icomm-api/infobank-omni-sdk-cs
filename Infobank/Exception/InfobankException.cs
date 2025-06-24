using System;

class InfobankException : Exception
{
    public int StatusCode { get; }
    public InfobankException(String message)
    {
        StatusCode = 9999;

    }
    public InfobankException(String message, int StatusCode)
    {
        this.StatusCode = StatusCode;
    }



}

class InitFailedException : InfobankException
{
    public InitFailedException(string message) : base(message)
    {

    }
    public InitFailedException(String message, int StatusCode): base(message,StatusCode)
    {

    }

}

class GetTokenException : InfobankException
{
    public GetTokenException(string message) : base(message)
    {

    }
    public GetTokenException(String message, int StatusCode): base(message,StatusCode)
    {

    }

}


class NotSupportServiceException : InfobankException
{
    public NotSupportServiceException(string message) : base(message)
    {

    }
    public NotSupportServiceException(String message, int StatusCode): base(message,StatusCode)
    {

    }

}

