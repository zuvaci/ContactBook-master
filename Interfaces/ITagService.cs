using ContactBook.Models;
namespace ContactBook.Interfaces
{
    public interface ITagService
    {
        List<Tag> GetAll();
        Tag GetById(int id);
        Tag Add(Tag tag);
        Tag Update(Tag tag);
        bool Delete(int id);
    }
}
