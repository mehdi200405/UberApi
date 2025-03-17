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
            public ActionResult<IEnumerable<Client>> GetAll()
            {
                return s221UberContext.Clients.ToList();
            }
            public ActionResult<Client> GetById(int id)
            {
                return s221UberContext.Clients.FirstOrDefault(u => u.IdClient == id);
            }
            public ActionResult<Client> GetByString(string mail)
            {
                return s221UberContext.Clients.FirstOrDefault(u => u.EmailUser.ToUpper() == mail.ToUpper());
            }
            public void Add(Client entity)
            {
                s221UberContext.Clients.Add(entity);
                s221UberContext.SaveChanges();
            }
            public void Update(Client newClient, Client entity)
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
            s221UberContext.SaveChanges();
            }
            public void Delete(Client utilisateur)
            {
                s221UberContext.Clients.Remove(utilisateur);
                s221UberContext.SaveChanges();
            }
        }
    
}
