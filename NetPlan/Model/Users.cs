using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPlan.Model
{
    public class Users
    {
     
        public int id { get; set; }    
        public string email { get; set; }  
        public string password { get; set; } 
        public string salt { get; set; }
        public string name { get; set; }
        public int? phone { get; set; }
        public string description { get; set; }
        public int? accessLevel { get; set; }


    }
}
