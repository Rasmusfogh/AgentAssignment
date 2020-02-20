using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AgentAssignmentNetCore
{
    public class Agent : INotifyPropertyChanged
    {
        string id;
        string codeName;
        string speciality;
        string assignment;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public Agent()
        {
        }

        public Agent(string aId, string aName, string aSpeciality, string aAssignment)
        {
            id = aId;
            codeName = aName;
            speciality = aSpeciality;
            assignment = aAssignment;
        }

        public string ID
        {
            get { return id; }
            set { id = value; Notify("ID"); }
        }

        public string CodeName
        {
            get { return codeName; }
            set { codeName = value; Notify("CodeName"); }
        }

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; Notify("Speciality"); }
        }

        public string Assignment
        {
            get { return assignment; }
            set { assignment = value; Notify("Assignment"); }
        }
    }
}
