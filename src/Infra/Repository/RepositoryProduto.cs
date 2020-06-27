using Entities;
using Interface;
using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryProduto : RepositoryGeneric<Produto>, InterfaceProduto
    {
    }
}
