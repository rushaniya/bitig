using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class BitigAlifbaRepository : AlifbaRepository
    {
        private readonly AlifbaRepository alifbaRepository;

        public BitigAlifbaRepository(AlifbaRepository innerRepository)
        {
            alifbaRepository = innerRepository;
        }

        public override void Update(Alifba Item)
        {
            alifbaRepository.Update(Item);
        }

        protected override void DeleteNoCheck(Alifba Item)
        {
            throw new NotImplementedException();
        }

        protected override void FlushChanges()
        {
            throw new NotImplementedException();
        }

        protected override Alifba GetIfExists(int ID)
        {
            throw new NotImplementedException();
        }

        protected override List<Alifba> GetListNoCreate()
        {
            throw new NotImplementedException();
        }

        protected override void InsertExactID(Alifba Item)
        {
            throw new NotImplementedException();
        }
    }
}
