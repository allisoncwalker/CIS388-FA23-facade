using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string secretColor;

        [ObservableProperty]
        private string currentGuess;

        [ObservableProperty]
        private bool didWin;

        public ObservableCollection<ColorGuess> Guesses { get; set; }

        //public string SecretColor { get; set; }

        public MainPageViewModel()
        {
            secretColor = "FACADE";
            currentGuess = "";

            Guesses = new ObservableCollection<ColorGuess>();

            Guesses.Add(new ColorGuess("#beaded"));
            Guesses.Add(new ColorGuess("#efaced"));

        }

        [RelayCommand]
        void AddLetter(string letter)
        {
            if (CurrentGuess.Length < 6)
            {
                CurrentGuess += letter;
                //Console.WriteLine("adding letter");
            }
        }

        [RelayCommand]
        void DeleteLetter()
        {
            if (CurrentGuess.Length > 0)
            {
                CurrentGuess = CurrentGuess.Remove(CurrentGuess.Length - 1);
            }
        }

        [RelayCommand]
        async void Guess()
        {
            if (CurrentGuess.Length == 6) // only if there's enough letters in the guess
            {
                if (CurrentGuess == SecretColor)
                {
                    // go to game over page,
                    DidWin = true;
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={true}");
                    ClearData();
                }
                else if (Guesses.Count == 5)
                {
                    // go to game over page, DidWin = false
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={false}");
                    ClearData();
                }
                else
                {
                    // add CurrentGuess to Guesses
                    Guesses.Add(new ColorGuess(CurrentGuess.ToLower()));
                    CurrentGuess = "";
                }
            }

        }

        [RelayCommand]
        void Clear()
        {
            CurrentGuess = "";
        }

        void ClearData()
        {
            CurrentGuess = "";
            Guesses.Clear();
        }



    }
}