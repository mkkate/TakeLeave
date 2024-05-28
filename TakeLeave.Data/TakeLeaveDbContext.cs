using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TakeLeave.Data.Database.ChatMessages;
using TakeLeave.Data.Database.DaysOffs;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Database.Positions;

namespace TakeLeave.Data
{
    public class TakeLeaveDbContext : IdentityDbContext<Employee, EmployeeRole, int, EmployeeUserClaim,
        EmployeeUserRole, EmployeeUserLogin, EmployeeRoleClaim, EmployeeUserToken>
    {
        public TakeLeaveDbContext(DbContextOptions<TakeLeaveDbContext> options) : base(options)
        {

        }

        public DbSet<DaysOff> DaysOffs { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees");
            });

            modelBuilder.Entity<EmployeeUserClaim>(b =>
            {
                b.ToTable("EmployeeUserClaims");
            });

            modelBuilder.Entity<EmployeeUserLogin>(b =>
            {
                b.ToTable("EmployeeUserLogins");
            });

            modelBuilder.Entity<EmployeeUserToken>(b =>
            {
                b.ToTable("EmployeeUserTokens");
            });

            modelBuilder.Entity<EmployeeRole>(b =>
            {
                b.ToTable("EmployeeRoles");
            });

            modelBuilder.Entity<EmployeeRoleClaim>(b =>
            {
                b.ToTable("EmployeeRoleClaims");
            });

            modelBuilder.Entity<EmployeeUserRole>(b =>
            {
                b.ToTable("EmployeeUserRoles");
            });


            // Employee -> LeaveRequest
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeLeaveRequests)
                .WithOne(lr => lr.RequestedByEmployee)
                .HasForeignKey(e => e.EmployeeID)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HandledLeaveRequests)
                .WithOne(lr => lr.HandledByHr)
                .HasForeignKey(lr => lr.HandledByHrID)
                .IsRequired(false);


            // LeaveRequest -> Employee
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.RequestedByEmployee)
                .WithMany(e => e.EmployeeLeaveRequests)
                .HasForeignKey(e => e.EmployeeID)
                .IsRequired();

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.HandledByHr)
                .WithMany(e => e.HandledLeaveRequests)
                .HasForeignKey(lr => lr.HandledByHrID)
                .IsRequired(false);


            // Employee -> Position
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionID)
                .IsRequired();


            // Position -> Employee
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionID)
                .IsRequired();


            // Employee -> DaysOff
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.DaysOff)
                .WithOne(d => d.Employee)
                .HasForeignKey<Employee>(e => e.DaysOffID)
                .IsRequired();


            // DaysOff -> Employee
            modelBuilder.Entity<DaysOff>()
                .HasOne(d => d.Employee)
                .WithOne(e => e.DaysOff)
                .HasForeignKey<Employee>(e => e.DaysOffID)
                .IsRequired();


            // Employee -> ChatMessage
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SentMessages)
                .WithOne(cm => cm.Sender)
                .HasForeignKey(cm => cm.SenderId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ReceivedMessages)
                .WithOne(cm => cm.Receiver)
                .HasForeignKey(cm => cm.ReceiverId)
                .IsRequired();


            // ChatMessage -> Employee
            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.Sender)
                .WithMany(e => e.SentMessages)
                .HasForeignKey(cm => cm.SenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.Receiver)
                .WithMany(e => e.ReceivedMessages)
                .HasForeignKey(cm => cm.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
