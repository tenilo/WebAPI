using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Domain
{
    public class Selfie
    {
        #region Properties
        public int Id { get; set; }
        public int WookieId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public Wookie Wookies { get; set; }
        #endregion
    }
}
