using StackExchange.Profiling;
using System;

namespace CaShare.Core.Infrastructure
{
    public static class Profiler
    {
        public static void Step(string name, Action action)
        {
            using (var step = MiniProfiler.Current.Step(name))
            {
                action();
            }
        }

        public static T Step<T>(string name, Func<T> action)
        {
            using (var step = MiniProfiler.Current.Step(name))
            {
                return action();
            }
        }
    }
}
