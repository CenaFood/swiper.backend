﻿// <auto-generated />
using ch.cena.swiper.backend.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ch.cena.swiper.backend.data.Migrations
{
    [DbContext(typeof(SwiperContext))]
    [Migration("20171103102941_RenamingPayload")]
    partial class RenamingPayload
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Annotation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<Guid?>("AnswerID");

                    b.Property<Guid>("ChallengeID");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("AnswerID");

                    b.HasIndex("ChallengeID");

                    b.HasIndex("UserID");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Answer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChallengeTypeID");

                    b.Property<string>("Descripton");

                    b.HasKey("ID");

                    b.HasIndex("ChallengeTypeID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Challenge", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ChallengeTypeID");

                    b.Property<string>("Payload");

                    b.Property<Guid>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ChallengeTypeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.ChallengeType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ChallengeTypes");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Project", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ExpiryDate");

                    b.Property<DateTime>("IssueDate");

                    b.Property<string>("ProjectDescription");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MailAddress");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Annotation", b =>
                {
                    b.HasOne("ch.cena.swiper.backend.data.Models.Answer")
                        .WithMany("Annotations")
                        .HasForeignKey("AnswerID");

                    b.HasOne("ch.cena.swiper.backend.data.Models.Challenge", "Challenge")
                        .WithMany("Annotations")
                        .HasForeignKey("ChallengeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.cena.swiper.backend.data.Models.User", "User")
                        .WithMany("Annotations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Answer", b =>
                {
                    b.HasOne("ch.cena.swiper.backend.data.Models.ChallengeType")
                        .WithMany("Answers")
                        .HasForeignKey("ChallengeTypeID");
                });

            modelBuilder.Entity("ch.cena.swiper.backend.data.Models.Challenge", b =>
                {
                    b.HasOne("ch.cena.swiper.backend.data.Models.ChallengeType", "ChallengeType")
                        .WithMany("Challenges")
                        .HasForeignKey("ChallengeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.cena.swiper.backend.data.Models.Project", "Project")
                        .WithMany("Challenges")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
