﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        private bool _isLoaded = false;
        private ObservableCollection<NoteViewModel> _notes = new ObservableCollection<NoteViewModel>();

        public override async void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            if (!_isLoaded)
            {
                _isLoaded = true;
                IsBusy = true;
                await Task.Delay(150);
                for (int i = 0; i < 10; i++)
                {
                    Notes.Add(new NoteViewModel("note " + i, "note description " + i));
                    await Task.Delay(20);
                }
                IsBusy = false;
            }
        }

        public ObservableCollection<NoteViewModel> Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }
    }
}