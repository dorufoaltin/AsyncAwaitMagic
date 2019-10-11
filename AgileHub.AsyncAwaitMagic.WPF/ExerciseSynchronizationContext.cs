using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.WPF
{
    class ExerciseSynchronizationContext : SynchronizationContext
    {
        public ExerciseSynchronizationContext()
        {
            Start();
        }

        public Task Stop()
        {
            throw new NotImplementedException("Stop");
            // TODO4: stop the Thread in Here, and return a task that completes when the thread finishes execution
        }

        public void Start()
        {
            // TODO1: Create the single Thread that should execute the code
        }

        public override void Post(SendOrPostCallback codeToRun, object state)
        {
            base.Post(codeToRun, state);

            // TODO2: use the single Thread to execute the delegate codeToRun
        }

        public override void Send(SendOrPostCallback codeToRun, object state)
        {
            base.Send(codeToRun, state);

            // TODO3: use the single Thread to execute the delegate codeToRun
        }
    }
}
