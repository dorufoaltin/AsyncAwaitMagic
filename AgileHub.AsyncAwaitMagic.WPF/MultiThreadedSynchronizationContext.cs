using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgileHub.AsyncAwaitMagic.WPF
{
    class MultiThreadedSynchronizationContext : SynchronizationContext
    {
        private BlockingCollection<Action> _allActionsBlockingCollection;
        private List<Task> _allTasks;

        public bool IsRunning { get; private set; }

        public int NumberOfThreads { get; }

        public MultiThreadedSynchronizationContext(int numberOfThreads)
        {
            NumberOfThreads = numberOfThreads;

            Start();
        }

        private void Start()
        {
            _allActionsBlockingCollection = new BlockingCollection<Action>(new ConcurrentBag<Action>());
            _allTasks = new List<Task>();

            IsRunning = true;

            for (int i = 0; i < NumberOfThreads; i++)
            {
                var task = Task.Factory.StartNew(ExecuteActionsThread_Run, TaskCreationOptions.LongRunning);

                _allTasks.Add(task);
            }
        }

        public Task Stop()
        {
            _allActionsBlockingCollection.CompleteAdding();

            return Task.WhenAll(_allTasks);
        }

        private void ExecuteActionsThread_Run()
        {
            // Set the current Synchronization Context for the internal Thread
            SetSynchronizationContext(this);

            Thread.CurrentThread.Name = "MultiThreadedSynchronizationContext";

            foreach (var action in _allActionsBlockingCollection.GetConsumingEnumerable())
            {
                action();
            }

            IsRunning = _allTasks.Count( k=> k.IsCompleted) == NumberOfThreads;
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
