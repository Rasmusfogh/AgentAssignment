using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using AgentAssignmentNetCore;
using System.Windows.Input;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace GUI7
{

    public class MainWindowViewModel : BindableBase
    {
        ObservableCollection<Agent> AgentList = new ObservableCollection<Agent>();
        int _currentIndex = 0;
        Agent _currentAgent = null;

        public Agent CurrentAgent
        {
            get => _currentAgent;
            set => SetProperty(ref _currentAgent, value);
        }

        public MainWindowViewModel()
        {
            AgentList.Add(new Agent("007", "Rasmus", "Rogue", "Steal yo mama"));
            AgentList.Add(new Agent("008", "Benjamin", "Mage", "Boom"));
        }
        public ObservableCollection<Agent> AgentList_
        {
            get => AgentList;
            set => SetProperty(ref AgentList, value);
        }

        public int CurrentIndex
        {
            get => _currentIndex;
            set => SetProperty(ref _currentIndex, value);
        }

        ICommand _nextAgent;
        public ICommand NextAgent => _nextAgent ?? (_nextAgent = new DelegateCommand(
                            () => ++CurrentIndex,
                            () => CurrentIndex < (AgentList.Count - 1)).ObservesProperty(() => CurrentIndex));

        ICommand _previousAgent;
        public ICommand PreviousAgent => _previousAgent ?? (_previousAgent = new DelegateCommand(
                            () => CurrentIndex = (CurrentIndex > 0 ? --CurrentIndex : CurrentIndex),
                            () => CurrentIndex > 0).ObservesProperty(() => CurrentIndex));

        ICommand _newAgent;
        public ICommand NewAgent
        {
            get
            {
                return _newAgent ?? (_newAgent = new DelegateCommand(() =>
                {
                    AgentList.Add(new Agent("000", "Code name", "What are ypu good at?", "Assign me"));
                    CurrentIndex = AgentList.Count - 1;
                }));
            }
        }

        ICommand _deleteAgent;
        public ICommand DeleteAgent
        {
            get
            {
                return _deleteAgent ?? (_deleteAgent = new DelegateCommand(() =>
                {
                    AgentList.RemoveAt(CurrentIndex);
                    CurrentIndex = AgentList.Count - 1;
                }));
            }
        }

        ICommand _exitApplication;
        public ICommand ExitApplication
        {
            get
            {
                return _exitApplication ?? (_exitApplication = new DelegateCommand(() =>
                {
                    System.Windows.Application.Current.Shutdown();
                }));
            }
        }

        ICommand _saveAs;
        public ICommand SaveAs
        {
            get 
            {
                return _saveAs ?? (_saveAs = new DelegateCommand(() =>
                {
                    //executeSaveAs();
                }));
            }
        }

        //public void executeSaveAs()
        //{
        //    Stream stream = File.OpenWrite(".xml");
        //    XmlSerializer sr = new XmlSerializer(typeof(ObservableCollection<Agent>));
        //    sr.Serialize(stream, AgentList_);
        //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //    saveFileDialog1.Filter = "*.xml";
        //    saveFileDialog1.Title = "Save an Image File";
        //    saveFileDialog1.ShowDialog();

        //    stream.Close();
        //}

        ICommand _open;
        public ICommand Open
        {
            get
            {
                return _open ?? (_open = new DelegateCommand(() =>
                {

                }));
            }
        }
        ICommand _save;
        public ICommand Save
        {
            get
            {
                return _save ?? (_save = new DelegateCommand(() =>
                {

                }));
            }
        }




    }
}

