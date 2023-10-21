using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly Transfers _transfers;
        private readonly Deposit _deposit;



        public UsersServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
            _gestorOfOperation = new GestorOfOperation(unitOfWork);
            _accountFinder = new AccountFinder();
            _transfers = new Transfers(_accountFinder, _gestorOfOperation);
            _deposit = new Deposit(_accountFinder, _gestorOfOperation);
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
                    Email = userCredentials.Email,
                    Token = token
                };
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

                    return ResponseFactory.CreateSuccessResponse(200, user);
                
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }

        public async Task<IActionResult> DepositCryptoAccount(int id, DepositCryptoDTO cryptoDeposit)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);


                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }


                CryptoAccount matchingAccount = await _accountFinder.FindMatchingCryptoAccountAsync(user.CryptoAccounts, cryptoDeposit);

                if (matchingAccount == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                await _gestorOfOperation.DepositCryptoAccount(matchingAccount, cryptoDeposit);

                return ResponseFactory.CreateSuccessResponse(200, user);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }

        public async Task<IActionResult> DepositFiduciaryAccount(int id ,DepositFiduciaryDTO fiduciaryAccount)
        {
            try
            {

                User user = await _unitOfWork.UserRepository.GetUserById(id);


                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }


                FiduciaryAccount matchingAccount = await _accountFinder.FindMatchingFiduciaryAccount(user.FiduciaryAccounts, fiduciaryAccount);

                if (matchingAccount == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                await _gestorOfOperation.DepositFiduciaryAccount(matchingAccount, fiduciaryAccount);

                return ResponseFactory.CreateSuccessResponse(200, user);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }

        public async Task<IActionResult> Transfers(int id, int parameter, TransferRequestFiduciaryDTO transferRequestFiduciaryDTO)
        {
            try
            {
                User user = await _unitOfWork.UserRepository.GetUserById(id);

                if (user == null)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                bool result = false;
                DepositFiduciaryDTO fiduciaryDepositOrigin = transferRequestFiduciaryDTO.TransfersFiduciaryOrigin;
                DepositCryptoDTO cryptoDepositOrigin = transferRequestFiduciaryDTO.TransfersCryptoOrigin;
                TransfersFiduciaryDTO fiduciaryDepositDestination = transferRequestFiduciaryDTO.TransfersFiduciaryDestination;
                TransfersCryptoDTO cryptoDepositDestination = transferRequestFiduciaryDTO.TransfersCryptoDestination;

                switch (parameter)
                {
                    case 0:
                        result = await _transfers.TransfersOriginToDestination(user, fiduciaryDepositOrigin, fiduciaryDepositDestination);
                        break;
                    case 1:
                        result = await _transfers.TransfersOriginToDestination(user, fiduciaryDepositOrigin, cryptoDepositDestination);
                        break;
                    case 2:
                        result = await _transfers.TransfersOriginToDestination(user, cryptoDepositOrigin, fiduciaryDepositDestination);
                        break;
                    case 3:
                        result = await _transfers.TransfersOriginToDestination(user, cryptoDepositOrigin, cryptoDepositDestination);
                        break;
                    default:
                        return ResponseFactory.CreateErrorResponse(400, "Invalid parameter");
                }

                if (!result)
                {
                    return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
                }

                return ResponseFactory.CreateSuccessResponse(200, user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");
            }
        }



    }
}
