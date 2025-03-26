using Microsoft.VisualStudio.TestTools.UnitTesting;
using UberApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.DataManager;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UberApi.Controllers.Tests
{
    [TestClass()]
    public class EntreprisesControllerTests
    {
        private S221UberContext _context;
        private EntreprisesController _controller;
        private IDataRepository<Entreprise> _entreprisesRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<S221UberContext>().UseNpgsql("Server=51.83.36.122;port=5432;Database=sae4_UberApiDB; uid=s221; password=VmFu4u;");
            _context = new S221UberContext(builder.Options);
            _entreprisesRepository = new EntrepriseManager(_context);
            _controller = new EntreprisesController(_entreprisesRepository);
        }


        [TestMethod()]
        public void GetEntrepriseById_NotExistingIdPassed_ReturnsRightItem_AvecMoq()
        {

            var mockRepository = new Mock<IDataRepository<Entreprise>>();
            var controller = new EntreprisesController(mockRepository.Object);
            // Act
            var actionResult = controller.GetEntrepriseAsync(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void GetEntrepriseById_ExistingIdPassed_AreEqual_AvecMoq()
        {

            Entreprise entreprise = new Entreprise
            {
                IdEntreprise = 1,
                IdAdresse = 1,
                SiretEntreprise = "12345678901234",
                NomEntreprise = "Innovatech",
                Taille = "Grande",
                Clients = [],
                Coursiers = [],
                IdAdresseNavigation = null,
            };
            var mockRepository = new Mock<IDataRepository<Entreprise>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(entreprise);
            var controller = new EntreprisesController(mockRepository.Object);
            // Act
            var actionResult = controller.GetEntrepriseAsync(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(entreprise, actionResult.Value as Entreprise);
        }


    }
}