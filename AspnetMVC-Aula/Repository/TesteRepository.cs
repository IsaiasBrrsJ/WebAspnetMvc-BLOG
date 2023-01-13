using System;
using System.Threading.Tasks;
using WebAspnet_.Models;
using WebAspnet_.Repository.Interfaces;

namespace WebAspnet_.Repository
{
    public class TesteRepository : ITesteRepository
    {
        private readonly IRepositoryBase<Teste> _repositoryBase; //Recebendo a interface
        public TesteRepository(IRepositoryBase<Teste> repositoryBase) => _repositoryBase = repositoryBase;
        public async Task AddAsync(Teste entity) => await _repositoryBase.AddAsync(entity);
        public async Task Delete(Teste Entity) => await _repositoryBase.AddAsync(Entity);
        public async Task<Teste> GetPerId(Guid id) => await _repositoryBase.GetId(id);
    }
}