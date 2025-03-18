using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;
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
    public class RestaurateursController : ControllerBase
    {
        private readonly IDataRepository<Restaurateur> dataRepository;

        public RestaurateursController(IDataRepository<Restaurateur> dataRepo)
        {
            dataRepository = dataRepo;
        }




        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurateur>>> GetRestaurateurs()
        {
            return dataRepository.GetAll();
        }





        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurateur>> GetRestaurateurById(int id)
        {
            var restaurateur = dataRepository.GetById(id);

            if (restaurateur == null)
            {
                return NotFound();
            }
            return restaurateur;
        }


        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurateur>> GetClientByEmail(string email)
        {
            var restaurateur = dataRepository.GetByString(email);

            if (restaurateur == null)
            {
                return NotFound();
            }
            return restaurateur;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRestaurateur(int id, Restaurateur restaurateur)
        {
            if (id != restaurateur.IdRestaurateur)
            {
                return BadRequest();
            }
            var userToUpdate = dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                dataRepository.Update(userToUpdate.Value, restaurateur);
                return NoContent();
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Restaurateur>> PostRestaurateur(Restaurateur restaurateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dataRepository.Add(restaurateur);
            return CreatedAtAction("GetById", new { id = restaurateur.IdRestaurateur }, restaurateur); // GetById : nom de l’action
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurateur(int id)
        {
            var restaurateur = dataRepository.GetById(id);
            if (restaurateur == null)
            {
                return NotFound();

            }
            dataRepository.Delete(restaurateur.Value);
            return NoContent();
        }

    }
}
