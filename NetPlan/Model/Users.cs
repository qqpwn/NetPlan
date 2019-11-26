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
        private int _id;
        private string _name;
        private int _phone;
        private string _email;
        private string _password;
        private string _description;
        private int _accessLevel;

        public static int autoIntriment = 1;

        public Users()
        {
            
            
            autoIntriment++;

        }



    }
}
