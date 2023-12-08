using Microsoft.EntityFrameworkCore;
using MissedWork.Models;
using MissedWork.Models.gofrmrequestModels;
using MissedWork.Models.TMODSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWTEmailSender
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=btwn004855;database=MissedWork;User Id=svc_cctfmrequest; Password=r3qu3st#svc;TrustServerCertificate=True;");
            options.UseSqlServer("Server=btwp014478;Initial Catalog=MissedWork;User ID=svc_cctfmrequest;Password=r3qu3st#svc;trustServerCertificate=True;"); //LIVE
        }
        public DbSet<Entries> Entries { get; set; }
        public DbSet<Company> Company { get; set; }

    }
    public class FmRequestDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=btwn004855;database=gofmrequest;User Id=svc_cctfmrequest; Password=r3qu3st#svc;TrustServerCertificate=True;");
            options.UseSqlServer("Server=btwp014478;database=gofmrequest;User Id=svc_cctfmrequest; Password=r3qu3st#svc;TrustServerCertificate=True;"); //LIVE
        }

        public DbSet<District_Hierarchy> District_Hierarchy { get; set; }

    }

    public class TmodsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=btwn004855;database=TMODS;User Id=svc_cctfmrequest; Password=r3qu3st#svc;TrustServerCertificate=True;");
            options.UseSqlServer("Server=btwp014478;database=TMODS;User Id=svc_cctfmrequest; Password=r3qu3st#svc;TrustServerCertificate=True;"); //LIVE
        }

        public DbSet<TMODS> TMODS { get; set; }

    }

}
