﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace travelia.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class traveliaEntitiesContext : DbContext
    {
        public traveliaEntitiesContext()
            : base("name=traveliaEntitiesContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bookinginfo> bookinginfoes { get; set; }
        public virtual DbSet<customercaresalary> customercaresalaries { get; set; }
        public virtual DbSet<hotelinfo> hotelinfoes { get; set; }
        public virtual DbSet<messagetocare> messagetocares { get; set; }
        public virtual DbSet<messagetohotel> messagetohotels { get; set; }
        public virtual DbSet<salarysheet> salarysheets { get; set; }
        public virtual DbSet<servicecharge> servicecharges { get; set; }
        public virtual DbSet<travelplace> travelplaces { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<userinfo> userinfoes { get; set; }
    }
}
