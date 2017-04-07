using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class InMemoryRepoProvider : RepositoryProvider
    {
        public override AlifbaRepository AlifbaRepository
        {
            get
            {
                return base.AlifbaRepository;
            }
        }

        public InMemoryRepoProvider(IRepository<Alifba, int> AlifbaRepository, IRepository<Direction, int> DirectionRepository) 
        {
            var _alifbaInMemory = new InMemoryRepository<Alifba, int>(AlifbaRepository);
            var _directionInMemory = new InMemoryRepository<Direction, int>(DirectionRepository);
            AlifbaRepository.RepositoryProvider = this;
            DirectionRepository.RepositoryProvider = this;
            this.AlifbaRepository = new AlifbaRepository(_alifbaInMemory);
            this.DirectionRepository = new DirectionRepository(_directionInMemory);
            //this.AlifbaRepository.RepositoryProvider = this;
            //this.DirectionRepository.RepositoryProvider = this;
        }
    }
}
