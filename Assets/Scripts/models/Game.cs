using System;
using System.Collections.Generic;

namespace models
{
    [Serializable]
    public class Game
    {
        public int PlayersMaxCount { get; }
        public List<User> Users { get; }

        public Game(int playersMaxCount)
        {
            PlayersMaxCount = playersMaxCount;
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }
    }
}