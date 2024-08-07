﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RMS.Dto.Enum;

namespace RMS.Dto
{
    public class Hall : Auditable
    {
        public int? CategoryId { get; set; }
        public string Category { get; set; } = string.Empty;
        [Required]
        public string HallNumber { get; set; } = string.Empty;
        public int NumberOfBed { get; set; }
        public string Facilities { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        private decimal price;
        public decimal Price
        {
            get => price;
            set => price = Math.Round(value, 2);
        }
        public string BedCharge { get; set; } = string.Empty;
        public string PersonCharge { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public bool ExtraCapacity { get; set; }
        public bool IsActive { get; set; }
        public string ImageName { get; set; } = string.Empty;

        public byte[]? ImageFile { get; set; }

        public RoomHallStatus Status { get; set; } = RoomHallStatus.Available;
        public Floor floor { get; set; } = Floor.FirstFloor;
    }
}
