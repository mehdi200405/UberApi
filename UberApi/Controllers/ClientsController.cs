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
    public class ClientsController : ControllerBase
    {
        private readonly IDataRepository<Client> dataRepository;

        public ClientsController(IDataRepository<Client> dataRepo)
        {
            dataRepository = dataRepo;
        }   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsAsync()
        {
            return await dataRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientAsync(int id)
        {
            var client = await dataRepository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            return client;

        }

        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetUtilisateurByEmailAsync(string email)
        {
            var utilisateur = await dataRepository.GetByStringAsync(email);
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
        public async Task<IActionResult> PutClientAsync(int id, Client client)
        {
            if (id != client.IdClient)
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
                await dataRepository.UpdateAsync(userToUpdate.Value, client);
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> PostClientAsync(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(client);
            return CreatedAtAction("GetById", new { id = client.IdClient }, client);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            var client = await dataRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();

            }
            await dataRepository.DeleteAsync(client.Value);
            return NoContent();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            try
            {
                var user = await dataRepository.GetByStringAsync(model.Email);

                if (user == null || user.Value == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Value.MotDePasseUser))
                {
                    return Unauthorized("Email ou mot de passe incorrect.");
                }

                return Ok(new
                {
                    message = "Authentification réussie",
                    user = new
                    {
                        user.Value.IdClient,
                        user.Value.NomUser,
                        user.Value.PrenomUser,
                        user.Value.EmailUser,
                        user.Value.GenreUser,
                        user.Value.PhotoProfile
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur serveur : " + ex.Message);
            }
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            var existingUser = await dataRepository.GetByStringAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("Un utilisateur avec cet email existe déjà.");
            }

            var newUser = new Client
            {
                NomUser = model.Nom,
                PrenomUser = model.Prenom,
                EmailUser = model.Email,
                MotDePasseUser = BCrypt.Net.BCrypt.HashPassword(model.Password),
                GenreUser = model.Genre,
                DateNaissance = model.DateNaissance,
                Telephone = model.Telephone,
                TypeClient = model.TypeClient
            };

            await dataRepository.AddAsync(newUser);

            return CreatedAtAction("GetById", new { id = newUser.IdClient }, newUser);
        }

        public class RegisterModel
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Genre { get; set; }
            public DateOnly DateNaissance { get; set; }
            public string Telephone { get; set; }
            public string TypeClient { get; set; }
        }
    }
}
