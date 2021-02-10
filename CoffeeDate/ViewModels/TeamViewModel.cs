using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CoffeeDate.Models;
using Xamarin.Forms;

namespace CoffeeDate.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        readonly IList<Person> source;
        Person selectedPerson;
        int selectionCount = 1;

        public ObservableCollection<Person> Team { get; private set; } = new ObservableCollection<Person>();


        public IList<Person> EmptyTeam { get; private set; }

        public Person SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                if (selectedPerson != value)
                {
                    selectedPerson = value;
                }
            }
        }

        ObservableCollection<object> selectedPersons;
        public ObservableCollection<object> SelectedPersons
        {
            get
            {
                return selectedPersons;
            }
            set
            {
                if (selectedPersons != value)
                {
                    selectedPersons = value;
                }
            }
        }

        public string SelectedPersonMessage { get; private set; }

        public ICommand DeleteCommand => new Command<Person>(RemovePerson);
        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand PersonSelectionChangedCommand => new Command(PersonSelectionChanged);

        public TeamViewModel()
        {
            source = new List<Person>();
            AddUTT();

        }

        void AddUTT()
        {
            source.Add(new Person
            {
                Name = "Laura",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Creating_Nikrouz_Cat_Race_%286%29.jpg"
            });

            source.Add(new Person
            {
                Name = "Alex",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/June_odd-eyed-cat_cropped.jpg/1424px-June_odd-eyed-cat_cropped.jpg"
            });

            source.Add(new Person
            {
                Name = "Rui",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/d/db/White_Cat_in_need_of_Wikilove.jpg"
            });

            source.Add(new Person
            {
                Name = "Natasa",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/1/15/Black_cat_%281%29.jpg"
            });

            source.Add(new Person
            {
                Name = "Marc",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Tired_20-year-old_cat.jpg/1594px-Tired_20-year-old_cat.jpg"
            });

            source.Add(new Person
            {
                Name = "Kevin",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ed/Surprised_Cat.jpg/900px-Surprised_Cat.jpg"
            });

            source.Add(new Person
            {
                Name = "Jil",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Cat_in_home.jpg/1600px-Cat_in_home.jpg"
            });

            source.Add(new Person
            {
                Name = "Sarah",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/23/Creating_Nikrouz_Cat_Race_%2810%29.jpg/970px-Creating_Nikrouz_Cat_Race_%2810%29.jpg"
            });

            source.Add(new Person
            {
                Name = "Johannes",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/f/f0/Black_Sphynx_cat_in_sweater.jpg"
            });

            source.Add(new Person
            {
                Name = "Micha",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Cat_of_Yokohama%2C_Kanagawa_Prefecture%3B_December_2019_%2801%29.jpg/1599px-Cat_of_Yokohama%2C_Kanagawa_Prefecture%3B_December_2019_%2801%29.jpg"
            });

            source.Add(new Person
            {
                Name = "Sven",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Cool_Cat_Headshot.jpg/1164px-Cool_Cat_Headshot.jpg"
            });

            source.Add(new Person
            {
                Name = "Jürgen",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Cool_Cat_Headshot.jpg/1164px-Cool_Cat_Headshot.jpg"
            });

            source.Add(new Person
            {
                Name = "Lukas",
                IsAvailable = true,
                ImageIcon = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Cool_Cat_Headshot.jpg/1164px-Cool_Cat_Headshot.jpg"
            });


            // sort member list alphabetically
            List<Person> sortedSource = source.OrderBy(o => o.Name).ToList();
            Team = new ObservableCollection<Person>(sortedSource);
        }

        void FilterItems(string filter)
        {
            var filteredItems = source.Where(person => person.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var person in source)
            {
                if (!filteredItems.Contains(person))
                {
                    Team.Remove(person);
                }
                else
                {
                    if (!Team.Contains(person))
                    {
                        Team.Add(person);
                    }
                }
            }
        }

        void PersonSelectionChanged()
        {
            SelectedPersonMessage = $"Selection {selectionCount}: {SelectedPerson.Name}";
            OnPropertyChanged("SelectedPersonMessage");
            selectionCount++;
        }

        void RemovePerson(Person person)
        {
            if (Team.Contains(person))
            {
                Team.Remove(person);
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
