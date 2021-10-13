using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookies.Core.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Infratructure.Data.TypeConfigurations
{
    class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        #region Public methods
       

        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            //pour le nom de la table
            builder.ToTable("Selfie");
            builder.HasKey(item => item.Id);
            /* 1 Selfies a 1 et 1 seul wookie, alors que 1 wookie peut avoir plusieurs Selfiess. 
             * Cette relation est représentée ci-dessous. Cette syntaxe est utilisée si on ne veut pas définir de clé étrangère*/
            builder.HasOne(item => item.Wookies)
                .WithMany(item => item.Selfies);

        }

        #endregion

    }
}
