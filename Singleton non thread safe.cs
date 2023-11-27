using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_pattern_DEMO
{
    // Bad code! Do not use!

    // The Singleton should always be a 'sealed' class to prevent class
    // inheritance through external classes and also through nested classes.
    public sealed class Singleton_non_thread_safe
    {
        private static Singleton_non_thread_safe _instance = null;

        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton_non_thread_safe()
        {
        }

        // The Singleton's instance is stored in a static field.
        public static Singleton_non_thread_safe GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton_non_thread_safe();
            }
            return _instance;
        }
    }
}
