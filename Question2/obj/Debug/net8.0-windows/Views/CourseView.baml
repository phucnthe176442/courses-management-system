   M S B A M L   `   `   `  ����K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseManagement.ViewModelsCourseManagement.ViewModels  5      ?$clr-namespace:CourseManagement.ViewsCourseManagement.Views  5      '    !CourseManagement.Views.CourseView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      2vm)clr-namespace:CourseManagement.ViewModels  5      0local$clr-namespace:CourseManagement.Views  5      .��5      � .+�5   
   �   � ColumnDefinitions  5      �� 5      $��2* �6#   60   �� 5      $��* �6#   6/   .+�5      � $��0��6   $��20 20 10 20q�5      .+�5      ��  �� Orientation$ Vertical=�6   $	��Top=�5      $��Center=�5      .+�5      #  MaterialDesignThemes.Wpf.Card  $��0 0 0 10q�6*   .��5      �� $��10q�6%   $ 
Horizontal=�5   %   $
��Left=�5   %   $��Center=�5   %   .+�5      ��  �� DisplayMemberPath$ CategoryName��5   '    �� SelectedValuePath$ 
CategoryId��5    '   $	��180��5!   '   ��5   '   �� *
Categories+ �� SelectedItem 5   '   �� *SelectedCategory+ �� UpdateSourceTrigger$ PropertyChanged=�5!   '   �� 5"      -   5        $��
search_tbx��5"   &   $	��420��5$   &   $��	20 0 20 0q�5%   &   ��5#   &   �� *SearchString+$ PropertyChanged=�5%   &   �� 5&      $��Search��6%   $��0 0 20 0q�5'   %   ��5&   6   �� *SearchCommand+5'   %   �� 5(      $��Refresh��6%   ��67   �� *RefreshCommand+5)      5*        5+      .��5,      �� .+�5-      �� -   5        $��	list_view��5-   '   $��10q�5.   '    �� SelectionMode$ Single=�51   '   ��5/   '   �� *	Courses+ 50   '   �� *
Selected+$ PropertyChanged=� �� Mode$ TwoWay=� �� View 52   "   �� 53   &   .P�54   *   �� 	 �� Width$
	 auto��69   $��CourseId��55   9   
 �� DisplayMemberBinding
 56   9   �� *
CourseId+6e   �� 57   *   $		 200��69   $��Title��58   9   
 59   9   �� *Title+6b   �� 5:   *   $		 240��69   $��Description��5;   9   
 5<   9   �� *Description+6h   �� 5=   *   $		 140��69   $��InstructorId��5>   9   
 5?   9   �� *InstructorId+6i   �� 5@   *   $		 160��69   $��InstructorName��5A   9   
 5B   9   �� *Instructor.Name+6l   5C   '   5E      5F      5G      5H      5I      � 5J      $��1��6   $��10 20 20 20q�5K      .+�5L        .��5M      �� $ Vertical=�6!   $	��Top=�5N   !   $��0 50 0 0q�5O   !   .+�5P      �� $��Course Information��6$   $��24(�6>   $��Center=�6L   �� 5Q      $ 
Horizontal=�6%   $��Center=�5R   %   .+�5S      �� $��80��6$   $��Id��5T   $   63   �� 5U      $	��300��5V   (   ��5U   (   �� *
CourseId+5V   6   5W      �� 5X      $ 
Horizontal=�6%   $��Center=�5Y   %   .+�5Z      �� $��80��6$   $��Title��5[   $   66   �� 5\      $	��300��5]   &   ��5\   &   �� *CourseTitle+$ PropertyChanged=�5]   4   5^      �� 5_      $ 
Horizontal=�6%   $��Center=�5`   %   .+�5a      �� $��80��6$   $��Description��5b   $   6<   �� 5c      $	��300��5d   &   ��5c   &   �� *CourseDescription+$ PropertyChanged=�5d   4   5e      �� 5f      $ 
Horizontal=�6%   $��Center=�5g   %   .+�5h      �� $��80��6$   $��
Instructor��5i   $   6;   �� 5j      $	��300��5k   '   $
 Name��5m   '   $ InstructorId��5n   '   ��5j   '   �� *Instructors+ 5l   '   �� *
Instructor+$ PropertyChanged=�5n   J   5o      �� 5p      .+�5q      �� $��5q�6'   ��5r   '   �� *CourseCategories+$ OneWay=� 5s   "   �� 5t   &   .P�5u   *   �� $
	 auto��69   $��
CategoryId��5v   9   
 5w   9   �� *
CategoryId+6g   �� 5x   *   $		 200��69   $��CategoryName��5y   9   
 5z   9   �� *CategoryName+6i   5{   '   5}      5~      �� 5      $��100, 15, 100, 0q�6%   $ 
Horizontal=�5�   %   $��Center=�5�   %   .+�5�      �� $	��Add��6%   $��5q�5�   %   ��5�   3   �� *
AddCommand+5�   %   �� 5�      $
��Edit��6%   $��5q�5�   %   ��5�   4   �� *EditCommand+5�   %   �� 5�      $��Delete��6%   $��5q�5�   %   ��5�   6   �� *DeleteCommand+5�   %   5�      5�      5�      5�      5�      5�      5�      