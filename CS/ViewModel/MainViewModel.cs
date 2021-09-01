using System.Linq;
using DevExpress.Mvvm;
using DXSample.Model;

namespace DXSample.ViewModel {
    public class MainViewModel : ViewModelBase {
        Person _SelectedPerson;

        public PersonCollection Items { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand CreateCommand { get; private set; }
        public Person SelectedItem {
            get { return _SelectedPerson; }
            set {
                if (_SelectedPerson == value) return;
                _SelectedPerson = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        public MainViewModel() {
            DeleteCommand = new DelegateCommand(DeleteCurrentPerson, () => _SelectedPerson != null);
            CreateCommand = new DelegateCommand(CreatePerson, () => true);
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
    }
}