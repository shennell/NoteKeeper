using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NoteKeeper.Models;
using NoteKeeper.Views;

namespace NoteKeeper.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //Handle "SaveNote" message
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "SaveNote",
                async (sender, note) => {
                    Notes.Add(note);
                    await MockDataStore.AddNoteAsync(note);
            });

            //Handle "UpdateNote" message
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "UpdateNote",
                async (sender, note) => {
                    await MockDataStore.UpdateNoteAsync(note);
                    await ExecuteLoadItemsCommand();
                    });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notes.Clear();
                var notes = await MockDataStore.GetNotesAsync();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}