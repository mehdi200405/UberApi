using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;

namespace UberApi.Models.DataManager
{


    public class ClientManager : IDataRepository<Client>
    {
        readonly S221UberContext? s221UberContext;
        public ClientManager() { }
        public ClientManager(S221UberContext context)
        {
            s221UberContext = context;
        }
        public async Task<ActionResult<IEnumerable<Client>>> GetAllAsync()
        {
            return await s221UberContext.Clients.ToListAsync();
        }
        public async Task<ActionResult<Client>> GetByIdAsync(int id)
        {
            return await s221UberContext.Clients.FirstOrDefaultAsync(u => u.IdClient == id);
        }
        public async Task<ActionResult<Client>> GetByStringAsync(string mail)
        {
            return await s221UberContext.Clients.FirstOrDefaultAsync(u => u.EmailUser.ToUpper() == mail.ToUpper());
        }

        public async Task AddAsync(Client entity)
        {
            s221UberContext.Clients.Add(entity);
            s221UberContext.SaveChanges();
        }
        public async Task UpdateAsync(Client newClient, Client entity)
        {
            s221UberContext.Entry(newClient).State = EntityState.Modified;
            newClient.IdClient = entity.IdClient;
            newClient.IdEntreprise = entity.IdEntreprise;
            newClient.IdAdresse = entity.IdAdresse;
            newClient.GenreUser = entity.GenreUser;
            newClient.NomUser = entity.NomUser;
            newClient.PrenomUser = entity.PrenomUser;
            newClient.DateNaissance = entity.DateNaissance;
            newClient.Telephone = entity.Telephone;
            newClient.EmailUser = entity.EmailUser;
            newClient.MotDePasseUser = entity.MotDePasseUser;
            newClient.PhotoProfile = entity.PhotoProfile;
            newClient.SouhaiteRecevoirBonPlan = entity.SouhaiteRecevoirBonPlan;
            newClient.MfaActivee = entity.MfaActivee;
            newClient.TypeClient = entity.TypeClient;
            newClient.DemandeSuppression = entity.DemandeSuppression;
            await s221UberContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Client utilisateur)
        {
            s221UberContext.Clients.Remove(utilisateur);
            await s221UberContext.SaveChangesAsync();
        }
    }

}
