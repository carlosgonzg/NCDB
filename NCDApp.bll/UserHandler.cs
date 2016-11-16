using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NCDApp.dal;
using NCDApp.bll.Helpers;

namespace NCDApp.bll
{
    public class UserHandler : BaseHandler<User>, IDisposable
    {
        // Private Variables
        private string _saltSecret;

        public UserHandler() : base()
        {
            //Because Why it should stop?
            _saltSecret = "TheWorldShouldRotateForever";
            _dataContext = new NCDBDataContext();
        }
        public string getEncryptedPassword(string password)
        {
            string pass = "";
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            pass = BCrypt.Net.BCrypt.HashPassword(password + _saltSecret, salt);
            return pass;
        }
        private bool DoesPasswordMatch(string hashedPwdFromDatabase, string userEnteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(userEnteredPassword + _saltSecret, hashedPwdFromDatabase);
        }

        //Register User
        public User Register(User user)
        {
            try
            {
                if (user.Email == null)
                {
                    throw new CException(DataList.CodeStatus.InvalidData, "The email is required");
                }
                var isThereUser = GetUser(user.Email);
                if(isThereUser != null)
                {
                    throw new CException(DataList.CodeStatus.InvalidData, "The user already exists");
                }
                user.Password = getEncryptedPassword(user.Password);
                user = this.Create(user);
            }
            catch(Exception e)
            {
                throw;
            }
            return user;
        }

        //Find User
        public async Task<User> Login(string email, string password)
        {
            var user = (from b in _dataContext.Users where b.Email == email select b).First();
            var matched = DoesPasswordMatch(user.Password, password);
            return matched ? user : null;
        }
        public User GetActualUser()
        {
            var username = HttpContext.Current.User.Identity.Name;
            return (from b in _dataContext.Users where b.Email == username select b).First();
        }
        public User GetUser(string email)
        {
            return (from b in _dataContext.Users where b.Email == email select b).FirstOrDefault();
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
