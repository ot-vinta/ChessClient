using System;

namespace models
{
    [Serializable]
    public class User
    {
        public string login;
        public string password;

        public User(){}
        
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}