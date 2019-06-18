using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Thread13._06.ViewModels;

namespace Thread13._06.Commands
{
    public class LoadCommand : ICommand
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoadCommand(MainWindowViewModel MainWindowViewModel)
        {
            this.MainWindowViewModel = MainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindowViewModel.Dictionary = new List<string>();

            if (File.Exists("dictionary.txt"))
            {
                var arr = File.ReadAllText("dictionary.txt").Split('\n');

                for (int i = 0; i < arr.Count(); i++)
                {
                    MainWindowViewModel.Dictionary.Add(arr[i]);
                }
            }
            else
                MessageBox.Show("File not exist ");

            

        }
    }
}
