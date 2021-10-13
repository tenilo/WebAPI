using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Dotnet.Framework;
using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Infratructure.Data.TypeConfigurations;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Infratructure.Data
{
    /* Le context ou encore l'orm est le mapping ou le lien entre les objets cotés c# et le relationnel coté sql*/
    public class SelfieContext : DbContext, IUnitOfWork
    {
        #region constructors
        public SelfieContext([NotNullAttribute] DbContextOptions options):base(options) { }
        public SelfieContext(): base() { }
        #endregion
        #region Internal methods
        /*Avec cette méthode on va définir des paramètres de configurations des relations entre tables de notre base
         comment fonctionne une table par rapport à une autre et donc les classes ou encore la relation entre la base et Entity framework(orm) */
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
        }

        #endregion
        #region Properties
        /*Les DbSet réprésentent les collections cotés c#. c'est aussi les objets*/
        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies { get; set; }
        #endregion
    }
}
