using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetPlan.Persistency;

namespace NetPlan.Viewmodel
{
    public class ViewModel
    {
        private int _selectedValue = 1;

        private List<Shifts> _shifts;
        private List<WorkhourTemplate> _works;
        private List<Users> _users;
        private Users _user;
        private WorkhourTemplate _work;
        private Shifts _shift;

        public ViewModel()
        {
            _shifts = Catalog<Shifts>.Get("api/shifts");
            _users = Catalog<Users>.Get("api/users");
            _works = Catalog<WorkhourTemplate>.Get("api/workhourtemplates");
            _shift = Catalog<Shifts>.Get("api/shifts", _selectedValue)[0];
            
            SetWork();
            SetUser();
          

        }
        public int SelectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; }
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
        public string FromTo
        {
            get {
                return string.Format("{0:hh\\:mm} - {1:hh\\:mm}", _work.Start, _work.End);
            }
        }

        public void SetUser()
        {
            _user = _users.Find(x => x.Id == _shift.Fk_users);
        }
        public void SetWork()
        {
            _work = _works.Find(x => x.Id ==_shift.Fk_workhourTemplate);
        }
    }
}
