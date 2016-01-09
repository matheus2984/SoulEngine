using System;
using System.Threading;

namespace Soul.Engine.Threading
{
    public class ThreadAction
    {
        private readonly Action action;
        private int delayClock;
        private Thread thread;
        private long ticks = Clock.Ticks;

        public int Delay
        {
            get { return delayClock; }
            set { delayClock = value < 1 ? 1 : value; }
        }

        public bool InProcess { get; set; }
        public bool IsLoopable { get; set; }

        private ThreadAction(Action action, bool run = true)
        {
            InProcess = false;
            this.action = action;
            thread = new Thread(Process) {IsBackground = true};
            if (run) StartThread();
        }

        private ThreadAction(Action action, int delay, bool run = true)
            : this(action, run)
        {
            Delay = delay;
        }

        public static ThreadAction Factory(Action action)
        {
            return new ThreadAction(action);
        }

        public static ThreadAction Factory(Action action, int delay, bool loopable)
        {
            var t = new ThreadAction(action) {Delay = delay, IsLoopable = loopable};
            return t;
        }

        public static ThreadAction Factory(Action action, bool loopable)
        {
            ThreadAction t = Factory(action, 0, loopable);
            return t;
        }

        public void StartThread()
        {
            if (thread == null) throw new Exception("Thread is null");
            thread.Start();
            InProcess = true;
        }

        public void CloseThread()
        {
            if (thread == null) return;
            thread.Abort();
            thread = null;
            InProcess = false;
        }

        private void Process()
        {
            Execute();

            while (IsLoopable)
                Execute();

            CloseThread();
        }

        private void Execute()
        {
            var deltaTime = (int) (Clock.Ticks - ticks);
            if (deltaTime > Delay)
            {
                action.Invoke();
                ticks = Clock.Ticks;
            }
            else
            {
                Thread.Sleep(Delay - deltaTime);
            }
        }
    }
}