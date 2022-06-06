﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokerClassLibrary;

namespace Poker.Migrations
{
    [DbContext(typeof(PokerContext))]
    [Migration("20220601161733_ChangedUserInRoom")]
    partial class ChangedUserInRoom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Hebrew_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poker.DataModel.Pot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Pots");
                });

            modelBuilder.Entity("Poker.DataModel.UserInGame", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MoneyInTable")
                        .HasColumnType("int");

                    b.Property<int>("MoneyInTurn")
                        .HasColumnType("int");

                    b.Property<bool>("PlayedThisTurn")
                        .HasColumnType("bit");

                    b.Property<short>("Position")
                        .HasColumnType("smallint");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("UsersInGame");
                });

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Suit")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BigBlind")
                        .HasColumnType("int");

                    b.Property<short>("DealerPosition")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Pot")
                        .HasColumnType("int");

                    b.Property<int>("Stage")
                        .HasColumnType("int");

                    b.Property<short>("TalkingPosition")
                        .HasColumnType("smallint");

                    b.Property<int>("TurnStake")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PokerClassLibrary.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.Property<int>("Money")
                        .HasColumnType("int")
                        .HasColumnName("userMoney");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Poker.DataModel.Pot", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Pots")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poker.DataModel.UserInGame", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokerClassLibrary.User", "User")
                        .WithOne("UserInGame")
                        .HasForeignKey("Poker.DataModel.UserInGame", "Username");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("CardsOnTable")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Poker.DataModel.UserInGame", null)
                        .WithMany("Cards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Poker.DataModel.UserInGame", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Navigation("CardsOnTable");

                    b.Navigation("Pots");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PokerClassLibrary.User", b =>
                {
                    b.Navigation("UserInGame");
                });
#pragma warning restore 612, 618
        }
    }
}