namespace ProjectWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shifttransfers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? fk_shiftRequest { get; set; }

        public int? fk_shifts { get; set; }

        public int? fk_users_primary { get; set; }

        public int? fk_users_secondary { get; set; }

        public byte? approved { get; set; }
    }
}
