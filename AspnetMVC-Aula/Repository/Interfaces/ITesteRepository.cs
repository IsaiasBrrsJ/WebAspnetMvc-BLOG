using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspnet_.Models;

namespace WebAspnet_.Repository.Interfaces
{
    public interface ITesteRepository
    {
        //Repositorio Teste
        Task<Teste> GetPerId(Guid id);

        Task AddAsync(Teste entity);

        Task Delete(Teste Entity);
    }
}