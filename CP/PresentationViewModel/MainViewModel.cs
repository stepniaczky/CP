using System.Collections.Generic;
using System.Windows.Input;
using PresentationModel;

namespace PresentationViewModel
{
    public class MainViewModel : ViewModelBase
    {

        //public MainViewModel() : this(ModelAbstractApi.CreateApi())
        public MainViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
        }

        public MainViewModel()
        {
            //ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
            StartCommand = new RelayCommand(OnStart, CanStart);
            StopCommand = new RelayCommand(OnStop, CanStop);

        }

        // public IList<object> CirclesCollection
        // {
        //  get
        //   {
        //      return b_CirclesCollection;
        // }
        //  set
        //  {
        // if (value.Equals(b_CirclesCollection))
        //     return;
        // RaisePropertyChanged("CirclesCollection");
        // }
        // }

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

        //private IList<object> b_CirclesCollection;
        private int b_Radious;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();


        private int _ballsNumber;
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