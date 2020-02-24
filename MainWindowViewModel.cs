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
using System.Drawing;
using System.Windows.Media;

namespace GUI7
{

    public class MainWindowViewModel : BindableBase
    {
        ObservableCollection<Agent> AgentList = new ObservableCollection<Agent>();
        int _currentIndex = 0;
        string _filename = null;
        string _availableFiletypes = "xml files (*.xml)|*.xml";
        Agent _currentAgent = null;
        public MainWindowViewModel()
        {
            AgentList.Add(new Agent("007", "Rasmus", "Rogue", "Steal yo mama"));
            AgentList.Add(new Agent("008", "Benjamin", "Mage", "Boom"));
        }
        public Agent CurrentAgent
        {
            get => _currentAgent;
            set => SetProperty(ref _currentAgent, value);
        }

        public string Filename
        {
            get => _filename;
            private set => SetProperty(ref _filename, value);
        }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }


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
                    AgentList.Add(new Agent("...", "...", "...", "..."));
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
                return _saveAs ?? (_saveAs = new DelegateCommand(() => { executeSaveAs(); }));
            }
        }

        public void executeSaveAs()
        {
            XmlSerializer XML_serial = new XmlSerializer(typeof(ObservableCollection<Agent>));

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = _availableFiletypes;
            saveFileDialog1.ShowDialog();
            Filename = saveFileDialog1.FileName;

            TextWriter writer = new StreamWriter(Filename);

            XML_serial.Serialize(writer, AgentList);

            writer.Close();
        }

        ICommand _open;
        public ICommand Open
        {
            get
            {
                return _open ?? (_open = new DelegateCommand(() => { executeOpen(); }));
            }
        }

        public void executeOpen()
        {
            XmlSerializer XML_serial = new XmlSerializer(typeof(ObservableCollection<Agent>));


            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = _availableFiletypes;
            OpenFileDialog1.ShowDialog();
            Filename = OpenFileDialog1.FileName;
            FileStream fs = new FileStream(Filename, FileMode.Open);
            AgentList_ = (ObservableCollection<Agent>)XML_serial.Deserialize(fs);
            fs.Close();
        }

        ICommand _save;
        public ICommand Save
        {
            get
            {
                return _save ?? (_save = new DelegateCommand(() => { executeSave(); }));
            }
        }

        public void executeSave()
        {
            XmlSerializer XML_serial = new XmlSerializer(typeof(ObservableCollection<Agent>));
            TextWriter writer = new StreamWriter(Filename);
            XML_serial.Serialize(writer, AgentList);
            writer.Close();
        }
    }

    

    public class ListOfAgent : ObservableCollection<string>
    {
        public ListOfAgent() : base() 
        {
            Add(new string("Rogue"));
            Add(new string("Rogue"));
            Add(new string("Rogue"));
            Add(new string("Rogue"));
            Add(new string("Rogue"));
        }
    }
}

