
using SelfieAWookie.Dotnet.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Domain
{
    public interface ISelfieRepository : IRepository
    {
        ICollection<Selfie> GetAll();
        Selfie AddOneSelfie(Selfie item);
    }
}
