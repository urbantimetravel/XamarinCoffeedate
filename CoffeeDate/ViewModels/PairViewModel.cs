using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CoffeeDate.Models;
using CoffeeDate.Helpers;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace CoffeeDate.ViewModels
{
    public class PairViewModel : INotifyPropertyChanged
    {
        public List<Person> Pool { get; private set; }
        public ObservableCollection<Pair> Pairs { get; private set; } = new ObservableCollection<Pair>();

        public PairViewModel(List<Person> pool)
        {
            Pool = pool;
            GeneratePairs();
        }

        public void GeneratePairs()
        {
            // Use Helper Class to randomize Array
            Randomizer.Randomize(Pool);
            Pairs.Clear();

            // Divide the names into groups.
            for(int i = 0; i < Pool.Count; i+=2)
            {
                Pair newpair;

                try
                {
                    newpair = new Pair(){ FirstPerson = Pool[i], SecondPerson = Pool[i + 1] };
                }
                catch(ArgumentOutOfRangeException e)
                {
                    newpair = new Pair(){ FirstPerson = Pool[i], SecondPerson = null };
                }
                Pairs.Add(newpair);
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
