namespace ProjectWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(32)]
        public string password { get; set; }

        [StringLength(3)]
        public string salt { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? phone { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public int? accessLevel { get; set; }
    }
}
