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
    public class ChildViewModel : ViewModelBase
    {
        private ObservableCollection<CityEvent> child_collection;
        public ChildViewModel(ObservableCollection<CityEvent> events)
        {
            child_collection = new ObservableCollection<CityEvent>();
            var arr = events;
            for(int i = 0; i < events.Count(); i++)
            {
                if(arr[i].Category.Contains("Для детей") == true || arr[i].Category.Contains("для детей") == true)
                {
                    if(arr[i].Description.Length > 134) 
                    {
                        arr[i].Description.Remove(135);
                        arr[i].Description += "...";
                    }
                    child_collection.Add(new CityEvent
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
        public ObservableCollection<CityEvent> ChildCollection
        {
            get 
            { 
                return child_collection; 
            }
            set 
            { 
                this.RaiseAndSetIfChanged(ref child_collection, value);
            }
        }
    }
}
