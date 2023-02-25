using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
    public abstract class singleton<T>
    {
        protected singleton() { }

        private static T instance;
        private static Func<T> act;
        private static readonly object padlock = new object();

        protected static void initializer(Func<T> action) { act = action; }

        protected static T Instance
        {
            get
            {
                lock (padlock)
                {
                    if (singleton<T>.instance == null) { instance = act(); }
                    return singleton<T>.instance;
                }
            }
        }
    }
}
