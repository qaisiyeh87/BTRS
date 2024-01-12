using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTRS.Controllers
{
    public class UserController : Controller
    {
        private SystemDbContext _context;

        public UserController(SystemDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Passenger passenger)
        {
            bool empty = checkEmpty(passenger);
            bool duplicat = checkUsername(passenger.username,passenger.phone_n,passenger.email);

            if (empty)
            {
                if (duplicat)
                {
                    _context.passenger.Add(passenger);
                    _context.SaveChanges();

                    TempData["Msg"] = "the data was saved";
                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please Change the username or email or phone number";
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill all input ";
                return View();
            }



        }


        public bool checkUsername(string username,string phone_n,string email)
        {
           

            Passenger user = _context.passenger.Where(u => u.username.Equals(username)||u.email.Equals(email)||u.phone_n.Equals(phone_n)).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkEmpty(Passenger user)
        {
            if (String.IsNullOrEmpty(user.username)) return false;
            else if (String.IsNullOrEmpty(user.password)) return false;
            else if (String.IsNullOrEmpty(user.name)) return false;
            else if (String.IsNullOrEmpty(user.Gender)) return false;
            else if (String.IsNullOrEmpty(user.phone_n)) return false;
            else if (String.IsNullOrEmpty(user.email)) return false;
            else return true;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login userlogin)
        {
            if (ModelState.IsValid)
            {
                string username = userlogin.username;
                string password = userlogin.password;

                Passenger user = _context.passenger.Where(
                     u => u.username.Equals(username) &&
                     u.password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.admin.Where(
                    a => a.username.Equals(username)
                    &&
                    a.password.Equals(password)
                    ).FirstOrDefault();




                if (user != null)
                {
                    HttpContext.Session.SetInt32("userID", user.ID);

                    return RedirectToAction("Bus_Trip");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminid", admin.Id);

                    return RedirectToAction("Create", "Trip");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else
            {

            }
            return View();
        }

        public IActionResult Bus_Trip()
        {
            return View(_context.trip.ToList());
        }
        public IActionResult Book(int id)
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            Passenger_Trip passenger_Trip = new Passenger_Trip();
            passenger_Trip.passenger = _context.passenger.Find(userID);
            passenger_Trip.trip = _context.trip.Find(id);

            _context.passenger_Trips.Add(passenger_Trip);
            _context.SaveChanges();


            return RedirectToAction("Book_List");
        }
        public IActionResult Book_List()
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            List<int> lst_passenger = _context.passenger_Trips.Where(
                t => t.passenger.ID == userID).Select(s => s.trip.Id).ToList();

            List<Trip> lst_trip = _context.trip.Where(
                t => lst_passenger.Contains(t.Id)
                ).ToList();

            return View(lst_trip);
        }
        public IActionResult DeleteBook(int tripid)
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

          Passenger_Trip passenger_Trip=  _context.passenger_Trips.Where(
                t =>t.passenger.ID==userID&&t.trip.Id==tripid ).FirstOrDefault();
                ;
            _context.passenger_Trips.Remove(passenger_Trip);
            _context.SaveChanges();
            return RedirectToAction("Book_List");

        }
        
    }
}
