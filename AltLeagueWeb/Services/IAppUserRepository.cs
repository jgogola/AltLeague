using AltFuture.Models;


namespace AltFuture.Services
{
    public interface IAppUserRepository : IDisposable
    {
      
        App_User_Model UserGet(int user_key);

        App_User_Model? UserGetByCredentials(string user_name, string password);

        List<App_User_Model> UserGetList(int is_active_user = -1);
     

    }
}
