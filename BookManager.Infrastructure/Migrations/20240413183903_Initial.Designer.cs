﻿// <auto-generated />
using System;
using BookManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookManager.Infrastructure.Migrations
{
    [DbContext(typeof(BookManagerContext))]
    [Migration("20240413183903_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("SQ_Author")
                .HasMin(1L);

            modelBuilder.HasSequence("SQ_Book")
                .HasMin(1L);

            modelBuilder.HasSequence("SQ_Review")
                .HasMin(1L);

            modelBuilder.HasSequence("SQ_User")
                .HasMin(1L);

            modelBuilder.Entity("BookManager.Domain.Base.Entity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("NEXT VALUE FOR [SQ_User]");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("BookManager.Domain.Entities.Author", b =>
                {
                    b.HasBaseType("BookManager.Domain.Base.Entity");

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasIndex("BookId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.Book", b =>
                {
                    b.HasBaseType("BookManager.Domain.Base.Entity");

                    b.Property<decimal>("Average")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BookCover")
                        .IsRequired()
                        .HasMaxLength(-1)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publishing")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TotalPages")
                        .HasColumnType("int");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.Review", b =>
                {
                    b.HasBaseType("BookManager.Domain.Base.Entity");

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<long>("BookId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.HasIndex("BookId");

                    b.HasIndex("BookId1");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.User", b =>
                {
                    b.HasBaseType("BookManager.Domain.Base.Entity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.Author", b =>
                {
                    b.HasOne("BookManager.Domain.Entities.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.Review", b =>
                {
                    b.HasOne("BookManager.Domain.Entities.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookManager.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookManager.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookManager.Domain.Entities.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId1");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.Book", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookManager.Domain.Entities.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
