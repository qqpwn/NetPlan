namespace ProjectWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("notify")]
    public partial class notify
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public byte? approved { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public int? fk_users { get; set; }
    }
}
