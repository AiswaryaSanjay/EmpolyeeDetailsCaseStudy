using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace EmpolyeeDetailsCaseStudy.Models
{
    public class Empolyee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("name"); }
        }
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("email"); }
        }
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("gender"); }
        }
        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }

    }
}
