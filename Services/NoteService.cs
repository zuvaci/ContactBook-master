using ContactBook.Entities;
using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;
        public NoteService(AppDbContext context)
        {
            _context = context;
        }
        public Models.Note Create(Models.Note note)
        {
            var entity = new Entities.Note();
            entity.Text = note.Text;
            entity.ContactId = note.ContactId;

            _context.Add(entity);
            _context.SaveChanges();

            return note;
        }

        public bool Delete(int contactId)
        {
            var entity = _context.Notes.FirstOrDefault(x => x.Id == contactId);
            if (entity != null)
            {
                _context.Notes.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Models.Note> GetAllByContactId(int contactId)
        {
            var entityList = _context.Notes.Where(n => n.ContactId == contactId).ToList();
            var modelList = new List<Models.Note>();

            foreach (var entity in entityList)
            {
                var model = new Models.Note();
                model.Id = entity.Id;
                model.Text = entity.Text;
                model.ContactId = contactId;
                modelList.Add(model);
            }
            return modelList;
        }

        public Models.Note Update(Models.Note note)
        {
            var entity = _context.Notes.FirstOrDefault(e => e.Id == note.Id);

            if (entity != null)
            {
                entity.Text = note.Text;
            }
            _context.SaveChanges();
            return note;
        }
    }
}
         
