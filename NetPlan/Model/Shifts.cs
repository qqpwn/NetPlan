﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NetPlan
{
    public partial class Shifts
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Fk_workhourTemplate { get; set; }
        public int? Fk_users { get; set; }
        public string DateToString
        {
            get
            { //return string.Format("{0:ddd, d MMM, yyyy}", Date, new CultureInfo("da-DK");
                if (Date != null) { 
                    DateTime lort = (DateTime)Date;
                    string pis = lort.ToString("dddd d. MMM yyyy", new CultureInfo("da-DK"));
                    return char.ToUpper(pis[0]) + pis.Substring(1);
                }
                return "Error! Error! Error! All mortals must perish!";
            }
        }
    }
}