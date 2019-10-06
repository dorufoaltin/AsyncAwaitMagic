using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.WPF
{
    class SingleThreadSynchronizationContext : SynchronizationContext
    {
        private BlockingCollection<Action> _allActionsBlockingCollection;
        private Task _executeActionTask;

        public bool IsRunning { get; private set; }

        public SingleThreadSynchronizationContext()
        {
            Start();
        }

        private void Start()
        {
            _allActionsBlockingCollection = new BlockingCollection<Action>();

            IsRunning = true;

            _executeActionTask = Task.Factory.StartNew(ExecuteActionsThread_Run, TaskCreationOptions.LongRunning);
        }

        public Task Stop()
        {
            _allActionsBlockingCollection.CompleteAdding();

            return _executeActionTask;
        }

        private void ExecuteActionsThread_Run()
        {
            Thread.CurrentThread.Name = "SingleThreadSynchronizationContext";

            // Set the current Synchronization Context for the internal Thread
            SetSynchronizationContext(this);

            foreach (var action in _allActionsBlockingCollection.GetConsumingEnumerable())
            {
                action();
            }

            IsRunning = false;
        }

        public override void Send(SendOrPostCallback codeToRun, object state)
        {
            if (!IsRunning)
                return;

            _allActionsBlockingCollection.Add(() => codeToRun(state));
        }

        public override void Post(SendOrPostCallback codeToRun, object state)
        {
            if (!IsRunning)
                return;

            _allActionsBlockingCollection.Add(() => codeToRun(state));
        }
    }
}
