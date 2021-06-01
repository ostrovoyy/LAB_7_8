using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int Idcitizen, string userType)
        {
            UserId = userId;
            Name = name;
            Idcitizen = idCitizen;
            Type = userType;
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int idCitizen { get; set; }
        public string Type { get; set; }
    }
}
