using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class NoteService
    {
        IRepository<Note> repository = new MbRepository<Note>();
           
        public void Create(Note note)
        {
            repository.Insert("InsertNote", note);
        }
         
        public Note GetTutorialsById(string noteID)
        {
            Note note = repository.GetByCondition("SelectNoteByCondition", new Note {NoteID = noteID});
            return note;
        }

        public IList<Note> GetNotes()
        {
            IList<Note> notes = repository.GetList("SelectNoteByCondition", null);
            return notes;
        }

        public IList<Note> GetNotes(int pageCount)
        {
            IList<Note> notes = repository.GetList("SelectNoteByCondition", null, pageCount);
            return notes;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectNoteCount", null);
            return count;
        }

        public void Update(Note note)
        {
            repository.Update("UpdateNote", note);
        }
        
        public void Delete(string noteID)
        {
            repository.Delete("DeleteNote", noteID);
        }
    }
}