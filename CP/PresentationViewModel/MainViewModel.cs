using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PresentationModel;

namespace PresentationViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel() : this(MainModel.CreateApi())
        {
           
        }

        public MainViewModel(MainModel modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
            StartCommand = new RelayCommand(OnStart, CanStart);
            StopCommand = new RelayCommand(OnStop, CanStop);
        }

        public ObservableCollection<ViewModelBase> BallsCollection
        {
            get
            {
                return b_BallsCollection;
            }
            set
            {
                if (value.Equals(b_BallsCollection))
                    return;
                RaisePropertyChanged("BallsCollection");
            }
        }

        public void LoadBalls()
        {
            BallsCollection.Clear();
            for (int i = 0; i < BallsNumber; i++)
            {
                BallsCollection.Add(new ViewModelBase { FirstName = "Mark", LastName = "Allain" });
            }
        }

        public int Radious
        {
            get
            {
                return b_Radious;
            }
            set
            {
                if (value.Equals(b_Radious))
                    return;
                b_Radious = value;
                RaisePropertyChanged("Radious");
            }
        }

        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }

        private void OnStart()
        {
            IsStopEnabled = true;
            LoadBalls();
        }

        private bool CanStart()
        {
            return IsStopEnabled == false;
        }

        private void OnStop()
        {
            IsStopEnabled = false;
        }

        private bool CanStop()
        {
            return IsStopEnabled;
        }

        private ObservableCollection<ViewModelBase> b_BallsCollection = new ObservableCollection<ViewModelBase>();
        private int b_Radious;
        private MainModel ModelLayer = MainModel.CreateApi();


        private int _ballsNumber = 1;
        private bool _isStopEnabled = false;

        public bool IsStopEnabled
        {
            get 
            { 
                return _isStopEnabled; 
            }

            set
            {
                _isStopEnabled = value;
                StopCommand.RaiseCanExecuteChanged();
                StartCommand.RaiseCanExecuteChanged();

            }
        }

        public int BallsNumber
        {
            get
            {
                return _ballsNumber;
            }

            set
            {
                _ballsNumber = value;
            }
        }
    }
}
