﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PSS;
using System;

namespace PSS.Migrations
{
    [DbContext(typeof(PSSContext))]
    [Migration("20190214123819_nextry")]
    partial class nextry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSS.AspNetUsersEmpresas", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int?>("EmpresaId")
                        .HasColumnName("EmpresaID");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers_Empresas");
                });
#pragma warning restore 612, 618
        }
    }
}