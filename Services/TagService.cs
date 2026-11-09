using ContactBook.Entities;
using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;
        public TagService(AppDbContext context)
        {
            _context = context;
        }
        public Models.Tag Add(Models.Tag tag)
        {
            var entity = new Entities.Tag();
            entity.Name = tag.Name;
            entity.ContactTags = tag.ContactTags;

            _context.Add(entity);
            _context.SaveChanges();

            return tag;
        }

        public bool Delete(int id)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Models.Tag> GetAll()
        {
            var entityList = _context.Tags.ToList();
            var modelList = new List<Models.Tag>();

            foreach (var entity in entityList)
            {
                var model = new Models.Tag();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.ContactTags = entity.ContactTags;

                modelList.Add(model);

            }
            return modelList;
        }

        public Models.Tag GetById(int id)
        {
            var entity = _context.Tags.FirstOrDefault(e => e.Id == id);

            if (entity != null)
            {
                var model = new Models.Tag();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.ContactTags = entity.ContactTags;
                return model;
            }

            return new Models.Tag();
        }

        public Models.Tag Update(Models.Tag tag)
        {
            var entity = _context.Tags.FirstOrDefault(e => e.Id == tag.Id);

            if (entity != null)
            {
                entity.Name = tag.Name;
                entity.ContactTags = tag.ContactTags;

            }
            _context.SaveChanges();
            return tag;
        }
    }
}
