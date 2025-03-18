using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;

namespace UberApi.Models.DataManager
{


        public class RestaurateurManager : IDataRepository<Restaurateur>
        {
            readonly S221UberContext? s221UberContext;
            public RestaurateurManager() { }
            public RestaurateurManager(S221UberContext context)
            {
                s221UberContext = context;
            }
            public ActionResult<IEnumerable<Restaurateur>> GetAll()
            {
                return s221UberContext.Restaurateurs.ToList();
            }
            public ActionResult<Restaurateur> GetById(int id)
            {
                return s221UberContext.Restaurateurs.FirstOrDefault(u => u.IdRestaurateur == id);
            }
            public ActionResult<Restaurateur> GetByString(string mail)
            {
                return s221UberContext.Restaurateurs.FirstOrDefault(u => u.EmailUser.ToUpper() == mail.ToUpper());
            }
            public void Add(Restaurateur entity)
            {
                s221UberContext.Restaurateurs.Add(entity);
                s221UberContext.SaveChanges();
            }
            public void Update(Restaurateur newRestaurateur, Restaurateur entity)
            {
                s221UberContext.Entry(newRestaurateur).State = EntityState.Modified;
                newRestaurateur.IdRestaurateur = entity.IdRestaurateur;
                newRestaurateur.NomUser = entity.NomUser;
                newRestaurateur.PrenomUser = entity.PrenomUser;
                newRestaurateur.Telephone = entity.Telephone;
                newRestaurateur.EmailUser = entity.EmailUser;
                newRestaurateur.MotDePasseUser = entity.MotDePasseUser;
                s221UberContext.SaveChanges();
            }
            public void Delete(Restaurateur utilisateur)
            {
                s221UberContext.Restaurateurs.Remove(utilisateur);
                s221UberContext.SaveChanges();
            }
        }
    
}
