using System;

namespace Ignis.Models
{
    // Esta es la clase Check que cumple el rol de las excepciones en nuestro programa.
    // Los controladores son los que mayoritariamente usan las excepciones. Y si
    // la excepción se levanta, redirige al usuario con el mensaje de dicha excepción.
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