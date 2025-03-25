using Microsoft.VisualStudio.TestTools.UnitTesting;
using UberApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberApi.Models.Repository;
using UberApi.Models.EntityFramework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UberApi.Controllers.Tests
{
    [TestClass()]
    public class CoursiersControllerTests
    {

        private S221UberContext _context;
        private CoursiersController _controller;
        private IDataRepository<Coursier> _coursiersRepository;
        private Mock<IDataRepository<Coursier>> _mockRepository;


        [TestMethod()]
        public void GetCoursierById_ExistingIdPassed_AreEqual_AvecMoq()
        {

            Coursier coursier = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Durant",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };
            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(coursier);
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod()]
        public void GetCoursierById_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCoursierByNumeroCarteVTC_ExistingIdPassed_AreEqual_AvecMoq()
        {
            Coursier coursier = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Durant",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };
            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _mockRepository.Setup(x => x.GetByStringAsync("123456789012").Result).Returns(coursier);
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod]
        public void GetCoursierByNumeroCarteVTC_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            _mockRepository = new Mock<IDataRepository<Coursier>>();
            _controller = new CoursiersController(_mockRepository.Object);
            // Act
            var actionResult = _controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void PostCoursier_ValideIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            var coursier = new Coursier
            {
                IdCoursier = 10,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Amir",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };

            _mockRepository = new Mock<IDataRepository<Coursier>>();

            _mockRepository.Setup(x => x.AddAsync(It.IsAny<Coursier>())).Returns(Task.CompletedTask);
            _mockRepository.Setup(x => x.GetByIdAsync(It.Is<int>(id => id == coursier.IdCoursier)))
                           .ReturnsAsync(coursier);

            _controller = new CoursiersController(_mockRepository.Object);

            // Act
            var actionResult = _controller.PostCoursierAsync(coursier).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Coursier>));
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);
            var ress = result.Value as Coursier;
            Assert.IsNotNull(ress);
            Assert.AreEqual(coursier.IdCoursier, ress.IdCoursier);
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<Coursier>()), Times.Once);
        }


        [TestMethod]
        public void PutCoursier_ValideIdPassed_ReturnsNoContent_AvecMoq()
        {
            // Arrange
            var coursier = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Durant",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };

            var coursierUpdate = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Enzo", //new name to update
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };

            _mockRepository = new Mock<IDataRepository<Coursier>>();


            _mockRepository.Setup(x => x.GetByIdAsync(coursier.IdCoursier)).ReturnsAsync(coursierUpdate);


            _mockRepository.Setup(x => x.UpdateAsync(coursier, coursierUpdate));

            _controller = new CoursiersController(_mockRepository.Object);

            // Act
            var actionResult = _controller.PutCoursierAsync(coursierUpdate.IdCoursier, coursierUpdate).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NoContent));

            _mockRepository.Verify(x => x.UpdateAsync(It.Is<Coursier>(c => c.IdCoursier == coursierUpdate.IdCoursier), coursierUpdate), Times.Once);
        }

        [TestMethod]
        public void DeleteCoursier_ValideIdPassed_ReturnsNoContent_AvecMoq()
        {
            // Arrange : Création du coursier
            var coursier = new Coursier
            {
                IdCoursier = 1,
                IdEntreprise = 1,
                IdAdresse = 1,
                GenreUser = "Homme",
                NomUser = "Durant",
                PrenomUser = "Julien",
                DateNaissance = DateOnly.Parse("1988-04-25"),
                Telephone = "0601010101",
                EmailUser = "julien.durant@example.com",
                MotDePasseUser = "hasedpassword123",
                NumeroCarteVtc = "123456789012",
                Iban = "FR7630006000011234567890189",
                DateDebutActivite = DateOnly.Parse("2023-01-15"),
                NoteMoyenne = 4.5m,
                Courses = [],
                Entretiens = [],
                Horaires = [],
                IdAdresseNavigation = null,
                IdEntrepriseNavigation = null,
                ReglementSalaires = [],
                Vehicules = []
            };

            _mockRepository = new Mock<IDataRepository<Coursier>>();

            // Simulation de GetByIdAsync retournant un coursier valide
            _mockRepository.Setup(x => x.GetByIdAsync(coursier.IdCoursier))
                           .ReturnsAsync(coursier);

            // Simulation de la suppression
            _mockRepository.Setup(x => x.DeleteAsync(coursier));

            _controller = new CoursiersController(_mockRepository.Object);

            // Act : Suppression
            var actionResult = _controller.DeleteCoursierAsync(coursier.IdCoursier).Result;

            // Assert : Vérification de la réponse
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult)); // Corrected to NoContent

            // Vérification que GetByIdAsync a bien été appelé une fois
            _mockRepository.Verify(x => x.GetByIdAsync(coursier.IdCoursier), Times.Once);

            // Vérification que DeleteAsync a bien été appelé une seule fois avec le bon objet
            _mockRepository.Verify(x => x.DeleteAsync(It.Is<Coursier>(c => c.IdCoursier == coursier.IdCoursier)), Times.Once);
        }



        [TestMethod]
        public void DeleteCoursier_NotValideIdPassed_ReturnsNotFound_AvecMoq()
        {
            // Arrange : ID inexistant
            int idCoursierInvalide = 19;

            _mockRepository = new Mock<IDataRepository<Coursier>>();

            // Retourner null dans la méthode GetByIdAsync pour simuler un coursier inexistant
            _mockRepository.Setup(x => x.GetByIdAsync(idCoursierInvalide))
                           .ReturnsAsync((Coursier)null);  // Retourner null pour simuler que le coursier n'existe pas

            _controller = new CoursiersController(_mockRepository.Object);

            // Act : Tentative de suppression avec un ID inexistant
            var actionResult = _controller.DeleteCoursierAsync(idCoursierInvalide).Result;

            // Assert : Vérification de la réponse
            Assert.IsNotNull(actionResult);

            // Vérification que l'action retourne un NotFoundResult quand le coursier n'est pas trouvé
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

            // Vérification que GetByIdAsync a bien été appelé une fois
            _mockRepository.Verify(x => x.GetByIdAsync(idCoursierInvalide), Times.Once);

            // Vérification que DeleteAsync N'A PAS été appelé
            _mockRepository.Verify(x => x.DeleteAsync(It.IsAny<Coursier>()), Times.Never);
        }







    }

}
