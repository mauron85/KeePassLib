using System;
using System.Threading.Tasks;
using Windows.System.Threading;

namespace KeePassLib.Utility
{
    static class ThreadUtil
    {
        public static bool Schedule(Action<object> action, object state)
        {
#if KeePassUWP
            // UWP doesn't support ThreadPool[.QueueUserWorkItem] so use Task.Factory.StartNew 
            Task.Factory.StartNew(s => action(s), state, TaskCreationOptions.DenyChildAttach);
            return true;
#else
            return ThreadPool.QueueUserWorkItem(action, state);
#endif
        }
    }
}
