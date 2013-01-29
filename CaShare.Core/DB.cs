using CaShare.Core.Infrastructure;
using System;

namespace CaShare.Core
{
    public static class DB
    {
        public static Func<Context> ContextFactory { get; set; }

        public static void Use(Action<Context> action)
        {

            using (var db = ContextFactory())
            {
                action(db);
            }
        }

        public static void Save(Action<Context> action)
        {

            using (var db = ContextFactory())
            {
                action(db);
                db.SaveChanges();
            }
        }

        public static T Use<T>(Func<Context, T> action)
        {
            using (var db = ContextFactory())
            {
                return action(db);
            }
        }

        public static void Use(string profilerStep, Action<Context> action)
        {
            Profiler.Step(profilerStep, () =>
            {
                using (var db = ContextFactory())
                {
                    action(db);
                }
            });
        }

        public static void Save(string profilerStep, Action<Context> action)
        {
            Profiler.Step(profilerStep, () =>
            {
                using (var db = ContextFactory())
                {
                    action(db);
                    db.SaveChanges();
                }
            });
        }

        public static T Use<T>(string profilerStep, Func<Context, T> action)
        {
            return Profiler.Step(profilerStep, () =>
            {
                using (var db = ContextFactory())
                {
                    return action(db);
                }
            });
        }

    }
}
