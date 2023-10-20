using SofttekFinalProjectBackend.Services;

namespace SofttekFinalProjectBackend.Logic
{
    public class GestorOfOperation
    {
        private readonly IUnitOfWork _unitOfWork;
        public GestorOfOperation (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Deposit()
        {

        }

        public async Task Transfers()
        {

        }

        public async Task Buy()
        {

        }
    }
}
