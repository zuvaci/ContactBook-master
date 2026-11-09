using ContactBook.Models;
namespace ContactBook.Interfaces
{
    public interface INoteService
    {
        List<Note> GetAllByContactId(int contactId);
        Note Create(Note note);
        Note Update(Note note);
        bool Delete(int contactId);
    }
}
