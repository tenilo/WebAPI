using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Asp.Net.Core.Api.Application.DTOs;
using SelfieAWookies.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Asp.Net.Core.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        #region Fields
        private readonly ISelfieRepository _repository = null;
        /* On ajoute l'environnement pour traiter la récupération de la photo.*/
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        #endregion
        #region Constructor
        public SelfieController(ISelfieRepository repository, IWebHostEnvironment webHostEnvironment) 
        {
            this._repository = repository;
            this._webHostEnvironment = webHostEnvironment;
        }

        #endregion
        #region Public Methods
        /*
        [HttpGet]
        public IActionResult GetAll()
        {
            
            var SelfiesList = this._repository.GetAll();

            var model = SelfiesList.Select(item => new SelfiesResumeDto () { Title = item.Title, WookieId = item.WookieId, NbSelfiessFromWookie = (item.Wookies?.Selfies?.Count).
                GetValueOrDefault(0) }).ToList();
            
            return this.Ok(model);
        }
        */
        [HttpGet]
        // METHODE GET avec un filtre: le filtre est sur wookieid dans ce cas. Par ex récupérer le selfie dont le 
        // wookieid = 1
        public IActionResult GetAll([FromQuery] int WookieId)
        {

            var SelfiesList = this._repository.GetAll();

            var model = SelfiesList.Select(item => new SelfiesResumeDto()
            {
                Title = item.Title,
                WookieId = item.WookieId,
                NbSelfiessFromWookie = (item.Wookies?.Selfies?.Count).
                GetValueOrDefault(0)
            }).ToList();

            return this.Ok(model);
        }
        #endregion

        #region Picture post
        /*[Route("Photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture()
        {
            // on utilise le stream pour lire un flux de fichier, ici la photo sera transmise en binaire 
            using var stream = new StreamReader(this.Request.Body);
            // pour lire le fichier de manière asynchrone
            var content = await stream.ReadToEndAsync();
            
            return this.Ok();
        }*/
        [Route("Photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            // chemin où l'image sera enregistrée
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");
            // on crée le dossier (images\selfies) dans l'application si ça n'existe pas, 
            // _webHostEnvironment.ContentRootPath est le chemin de l'application
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = Path.Combine(filePath, picture.FileName);
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);
            
            return this.Ok();
        }

        #endregion

        #region

        [HttpPost]
        public IActionResult AddOne(SelfieDto dto)
        {
            IActionResult result = this.BadRequest();
            Selfie addSelfie = this._repository.AddOneSelfie(new Selfie()
            {
                ImagePath = dto.ImagePath,
                Title = dto.Title
            });
            this._repository.unitOfWork.SaveChanges();
            if (addSelfie != null)
            {
                dto.Id = addSelfie.Id;
                result = this.Ok(dto);

            }

            return result;
            
        }
        
        #endregion

        
    }
}
