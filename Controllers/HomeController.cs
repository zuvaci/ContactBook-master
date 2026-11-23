using System.Diagnostics;
using ContactBook.Interfaces;
using ContactBook.Models;
using ContactBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;
        private readonly INoteService _noteService;


        public HomeController(ILogger<HomeController> logger, IContactService contactService, INoteService noteService)
        {
            _logger = logger;
            _contactService = contactService;
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }
        public IActionResult NoteDetail(int noteId, int contactId)
        {
            var notes = _noteService.GetAllByContactId(contactId);
            var note = notes.FirstOrDefault(n => n.Id == noteId);
            return View(note);
        }
        [HttpPost]
        public IActionResult NoteDetail(Note note) { 
            _noteService.Update(note);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetail(int id)
        {
            var contact = _contactService.GetById(id);
            contact.Notes = _noteService.GetAllByContactId(id);
            return View(contact);
        }

        public IActionResult NoteDelete(int Id)
        {
            _noteService.Delete(Id);
            return RedirectToAction("Index");
        }
        public IActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNote(int contactId, string text)
        {
            var note = new Note
            {
                ContactId = contactId,
                Text = text
            };
            _noteService.Create(note);
            return RedirectToAction("Index");
        }




        [HttpPost] 
        public IActionResult ContactDetail(Contact contact)
        {
            _contactService.Update(contact);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ContactDelete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
