using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    [Serializable]
    public class RepositoryEntityNotFoundException : Exception
    {
        public string[] Messages { get; }
        public RepositoryEntityNotFoundException(string message) : base(message) { }
        public RepositoryEntityNotFoundException(string message, string[] messages) : base(message) { Messages = messages; }
        public RepositoryEntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
