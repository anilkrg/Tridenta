using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tridenta.BAL.Interface;
using Tridenta.DAL;
using Tridenta.Model;
using Tridenta.Model.ViewModel;

namespace Tridenta.BAL.Services
{
    public class RegistrationServices : IUserRegistration
    {
        private readonly ApplicationDbContext _dbContext;
        public RegistrationServices(ApplicationDbContext dbContext)
        {
                _dbContext = dbContext;
        }
        public Task<TblUserRegistration> GetEmailbyID(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<TblUserRegistration> SignIn(SignInModel signInModel)
        {
            try
            {
                var res = await _dbContext.TblUserRegistrations.SingleOrDefaultAsync(e => e.Email == signInModel.Email && e.Password == signInModel.Password);
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

      
        public async Task<TblUserRegistration> SignUp(SignUpModel signUpModel)
        {
            try
            {

                var newUser = new TblUserRegistration
                {
                    Name = signUpModel.Name,
                    Email = signUpModel.Email,
                    Password = signUpModel.Password,
                    Phone = signUpModel.Phone,
                    Gender = signUpModel.Gender,
                };

                // Add the new user to the database
                await _dbContext.TblUserRegistrations.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();
                return newUser;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
