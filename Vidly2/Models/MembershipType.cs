using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SignUpFee { get; set; }

        public int DurationInMonths { get; set; }

        public int DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
        /*
         Id = 2 => Monthly
         Id = 3 => Quaterly
         Id = 4 => Annually
         
         */
    }
}