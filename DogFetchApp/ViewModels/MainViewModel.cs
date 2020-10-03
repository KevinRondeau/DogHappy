
using ApiHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        
        private string selectedBreed;
        private ObservableCollection<string> breeds;

        public string SelectedBreed
        {
            get => selectedBreed;
            set
            {
                selectedBreed = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Breeds
        {
            get => breeds;
            set
            {
                breeds = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            breeds = new ObservableCollection<string>();

        }

        public async Task LoadBreedList()
        {
            Breeds = await DogApiProcessor.LoadBreedList();
   
        }
    }
}
