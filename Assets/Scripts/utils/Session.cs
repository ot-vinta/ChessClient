using models;

namespace utils
{
    public class Session
    {
        private NetClient _client;
        private User _user;
        private Game _game;

        public Session(User user)
        {
            _user = user;
            _client = NetClient.GetInstance();
        }
        
        
    }
}