using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PresentationModel;
using System.Drawing;

namespace PresentationViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Point> b_BallsCollection;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi(); // z inicjalizacja ?
        private int b_Radius;
        private int _ballsNumber;
        private bool _isStopEnabled;

        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }


        public MainViewModel() : this(ModelAbstractApi.CreateApi())
        {
           
        }

        public MainViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            BallsCollection = new ObservableCollection<Point>((IEnumerable<Point>)ModelLayer.GetBalls());
            Radius = ModelLayer.Radius;
            BallsNumber = 1;
            IsStopEnabled = false;
            StartCommand = new RelayCommand(OnStart, CanStart);
            StopCommand = new RelayCommand(OnStop, CanStop);
        }

        public ObservableCollection<Point> BallsCollection
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

        public int Radius
        {
            get
            {
                return b_Radius;
            }
            set
            {
                if (value.Equals(b_Radius))
                    return;
                b_Radius = value;
                RaisePropertyChanged("Radious");
            }
        }

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


        private void OnStart()
        {
            ModelLayer.CreateBalls(BallsNumber);
            RaisePropertyChanged("GetBalls");
            IsStopEnabled = true;
        }

        private bool CanStart()
        {
            return IsStopEnabled == false;
        }

        private void OnStop()
        {
            ModelLayer.ClearBalls();
            RaisePropertyChanged("GetBalls");
            IsStopEnabled = false;
        }

        private bool CanStop()
        {
            return IsStopEnabled;
        }
    }
}
