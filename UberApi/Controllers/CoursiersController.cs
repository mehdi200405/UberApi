﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;

namespace UberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursiersController : ControllerBase
    {
        private readonly IDataRepository<Coursier> dataRepository;

        public CoursiersController(IDataRepository<Coursier> dataRepo)
        {
            dataRepository = dataRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coursier>>> GetCoursiersAsync()
        {
            return await dataRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Coursier>> GetCoursierAsync(int id)
        {
            var coursier = await dataRepository.GetByIdAsync(id);

            if (coursier == null)
            {
                return NotFound();
            }
            return coursier;

        }

        [HttpGet]
        [Route("[action]/{numeroCarteVTC}")]
        [ActionName("GetByNumeroCarteVTC")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Coursier>> GetCoursierByNumeroCarteVTCAsync(string numeroCarteVTC)
        {
            var utilisateur = await dataRepository.GetByStringAsync(numeroCarteVTC);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCoursierAsync(int id, Coursier coursier)
        {
            if (id != coursier.IdCoursier)
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
                await dataRepository.UpdateAsync(userToUpdate.Value, coursier);
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Coursier>> PostCoursierAsync(Coursier coursier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(coursier);
            return CreatedAtAction("GetById", new { id = coursier.IdCoursier }, coursier); // GetById : nom de l’action
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCoursierAsync(int id)
        {
            var coursier = await dataRepository.GetByIdAsync(id);
            if (coursier.Value == null)
            {
                return NotFound();

            }
            await dataRepository.DeleteAsync(coursier.Value);
            return NoContent();
        }
    }
}
