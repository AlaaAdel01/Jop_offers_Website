﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using JopOffere.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication4.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }

        public virtual ICollection<Jop> jobs { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		public System.Data.Entity.DbSet<JopOffere.Models.Category> Categories { get; set; }

		public System.Data.Entity.DbSet<JopOffere.Models.Jop> Jops { get; set; }

        public System.Data.Entity.DbSet<JopOffere.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<JopOffere.Models.ApplyForJob> ApplyForJobs { get; set; }

    }
}