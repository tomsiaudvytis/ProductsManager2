using System;

namespace MyExceptions
{
    public class RecordAlreadyExistsException : Exception
    {
        public RecordAlreadyExistsException()
        {

        }

        public RecordAlreadyExistsException(string msg) : base(msg)
        {

        }
    }
}
