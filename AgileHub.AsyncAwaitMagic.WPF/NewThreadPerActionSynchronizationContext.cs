using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.WPF
{
    class NewThreadPerActionSynchronizationContext : SynchronizationContext
    {
        public override void Send(SendOrPostCallback codeToRun, object state)
        {
            ExecuteAction(codeToRun, state);
        }

        public override void Post(SendOrPostCallback codeToRun, object state)
        {
            ExecuteAction(codeToRun, state);
        }

        private void ExecuteAction(SendOrPostCallback codeToRun, object state)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.CurrentThread.Name = "NewThreadPerActionSynchronizationContext";

                // Set the current Synchronization Context for the internal Thread
                SetSynchronizationContext(this);

                codeToRun(state);
            }, TaskCreationOptions.LongRunning);
        }
    }
}
