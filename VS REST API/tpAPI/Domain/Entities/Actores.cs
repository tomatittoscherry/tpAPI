﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace tpAPI.Domain.Entities
{
    public partial class Actores
    {
        public Actores()
        {
            Actuaciones = new HashSet<Actuaciones>();
        }

        public int? IdActor { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Actuaciones> Actuaciones { get; set; }
    }
}