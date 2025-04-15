﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IDOrPassportNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhysicalAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SubCountyId")
                        .HasColumnType("int");

                    b.Property<int>("SubLocationId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneContact")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.HasIndex("LocationId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("SexId");

                    b.HasIndex("SubCountyId");

                    b.HasIndex("SubLocationId");

                    b.HasIndex("UserId");

                    b.HasIndex("VillageId");

                    b.ToTable("Applicants", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ApplicantProgram", b =>
                {
                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<int>("AssistanceProgramId")
                        .HasColumnType("int");

                    b.HasKey("ApplicantId", "AssistanceProgramId");

                    b.HasIndex("AssistanceProgramId");

                    b.ToTable("ApplicantPrograms", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AssistanceProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("AssistancePrograms", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Counties", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SubCountyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCountyId");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatusLookup", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SexLookup", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SubCounty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("SubCountyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("SubCounties", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SubLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("SubLocationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK_SubLocation");

                    b.HasIndex("LocationId");

                    b.ToTable("SubLocations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("AccountConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Village", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SubLocationId")
                        .HasColumnType("int");

                    b.Property<string>("VillageName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SubLocationId");

                    b.ToTable("Villages", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Xml")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator().HasValue("IdentityRole");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasDiscriminator().HasValue("IdentityRoleClaim<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUserClaim<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("AspNetUserLogins", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUserLogin<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUserRole<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUserToken<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasDiscriminator().HasValue("ApplicationRole");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>");

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Group")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasDiscriminator().HasValue("ApplicationRoleClaim");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>");

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("ApplicationUserClaim");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserLogin", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>");

                    b.Property<string>("UserId1")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("ApplicationUserLogin");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<string>("UserId1")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserToken", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserToken<string>");

                    b.Property<string>("UserId1")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("ApplicationUserToken");
                });

            modelBuilder.Entity("Domain.Entities.Applicant", b =>
                {
                    b.HasOne("Domain.Entities.County", "County")
                        .WithMany("Applicants")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany("Applicants")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.MaritalStatus", "MaritalStatus")
                        .WithMany("Applicants")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sex", "Sex")
                        .WithMany("Applicants")
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SubCounty", "SubCounty")
                        .WithMany("Applicants")
                        .HasForeignKey("SubCountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SubLocation", "SubLocation")
                        .WithMany("Applicants")
                        .HasForeignKey("SubLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Applicants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.Village", "Village")
                        .WithMany("Applicants")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");

                    b.Navigation("Location");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Sex");

                    b.Navigation("SubCounty");

                    b.Navigation("SubLocation");

                    b.Navigation("User");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Domain.Entities.ApplicantProgram", b =>
                {
                    b.HasOne("Domain.Entities.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AssistanceProgram", "AssistanceProgram")
                        .WithMany()
                        .HasForeignKey("AssistanceProgramId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("AssistanceProgram");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.HasOne("Domain.Entities.SubCounty", "SubCounty")
                        .WithMany("Locations")
                        .HasForeignKey("SubCountyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubCounty");
                });

            modelBuilder.Entity("Domain.Entities.SubCounty", b =>
                {
                    b.HasOne("Domain.Entities.County", "County")
                        .WithMany("SubCounties")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("Domain.Entities.SubLocation", b =>
                {
                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany("SubLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_SubLocation_Location");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.User", "LastModifiedByUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedByUser");

                    b.Navigation("LastModifiedByUser");
                });

            modelBuilder.Entity("Domain.Entities.Village", b =>
                {
                    b.HasOne("Domain.Entities.SubLocation", "SubLocation")
                        .WithMany("Villages")
                        .HasForeignKey("SubLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubLocation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId1");

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.County", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("SubCounties");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("SubLocations");
                });

            modelBuilder.Entity("Domain.Entities.MaritalStatus", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Domain.Entities.Sex", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Domain.Entities.SubCounty", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Domain.Entities.SubLocation", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("Villages");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("Logins");

                    b.Navigation("Tokens");

                    b.Navigation("UserClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Village", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationRole", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
