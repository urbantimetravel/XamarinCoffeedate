using CoffeeDate.ViewModels;
using CoffeeDate.Models;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using System;

namespace CoffeeDate.Views
{
    public partial class MainPage : ContentPage
    {
        List<Person> PeopleSelection;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TeamViewModel();
            UpdateSelectionData(Enumerable.Empty<Person>());
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> currentSelectedItems)
        {
            // Convert ObservableCollection<object> to List<Person>
            PeopleSelection = currentSelectedItems.Cast<Person>().ToList();

            var current = ToList(currentSelectedItems);
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "No one :(" : current;
        }

        private async void CreateButton_OnClicked(object sender, EventArgs e)
        {
            PairView pairs = new PairView(new PairViewModel(PeopleSelection));
            await Navigation.PushAsync(new NavigationPage(pairs));
        }

        static string ToList(IEnumerable<object> items)
        {
            if (items == null)
            {
                return string.Empty;
            }

            return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((Person)obj).Name);
        }
    }
}
