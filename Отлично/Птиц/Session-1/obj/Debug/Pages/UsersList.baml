   M S B A M L   `   `   `  ����C  ?Session1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Session1.PagesSession1.Pages  5          Session1.Pages.UsersList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Session1.Pages     5        N� Title$  	UsersList��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��67* �6   �� 5      $��8* �6    � ColumnDefinitions 5   
   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgUserlist��5         AutoGenerateColumns .  $��0��6D   $��0��6Q      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Login+  5      $ Фамилия��6%    66   �� *
LastName+  5      $ Имя��6%    62   �� *	FirstName+  5      $ Отчество��6%    67   �� *
MiddleName+  5      $ Пароль��6%    65   �� *
Password+  5      $ 
Почта��6%    64   �� *Email+4  .System.Windows.Controls.DataGridComboBoxColumn  5      -   5        cmbPosition��$ Должность��5   >      DisplayMemberPath$
 Name��6|   	   SelectedItemBinding	 6Q   �� 
 �� Path$
 Roles�6|   5      �� 5    
   -   5        $��
Выйти��5       $��Segoe UI Historic)�6#   ���	#FF0DB108$
��Left=�6\   $��1��6x   $��Center=�6�   $��18(�6�   $
��20,8q�6�   $��10,0,0,0q�6�   $��42��6�   $��93��6�   �� 5"   
   -   5         ��Name$ btnWatchClRecords��5"   x   $��1��6   $��Segoe UI Historic)�6   ���	#FF0DB108$��18(�6V   $��Сохранить��6d   $��0,0,10,0q�6�   $��Center=�6�   $
��20,8q�6�   $��Right=�6�   $��42��6  $	��129��6  5$      5%      