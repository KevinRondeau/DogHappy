
using DogFetchApp.Commands;
using DogFetchApp.Helper;
using DogFetchApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        private string selectedBreed;
        private int selectedAmount;
        private string currentBreed;
        private int currentAmount;
        private ObservableCollection<string> breeds;
        private ObservableCollection<string> images; 
        public List<int> Quantities { get; set; } = new List<int> { 1, 3, 5, 10 };

        public AsyncCommand<object> FetchImageCommand { get; private set; }
        public AsyncCommand<object> NextImageCommand { get; private set; }
        public DelegateCommand<object> restartCommand { get; private set; }
        public DelegateCommand<object> changeLanguageEnCommand { get; private set; }
        public DelegateCommand<object> changeLanguageFrCommand { get; private set; }
        public string SelectedBreed
        {
            get => selectedBreed;
            set
            {
                selectedBreed = value;
                OnPropertyChanged();
            }
        }
        public int SelectedAmount
        {
            get => selectedAmount;
            set
            {   
                selectedAmount = value;
                OnPropertyChanged();
            }
        }

        public string CurrentBreed
        {
            get => currentBreed;
            set
            {
                currentBreed = value;
                OnPropertyChanged();
            }
        }
        public int CurrentAmount
        {
            get => currentAmount;
            set
            {
                currentAmount = value;
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

        public ObservableCollection<string> Images
        {
            get => images;
            set
            {
                images = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Breeds = new ObservableCollection<string>();
            Images=new ObservableCollection<string>();
            FetchImageCommand = new AsyncCommand<object>(FetchImageAsync);
            NextImageCommand = new AsyncCommand<object>(NextImageAsync);
            restartCommand = new DelegateCommand<object>(Restart, CanRestart);
            changeLanguageEnCommand = new DelegateCommand<object>(changeLanguageEn, CanChangeLanguage);
            changeLanguageFrCommand = new DelegateCommand<object>(changeLanguageFr, CanChangeLanguage);
        }

        public async Task LoadBreedList()
        {
            Breeds = await DogApiProcessor.LoadBreedList();

        }

        private async Task FetchImageAsync(object arg)
        {
            CurrentBreed = SelectedBreed;
            currentAmount = SelectedAmount;
            int i = 0;
            Images.Clear();
            while (i < SelectedAmount)
            {
                DogModel dogImage = await DogApiProcessor.GetImageUrl(SelectedBreed);
                Images.Add(dogImage.DogPicture);
                i++;
            }

        }

        private async Task NextImageAsync(object arg)
        {
            int i = 0;
            Images.Clear();
            while (i < CurrentAmount)
            {
                DogModel dogImage = await DogApiProcessor.GetImageUrl(CurrentBreed);
                Images.Add(dogImage.DogPicture);
                i++;
            }

        }

        public void Restart(object arg)
        {

            var filename = Application.ResourceAssembly.Location;
            var newFile = Path.ChangeExtension(filename, ".exe");
            Process.Start(newFile);
            Application.Current.Shutdown();
        }
        private bool CanRestart(object arg) => true;

        private void changeLanguageEn(object arg)
        {
            string param = Properties.Settings.Default.Language;
            if (param == "en")
            {
                MessageBoxResult messageErrorBoxResult = System.Windows.MessageBox.Show("Already in english");
            }
            else
            {


                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Changer le language pour l'anglais?","Language", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                        Properties.Settings.Default.Language = "en";
                  
                        Properties.Settings.Default.Save();
                        Restart(arg);
                }
            }
        }
        private void changeLanguageFr(object arg)
        {
            string param = Properties.Settings.Default.Language;
            if (param == "fr")
            {
                MessageBoxResult messageErrorBoxResult = System.Windows.MessageBox.Show("Deja en francais!");
            }
            else
            {


                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Change language to french?", "Language", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Properties.Settings.Default.Language = "fr";

                    Properties.Settings.Default.Save();
                    Restart(arg);
                }
            }
        }
        private bool CanChangeLanguage(object arg) => true;
    }
    
}
