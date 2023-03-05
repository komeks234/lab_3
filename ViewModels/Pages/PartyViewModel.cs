using List_of_events.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_events.ViewModels.Pages
{
    public class PartyViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> party_collection;
        public PartyViewModel(ObservableCollection<CityEvent> events)
        {
            party_collection = new ObservableCollection<CityEvent>();
            var arr = events;
            for (int i = 0; i < events.Count(); i++)
            {
                if (arr[i].Category.Contains("Вечеринка") == true || arr[i].Category.Contains("вечеринка") == true)
                {
                    if (arr[i].Description.Length > 134)
                    {
                        arr[i].Description.Remove(135);
                        arr[i].Description += "...";
                    }
                    party_collection.Add(new CityEvent
                    {
                        Header = arr[i].Header,
                        Description = arr[i].Description,
                        Image = arr[i].Image,
                        Date = arr[i].Date,
                        Category = arr[i].Category,
                        Price = arr[i].Price
                    });
                }
            }
        }
        public ObservableCollection<CityEvent> PartyCollection
        {
            get
            {
                return party_collection;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref party_collection, value);
            }
        }
    }
}
