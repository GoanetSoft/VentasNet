﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Entity.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Stock = new HashSet<Stock>();
        }

        public int IdProducto { get; set; }
        public int? IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public double? ImporteProducto { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Stock> Stock { get; set; }
    }
}