using CourseManagement.Core;
using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManagement.ViewModels
{
    public class AddCourseViewModel : BaseViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Instructor> Instructors { get; set; }
        public Instructor Instructor { get; set; }
        public List<CourseCategory> Categories { get; set; }
        public CourseCategory PrimaryCategory { get; set; }
        public CourseCategory SecondaryCategory { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }

        private AppDbContext _appDbContext;

        public AddCourseViewModel(AppDbContext context, Action closeCallback)
        {
            _appDbContext = context;
            Instructors = _appDbContext.Instructors.ToList();
            Categories = _appDbContext.CourseCategories.ToList();
            CancelCommand = new RelayCommand((o) =>
            {
                if (o is Window wd) wd.Close();
            }, (o) => o != null);
            SubmitCommand = new RelayCommand((o) =>
            {
                var categories = new List<CourseCategory>();
                if (PrimaryCategory != null) categories.Add(PrimaryCategory);
                if (SecondaryCategory != null) categories.Add(SecondaryCategory);
                var course = new Course
                {
                    Title = Title,
                    Description = Description,
                    InstructorId = Instructor.InstructorId,
                    Categories = categories
                };
                _appDbContext.Add(course);
                _appDbContext.SaveChanges();
                if (o is Window wd)
                {
                    closeCallback?.Invoke(); 
                    wd.Close();
                }
            }, (o) => o != null && !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description) && Instructor != null &&
            PrimaryCategory != SecondaryCategory);
        }
    }
}
