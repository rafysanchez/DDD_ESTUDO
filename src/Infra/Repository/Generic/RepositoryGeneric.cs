using Config;
using Interface.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public class RepositoryGeneric<T> : InterfaceGeneric<T>, IDisposable where T : class
    {
        private DbContextOptionsBuilder<ContextBase> _OptionsBuilder;


        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<ContextBase>();
        }

        ~RepositoryGeneric()
        {
            Dispose(false);
        }

        public void Add(T Entitie)
        {
            using (var banco = new ContextBase(_OptionsBuilder.Options))
            {
                banco.Add(Entitie);
                banco.SaveChanges();
            };
        }

        public void Delete(int Id)
        {
            using (var banco = new ContextBase(_OptionsBuilder.Options))
            {
                var Objeto = banco.Set<T>().Find(Id);
                banco.Remove(Objeto);
                banco.SaveChanges();
            };
        }

        public List<T> List()
        {
            using (var banco = new ContextBase(_OptionsBuilder.Options))
            {
                return banco.Set<T>().ToList();
            };
        }

        public void Update(T Entitie)
        {
            using (var banco = new ContextBase(_OptionsBuilder.Options))
            {
                banco.Update(Entitie);
                banco.SaveChanges();
            };
        }

        public T GetForId(int id)
        {
            using (var banco = new ContextBase(_OptionsBuilder.Options))
            {
               return  banco.Set<T>().Find(id);
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool Status)
        {
            if (!Status) return;
        }


    }
}
