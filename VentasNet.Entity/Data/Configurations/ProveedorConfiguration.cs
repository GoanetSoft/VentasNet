﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;

namespace VentasNet.Entity.Data.Configurations
{
    public partial class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> entity)
        {
            entity.HasKey(e => e.IdProveedor);

            entity.Property(e => e.Cuit)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            entity.Property(e => e.Domicilio)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.Property(e => e.Provincia)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.Property(e => e.RazonSocial)
                .IsRequired()
                .HasMaxLength(20)
                .IsFixedLength();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Proveedor> entity);
    }
}
