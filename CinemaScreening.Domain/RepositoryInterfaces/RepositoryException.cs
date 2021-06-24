using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public string[] Messages { get; }
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string message, string[] messages) : base(message) { Messages = messages; }
        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
