// <auto-generated />
using System;
using BE_AGENDA_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BE_AGENDA_API.Migrations
{
    [DbContext(typeof(AgendaApiContext))]
    partial class AgendaApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("BE_AGENDA_API.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CelularNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("TelephoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CelularNumber = 11425789L,
                            Description = "Jefa",
                            Email = "maria@gmail.com",
                            LastName = "Perez",
                            Name = "Maria",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CelularNumber = 34156978L,
                            Description = "Papa",
                            Email = "pepe@gmail.com",
                            LastName = "Gonzalez",
                            Name = "Pepe",
                            TelephoneNumber = 422568L,
                            UserId = 2
                        },
                        new
                        {
                            Id = 1,
                            CelularNumber = 341457896L,
                            Description = "Plomero",
                            Email = "jaimito@gmail.com",
                            LastName = "Sanchez",
                            Name = "Jaimito",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BE_AGENDA_API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "karenbailapiola@gmail.com",
                            LastName = "Lasot",
                            Name = "Karen",
                            Password = "Pa$$w0rd",
                            UserName = "karenpiola"
                        },
                        new
                        {
                            Id = 2,
                            Email = "elluismidetotoras@gmail.com",
                            LastName = "Gonzales",
                            Name = "Luis Gonzalez",
                            Password = "lamismadesiempre",
                            UserName = "luismitoto"
                        });
                });

            modelBuilder.Entity("BE_AGENDA_API.Entities.Contact", b =>
                {
                    b.HasOne("BE_AGENDA_API.Entities.User", "User")
                        .WithMany("Contact")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BE_AGENDA_API.Entities.User", b =>
                {
                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
