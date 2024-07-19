using CourseManagement.Core;
using CourseManagement.Models;
using System.Windows.Controls;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.ViewModels
{
    public class CourseViewModel : BaseViewModel
    {
        #region Binding
        private string _courseId;
        public string CourseId
        {
            get => _courseId; set
            {
                _courseId = value;
                OnPropertyChanged(nameof(CourseId));
            }
        }

        private string _courseTitle;
        public string CourseTitle
        {
            get => _courseTitle;
            set
            {
                _courseTitle = value;
                OnPropertyChanged(nameof(CourseTitle));
            }
        }

        private string _courseDescription;
        public string CourseDescription
        {
            get => _courseDescription;
            set
            {
                _courseDescription = value;
                OnPropertyChanged(nameof(CourseDescription));
            }
        }

        private Instructor _instructor;
        public Instructor Instructor
        {
            get => _instructor;
            set
            {
                _instructor = value;
                OnPropertyChanged(nameof(Instructor));
            }
        }

        private List<CourseCategory> _categories;
        public List<CourseCategory> CourseCategories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(CourseCategories));
            }
        }
        private CourseCategory _selectedCategory;
        public CourseCategory SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                if (value == null) return;
                Courses = _context.Courses.Include(c => c.Categories).Where(c => c.Categories.Contains(value)).ToList();
            }
        }

        private List<Course> _courses;

        public List<Course> Courses
        {
            get => _courses; private set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        private string _searchString = "Search...";
        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        #endregion

        private AppDbContext _context;

        public RelayCommand SearchCommand { get; set; }

        public RelayCommand RefreshCommand { get; set; }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand EditCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public List<CourseCategory> Categories { get; }

        public List<Instructor> Instructors { get; }

        private Course _selected;

        public Course Selected
        {
            get => _selected; set
            {
                _selected = value;
                CourseId = value?.CourseId.ToString() ?? "";
                CourseTitle = value?.Title ?? "";
                CourseDescription = value?.Description ?? "";
                Instructor = value?.Instructor ?? null;
                CourseCategories = value?.Categories?.ToList() ?? null;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public CourseViewModel(AppDbContext context)
        {
            _context = context;
            Categories = _context.CourseCategories.ToList();
            Instructors = _context.Instructors.ToList();
            Courses = _context.Courses.Include(c => c.Categories).ToList();
            RefreshCommand = new RelayCommand((o) =>
            {
                Courses = _context.Courses.Include(c => c.Categories).ToList();
                Selected = null;
                SelectedCategory = null;
                SearchString = "Search...";
            }, (o) => true);
            SearchCommand = new RelayCommand((o) =>
            {
                Courses = _context.Courses.Include(c => c.Categories).Include(c => c.Instructor)
                .Where(c => (c.Title != null && c.Title.Contains(SearchString)) ||
                (c.Description != null && c.Description.Contains(SearchString)) ||
                (c.Instructor != null && c.Instructor.Name.Contains(SearchString))).ToList();
            }, (o) => !string.IsNullOrEmpty(SearchString));
            AddCommand = new RelayCommand((o) =>
            {
                MessageBox.Show($"{_courseDescription}");
            }, (o) => true);
            EditCommand = new RelayCommand((o) =>
            {
                var id = CourseId;
                var course = _context.Courses.Include(c => c.Categories).FirstOrDefault(c => c.CourseId == int.Parse(id));
                if (course == null) return;
                course.Title = CourseTitle;
                course.Description = CourseDescription;
                course.Instructor = Instructor;
                course.InstructorId = course.Instructor.InstructorId;
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
                Courses = _context.Courses.Include(c => c.Categories).ToList();
                Selected = course;
                MessageBox.Show("Edited course success.", "Edit");
            }, (o) => !string.IsNullOrEmpty(CourseId) && !string.IsNullOrEmpty(CourseTitle)
                    && !string.IsNullOrEmpty(CourseDescription) && Instructor != null);
            DeleteCommand = new RelayCommand((o) =>
            {
                var course = _context.Courses.First(c => c.CourseId == int.Parse(CourseId));
                if (course == null) return;
                var enrollments = _context.Enrollments.Where(e => e.CourseId == course.CourseId).ToArray();
                var reviews = _context.Reviews.Where(r => r.CourseId == course.CourseId).ToArray();
                _context.Reviews.RemoveRange(reviews);
                _context.Enrollments.RemoveRange(enrollments);
                _context.Courses.Remove(course);
                _context.SaveChanges();
                Courses = _context.Courses.Include(c => c.Categories).ToList();
                MessageBox.Show("Deleted course success.", "Delete");
            }, (o) => !string.IsNullOrEmpty(CourseId));
        }

        private void on_click_add(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
    }
}
