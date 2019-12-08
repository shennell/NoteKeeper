using NoteKeeper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeper.Services
{
    public interface IDataStore
    {
        Task<String> AddNoteAsync(Note courseNote);
        Task<bool> UpdateNoteAsync(Note courseNote);
        Task<Note> GetNoteAsync(String id);
        Task<IList<Note>> GetNotesAsync();
        Task<IList<String>> GetCoursesAsync();
    }
}
