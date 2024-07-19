using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace CourseManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppDbContext _context;

        public MainWindow(AppDbContext context)
        {
            InitializeComponent();
            _context = context;

            list_view.ItemsSource = _context.Courses.Include(c => c.Categories).ToList();
            category_cb.ItemsSource = _context.CourseCategories.ToList();
            instructor_cb.ItemsSource = _context.Instructors.ToList();
        }

        private void list_view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var course = list_view.SelectedItem as Course;
                course_id_tb.Text = course?.CourseId.ToString();
                course_title_tbx.Text = course?.Title;
                course_desc_tbx.Text = course?.Description;
                instructor_cb.SelectedItem = course?.Instructor;
                category_list_view.ItemsSource = course?.Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void on_click_category(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var category = category_cb.SelectedItem as CourseCategory;
                if (category == null) return;
                var courses = _context.Courses.Include(c => c.Categories).ThenInclude(cc => cc.Courses).ToList();
                list_view.ItemsSource = courses.Where(c => c.Categories.Any(cg => cg.CategoryId == category.CategoryId));
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
                var searchString = search_tbx.Text;
                if (_context == null) return;
                if (string.IsNullOrEmpty(searchString))
                {
                    return;
                }
                list_view.ItemsSource = _context.Courses.Include(c => c.Categories).Include(c => c.Instructor)
                .Where(c => (c.Title != null && c.Title.Contains(searchString)) ||
                (c.Description != null && c.Description.Contains(searchString)) ||
                (c.Instructor != null && c.Instructor.Name.Contains(searchString))).ToList();
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
                list_view.ItemsSource = _context.Courses.ToList();
                category_cb.SelectedItem = null;
                course_desc_tbx.Text = string.Empty;
                course_title_tbx.Text = string.Empty;
                course_id_tb.Text = string.Empty;
                instructor_cb.SelectedItem = null;
                category_list_view.ItemsSource = null;
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
                list_view.ItemsSource = _context.Courses.ToList();
                category_cb.SelectedItem = null;
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
                var id = course_id_tb.Text;
                if (id.IsNullOrEmpty()) throw new Exception("Choose a course to edit.");
                var course = _context.Courses.Include(c => c.Categories).FirstOrDefault(c => c.CourseId == int.Parse(id));
                if (course == null) return;
                course.Title = course_title_tbx.Text;
                course.Description = course_desc_tbx.Text;
                course.Instructor = instructor_cb.SelectedItem as Instructor;
                course.InstructorId = course.Instructor.InstructorId;
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
                list_view.ItemsSource = _context.Courses.Include(c => c.Categories).ToList();
                MessageBox.Show("Edited course success.", "Edit");
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
                var id = course_id_tb.Text;
                if (id.IsNullOrEmpty()) throw new Exception("Choose a course to delete.");
                var course = _context.Courses.FirstOrDefault(c => c.CourseId == int.Parse(id));
                if (course == null) return;
                _context.Courses.Remove(course);
                _context.SaveChanges();
                list_view.ItemsSource = _context.Courses.Include(c => c.Categories).ToList();
                MessageBox.Show("Deleted course success.", "Delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
    }
}