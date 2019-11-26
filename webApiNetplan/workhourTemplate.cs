namespace webApiNetplan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("workhourTemplate")]
    public partial class workhourTemplate
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public TimeSpan? start { get; set; }

        public TimeSpan? end { get; set; }

        public float? rate { get; set; }
    }
}
