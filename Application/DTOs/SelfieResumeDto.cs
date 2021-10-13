using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Asp.Net.Core.Api.Application.DTOs
{
    public class SelfiesResumeDto
    {
        #region Properties
        public int NbSelfiessFromWookie { get; set; }
        public string Title { get; set; }
        public int WookieId { get; set; }
        #endregion
    }
}
