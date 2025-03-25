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
using Microsoft.EntityFrameworkCore;
using UberApi.Models.DataManager;

namespace UberApi.Controllers.Tests
{
    [TestClass()]
    public class CoursiersControllerTests
    {

        /// <summary>
        /// AVEC MOQ
        /// </summary>

        private S221UberContext _context;
        private CoursiersController _controller;
        private IDataRepository<Coursier> _coursiersRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<S221UberContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sae4_UberApiDB; uid=s221; password=VmFu4u;");
            _context = new S221UberContext(builder.Options);
            _coursiersRepository = new CoursierManager(_context);
            _controller = new CoursiersController(_coursiersRepository);
        }

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
            var mockRepository = new Mock<IDataRepository<Coursier>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(coursier);
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod()]
        public void GetCoursierById_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            var mockRepository = new Mock<IDataRepository<Coursier>>();
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierAsync(1).Result;
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
            var mockRepository = new Mock<IDataRepository<Coursier>>();
            mockRepository.Setup(x => x.GetByStringAsync("123456789012").Result).Returns(coursier);
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod]
        public void GetCoursierByNumeroCarteVTC_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            var mockRepository = new Mock<IDataRepository<Coursier>>();
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
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

            var mockRepository = new Mock<IDataRepository<Coursier>>();

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Coursier>())).Returns(Task.CompletedTask);
            mockRepository.Setup(x => x.GetByIdAsync(It.Is<int>(id => id == coursier.IdCoursier)))
                           .ReturnsAsync(coursier);

            var controller = new CoursiersController(mockRepository.Object);

            // Act
            var actionResult = controller.PostCoursierAsync(coursier).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Coursier>));
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);
            var ress = result.Value as Coursier;
            Assert.IsNotNull(ress);
            Assert.AreEqual(coursier.IdCoursier, ress.IdCoursier);
            mockRepository.Verify(x => x.AddAsync(It.IsAny<Coursier>()), Times.Once);
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

            var mockRepository = new Mock<IDataRepository<Coursier>>();


            mockRepository.Setup(x => x.GetByIdAsync(coursier.IdCoursier)).ReturnsAsync(coursierUpdate);


            mockRepository.Setup(x => x.UpdateAsync(coursier, coursierUpdate));

            var controller = new CoursiersController(mockRepository.Object);

            // Act
            var actionResult = controller.PutCoursierAsync(coursierUpdate.IdCoursier, coursierUpdate).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));

            mockRepository.Verify(x => x.UpdateAsync(It.Is<Coursier>(c => c.IdCoursier == coursierUpdate.IdCoursier), coursierUpdate), Times.Once);
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

            var mockRepository = new Mock<IDataRepository<Coursier>>();

            
            mockRepository.Setup(x => x.GetByIdAsync(coursier.IdCoursier))
                           .ReturnsAsync(coursier);

           
            mockRepository.Setup(x => x.DeleteAsync(coursier));

            var controller = new CoursiersController(mockRepository.Object);

            // Act : Suppression
            var actionResult = controller.DeleteCoursierAsync(coursier.IdCoursier).Result;

            // Assert : Vérification de la réponse
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));

           
            mockRepository.Verify(x => x.GetByIdAsync(coursier.IdCoursier), Times.Once);


            mockRepository.Verify(x => x.DeleteAsync(It.Is<Coursier>(c => c.IdCoursier == coursier.IdCoursier)), Times.Once);
        }



        [TestMethod]
        public void DeleteCoursier_NotValideIdPassed_ReturnsNotFound_AvecMoq()
        {
            // Arrange : ID inexistant
            int idCoursierInvalide = 19;

            var mockRepository = new Mock<IDataRepository<Coursier>>();

            mockRepository.Setup(x => x.GetByIdAsync(idCoursierInvalide))
                           .ReturnsAsync((Coursier)null);  // Retourner null pour simuler que le coursier n'existe pas

            var controller = new CoursiersController(mockRepository.Object);

            var actionResult = controller.DeleteCoursierAsync(idCoursierInvalide).Result;


            Assert.IsNotNull(actionResult);

 
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));  

            mockRepository.Verify(x => x.GetByIdAsync(idCoursierInvalide), Times.Once);


            mockRepository.Verify(x => x.DeleteAsync(It.IsAny<Coursier>()), Times.Never);
        }


        /// <summary>
        /// SANS MOQ /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        [TestMethod()]
        public void GetCoursiers_SansMoq()
        {

            List<Coursier> expected = _context.Coursiers.ToList();


            // Act
            var actionResult = _controller.GetCoursiersAsync().Result;
            // Assert
            CollectionAssert.AreEqual(expected, actionResult.Value.ToList(), "");
        }

        [TestMethod()]
        public void GetCoursierById_ExistingIdPassed_AreEqual_SansMoq()
        {

            var expected = _context.Coursiers.FirstOrDefault(u => u.IdCoursier == 1);


            // Act
            var actionResult = _controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(expected, actionResult.Value);
        }
/// <summary>
/// LA SUITE A FAIRE /*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*///*/*/
/// </summary>
        [TestMethod()]
        public void GetCoursierById_NotExistingIdPassed_ReturnsRightItem_SansMoq()
        {

            var mockRepository = new Mock<IDataRepository<Coursier>>();
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierAsync(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCoursierByNumeroCarteVTC_ExistingIdPassed_AreEqual_SansMoq()
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
            var mockRepository = new Mock<IDataRepository<Coursier>>();
            mockRepository.Setup(x => x.GetByStringAsync("123456789012").Result).Returns(coursier);
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(coursier, actionResult.Value as Coursier);
        }

        [TestMethod]
        public void GetCoursierByNumeroCarteVTC_NotExistingIdPassed_ReturnsRightItem_SansMoq()
        {

            var mockRepository = new Mock<IDataRepository<Coursier>>();
            var controller = new CoursiersController(mockRepository.Object);
            // Act
            var actionResult = controller.GetCoursierByNumeroCarteVTCAsync("123456789012").Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void PostCoursier_ValideIdPassed_ReturnsRightItem_SansMoq()
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

            var mockRepository = new Mock<IDataRepository<Coursier>>();

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Coursier>())).Returns(Task.CompletedTask);
            mockRepository.Setup(x => x.GetByIdAsync(It.Is<int>(id => id == coursier.IdCoursier)))
                           .ReturnsAsync(coursier);

            var controller = new CoursiersController(mockRepository.Object);

            // Act
            var actionResult = controller.PostCoursierAsync(coursier).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Coursier>));
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);
            var ress = result.Value as Coursier;
            Assert.IsNotNull(ress);
            Assert.AreEqual(coursier.IdCoursier, ress.IdCoursier);
            mockRepository.Verify(x => x.AddAsync(It.IsAny<Coursier>()), Times.Once);
        }


        [TestMethod]
        public void PutCoursier_ValideIdPassed_ReturnsNoContent_SansMoq()
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

            var mockRepository = new Mock<IDataRepository<Coursier>>();


            mockRepository.Setup(x => x.GetByIdAsync(coursier.IdCoursier)).ReturnsAsync(coursierUpdate);


            mockRepository.Setup(x => x.UpdateAsync(coursier, coursierUpdate));

            var controller = new CoursiersController(mockRepository.Object);

            // Act
            var actionResult = controller.PutCoursierAsync(coursierUpdate.IdCoursier, coursierUpdate).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));

            mockRepository.Verify(x => x.UpdateAsync(It.Is<Coursier>(c => c.IdCoursier == coursierUpdate.IdCoursier), coursierUpdate), Times.Once);
        }

        [TestMethod]
        public void DeleteCoursier_ValideIdPassed_ReturnsNoContent_SansMoq()
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

            var mockRepository = new Mock<IDataRepository<Coursier>>();


            mockRepository.Setup(x => x.GetByIdAsync(coursier.IdCoursier))
                           .ReturnsAsync(coursier);


            mockRepository.Setup(x => x.DeleteAsync(coursier));

            var controller = new CoursiersController(mockRepository.Object);

            // Act : Suppression
            var actionResult = controller.DeleteCoursierAsync(coursier.IdCoursier).Result;

            // Assert : Vérification de la réponse
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));


            mockRepository.Verify(x => x.GetByIdAsync(coursier.IdCoursier), Times.Once);


            mockRepository.Verify(x => x.DeleteAsync(It.Is<Coursier>(c => c.IdCoursier == coursier.IdCoursier)), Times.Once);
        }



        [TestMethod]
        public void DeleteCoursier_NotValideIdPassed_ReturnsNotFound_SansMoq()
        {
            // Arrange : ID inexistant
            int idCoursierInvalide = 19;

            var mockRepository = new Mock<IDataRepository<Coursier>>();

            mockRepository.Setup(x => x.GetByIdAsync(idCoursierInvalide))
                           .ReturnsAsync((Coursier)null);  // Retourner null pour simuler que le coursier n'existe pas

            var controller = new CoursiersController(mockRepository.Object);

            var actionResult = controller.DeleteCoursierAsync(idCoursierInvalide).Result;


            Assert.IsNotNull(actionResult);


            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

            mockRepository.Verify(x => x.GetByIdAsync(idCoursierInvalide), Times.Once);


            mockRepository.Verify(x => x.DeleteAsync(It.IsAny<Coursier>()), Times.Never);
        }


    }

}
