using System;

namespace Ignis.Models
{
    public class Check : Exception
    {
        public class PreconditionException : Exception
        {
            public PreconditionException() : base() {}
            public PreconditionException(string message) : base(message) {}
        }
        public class PostconditionException : Exception
        {
            public PostconditionException() : base() { }
            public PostconditionException(string message) : base(message) { }
        }
        public static void Precondition(bool condition, string message)
        {
            if (!condition)
            {
                throw new PreconditionException(message);
            }
        }
        public static void Postcondition(bool condition, string message)
        {
            if (!condition)
            {
                throw new PostconditionException(message);
            }
        }
    }
}