using System;
using System.Runtime.Serialization;

namespace VisionsContracts.Land.Systems.GuildSystem.Exceptions
{
    
    public class GuildNameAlreadyInUseException : Exception
    {   
        public string Name { get; private set; }
        public GuildNameAlreadyInUseException(string name) : base($"Guild Name already in use: {name}")
        {
            Name = name;
        }
    }
}