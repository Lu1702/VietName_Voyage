using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using VietNamVoyage.Models;

namespace VietNamVoyage.Controllers
{
    public class BookingsController : Controller
    {
        TravelDBEntities db = new TravelDBEntities();

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Destinations = db.Destinations.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {

            var username = Session["Username"] as string;
            var user = db.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return RedirectToAction("Login", "Account");

            db.Database.ExecuteSqlCommand(
                "INSERT INTO Bookings (IdUser, IdDestination, FullName, Phone, Email, BookingDate, DepartureDate, NumberOfPeople, TotalPrice, Trangthai, Note) " +
                "VALUES (@IdUser, @IdDestination, @FullName, @Phone, @Email, @BookingDate, @DepartureDate, @NumberOfPeople, @TotalPrice, @Trangthai, @Note)",
                new SqlParameter("@IdUser", user.IdUser),
                new SqlParameter("@IdDestination", int.Parse(form["idDestination"])),
                new SqlParameter("@FullName", form["fullName"]),
                new SqlParameter("@Phone", form["phone"]),
                new SqlParameter("@Email", form["email"]),
                new SqlParameter("@BookingDate", DateTime.Now),
                new SqlParameter("@DepartureDate", DateTime.Parse(form["departureDate"])),
                new SqlParameter("@NumberOfPeople", int.Parse(form["numberOfPeople"])),
                new SqlParameter("@TotalPrice", decimal.Parse(form["totalPrice"])),
                new SqlParameter("@Trangthai", "Pending"),
                new SqlParameter("@Note", (object)form["note"] ?? DBNull.Value));

            return RedirectToAction("Create");
        }
    }
}
