using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class RepositoryProvider
    {
        public virtual AlifbaRepository AlifbaRepository { get; protected set; }
        public virtual DirectionRepository DirectionRepository { get; protected set; }

        public RepositoryProvider(IRepository<Alifba, int> AlifbaRepository, IRepository<Direction, int> DirectionRepository)
        {
            AlifbaRepository.RepositoryProvider = this;
            DirectionRepository.RepositoryProvider = this;
            this.AlifbaRepository = new AlifbaRepository(AlifbaRepository);
            this.DirectionRepository = new DirectionRepository(DirectionRepository);
        }

        protected RepositoryProvider()
        {

        }
    }
}
