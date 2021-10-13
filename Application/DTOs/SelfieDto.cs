using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Asp.Net.Core.Api.Application.DTOs
{
    public class SelfieDto
    {
        #region Properties
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }

        #endregion
    }
}
