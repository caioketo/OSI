using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;

namespace OSI.Models
{
    [ActiveRecord(Schema = "public")]
    public class Users : BaseModel
    {
        [Property]
        public string Name { get; set; }

        [Property]
        public string Username { get; set; }

        [Property]
        public string Password { get; set; }

        [Property]
        public string Email { get; set; }

        [Property]
        public float? Prestige { get; set; }
    }
}