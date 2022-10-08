using System;

namespace ramdb.Except
{
        [Serializable]
        public class KeyNotFoundException : Exception
        {
                public KeyNotFoundException(string message) : base(message){ }

        }

        [Serializable]
        public class MaxDbReached : Exception
        {
                public MaxDbReached(string message) : base(message){ }

        }
        
}
