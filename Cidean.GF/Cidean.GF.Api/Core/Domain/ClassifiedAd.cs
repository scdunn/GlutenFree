﻿using System.ComponentModel.DataAnnotations;


namespace Cidean.GF.Api.Core.Domain
{


    public partial class Business
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(255)]
        public string LocationUrl { get; set; }
        
        public decimal Rating { get; set; }

    }
}
