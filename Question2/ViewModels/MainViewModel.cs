using CourseManagement.Core;
using CourseManagement.Models;

namespace CourseManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; }

        public MainViewModel(AppDbContext context)
        {
            CurrentViewModel = new CourseViewModel(context);
        }
    }
}
