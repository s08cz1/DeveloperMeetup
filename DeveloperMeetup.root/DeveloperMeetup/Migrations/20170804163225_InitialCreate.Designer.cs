using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DeveloperMeetup.Data;
using DeveloperMeetup.Code.Labels.Enums;

namespace DeveloperMeetup.Migrations
{
    [DbContext(typeof(DeveloperMeetupContext))]
    [Migration("20170804163225_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("AmountPaid");

                    b.Property<DateTime>("DateBookedUtc");

                    b.Property<DateTime?>("DeletedUtc");

                    b.Property<string>("EmailAddress");

                    b.Property<Guid>("EventId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DeletedUtc");

                    b.Property<DateTime>("EndDateTimeUtc");

                    b.Property<decimal?>("FeePerSeat");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDateTimeUtc");

                    b.Property<Guid>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookedFor");

                    b.Property<Guid?>("BookingId");

                    b.Property<string>("Col");

                    b.Property<DateTime?>("DeletedUtc");

                    b.Property<Guid>("EventId");

                    b.Property<string>("Row");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("EventId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("ColLabelType");

                    b.Property<int>("Cols");

                    b.Property<DateTime?>("DeletedUtc");

                    b.Property<int>("RowLabelType");

                    b.Property<int>("Rows");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Booking", b =>
                {
                    b.HasOne("DeveloperMeetup.Data.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Event", b =>
                {
                    b.HasOne("DeveloperMeetup.Data.Entities.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeveloperMeetup.Data.Entities.Seat", b =>
                {
                    b.HasOne("DeveloperMeetup.Data.Entities.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingId");

                    b.HasOne("DeveloperMeetup.Data.Entities.Event", "Event")
                        .WithMany("Seats")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
