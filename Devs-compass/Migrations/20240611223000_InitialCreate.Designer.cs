﻿// <auto-generated />
using System;
using Devs_compass.DBConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devs_compass.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240611223000_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeveloperGroup", b =>
                {
                    b.Property<int>("DevelopersId")
                        .HasColumnType("int");

                    b.Property<int>("groupsId")
                        .HasColumnType("int");

                    b.HasKey("DevelopersId", "groupsId");

                    b.HasIndex("groupsId");

                    b.ToTable("DeveloperGroup");
                });

            modelBuilder.Entity("Devs_compass.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Devs_compass.Models.GameJam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("motif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("GameJam");

                    b.HasDiscriminator<string>("Discriminator").HasValue("GameJam");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Devs_compass.Models.GameJamParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameJamId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("Place")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameJamId");

                    b.HasIndex("GroupId");

                    b.ToTable("GameJamsParticipations");
                });

            modelBuilder.Entity("Devs_compass.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Devs_compass.Models.Opinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MakeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("Devs_compass.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("Devs_compass.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameJamId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("TimeToBeat")
                        .HasColumnType("real");

                    b.Property<string>("UseLicense")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameJamId");

                    b.HasIndex("GroupId");

                    b.ToTable("Softwares");
                });

            modelBuilder.Entity("Devs_compass.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SoftwareTag", b =>
                {
                    b.Property<int>("SoftwaresId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("SoftwaresId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("SoftwareTag");
                });

            modelBuilder.Entity("Devs_compass.Models.OwnGameJam", b =>
                {
                    b.HasBaseType("Devs_compass.Models.GameJam");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("OwnGameJam");
                });

            modelBuilder.Entity("Devs_compass.Models.SponsoredGameJam", b =>
                {
                    b.HasBaseType("Devs_compass.Models.GameJam");

                    b.Property<string>("Sponsor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("SponsoredGameJam");
                });

            modelBuilder.Entity("DeveloperGroup", b =>
                {
                    b.HasOne("Devs_compass.Models.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devs_compass.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("groupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Devs_compass.Models.GameJam", b =>
                {
                    b.HasOne("Devs_compass.Models.Organizer", null)
                        .WithMany("GameJams")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Devs_compass.Models.GameJamParticipation", b =>
                {
                    b.HasOne("Devs_compass.Models.GameJam", "GameJam")
                        .WithMany("GameJamParticipations")
                        .HasForeignKey("GameJamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devs_compass.Models.Group", "Group")
                        .WithMany("GameJamParticipations")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameJam");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Devs_compass.Models.Opinion", b =>
                {
                    b.HasOne("Devs_compass.Models.Developer", null)
                        .WithMany("Opinions")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("Devs_compass.Models.Organizer", null)
                        .WithMany("Opinions")
                        .HasForeignKey("OrganizerId");

                    b.HasOne("Devs_compass.Models.Software", null)
                        .WithMany("Opinions")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Devs_compass.Models.Software", b =>
                {
                    b.HasOne("Devs_compass.Models.GameJam", null)
                        .WithMany("Softwares")
                        .HasForeignKey("GameJamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devs_compass.Models.Group", null)
                        .WithMany("Softwares")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoftwareTag", b =>
                {
                    b.HasOne("Devs_compass.Models.Software", null)
                        .WithMany()
                        .HasForeignKey("SoftwaresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devs_compass.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Devs_compass.Models.Developer", b =>
                {
                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("Devs_compass.Models.GameJam", b =>
                {
                    b.Navigation("GameJamParticipations");

                    b.Navigation("Softwares");
                });

            modelBuilder.Entity("Devs_compass.Models.Group", b =>
                {
                    b.Navigation("GameJamParticipations");

                    b.Navigation("Softwares");
                });

            modelBuilder.Entity("Devs_compass.Models.Organizer", b =>
                {
                    b.Navigation("GameJams");

                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("Devs_compass.Models.Software", b =>
                {
                    b.Navigation("Opinions");
                });
#pragma warning restore 612, 618
        }
    }
}
