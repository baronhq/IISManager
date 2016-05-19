﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VM.Models
{
    [Serializable]
    public class InvalidUserNameException : Exception
    {
        public InvalidUserNameException() { }
        public InvalidUserNameException(string message) : base(message) { }
        public InvalidUserNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidUserNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() { }
        public InvalidPasswordException(string message) : base(message) { }
        public InvalidPasswordException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPasswordException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class OutOfStockException : Exception
    {
        public OutOfStockException() { }
        public OutOfStockException(string message) : base(message) { }
        public OutOfStockException(string message, Exception inner) : base(message, inner) { }
        protected OutOfStockException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}