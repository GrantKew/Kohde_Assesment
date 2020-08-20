using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment.Exceptions {
    public class InvalidBeingObjectException : Exception {
        public InvalidBeingObjectException(string message) : base(message) {
        }
    }
    public class NoEvenNumbersException : Exception {
        public NoEvenNumbersException(string message) : base(message) {
        }
    }

    public class NoNameContainsSearchString : Exception {
        public NoNameContainsSearchString(string message) : base(message) {
        }
    }
}
