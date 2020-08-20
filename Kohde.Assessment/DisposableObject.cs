using System;
using System.Linq;
using static System.Linq.Enumerable;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int? Counter { get; private set; }

        public void PerformSomeLongRunningOperation(string data)
        {

            // changing Enumerable.Range to Range (import using static System.Linq.Enumerable;) reduces loop time on larger data set.
            // +- 5ms difference on 100000 records
            //added RaisedEvent() method here instead of callong it in the main class.

            foreach (var i in Range(1, 10))
            {
                this.SomethingHappened += HandleSomethingHappened;
            }

            this.RaiseEvent(data);
        }

        internal void RaiseEvent(string data)
        {
            this.SomethingHappened?.Invoke(data);
        }

        internal void HandleSomethingHappened(string foo)
        {
            this.Counter++;
            Console.WriteLine($"HIT {this.Counter} => HandleSomethingHappened. Data: {foo}");
        }

         protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Counter = null;
                this.SomethingHappened = null;
            }

            // Free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }

    }


}