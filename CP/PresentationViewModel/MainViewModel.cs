using System.Collections.ObjectModel;
using PresentationModel;
using Logic;

namespace PresentationViewModel
{
    public class MainViewModel : ViewModelBase, IObserver
    {
        private readonly ModelAbstractApi ModelLayer;
        private int _ballsNumber;
        private bool _isStopEnabled;
        private ObservableCollection<Ball> _ballsCollection;

        public RelayCommand StartCommand { get; set; }
        public RelayCommand StopCommand { get; set; }

        public MainViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }
        public MainViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi ?? ModelAbstractApi.CreateApi();
            StartCommand = new RelayCommand(OnStart, CanStart);
            StopCommand = new RelayCommand(OnStop, CanStop);
            BallsNumber = 1;
            _isStopEnabled = false;
        }

        public ObservableCollection<Ball> BallsCollection
        {
            get
            {
                return _ballsCollection;
            }

            set
            {
                _ballsCollection = value;
                RaisePropertyChanged(nameof(BallsCollection));
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


        private void OnStart()
        {
            ModelLayer.CreateBalls(BallsNumber);
            ModelLayer.AttachObserver(this);
            _isStopEnabled = true;
            StopCommand.RaiseCanExecuteChanged();
        }

        private bool CanStart()
        {
            return _isStopEnabled == false;
        }

        private void OnStop()
        {
            ModelLayer.ClearBalls();
            ModelLayer.RemoveObserver(this);
            _isStopEnabled = false;
            StartCommand.RaiseCanExecuteChanged();
        }

        private bool CanStop()
        {
            return _isStopEnabled;
        }

        public void Update(ISubject subject)
        {
            BallsCollection = new ObservableCollection<Ball>(subject.Balls);
        }
    }
}
