using Microsoft.AspNetCore.Mvc;
using Moq;
using Projet.Asp.Net.Core.Api.Application.DTOs;
using Projet.Asp.Net.Core.Api.Controllers;
using SelfieAWookie.Dotnet.Framework;
using SelfieAWookies.Core.Domain;
using System;
using System.Collections.Generic;
using Xunit;



namespace TestWebApi
{
    public class SelfiesscontrollerUnitTest
    {
        #region public methods
        
        [Fact]
        public void ShouldAddOneSelfies()
        {
            // ARRANGE
            SelfieDto selfie = new SelfieDto();
            var repositoryMock = new Mock<ISelfieRepository>();
            var unit = new Mock<IUnitOfWork>();
            repositoryMock.Setup(item => item.unitOfWork).Returns(unit.Object);
            repositoryMock.Setup(item => item.AddOneSelfie(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });

            // ACT
            var controller = new SelfieController(repositoryMock.Object);
            var result = controller.AddOne(selfie);
            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var addedSelfies = (result as OkObjectResult).Value as SelfieDto;
            Assert.NotNull(addedSelfies);
            Assert.True(addedSelfies.Id > 0);
        }
        #endregion
        

        #region Public methods
        [Fact]
        public void ShouldReturnListOfSelfiess()
        {
            //ARRANGE : pour les données
            // on doit recupérer les données mais nous ne devons pas faire des requêtes à la base de données, on va utiliser le mock
            // le mock permet de simuler le comportement d'une classe et ses méthodes. Il permet de simuler le retour d'une méthode
            // nous allons simuler le retour de GetAll qui sera une liste de 2 selfie
            var expectedList = new List<Selfie>() // list simulée
            {
                new Selfie(){Wookies = new Wookie()},
                new Selfie(){Wookies = new Wookie()}
            } ;
            var repositoryMock = new Mock<ISelfieRepository>();
            repositoryMock.Setup(item => item.GetAll()).Returns(expectedList);
            var controller = new SelfieController(repositoryMock.Object);

            //ACT : pour l'action que l'on fait
            var result = controller.GetAll(0);

            //ASSERT: pour verifier
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
            Assert.IsType<List<SelfiesResumeDto>>(okResult.Value);
            List<SelfiesResumeDto> list = okResult.Value as List<SelfiesResumeDto>;
            Assert.True(list.Count == 2);

            
        }
        #endregion


    }


}

