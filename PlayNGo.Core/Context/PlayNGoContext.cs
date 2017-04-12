using PlayNGo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGo.Core.Context
{
    public class PlayNGoContext : DbContext, IContext
    {

        //public PlayNGoContext()
        //{
        //    Database.SetInitializer<PlayNGoContext>(new CreateDatabaseIfNotExists<PlayNGoContext>());
        //}

        public virtual DbSet<Employee> Employees { get; set; }

        // NOTE : When no data on first run type in Package manager console enable-migration and then after that type update-database.
    }
}
