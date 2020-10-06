using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SDS.SDSRequest.Models;

namespace SDS.SDSRequest.DAL
{
    public class SDSRequestDbContext : DbContext
    {
        public SDSRequestDbContext() : base("name=SDSRequestDbContext")
        {
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        //public DbSet<ProductType> ProductTypes { get; set; }
        //public DbSet<ProductPhysicalState> ProductPhysicalStates { get; set; }
        //public DbSet<Region> Regions { get; set; }
        //public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<RequestOwner> RequestOwners { get; set; }
        public DbSet<RequestActivity> RequestActivity { get; set; }

        public System.Data.Entity.DbSet<SDS.SDSRequest.Models.FormulaImportRequestListItem> FormulaImportRequestListItems { get; set; }

        public System.Data.Entity.DbSet<SDS.SDSRequest.Models.FormulaImportRequestQueueItem> FormulaImportRequestQueueItems { get; set; }

        public System.Data.Entity.DbSet<SDS.SDSRequest.Models.SDSBOS> SDSBOS { get; set; }

        public System.Data.Entity.DbSet<SDS.SDSRequest.Models.FormulaImportRequestActivity> FormulaImportRequestActivities { get; set; }

        public System.Data.Entity.DbSet<SDS.SDSRequest.Models.FormulaImportRequestMessage> FormulaImportRequestMessages { get; set; }

        //public System.Data.Entity.DbSet<SDSRequestManager.Models.SDSFormulaImportRequest> CompassRequest { get; set; }
    }


    public class WercsDbContext : DbContext
    {
        public WercsDbContext()
            : base("name=WercsDbContext")
        //public SDSRequestMgrDbContext() : base("SDSRequestMgrDbContext")
        {
        }
        //public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductPhysicalState> ProductPhysicalStates { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }

    }
}