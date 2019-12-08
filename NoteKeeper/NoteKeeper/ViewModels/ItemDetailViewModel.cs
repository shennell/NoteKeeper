using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        public bool IsNewNote { get; set; }

        public string NoteCourse
        {
            get { return Note.Course; }
            set
            {
                Note.Course = value;
                OnPropertyChanged();
            }
        }

        public string NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }
        }

        public string NoteText
        {
            get { return Note.Text; }
            set
            {
                Note.Text = value;
                OnPropertyChanged();
            }
        }


        public ItemDetailViewModel(Note note = null)
        {
            IsNewNote = note == null;

            Title = "Edit Note";
            InitializeCourseList();
            Note = note ?? new Note();
        }

        async void InitializeCourseList()
        {
            CourseList = await MockDataStore.GetCoursesAsync();
        }
    }
}
