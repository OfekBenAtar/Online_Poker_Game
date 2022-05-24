﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Poker.DataModel;

#nullable disable

namespace PokerClassLibrary
{
    public partial class PokerContext : DbContext
    {
        public PokerContext()
        {
        }

        public PokerContext(DbContextOptions<PokerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Pot> Pots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            // Room
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Money).HasColumnName("userMoney");

                entity.HasOne<Room>().WithMany(room => room.Users).HasForeignKey(user => user.RoomId).IsRequired(false);
            });

            // Pot
            modelBuilder.Entity<Pot>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne<Room>().WithMany(room => room.Pots).HasForeignKey(pot => pot.RoomId).IsRequired(false);
            });

            // Card
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne<User>().WithMany(room => room.Cards).HasForeignKey(card => card.UserId).IsRequired(false);

                entity.HasOne<Room>().WithMany(room => room.CardsOnTable).HasForeignKey(card => card.RoomId).IsRequired(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}