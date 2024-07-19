using CourseManagement.Containers;
using CourseManagement.Core;
using CourseManagement.Models;

namespace CourseManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private NavigationContainer _navigationContainer;
        public BaseViewModel CurrentViewModel => _navigationContainer.CurrentViewModel;

        public MainViewModel(NavigationContainer navigationContainer, AppDbContext context)
        {
            _navigationContainer = navigationContainer;
            _navigationContainer.OnCurrentViewModelChanged += OnViewModelChanged;
            _navigationContainer.CurrentViewModel = new CourseViewModel(context);
        }

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
