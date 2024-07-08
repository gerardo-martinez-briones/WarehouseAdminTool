﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Profile", b =>
                {
                    b.Property<int>("IdProfile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfile"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdProfile");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            IdProfile = 1,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8212),
                            CreatedBy = 0,
                            IsActive = true,
                            ProfileName = "Administrador"
                        },
                        new
                        {
                            IdProfile = 2,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8216),
                            CreatedBy = 0,
                            IsActive = true,
                            ProfileName = "Super Usuario"
                        },
                        new
                        {
                            IdProfile = 3,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8217),
                            CreatedBy = 0,
                            IsActive = true,
                            ProfileName = "Usuario"
                        });
                });

            modelBuilder.Entity("Domain.PurchaseOrder", b =>
                {
                    b.Property<int>("IdPurchaseOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPurchaseOrder"), 1L, 1);

                    b.Property<string>("Comments")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerPO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ReqShipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPurchaseOrder");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("Domain.PurchaseOrderDetail", b =>
                {
                    b.Property<int>("IdPurchaseOrderDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPurchaseOrderDetail"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedBy")
                        .HasColumnType("int");

                    b.Property<int>("IdPurchaseOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ItemDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ItemNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Ordered")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPurchaseOrderDetail");

                    b.HasIndex("IdPurchaseOrder");

                    b.ToTable("PurchaseOrderDetails");
                });

            modelBuilder.Entity("Domain.PurchaseOrderStatusLog", b =>
                {
                    b.Property<int>("IdPurchaseOrderStatusLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPurchaseOrderStatusLog"), 1L, 1);

                    b.Property<string>("Comments")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPurchaseOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdPurchaseOrderStatusLog");

                    b.HasIndex("IdPurchaseOrder");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdUser");

                    b.ToTable("PurchaseOrderStatusLogs");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdStatus");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            IdStatus = 1,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8352),
                            CreatedBy = 0,
                            Description = "Orden Importada desde un archivo .csv, sin tener ningún Item escaneado.",
                            IsActive = true,
                            StatusName = "Creada"
                        },
                        new
                        {
                            IdStatus = 2,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8353),
                            CreatedBy = 0,
                            Description = "Orden que ha comenzado con el proceso de escaneo de sus Items.",
                            IsActive = true,
                            StatusName = "En Proceso"
                        },
                        new
                        {
                            IdStatus = 3,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8354),
                            CreatedBy = 0,
                            Description = "Orden con todos los Items escaneados correctamente.",
                            IsActive = true,
                            StatusName = "Completada"
                        },
                        new
                        {
                            IdStatus = 4,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8355),
                            CreatedBy = 0,
                            Description = "Orden con algunos Items faltantes, que pudiese ser enviada.",
                            IsActive = true,
                            StatusName = "Incompleta"
                        });
                });

            modelBuilder.Entity("Domain.Tracking", b =>
                {
                    b.Property<int>("IdTracking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTracking"), 1L, 1);

                    b.Property<byte>("BedNumber")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdPurchaseOrderDetail")
                        .HasColumnType("int");

                    b.Property<string>("ItemNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("PalletNumber")
                        .HasColumnType("tinyint");

                    b.Property<int>("ReviewedBy")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTracking");

                    b.HasIndex("IdPurchaseOrderDetail");

                    b.ToTable("Trackings");
                });

            modelBuilder.Entity("Domain.TrackingStatusLog", b =>
                {
                    b.Property<int>("IdTrackingStatusLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrackingStatusLog"), 1L, 1);

                    b.Property<int>("BedNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedBy")
                        .HasColumnType("int");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdPurchaseOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("PalletNumber")
                        .HasColumnType("int");

                    b.HasKey("IdTrackingStatusLog");

                    b.HasIndex("IdPurchaseOrder");

                    b.ToTable("TrackingStatusLogs");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdUser");

                    b.HasIndex("IdProfile");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8309),
                            CreatedBy = 0,
                            Email = "admin@example.com",
                            FirstName = "Administrador",
                            HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                            IdProfile = 1,
                            IsActive = true,
                            LastName = "Sistema",
                            UserName = "admin"
                        },
                        new
                        {
                            IdUser = 2,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8311),
                            CreatedBy = 0,
                            Email = "gerardo.martinez@drivespro.com",
                            FirstName = "Gerardo",
                            HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                            IdProfile = 1,
                            IsActive = true,
                            LastName = "Martinez Briones",
                            UserName = "gerardo.martinez"
                        },
                        new
                        {
                            IdUser = 3,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8312),
                            CreatedBy = 0,
                            Email = "victor.luna@drivespro.com",
                            FirstName = "Victor",
                            HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                            IdProfile = 1,
                            IsActive = true,
                            LastName = "Luna Narvaez",
                            UserName = "victor.luna"
                        },
                        new
                        {
                            IdUser = 4,
                            CreatedAt = new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8313),
                            CreatedBy = 0,
                            Email = "israel.salas@drivespro.com",
                            FirstName = "Israel",
                            HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                            IdProfile = 1,
                            IsActive = true,
                            LastName = "Salas",
                            UserName = "israel.salas"
                        });
                });

            modelBuilder.Entity("Domain.PurchaseOrderDetail", b =>
                {
                    b.HasOne("Domain.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseOrderDetails")
                        .HasForeignKey("IdPurchaseOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("Domain.PurchaseOrderStatusLog", b =>
                {
                    b.HasOne("Domain.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseOrderStatusLogs")
                        .HasForeignKey("IdPurchaseOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Status", "Status")
                        .WithMany("PurchaseOrderStatusLogs")
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany("PurchaseOrderStatusLogs")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Tracking", b =>
                {
                    b.HasOne("Domain.PurchaseOrderDetail", "PurchaseOrderDetail")
                        .WithMany()
                        .HasForeignKey("IdPurchaseOrderDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrderDetail");
                });

            modelBuilder.Entity("Domain.TrackingStatusLog", b =>
                {
                    b.HasOne("Domain.PurchaseOrder", "PurchaseOrder")
                        .WithMany("TrackingStatusLog")
                        .HasForeignKey("IdPurchaseOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Profile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Domain.Profile", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.PurchaseOrder", b =>
                {
                    b.Navigation("PurchaseOrderDetails");

                    b.Navigation("PurchaseOrderStatusLogs");

                    b.Navigation("TrackingStatusLog");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Navigation("PurchaseOrderStatusLogs");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("PurchaseOrderStatusLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
