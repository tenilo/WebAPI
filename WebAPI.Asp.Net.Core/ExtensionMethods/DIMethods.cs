using Microsoft.Extensions.DependencyInjection;
using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Infratructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Projet.Asp.Net.Core.Api.ExtensionMethods
{
    public static class DIMethods
    {
        #region Public Methods
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddTransient<ISelfieRepository, DefaultSelfieRepository>();
        }
        #endregion
    }
}
