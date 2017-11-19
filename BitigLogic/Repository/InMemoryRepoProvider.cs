using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class InMemoryRepoProvider : RepositoryProvider
    {
        public InMemoryRepoProvider(IRepository<Alifba, int> AlifbaRepository, IRepository<Direction, int> DirectionRepository) 
        {
            AlifbaRepository.RepositoryProvider = this;
            DirectionRepository.RepositoryProvider = this;
            var _alifbaInMemory = new InMemoryRepository<Alifba, int>(AlifbaRepository);
            this.AlifbaRepository = new AlifbaRepository(_alifbaInMemory);
            var _directionInMemory = new InMemoryRepository<Direction, int>(DirectionRepository);
            this.DirectionRepository = new DirectionRepository(_directionInMemory);
        }
    }
}
