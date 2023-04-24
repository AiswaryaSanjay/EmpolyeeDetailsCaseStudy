using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using EmpolyeeDetailsCaseStudy.Models;
using EmpolyeeDetailsCaseStudy.Commands;
using System.Collections.ObjectModel;

namespace EmpolyeeDetailsCaseStudy.ViewModels
{
    #region INotifyPropertyChanged
    public class EmpolyeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region DisplayOperation

        EmpolyeeService ObjEmpolyeeService;
        public EmpolyeeViewModel()
        {
            ObjEmpolyeeService = new EmpolyeeService();
            LoadData();
            currentEmpolyee = new Empolyee();
            //saveCommand = new RelayCommand(Save);
            //searchCommand = new RelayCommand(Search);
            //updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private ObservableCollection<Empolyee> empolyeesList;
        public ObservableCollection<Empolyee> EmpolyeesList
        {
            get { return empolyeesList; }
            set { empolyeesList = value; OnPropertyChanged("EmpolyeesList"); }
        }
        public async void LoadData()
        {
            EmpolyeesList =await ObjEmpolyeeService.GetAll();
        }
        #endregion
        private Empolyee currentEmpolyee;
        public Empolyee CurrentEmpolyee
        {
            get { return currentEmpolyee; }
            set { currentEmpolyee = value; OnPropertyChanged("CurrentEmpolyee"); }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

            #region SaveOperation
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
             
        }
        //public void Save()
        //{
        //    try
        //    {
        //        var IsSaved = ObjEmpolyeeService.Add(currentEmpolyee);
        //        LoadData();
        //        if (IsSaved)
        //            Message = "Empolyee Saved";
        //        else
        //            Message = "Save Operation failed";
        //    }
        //    catch(Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        //#endregion
        //#region SearchOperation
        //private RelayCommand searchCommand;
        //public RelayCommand SearchCommand
        //{
        //    get { return searchCommand; }
        //    set { searchCommand = value; }

        //}
        //public void Search()
        //{
        //    try
        //    {
        //        var ObjEmpolyee = ObjEmpolyeeService.Search(CurrentEmpolyee.Id);
        //        if(ObjEmpolyee!=null)
        //        {

        //            CurrentEmpolyee.Name = ObjEmpolyee.Name;
        //            CurrentEmpolyee.Email = ObjEmpolyee.Email;
        //        }
        //        else
        //        {
        //            Message = "Empolyee Not Found";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        //#endregion

        //#region UpdateOperation
        //private RelayCommand updateCommand;
        //public RelayCommand UpdateCommand
        //{
        //    get { return updateCommand; }
        //}
        //public void Update()
        //{
        //    try
        //    {
        //        var IsUpdated = ObjEmpolyeeService.Update(CurrentEmpolyee);
        //        if(IsUpdated)
        //        {
        //            Message = "Empolyee Updated";
        //            LoadData();
        //        }
        //        else
        //        {
        //            Message = "Update Fail";
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        #endregion
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var Deleted = ObjEmpolyeeService.ClientDeleteRequest(CurrentEmpolyee.id);
                if (Deleted!=null)
                {
                    Message = "Empolyee Deleted";
                    LoadData();
                }
                else
                {
                    Message = "Employee not Deleted";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}