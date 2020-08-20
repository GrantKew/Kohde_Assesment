using System.Collections.Generic;
using System.Diagnostics;
using Kohde.Assessment.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentC
    {
        [TestMethod]
        [ExpectedException(typeof(NoEvenNumbersException),"No Even numbers were contained in the array")]
        public void Check_For_Even_Numbers_While_Only_Odd_Numbers_Are_Present()
        {
            Program.GetFirstEvenValue(new List<int>
            {
                1, 3, 5, 7, 9, 11, 13, 15, 17, 19
            });
        }

        [TestMethod]
       
        public void CheckForEvenNumbers() {
            var value = Program.GetFirstEvenValue(new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            });

            Trace.TraceInformation("Value: {0}", value);
            Assert.IsTrue(value % 2 == 0, "Indicates whether the use made use of the correct logic");
        }

        [TestMethod]
        public void SingleOrDefaultUsed()
        {
            var value = Program.GetSingleStringValue(new List<string>
            {
                "Jhn", "Jn", "Srh", "Pt"
            });

            Trace.TraceInformation("Testing for: System.InvalidOperationException: Sequence contains no elements");
            Trace.TraceInformation("Value: {0}", value);

            var value2 = Program.GetSingleStringValue(new List<string>
            {
                "Jhn", "Jn", "Sarah", "Pt"
            });

            Assert.IsTrue(!string.IsNullOrEmpty(value2));
        }
    }
}
