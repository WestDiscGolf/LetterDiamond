using System;

/// <summary>
/// Exception class to throw when the required letter char is not valid.
/// </summary>
public class NotValidLetterException : Exception
{
    public NotValidLetterException(string message)
        : base(message)
    {
    }
}