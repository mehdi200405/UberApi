using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;
using UberApi.Models.Repository;

namespace UberApi.Models.DataManager
{
    public class CoursierManager : IDataRepository<Coursier>
    {
        readonly S221UberContext? s221UberContext;
        public CoursierManager() { }
        public CoursierManager(S221UberContext context)
        {
            s221UberContext = context;
        }
        public ActionResult<IEnumerable<Coursier>> GetAll()
        {
            return s221UberContext.Coursiers.ToList();
        }
        public ActionResult<Coursier> GetById(int id)
        {
            return s221UberContext.Coursiers.FirstOrDefault(u => u.IdCoursier == id);
        }
        public ActionResult<Coursier> GetByString(string mail)
        {
            return s221UberContext.Coursiers.FirstOrDefault(u => u.EmailUser.ToUpper() == mail.ToUpper());
        }
        public void Add(Coursier entity)
        {
            s221UberContext.Coursiers.Add(entity);
            s221UberContext.SaveChanges();
        }
        public void Update(Coursier newCoursier, Coursier entity)
        {
            s221UberContext.Entry(newCoursier).State = EntityState.Modified;
            newCoursier.IdCoursier = entity.IdCoursier;
            newCoursier.IdEntreprise = entity.IdEntreprise;
            newCoursier.IdAdresse = entity.IdAdresse;
            newCoursier.GenreUser = entity.GenreUser;
            newCoursier.NomUser = entity.NomUser;
            newCoursier.PrenomUser = entity.PrenomUser;
            newCoursier.DateNaissance = entity.DateNaissance;
            newCoursier.Telephone = entity.Telephone;
            newCoursier.EmailUser = entity.EmailUser;
            newCoursier.MotDePasseUser = entity.MotDePasseUser;
            s221UberContext.SaveChanges();
        }
        public void Delete(Coursier utilisateur)
        {
            s221UberContext.Coursiers.Remove(utilisateur);
            s221UberContext.SaveChanges();
        }
    }
}
