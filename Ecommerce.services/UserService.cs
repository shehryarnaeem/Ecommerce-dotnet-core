using Ecommerce.models;
using Ecommerce.repositories;
using Ecommerce.services.interfaces;
using Ecommerce.repositories.interfaces;
using System.Collections.Generic;

namespace Ecommerce.services
{
    public class UserService : Service<ecommerceContext, User, UserRepository>, IUserService
    {
        public UserService(IUnitOfWork<ecommerceContext> unitOfWork, UserRepository repository) : base(unitOfWork, repository)
        {
        }

        public User GetUserByEmail(string email)
        {
            User user = this.UnitOfWork.UserRepository.FindOne(u => u.Email == email);
            return user;
        }
    }
}