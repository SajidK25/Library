﻿// <auto-generated />
using System;
using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190917143326_CreateReturnBookTable")]
    partial class CreateReturnBookTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Barcode");

                    b.Property<int>("CopyCount");

                    b.Property<string>("Edition");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.BookIssue", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("BookId");

                    b.Property<DateTime>("IssueDate");

                    b.HasKey("StudentId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookIssues");
                });

            modelBuilder.Entity("Library.ReturnBook", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<string>("Barcode");

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("StudentId", "Barcode");

                    b.HasIndex("BookId");

                    b.ToTable("ReturnBooks");
                });

            modelBuilder.Entity("Library.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FineAmount");

                    b.Property<string>("StudentName");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Library.BookIssue", b =>
                {
                    b.HasOne("Library.Book", "Book")
                        .WithMany("Students")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Student", "Student")
                        .WithMany("Books")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.ReturnBook", b =>
                {
                    b.HasOne("Library.Book", "Book")
                        .WithMany("rStudents")
                        .HasForeignKey("BookId");

                    b.HasOne("Library.Student", "Student")
                        .WithMany("rBooks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
