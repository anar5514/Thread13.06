using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thread13._06.Commands;

namespace Thread13._06.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public LoadCommand LoadCommand => new LoadCommand(this);

        public List<string> Dictionary { get; set; }

        private List<string> currentBuffer;
        public List<string> CurrentBuffer
        {
            get
            {
                return currentBuffer;
            }
            set
            {
                currentBuffer = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentBuffer)));
            }
        }



        private string currentText;
        public string CurrentText
        {
            get
            {
                return currentText;
            }
            set
            {
                currentText = value;
                word = currentText;
                if (value == string.Empty)
                    CurrentBuffer = new List<string>();
                else
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Search));                   
                }
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentText)));
            }
        }
        public string word { get; set; }
        public void Search(object a)
        {
            CurrentBuffer = new List<string>();
            CurrentBuffer = Dictionary.Where(x => x.Contains(CurrentBuffer)).ToList();
        }
    }
}
