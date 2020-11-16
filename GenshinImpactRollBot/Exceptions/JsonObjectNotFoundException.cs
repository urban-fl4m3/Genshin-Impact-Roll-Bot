using System;

namespace GenshinImpactRollBot.Exceptions
{
    public class JsonObjectNotFoundException : Exception
    {
        public JsonObjectNotFoundException()
        {
            
        }

        public JsonObjectNotFoundException(string message) : base(message)
        {
            
        }

        public JsonObjectNotFoundException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}