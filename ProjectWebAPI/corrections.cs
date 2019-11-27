namespace ProjectWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class corrections
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? fk_users { get; set; }

        public int? fk_shifts_primary { get; set; }

        public int? fk_shifts_secondary { get; set; }

        public float? hours { get; set; }

        public byte? approved { get; set; }
    }
}
