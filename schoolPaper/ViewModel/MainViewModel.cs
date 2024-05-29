using schoolPaper.Command;
using schoolPaper.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace schoolPaper.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { currentView = value; OnPropertyChanged(); }
		}

        HomeView homeView;
        TaskOneView taskOneView;
        DataView dataView;

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand OpenHomeCommand { get; }
        public RelayCommand OpenTaskOneViewCommand { get; }

        public MainViewModel()
        {
            homeView = new HomeView();
            taskOneView = new TaskOneView();
            dataView = new DataView();

            OpenHomeCommand = new RelayCommand(OpenHome);
            OpenTaskOneViewCommand = new RelayCommand(OpenTaskOneView);

            CurrentView = homeView;
        }

        private void OpenHome(object parameter)
        {
            CurrentView = homeView;
        }

        private void OpenTaskOneView(object parameter)
        {
            CurrentView = taskOneView;
        }        
        
        private void DataView(object parameter)
        {
            DataView = dataView;
        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
