﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Data;

#nullable disable

namespace todoapi.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20250221094008_Initialmigration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoApi.Models.SubTodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentTodoId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentTodoId");

                    b.ToTable("SubTodos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deadline = new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Créer le wireframe",
                            Name = "Faire une maquette",
                            ParentTodoId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            Deadline = new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Développer les composants de base",
                            Name = "Créer composants Vue",
                            ParentTodoId = 2,
                            Status = 1
                        });
                });

            modelBuilder.Entity("TodoApi.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Blue",
                            Name = "Travail"
                        },
                        new
                        {
                            Id = 2,
                            Color = "Green",
                            Name = "Personnel"
                        },
                        new
                        {
                            Id = 3,
                            Color = "Red",
                            Name = "Urgent"
                        });
                });

            modelBuilder.Entity("TodoApi.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deadline = new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Aller au supermarché",
                            Name = "Acheter du lait",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            Deadline = new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Étudier l'API Web",
                            Name = "Réviser .NET",
                            Status = 1
                        });
                });

            modelBuilder.Entity("TodoApi.Models.TodoTag", b =>
                {
                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("TodoId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TodoTags");

                    b.HasData(
                        new
                        {
                            TodoId = 1,
                            TagId = 1
                        },
                        new
                        {
                            TodoId = 2,
                            TagId = 2
                        });
                });

            modelBuilder.Entity("TodoApi.Models.SubTodo", b =>
                {
                    b.HasOne("TodoApi.Models.TodoItem", "ParentTodo")
                        .WithMany("SubTodos")
                        .HasForeignKey("ParentTodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentTodo");
                });

            modelBuilder.Entity("TodoApi.Models.TodoTag", b =>
                {
                    b.HasOne("TodoApi.Models.Tag", "Tag")
                        .WithMany("TodoTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoApi.Models.TodoItem", "Todo")
                        .WithMany("TodoTags")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("TodoApi.Models.Tag", b =>
                {
                    b.Navigation("TodoTags");
                });

            modelBuilder.Entity("TodoApi.Models.TodoItem", b =>
                {
                    b.Navigation("SubTodos");

                    b.Navigation("TodoTags");
                });
#pragma warning restore 612, 618
        }
    }
}
