using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YKarpchuk_MVC_EFProject.Models
{
    public class DrivingSchoolDbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ref_Customer_Status> Ref_Customer_Statuses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ref_Lesson_Status> Ref_Lesson_Statuses { get; set; }
        public DbSet<Customer_Payment> Customer_Payments { get; set; }
        public DbSet<Ref_Payment_Methods> Ref_Payment_Methods { get; set; }



        //public DrivingSchoolDbContext() : base("Task2DrivingSchoolConnection")
        //{
        //    // Database.SetInitializer<DrivingSchoolDbContext>(new DropCreateDatabaseIfModelChanges<DrivingSchoolDbContext>());
        //    Database.SetInitializer(new DrivingSchoolDbInitialiser());
        //}



    }
}