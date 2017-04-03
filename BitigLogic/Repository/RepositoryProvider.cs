namespace Bitig.Logic.Repository
{
    public class RepositoryProvider
    {
        public BitigAlifbaRepository AlifbaRepository { get; private set; }
        public BitigDirectionRepository DirectionRepository { get; private set; }

        public RepositoryProvider(AlifbaRepository AlifbaRepository, DirectionRepository DirectionRepository)
        {
            AlifbaRepository.RepositoryProvider = this;
            DirectionRepository.RepositoryProvider = this;
            this.AlifbaRepository = new BitigAlifbaRepository(AlifbaRepository);
            this.DirectionRepository = new BitigDirectionRepository(DirectionRepository);
            this.AlifbaRepository.RepositoryProvider = this;
            this.DirectionRepository.RepositoryProvider = this;
        }
    }
}
