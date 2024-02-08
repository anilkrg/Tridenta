using Tridenta.Model;
using Tridenta.Model.ViewModel;

namespace Tridenta.BAL.Interface
{
    public interface IUserRegistration
    {
        Task<TblUserRegistration> SignUp(SignUpModel signUpModel);
        Task<TblUserRegistration> SignIn(SignInModel signInModel);
        Task<TblUserRegistration> GetEmailbyID(string Email);
    }
}
