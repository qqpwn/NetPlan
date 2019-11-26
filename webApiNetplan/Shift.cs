namespace webApiNetplan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shift
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int? fk_workhourTemplate { get; set; }

        public int? fk_users { get; set; }
    }
}
