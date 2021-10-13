

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Infratructure.Data;
using SelfieAWookie.Dotnet.Framework;

namespace SelfieAWookies.Core.Infratructure.Repositories
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        #region Fields
        private readonly SelfieContext _context;

        #endregion

        #region constructors
        public DefaultSelfieRepository(SelfieContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public Methods
        public ICollection<Selfie> GetAll()
        {
            return  this._context.Selfies.Include(item => item.Wookies).ToList();
            
        }
        public Selfie AddOneSelfie(Selfie item)
        {
            return this._context.Selfies.Add(item).Entity;
        }
        #endregion

        #region Properties
        public IUnitOfWork unitOfWork => this._context;

        #endregion



    }
}
