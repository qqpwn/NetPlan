using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NetPlan.Persistency;
using NetPlan.Viewmodel;
using System.Windows.Input;
using NetPlan.Common;


namespace NetPlan.Viewmodel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public static int selectedValue;

        private Catalog<Shifts> _shifts;
        private Catalog<WorkhourTemplate> _works;
        private Catalog<Users> _users;

        private Users _user;
        private WorkhourTemplate _work;
        private Shifts _shift;


        public ViewModel()
        {
           
            _shifts = Catalog<Shifts>.Instance;
            _shifts.Cataloglist = Catalog<Shifts>.Get("api/shifts");
            _users = Catalog<Users>.Instance;
            _users.Cataloglist = Catalog<Users>.Get("api/users");
            _works = Catalog<WorkhourTemplate>.Instance;
            _works.Cataloglist = Catalog<WorkhourTemplate>.Get("api/workhourTemplates");

            OpretShift = new Shifts();
            
            

            _shift = Catalog<Shifts>.Get("api/shifts", SelectedValue)[0];
            OpdaterShift = _shift;
            

            SetWork();
            SetUser();
  
            CreateShiftCommand = new RelayCommand(CreateShiftAsync);
            DeleteShiftCommand = new RelayCommand(DeleteShiftAsync);
     
        }
        //Properties
        public int SelectedValue
        {
            get { return selectedValue; }
            set { selectedValue = value; }
        }

        public Shifts OpretShift
        {
            get; set;
        }

        public Shifts OpdaterShift
        {
            get; set;
        }

        public List<Users> Users
        {
            get { return _users.Cataloglist; }
        }

        public List<Shifts> Shifts
        {
            get { return _shifts.Cataloglist; }
        }

        public List<WorkhourTemplate> Works
        {
            get { return _works.Cataloglist; }
        }

        public Users User
        {
            get{ return _user; }
        }
        public Shifts Shift
        {
            get { return _shift; }
        }
        public WorkhourTemplate Work
        {
            get { return _work; }
        }

        public List<Shifts> ShiftList
        {
            get
            {
                List<Shifts> returnList = _shifts.Cataloglist;
                foreach (Shifts shift in returnList)
                {
                    shift.User = _users.Cataloglist.Find(x => x.Id == shift.Fk_users);
                    shift.Work = _works.Cataloglist.Find(x => x.Id == shift.Fk_workhourTemplate);
                }
                return returnList;
            }

        }

        public ICommand CreateShiftCommand { get; set; }
        public ICommand DeleteShiftCommand { get; set; }
        public ICommand UpdateShiftCommand { get; set; }


        //metoder
        public void SetUser()
        {
            _user = _users.Cataloglist.Find(x => x.Id == _shift.Fk_users);
        }
        public void SetWork()
        {
            _work = _works.Cataloglist.Find(x => x.Id ==_shift.Fk_workhourTemplate);
        }

        public async void CreateShiftAsync()
        {
           await Catalog<Shifts>.Post("api/shifts", OpretShift);
        }

        public async void DeleteShiftAsync()
        {
            await Catalog<Shifts>.Delete("api/shifts/"+ SelectedValue);
            OnPropertyChanged(nameof(ShiftList));
        }



        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
