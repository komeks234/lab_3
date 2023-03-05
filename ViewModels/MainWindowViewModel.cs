using List_of_events.Models;
using List_of_events.ViewModels.Pages;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace List_of_events.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> VMBCollection;
        private ObservableCollection<CityEvent> CECollection;

        public MainWindowViewModel()
        {
            CECollection = new ObservableCollection<CityEvent>();
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<CityEvent>));
            using (StreamReader rd = new StreamReader(@"..\..\..\events.xml"))
            {
                CECollection = xs.Deserialize(rd) as ObservableCollection<CityEvent>;
            }
            VMBCollection = new ObservableCollection<ViewModelBase>();
            VMBCollection.Add(new ChildViewModel(CECollection));
            VMBCollection.Add(new CultureViewModel(CECollection));
            VMBCollection.Add(new EducationViewModel(CECollection));
            VMBCollection.Add(new LifeViewModel(CECollection));
            VMBCollection.Add(new OnlineViewModel(CECollection));
            VMBCollection.Add(new PartyViewModel(CECollection));
            VMBCollection.Add(new ShowViewModel(CECollection));
            VMBCollection.Add(new SportViewModel(CECollection));
            VMBCollection.Add(new TravelViewModel(CECollection));
        }

        public object Child
        {
            get => VMBCollection[0];
        }

        public object Culture
        {
            get => VMBCollection[1];
        }

        public object Education
        {
            get => VMBCollection[2];
        }

        public object Life
        {
            get => VMBCollection[3];
        }

        public object Online
        {
            get => VMBCollection[4];
        }

        public object Party
        {
            get => VMBCollection[5];
        }

        public object Show
        {
            get => VMBCollection[6];
        }

        public object Sport
        {
            get => VMBCollection[7];
        }

        public object Travel
        {
            get => VMBCollection[8];
        }


    }

    
}