﻿// <auto-generated />
using GitHubApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GitHubApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190425011953_MaxLengthOnDescription")]
    partial class MaxLengthOnDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GitHubApi.Models.Repo", b =>
                {
                    b.Property<int>("RepoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("Forks");

                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("Stars");

                    b.HasKey("RepoID");

                    b.ToTable("Repo");
                });
#pragma warning restore 612, 618
        }
    }
}
