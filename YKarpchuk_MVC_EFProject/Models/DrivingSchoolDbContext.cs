using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YKarpchuk_MVC_EFProject.Models
{

    // step 5. Create DbContext class.
    // step 6. Add dbset property for each entity
    //
    public class DrivingSchoolDbContext:DbContext
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

        

        public DrivingSchoolDbContext() : base("DrivingSchoolConnection")
        {
            // Database.SetInitializer<DrivingSchoolDbContext>(new DropCreateDatabaseIfModelChanges<DrivingSchoolDbContext>());
            Database.SetInitializer(new DrivingSchoolDbInitialiser());
        }


    }
    // Step 7. Configure the connection string.
    // Step 8. set the Database Initialisation Strategy
    public class DrivingSchoolDbInitialiser : DropCreateDatabaseAlways<DrivingSchoolDbContext>
    {

        // step 9. Seed database
        protected override void Seed(DrivingSchoolDbContext context)
        {
            base.Seed(context);

            //creating some addresses
            Address address1 = new Address()
            {
                Building_Number = 10,
                Street_Name = "Main St",
                City = "Glasgow",
                Postcode = "G9 123",
                Country = "Scotland",
                Other_Address_Details = ""
            };

            Address address2 = new Address()
            {
                Building_Number = 55,
                Street_Name = "South St",
                City = "Wishaw",
                Postcode = "ML9 123",
                Country = "Scotland",
                Other_Address_Details = ""
            };

            Address address3 = new Address()
            {
                Building_Number = 5,
                Street_Name = "Happy St",
                City = "Glasgow",
                Postcode = "G9 123",
                Country = "Scotland",
                Other_Address_Details = ""
            };

            //creating some types of method payments
            Ref_Payment_Methods payment_Method1 = new Ref_Payment_Methods()
            {
                Payment_Method_Description = "Credit Card"
            };
            Ref_Payment_Methods payment_Method2 = new Ref_Payment_Methods()
            {
                Payment_Method_Description = "Cash"
            };
            Ref_Payment_Methods payment_Method3 = new Ref_Payment_Methods()
            {
                Payment_Method_Description = "Debit Card"
            };


            //creating some lesson status

            Ref_Lesson_Status lessonstatus1 = new Ref_Lesson_Status()
            {
                Lesson_Status_Description = "Completed"
            };
            Ref_Lesson_Status lessonstatus2 = new Ref_Lesson_Status()
            {
                Lesson_Status_Description = "Cancelled"
            };
            Ref_Lesson_Status lessonstatus3 = new Ref_Lesson_Status()
            {
                Lesson_Status_Description = "Pending"
            };


            //creating some customer status
            Ref_Customer_Status customer_Status1 = new Ref_Customer_Status()
            {
                Customer_Status_Description = "Bad"
            };
            Ref_Customer_Status customer_Status2 = new Ref_Customer_Status()
            {
                Customer_Status_Description = "Ok"
            };
            Ref_Customer_Status customer_Status3 = new Ref_Customer_Status()
            {
                Customer_Status_Description = "Good"
            };


            //creating some vechicles
            Vehicle vehicle1 = new Vehicle()
            {
                Vehicle_Details = "Manual Red Toyota Hylux 2.0L"
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Vehicle_Details = "Automatic Blue Kia Sportage 1.5L"
            };

            //creating some customers
            Customer customer1 = new Customer()
            {

                First_Name = "John",
                Last_Name = "Doe",
                Date_Of_Birth = new DateTime(1970, 01, 01).Date,
                Date_Became_Customer = new DateTime(2020, 12, 19).Date,
                Email = "johndoe@gmail.com",
                Phone_Number = "0123456789",
                Cell_Mobile_Phone_Number = "07112233445",
                Other_Customer_Details = "",
                Address = address2,//navigational property
                Ref_Customer_Status = customer_Status2 //navigational property

            };

            Customer customer2 = new Customer()
            {

                First_Name = "Jack",
                Last_Name = "Black",
                Date_Of_Birth = new DateTime(2003, 02, 05).Date,
                Date_Became_Customer = new DateTime(2021, 07, 19).Date,
                Email = "jack@gmail.com",
                Phone_Number = "0123456789",
                Cell_Mobile_Phone_Number = "07112233445",
                Other_Customer_Details = "",
                Address = address3,//navigational property
                Ref_Customer_Status = customer_Status1 //navigational property

            };

            Staff staff1 = new Staff()
            {

                First_Name = "Mario",
                Middle_Name = "",
                Last_Name = "Andretti",
                Date_Of_Birth = new DateTime(1950, 03, 01).Date,
                Nickname = "SuperMario",
                Date_Joined_Staff = new DateTime(1975, 01, 05).Date,
                Date_Left_Staff = null,
                Other_Staff_Details = "",
                Address = address1//navihational property this is the office address
            };

            Staff staff2 = new Staff()
            {

                First_Name = "Luigi",
                Middle_Name = "",
                Last_Name = "Luigi",
                Date_Of_Birth = new DateTime(1979, 03, 03).Date,
                Nickname = "SuperLuigi",
                Date_Joined_Staff = new DateTime(2000, 01, 05).Date,
                Date_Left_Staff = null,
                Other_Staff_Details = "",
                Address = address1//navigational propoerty this is the office address
            };



            Lesson lesson1 = new Lesson()
            {
                Customer = customer1,//navigational property
                Staff = staff1,//navigational property
                Lesson_Date = new DateTime(2021, 05, 01).Date,
                Lesson_Time = new DateTime(2021, 05, 01, 10, 30, 00),
                Vehicle = vehicle1,//navigational property
                Price = 30,
                Ref_Lesson_Status = lessonstatus2//navigational properrty
            };
            Lesson lesson2 = new Lesson()
            {
                Customer = customer1,//navigational property
                Staff = staff1,//navigational property
                Lesson_Date = new DateTime(2021, 05, 08).Date,
                Lesson_Time = new DateTime(2021, 05, 08, 12, 00, 00),
                Vehicle = vehicle2,//navigational property
                Price = 25,
                Ref_Lesson_Status = lessonstatus3//navigational property
            };
            Lesson lesson3 = new Lesson()
            {
                Customer = customer2,//navigational property
                Staff = staff2,//navigational property
                Lesson_Date = new DateTime(2021, 05, 18).Date,
                Lesson_Time = new DateTime(2021, 05, 18, 12, 00, 00),
                Vehicle = vehicle2,//navigational property
                Price = 25,
                Ref_Lesson_Status = lessonstatus3//navigational property
            };

            //SEEDING THE LESSONS TABLE
            context.Lessons.Add(lesson1);
            context.Lessons.Add(lesson2);
            context.Lessons.Add(lesson2);
            context.SaveChanges();//SAVING THE CHANGES TO THE DATABASE  IMPORTANT


            Customer_Payment customer_Payment1 = new Customer_Payment()
            {
                Datetime_Payment = new DateTime(2021, 05, 01, 11, 00, 00),//primary key composite
                Ammount_Payment = 25.00M,
                Ref_Payment_Methods = payment_Method1,//navigational property
                Customer = customer1//primary key composite
            };
            Customer_Payment customer_Payment2 = new Customer_Payment()
            {
                Datetime_Payment = new DateTime(2021, 09, 11, 10, 05, 06),//primary key composite
                Ammount_Payment = 25.00M,
                Ref_Payment_Methods = payment_Method2,//navigational property
                Customer = customer2//primary key composite
            };

            //SEEDING THE CUSTOMER PAYMENTS TABLE
            context.Customer_Payments.Add(customer_Payment1);
            context.Customer_Payments.Add(customer_Payment2);
            context.SaveChanges();//saving the changes to the database



        }
    }


}