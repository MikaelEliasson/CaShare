using CaShare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CaShare.Tests
{
    public class TestBase
    {
        public virtual void InitDb(Action<Context> seed = null)
        {

            DB.ContextFactory = () =>
            {

                var db = new Context("data source=.\\;initial catalog=CaShareTest;integrated security=SSPI;");
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                return db;
            };

            DB.Use(db =>
            {
                if (db.Database.Exists())
                {
                    db.Database.Delete();
                }
                db.Database.Create();

                if (seed != null)
                {
                    seed(db);
                    db.SaveChanges();
                }
            });
        }

        public T DataFromView<T>(ActionResult result)
        {
            return (T)(result as ViewResult).ViewData.Model;
        }
    }
}
