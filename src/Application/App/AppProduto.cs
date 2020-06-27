using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace App
{
    public class AppProduto : IAppProduto
    {

        InterfaceProduto _InterfaceProduto;

        public AppProduto(InterfaceProduto InterfaceProduto)
        {
            _InterfaceProduto = InterfaceProduto;
        }


        public void Add(Produto Entitie)
        {
            _InterfaceProduto.Add(Entitie);
        }

        public void Delete(int Id)
        {
            _InterfaceProduto.Delete(Id);
        }

        public Produto GetForId(int id)
        {
            return _InterfaceProduto.GetForId(id);
        }

        public List<Produto> List()
        {
            return _InterfaceProduto.List();
        }

        public void Update(Produto Entitie)
        {
            _InterfaceProduto.Update(Entitie);
        }
    }
}
