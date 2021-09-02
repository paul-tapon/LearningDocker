﻿// <auto-generated />
using System;
using DOTR.QLess.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DOTR.QLess.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(QLessDbContext))]
    partial class QLessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedByAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerUniqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ForgotPasswordExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForgotPasswordUrlParam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLocalNetworkUser")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedByAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Qualifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppUserId");

                    b.HasIndex("CreatedByAppUserId");

                    b.HasIndex("LastModifiedByAppUserId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            AppUserId = 1,
                            CreatedDate = new DateTime(2021, 9, 1, 2, 32, 14, 100, DateTimeKind.Local).AddTicks(6390),
                            CustomerUniqueId = new Guid("8f563b98-6f6b-4579-b386-b8096b0adbbd"),
                            IsActive = true,
                            PasswordHash = "C18EB64337F215B3FD54A7EC73CBCE6BAAA2AF0F2F7BB8F68F311C2274EB903628AC26149CF94BC310624F1FE9C2B18FF718F121755273995D4574E9BF2D2464",
                            PasswordSalt = "811439E1442F7FD2F5B3E28410EC984094EB8036C7C3781973B56E0C7020EBF076DB83CD8BDE2D9EA2838361259FB7489B6779B6310EDBCAB2958896B7AC6BFC",
                            Username = "sys.default"
                        });
                });

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreatedByAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedByAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUsedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TicketNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("CreatedByAppUserId");

                    b.HasIndex("LastModifiedByAppUserId");

                    b.HasIndex("TicketNumber")
                        .IsUnique()
                        .HasFilter("[TicketNumber] IS NOT NULL");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.TicketNumberSeeder", b =>
                {
                    b.Property<int>("TicketNumberSeederId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("SeedValue")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("TicketNumberSeederId");

                    b.ToTable("TicketNumberSeeder");
                });

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.TicketType", b =>
                {
                    b.Property<int>("TicketTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExpirationInMonths")
                        .HasColumnType("int");

                    b.Property<decimal>("FixRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InitialLoad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedByAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketTypeId");

                    b.HasIndex("CreatedByAppUserId");

                    b.HasIndex("LastModifiedByAppUserId");

                    b.ToTable("TicketTypes");

                    b.HasData(
                        new
                        {
                            TicketTypeId = 1,
                            CreatedByAppUserId = 1,
                            CreatedDate = new DateTime(2021, 9, 1, 2, 32, 14, 111, DateTimeKind.Local).AddTicks(5570),
                            ExpirationInMonths = 60,
                            FixRate = 15m,
                            InitialLoad = 100m,
                            IsActive = true,
                            Name = "Regular"
                        },
                        new
                        {
                            TicketTypeId = 2,
                            CreatedByAppUserId = 1,
                            CreatedDate = new DateTime(2021, 9, 1, 2, 32, 14, 111, DateTimeKind.Local).AddTicks(6610),
                            ExpirationInMonths = 36,
                            FixRate = 10m,
                            InitialLoad = 500m,
                            IsActive = true,
                            Name = "Discounted"
                        });
                });

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.AppUser", b =>
                {
                    b.HasOne("DOTR.QLess.Domain.Entities.AppUser", "CreatedByAppUser")
                        .WithMany()
                        .HasForeignKey("CreatedByAppUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DOTR.QLess.Domain.Entities.AppUser", "LastModifiedByAppUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByAppUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedByAppUser");

                    b.Navigation("LastModifiedByAppUser");
                });

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("DOTR.QLess.Domain.Entities.AppUser", "CreatedByAppUser")
                        .WithMany()
                        .HasForeignKey("CreatedByAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOTR.QLess.Domain.Entities.AppUser", "LastModifiedByAppUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByAppUserId");

                    b.HasOne("DOTR.QLess.Domain.Entities.TicketType", "TicketType")
                        .WithMany()
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByAppUser");

                    b.Navigation("LastModifiedByAppUser");

                    b.Navigation("TicketType");
                });

            modelBuilder.Entity("DOTR.QLess.Domain.Entities.TicketType", b =>
                {
                    b.HasOne("DOTR.QLess.Domain.Entities.AppUser", "CreatedByAppUser")
                        .WithMany()
                        .HasForeignKey("CreatedByAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOTR.QLess.Domain.Entities.AppUser", "LastModifiedByAppUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedByAppUserId");

                    b.Navigation("CreatedByAppUser");

                    b.Navigation("LastModifiedByAppUser");
                });
#pragma warning restore 612, 618
        }
    }
}
