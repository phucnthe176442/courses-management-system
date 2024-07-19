using CourseManagement.Core;
using CourseManagement.Models;
using System.Windows.Controls;
using System.Windows;

namespace CourseManagement.ViewModels
{
    public class CourseViewModel : BaseViewModel
    {
        private AppDbContext _context;

        public RelayCommand SearchCommand { get; set; }

        public RelayCommand RefreshCommand { get; set; }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand EditCommand { get; set; }

        public RelayCommand RelayCommand { get; set; }

        public List<Course> Courses => _context.Courses.ToList();

        public List<CourseCategory> Categories => _context.CourseCategories.ToList();

        public List<Instructor> Instructors => _context.Instructors.ToList();

        public Course Selected { get; set; }

        public CourseViewModel(AppDbContext context) => _context = context;

        private void on_click_category(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //var category = category_cb.SelectedItem as CourseCategory;
                //if (category == null) return;
                //var courses = _context.Courses.Include(c => c.Categories).ThenInclude(cc => cc.Courses).ToList();
                //list_view.ItemsSource = courses.Where(c => c.Categories.Any(cg => cg.CategoryId == category.CategoryId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }


        private void on_click_search(object sender, RoutedEventArgs e)
        {
            try
            {
                //var searchString = search_tbx.Text;
                //if (_context == null) return;
                //if (string.IsNullOrEmpty(searchString))
                //{
                //    return;
                //}
                //list_view.ItemsSource = _context.Courses.Include(c => c.Categories).Include(c => c.Instructor)
                //.Where(c => (c.Title != null && c.Title.Contains(searchString)) ||
                //(c.Description != null && c.Description.Contains(searchString)) ||
                //(c.Instructor != null && c.Instructor.Name.Contains(searchString))).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void on_click_refresh(object sender, RoutedEventArgs e)
        {
            try
            {
                Selected = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
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

        private void on_click_edit(object sender, RoutedEventArgs e)
        {
            try
            {
                //var id = course_id_tb.Text;
                //if (id.IsNullOrEmpty()) throw new Exception("Choose a course to edit.");
                //var course = _context.Courses.Include(c => c.Categories).FirstOrDefault(c => c.CourseId == int.Parse(id));
                //if (course == null) return;
                //course.Title = course_title_tbx.Text;
                //course.Description = course_desc_tbx.Text;
                //course.Instructor = instructor_cb.SelectedItem as Instructor;
                //course.InstructorId = course.Instructor.InstructorId;
                //_context.Entry(course).State = EntityState.Modified;
                //_context.SaveChanges();
                //list_view.ItemsSource = _context.Courses.Include(c => c.Categories).ToList();
                //MessageBox.Show("Edited course success.", "Edit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void on_click_delete(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Selected == null) throw new Exception("Choose a course to delete.");
                _context.Courses.Remove(Selected);
                _context.SaveChanges();
                MessageBox.Show("Deleted course success.", "Delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
    }
}
