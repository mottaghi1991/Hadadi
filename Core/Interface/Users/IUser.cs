using System.Collections;
using System.Collections.Generic;
using Core.Dto.ViewModel.User;
using Core.Dto.ViewModel.User.Login;
using Domain;
using Domain.User;
using Domain.Users;
using Microsoft.AspNetCore.Http;


namespace Core.Interface.Users
{
    public interface IUser
    {
    bool ISExistUserName(string userName);
    bool ISExistEmail(string Email);
    MyUser AddUser(MyUser user);
    MyUser LoginCheck(LoginViewModel model);
    InformationUserViewModel GetUserInformation(string userName);

    MyUser GetUserByUserName(string userName);

    int BalanceUserWallet(string  userName);
    UserPanelViewModel GetUserPanel(string userName);
    bool IsActiveCode(string code);
    MyUser GetUserByActiveCode(string code);

    MyUser Update(MyUser user);
    
    IEnumerable<ShowUserBrifViewModel> GetPAggingUser(int Page,int pagesize);
    IEnumerable<ShowUserBrifViewModel> GetAllAdmin();
        public MyUser GetUserByUserId(int userId);
        public MyUser GetOrCreateUser(string phoneNumber);
        public void SignIn(HttpContext context, MyUser user);
    }
}