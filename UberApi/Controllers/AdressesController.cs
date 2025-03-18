﻿using System;
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
    public class AdressesController : ControllerBase
    {
        private readonly IDataRepository<Adresse> dataRepository;

        public AdressesController(IDataRepository<Adresse> dataRepo)
        {
            dataRepository = dataRepo;
        }   




        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdressesAsync()
        {
            return await dataRepository.GetAllAsync();
        }





        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresseAsync(int id)
        {
            var adresse = await dataRepository.GetByIdAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }
            return adresse;

        }


        [HttpGet]
        [Route("[action]/{libelleAdresse}")]
        [ActionName("GetByLibelleAdresse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetUtilisateurByLibelleAdresseAsync(string libelleAdresse)
        {
            var adresse = await dataRepository.GetByStringAsync(libelleAdresse);
            if (adresse == null)
            {
                return NotFound();
            }
            return adresse;
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAdresseAsync(int id, Adresse adresse)
        {
            if (id != adresse.IdAdresse)
            {
                return BadRequest();
            }
            var userToUpdate = await dataRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(userToUpdate.Value, adresse);
                return NoContent();
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adresse>> PostAdresseAsync(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(adresse);
            return CreatedAtAction("GetById", new { id = adresse.IdAdresse }, adresse); // GetById : nom de l’action
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdresseAsync(int id)
        {
            var adresse = await dataRepository.GetByIdAsync(id);
            if (adresse == null)
            {
                return NotFound();

            }
            await dataRepository.DeleteAsync(adresse.Value);
            return NoContent();
        }
    }
}
