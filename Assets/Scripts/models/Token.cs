using System;

namespace models
{
    [Serializable]
    public class Token
    {
        public string token;

        public Token(string token)
        {
            this.token = token;
        }
    }
}