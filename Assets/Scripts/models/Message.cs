using System;

namespace models
{
    [Serializable]
    public class Message<T>
    {
        public string command;
        public T argument;
        
        public Message(){}

        public Message(string command, T argument)
        {
            this.command = command;
            this.argument = argument;
        }
    }
}