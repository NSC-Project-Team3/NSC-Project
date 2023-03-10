using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSC_project.Data;
using NSC_project.Models;
using NSC_project.Models.NSCViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSC_project.Controllers
{
    public class MoviesController : Controller
    {
        private readonly NSC_projectContext _context;

        public MoviesController(NSC_projectContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return _context.Movie != null ?
                        View(await _context.Movie.ToListAsync()) :
                        Problem("Entity set 'NSC_projectContext.Movie'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Details/5
        //// 
        public async Task<IActionResult> Ticket(int? id, int? theaterAddressId, int? theaterId, int? auditoriumId, int? screeningId)
        {

            var viewModel = new TicketData();
            viewModel.Movies = await _context.Movie
                .Where(m => m.Id == id)
                  .Include(m => m.Screenings)
                  .Include(m => m.Screenings)
                    .ThenInclude(m => m.Theater)
                    .ThenInclude(m => m.TheaterAddress)
                  .Include(m => m.Screenings)
                    .ThenInclude(m => m.Auditorium)
                  .Include(m => m.Screenings)
                    .ThenInclude(m => m.Auditorium)
                        .ThenInclude(m => m.Seats)
                  .AsNoTracking()
                  .OrderBy(m => m.Title)
                  .ToListAsync();


            ViewData["MovieID"] = id.Value;

            if (id != null)
            {
                Movie movie = viewModel.Movies.Single();
                viewModel.Screenings = movie.Screenings;
                viewModel.TheaterAddresses = await _context.TheaterAddress.ToListAsync();
            }

            if (theaterAddressId != null)
            {
                ViewData["theaterAddressId"] = theaterAddressId.Value;
                viewModel.Theaters = viewModel.Screenings.Select(m => m.Theater).Where(t => t.TheaterAddressId == theaterAddressId).ToList();
            }

            if (theaterId != null)
            {
                ViewData["theaterId"] = theaterId.Value;
                viewModel.Auditoriums = viewModel.Screenings.Where(x => x.TheaterId == theaterId).Select(a => a.Auditorium);
                // viewModel.Auditoriums = viewModel.Theaters.Where(x => x.Id == theaterId).Single().Auditoriums;

            }

            if (auditoriumId != null)
            {
                ViewData["screeningId"] = screeningId.Value;
                var screening = await _context.Screening
               .Include(s => s.ReservedSeats)
               .Include(s => s.Auditorium)
                   .ThenInclude(s => s.Seats)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.Id == screeningId);
                PopulateAssignedCourseData(screening, auditoriumId);
            }

            return View(viewModel);
        }

        private void PopulateAssignedCourseData(Screening screening, int? auditoriumId)
        {
            var allSeats = _context.Seat.Where(s => s.AuditoriumId == auditoriumId);
            var reservedSeats = new HashSet<int>(screening.ReservedSeats.Select(r => r.SeatId));
            var viewModel = new List<SeatData>();
            foreach (var seat in allSeats)
            {
                viewModel.Add(new SeatData
                {
                    SeatID = seat.Id,
                    Number = seat.Number,
                    Assigned = reservedSeats.Contains(seat.Id)
                });
            }
            ViewData["Seats"] = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket(int selectedScreening, string[] selectedSeats)
        {
            var reservetion = new Reservetion
            {
                Status = "Yes",
                UserId = 1,
                ScreeningId = selectedScreening
            };
            if (selectedSeats != null)
            {
                reservetion.ReservedSeats = new List<ReservedSeat>();
                foreach (var seat in selectedSeats)
                {
                    var seatToAdd = new ReservedSeat { ScreeningId = reservetion.ScreeningId, SeatId = int.Parse(seat), ReservetionId = reservetion.Id };
                    reservetion.ReservedSeats.Add(seatToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(reservetion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Thanks", selectedScreening);
            }
            return View(reservetion);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Thanks(int? screeningId)
        {
            return View(screeningId);
        }


        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
