using System;

namespace Application.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string title, string message)
            : base(message) =>
            Title = title;

        public string Title { get; }
    }
}
