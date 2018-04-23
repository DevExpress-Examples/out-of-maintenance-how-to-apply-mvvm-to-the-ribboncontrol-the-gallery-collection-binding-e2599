using System.Linq;
using DXSample.Model;
using System.ComponentModel;

namespace DXSample.ViewModel {
    public class MainViewModel : INotifyPropertyChanged {
        Person _SelectedPerson;

        public PersonCollection Items { get; private set; }
        public CustomCommand DeleteCommand { get; private set; }
        public CustomCommand CreateCommand { get; private set; }
        public Person SelectedItem {
            get { return _SelectedPerson; }
            set {
                if (_SelectedPerson == value) return;
                _SelectedPerson = value;
                DeleteCommand.CheckCanExecuteChanged();
                RaisePropertyChanged("SelectedItem");
            }
        }

        public MainViewModel() {
            DeleteCommand = new CustomCommand(DeleteCurrentPerson, () => _SelectedPerson != null);
            CreateCommand = new CustomCommand(CreatePerson, () => true);
            Items = PersonCollection.Generate();
        }

        void DeleteCurrentPerson() {
            DeletePerson(SelectedItem);
        }
        void DeletePerson(Person person) {
            if (person == null)
                return;
            if (Items.Last() == person) {
                Items.Remove(person);
                SelectedItem = Items.LastOrDefault();
                return;
            }
            int index = Items.IndexOf(person);
            Items.Remove(person);
            SelectedItem = Items[index];
        }
        void CreatePerson() {
            Person newPerson = new Person();
            Items.Add(newPerson);
            SelectedItem = newPerson;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name = null) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}