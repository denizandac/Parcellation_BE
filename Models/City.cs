﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
namespace Belsis_Parselasyon_Backend.Models
{
    public class City
    {
        public float lon { get; set; }
        public float lat { get; set; }

    }
}
