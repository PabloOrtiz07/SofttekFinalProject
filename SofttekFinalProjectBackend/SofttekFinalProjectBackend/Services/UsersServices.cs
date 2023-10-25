using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SofttekFinalProjectBackend.DataAccess;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;
using SofttekFinalProjectBackend.Helper;
using SofttekFinalProjectBackend.Infrastructure;
using SofttekFinalProjectBackend.Logic;
using System.Data;

namespace SofttekFinalProjectBackend.Services
{
    public class UsersServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private TokenJwtHelper _tokenJwtHelper;
        private readonly GestorOfOperation _gestorOfOperation;
        private readonly AccountFinder _accountFinder;
        private readonly TransfersManager _transfersManager;
        private readonly DepositManager _depositManager;
        private readonly SaleManager _saleManager;
        private readonly BuyManager _buyManager;
        private readonly WithDrawManager _withDrawManager;
        private readonly SaveTransactionManager _saveTransactionManager;


        public UsersServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
            _gestorOfOperation = new GestorOfOperation(unitOfWork);
            _accountFinder = new AccountFinder();
            _transfersManager = new TransfersManager(_accountFinder, _gestorOfOperation);
            _depositManager = new DepositManager(_accountFinder, _gestorOfOperation);
            _saleManager = new SaleManager(_accountFinder, _gestorOfOperation);
            _buyManager = new BuyManager(_accountFinder, _gestorOfOperation);
            _withDrawManager = new WithDrawManager(_accountFinder, _gestorOfOperation);
            _saveTransactionManager = new SaveTransactionManager(_accountFinder, _gestorOfOperation, unitOfWork);

        }

        public async Task<IActionResult> UserLogin(AuthenticateDTO authenticateDTO)
        {
            try
            {
                var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(authenticateDTO);
                if (userCredentials is null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                var token = _tokenJwtHelper.GenerateToken(userCredentials);

                var user = new UserLoginDTO()
                {
                    Id = userCredentials.Id,
                    Email = userCredentials.Email,
                    Token = token
                };
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, user);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
        }

        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);

                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }
                UserDTO userDTO = await _unitOfWork.UserRepository.GetUserDTOById(id);
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, userDTO);
                
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }

        public async Task<IActionResult> Buy(int id, int saleNumber)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);
                List<Sale> sales = await _unitOfWork.SaleRepository.GetAllAvailable();
                List<FiduciaryAccount> allAccounts = await _unitOfWork.FiduciaryAccountRepository.GetAllAccountInPesos();

                bool result = false;


                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }



                result = await _buyManager.Buy(user, sales ,saleNumber,allAccounts);
                result = await _saveTransactionManager.SaveTransactionBuy(user.Id, saleNumber);


                if (result == true)
                {
                    UserDTO userDTO = await _unitOfWork.UserRepository.GetUserDTOById(id);
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, userDTO);

                }
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }

        public async Task<IActionResult> Sale(int id, SaleRequestDTO saleRequest)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);

                bool result = false;


                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                result = await _saleManager.Sale(user, saleRequest); 
                result = await _saveTransactionManager.SaveTransactionSale(user.Id, saleRequest);


                if (result == true)
                {
                    UserDTO userDTO = await _unitOfWork.UserRepository.GetUserDTOById(id);
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, userDTO);

                }
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }
        public async Task<IActionResult> WithDrawMoney(int id, int parameter, WithDrawMoneyDTO withDrawMoneyDTO)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);

                bool result = false;


                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                if (parameter == 0)
                {

                    result = await _withDrawManager.WithDraw(user, withDrawMoneyDTO.WithDrawMoneyFiduciary);
                    result = await _saveTransactionManager.SaveTransactionWithDraw(user.Id, withDrawMoneyDTO.WithDrawMoneyFiduciary);

                }

                if (parameter == 1)
                {
                    result = await _withDrawManager.WithDraw(user, withDrawMoneyDTO.WithDrawMoneyCrypto);
                    result = await _saveTransactionManager.SaveTransactionWithDraw(user.Id, withDrawMoneyDTO.WithDrawMoneyCrypto);
                }

                if (result == false)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

                }

                UserDTO userDTO = await _unitOfWork.UserRepository.GetUserDTOById(id);
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "The withdraw operation was succesfull");

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }
        public async Task<IActionResult> Deposit(int id, int parameter, DepositRequestDTO depositRequest)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);

                bool result = false;



                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                if (parameter == 0)
                {
                    DepositFiduciary fiduciaryAccount = depositRequest.DepositFiduciary;
                    result = await _depositManager.Deposit(user, fiduciaryAccount);
                    result = await _saveTransactionManager.SaveTransactionDeposit(user.Id, depositRequest.DepositFiduciary);
                }

                if (parameter == 1)
                {
                    DepositCrypto cryptoAccount = depositRequest.DepositCrypto;
                    result = await _depositManager.Deposit(user, cryptoAccount);
                    result = await _saveTransactionManager.SaveTransactionDeposit(user.Id, depositRequest.DepositCrypto);
                }

                if (result == false)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

                }

                UserDTO userDTO = await _unitOfWork.UserRepository.GetUserDTOById(id);
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, userDTO);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }
        public async Task<IActionResult> Transfers(int id, int parameter, TransferRequestDTO transferRequestFiduciaryDTO)
        {
            try
            {
                User user = await _unitOfWork.UserRepository.GetUserById(id);

                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                bool result = false;
                DepositFiduciary fiduciaryDepositOrigin = transferRequestFiduciaryDTO.TransfersFiduciaryOrigin;
                DepositCrypto cryptoDepositOrigin = transferRequestFiduciaryDTO.TransfersCryptoOrigin;
                TransfersFiduciary fiduciaryDepositDestination = transferRequestFiduciaryDTO.TransfersFiduciaryDestination;
                TransfersCrypto cryptoDepositDestination = transferRequestFiduciaryDTO.TransfersCryptoDestination;

                switch (parameter)
                {
                    case 0:
                        result = await _transfersManager.TransfersOriginToDestination(user, fiduciaryDepositOrigin, fiduciaryDepositDestination);
                        result = await _saveTransactionManager.SaveTransactionTransfers(user.Id, fiduciaryDepositOrigin, fiduciaryDepositDestination);
                        break;
                    case 1:
                        result = await _transfersManager.TransfersOriginToDestination(user, fiduciaryDepositOrigin, cryptoDepositDestination);
                        result = await _saveTransactionManager.SaveTransactionTransfers(user.Id, fiduciaryDepositOrigin, cryptoDepositDestination);
                        break;
                    case 2:
                        result = await _transfersManager.TransfersOriginToDestination(user, cryptoDepositOrigin, fiduciaryDepositDestination);
                        result = await _saveTransactionManager.SaveTransactionTransfers(user.Id, cryptoDepositOrigin, fiduciaryDepositDestination);
                        break;
                    case 3:
                        result = await _transfersManager.TransfersOriginToDestination(user, cryptoDepositOrigin, cryptoDepositDestination);
                        result = await _saveTransactionManager.SaveTransactionTransfers(user.Id, cryptoDepositOrigin, cryptoDepositDestination);
                        break;
                    default:
                        return ResponseFactory.CreateErrorResponse(400, "Invalid parameter");
                }

                if (result == false)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }
                UserDTO userDTO = await _unitOfWork.UserRepository.GetUserDTOById(id);
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, userDTO);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }



    }
}
