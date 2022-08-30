using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirlineApp.Repository.Model
{
    public partial class airlinedbContext : DbContext
    {

        public airlinedbContext(DbContextOptions<airlinedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AncillaryService> AncillaryServices { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<PassengerMeal> PassengerMeals { get; set; }
        public virtual DbSet<PassengerService> PassengerServices { get; set; }
        public virtual DbSet<PassengerShopRequest> PassengerShopRequests { get; set; }
        public virtual DbSet<PassengerStatus> PassengerStatuses { get; set; }
        public virtual DbSet<PassportDetail> PassportDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShopRequest> ShopRequests { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AncillaryService>(entity =>
            {
                entity.Property(e => e.AncillaryServiceId).HasColumnName("ancillaryServiceId");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("serviceName");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).HasColumnName("flightId");

                entity.Property(e => e.FlightName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("flightName");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.Property(e => e.MealId).HasColumnName("mealId");

                entity.Property(e => e.MealTancillaryservicesancillaryservicesype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("mealTancillaryservicesancillaryservicesype");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passenger");

                entity.HasIndex(e => e.FlightId, "FK_FlightPassenger");

                entity.HasIndex(e => e.PassportDetailsId, "FK_PassportDetailsPassenger");

                entity.HasIndex(e => e.StatusId, "FK_StatusPassenger");

                entity.HasIndex(e => e.UserId, "FK_UsersPassenger");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.FlightDateTime).HasColumnName("flightDateTime");

                entity.Property(e => e.FlightId).HasColumnName("flightId");

                entity.Property(e => e.PassengerName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("passengerName");

                entity.Property(e => e.PassportDetailsId).HasColumnName("passportDetailsId");

                entity.Property(e => e.SeatNumber).HasColumnName("seatNumber");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlightPassenger");

                entity.HasOne(d => d.PassportDetails)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.PassportDetailsId)
                    .HasConstraintName("FK_PassportDetailsPassenger");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StatusPassenger");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersPassenger");
            });

            modelBuilder.Entity<PassengerMeal>(entity =>
            {
                entity.HasIndex(e => e.PassengerId, "FK_PassengerpassengerId");

                entity.HasIndex(e => new { e.MealId, e.PassengerId }, "uq_PassengerMeals")
                    .IsUnique();

                entity.Property(e => e.PassengerMealId).HasColumnName("passengerMealId");

                entity.Property(e => e.MealId).HasColumnName("mealId");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.PassengerMeals)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MealPassenger");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.PassengerMeals)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PassengerpassengerId");
            });

            modelBuilder.Entity<PassengerService>(entity =>
            {
                entity.HasIndex(e => e.PassengerId, "FK_Passenger");

                entity.HasIndex(e => new { e.AncillaryServiceId, e.PassengerId }, "uq_PassengerServices")
                    .IsUnique();

                entity.Property(e => e.PassengerServiceId).HasColumnName("passengerServiceId");

                entity.Property(e => e.AncillaryServiceId).HasColumnName("ancillaryServiceId");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.HasOne(d => d.AncillaryService)
                    .WithMany(p => p.PassengerServices)
                    .HasForeignKey(d => d.AncillaryServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesPassenger");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.PassengerServices)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passenger");
            });

            modelBuilder.Entity<PassengerShopRequest>(entity =>
            {
                entity.HasKey(e => e.PassengerRequestId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.PassengerId, "FK_PassengerShopRequests");

                entity.HasIndex(e => new { e.ShopRequestId, e.PassengerId }, "uq_PassengerShop")
                    .IsUnique();

                entity.Property(e => e.PassengerRequestId).HasColumnName("passengerRequestId");

                entity.Property(e => e.PassengerId).HasColumnName("passengerId");

                entity.Property(e => e.ShopRequestId).HasColumnName("shopRequestId");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.PassengerShopRequests)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PassengerShopRequests");

                entity.HasOne(d => d.ShopRequest)
                    .WithMany(p => p.PassengerShopRequests)
                    .HasForeignKey(d => d.ShopRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopPassenger");
            });

            modelBuilder.Entity<PassengerStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PRIMARY");

                entity.ToTable("PassengerStatus");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.CheckedIn)
                    .HasColumnType("bit(1)")
                    .HasColumnName("checkedIn");

                entity.Property(e => e.PassengerWithInfants)
                    .HasColumnType("bit(1)")
                    .HasColumnName("passengerWithInfants");

                entity.Property(e => e.RequiringWheelChair)
                    .HasColumnType("bit(1)")
                    .HasColumnName("requiringWheelChair");
            });

            modelBuilder.Entity<PassportDetail>(entity =>
            {
                entity.HasKey(e => e.PassportDetailsId)
                    .HasName("PRIMARY");

                entity.Property(e => e.PassportDetailsId).HasColumnName("passportDetailsId");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.DateOfExpiry)
                    .HasColumnType("date")
                    .HasColumnName("dateOfExpiry");

                entity.Property(e => e.DateOfIssue)
                    .HasColumnType("date")
                    .HasColumnName("dateOfIssue");

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("passportNumber");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<ShopRequest>(entity =>
            {
                entity.Property(e => e.ShopRequestId).HasColumnName("shopRequestId");

                entity.Property(e => e.ShopRequestType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("shopRequestType");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "FK_UsersRoles");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("emailId");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("userPassword");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersRoles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
