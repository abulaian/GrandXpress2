﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.API.Models
{
    public class ItemForCreationDto
    {
        [Required(ErrorMessage ="Reciever Name is required")]
        [MaxLength(50)]
        public ReceiverDto Receiver { get; set; }
      

        public decimal Amount { get; set; }
        public int Id { get; internal set; }
    }
}