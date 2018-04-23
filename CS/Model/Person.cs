using System.ComponentModel;

namespace DXSample.Model {
    public class Person : INotifyPropertyChanged {
        string name = "Untitled";
        string email;
        string phone;
        
        public string Name {
            get { return name; }
            set {
                if (name == value) return;
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Email {
            get { return email; }
            set {
                if (email == value) return;
                email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string Phone {
            get { return phone; }
            set {
                if (phone == value) return;
                phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public Person() { }
        public Person(string name, string email, string phone) {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}