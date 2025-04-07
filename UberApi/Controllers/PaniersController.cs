using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.DataManager;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using UberApi.Models.Repository;

namespace UberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaniersController : ControllerBase
    {
        private readonly IDataRepository<Panier> dataRepository;

        public PaniersController(IDataRepository<Panier> dataRepo)
        {
            dataRepository = dataRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> GetPaniersAsync()
        {
            return await dataRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Panier>> GetPanierAsync(int id)
        {
            var Panier = await dataRepository.GetByIdAsync(id);

            if (Panier.Value == null)
            {
                return NotFound();
            }
            return Panier;

        }

        [HttpGet]
        [Route("[action]/{prix}")]
        [ActionName("GetByLibellePrix")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Panier>> GetCBByNumeroCbPanierAsync(string prix)
        {
            var Panier = await dataRepository.GetByStringAsync(prix);
            if (Panier.Value == null)
            {
                return NotFound();
            }
            return Panier;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPanierAsync(int id, Panier Panier)
        {
            if (id != Panier.IdPanier)
            {
                return BadRequest();
            }
            var userToUpdate = await dataRepository.GetByIdAsync(id);
            if (userToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(userToUpdate.Value, Panier);
                return NoContent();
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Panier>> PostPanierAsync(Panier Panier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                await dataRepository.AddAsync(Panier);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return CreatedAtAction("GetById", new { id = Panier.IdPanier }, Panier);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePanierAsync(int id)
        {
            var Panier = await dataRepository.GetByIdAsync(id);

            if (Panier.Value == null)
            {
                return NotFound();

            }

            await dataRepository.DeleteAsync(Panier.Value);
            return NoContent();
        }
    }
}
