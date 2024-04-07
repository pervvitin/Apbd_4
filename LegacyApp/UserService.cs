using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!UserDataValidator.userDataIsValid(firstName, lastName, dateOfBirth, email))
            {
                return false;
            }


            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User(firstName, lastName, email, dateOfBirth, client);

            if (!UserCreditService.CalculateCreditLimit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }


    }
}
