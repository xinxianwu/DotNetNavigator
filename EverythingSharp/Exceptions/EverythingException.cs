using System;
using EverythingSharp.Enums;

namespace EverythingSharp.Exceptions
{
    public class EverythingException : Exception
    {
        public Error ErrorCode { get; }

        public EverythingException(Error errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
