   M S B A M L   `   `   `  ����C  ?Session1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Session1.PagesSession1.Pages  5   	       Session1.Pages.CartWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Session1.Pages     5   	     � Title$  Корзина��5   	   $	��450��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   �� 5      �� 5      $��0.15* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��16(�6   $��Номер заказа��6"   6;   �� 5      -   5         ��Name$ lCartNumber��5      $��16(�6)   $�� ��67   6D   5      �� 5   
   -   5        $��
BusketView��5      $��1��6&   ��5      �� 5      .R�5      �  5      �� 5      $��50 �6,   �� 5      $��30 �6,   �� 5      $��40 �6,   �� 5      $��60 �6,   �� 5      $��15 �6,    � ColumnDefinitions 5      �� 5       $
��239* �6/   �� 5!      $
��auto �6/   .+�5#      �� $��0��6    $
��Left=�61   $	��194��6L   $	��Top=�6Y   $	��239��6q   $��4��6}   $��0��6�   ��5$      �� 5%   "    �� Path$ Product.Image�6*    �� TargetNullValue 5&   &   ��5'   *   *&pack://application:,,,/Images/none.jpg��6^   5)   #   5+      �� 5,      $��1��6%   $��0��65   $��5��6B   .+�5-      �� $ 
Horizontal=�6)   5.      �� 50      $ 
Horizontal=�6)   .+�51   "   �� $7��1Цена указанная в магазине: ��6,   $��26(�6O   6_   �� 52   "   $��26(�6P   ��6,   �� $ Product.Price�6`   53      �� 54      $ 
Horizontal=�6)   .+�55   "   �� $��Скидка: ��6,   $��26(�6<   6L   �� 56   "   $��26(�6S   ��6,   �� $ Product.Discount�6c   57      �� 59      $ 
Horizontal=�6)   .+�5:   "   �� $#��Кол-во в заказе: ��6,   $��20(�6E   6U   �� 5;   "   $��20(�6E   ��6-   �� *Count+6U   �� 5<   "   $�� ��6,   $��20(�65   6E   �� 5=   "   $��ед.��6-   $��20(�69   6I   5>      �� 5?      5A      5B      5D      5F       � 	Resources 5J       �� 
TargetType	 �� Property
 �� Value��%T   '�       �� 5K      " �6   .�5L      �� 	 � ��

 �����63   5M      5N      5O      �� 5P   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5Q      �� $��16(�6   $=��7ИТОГОВАЯ ЦЕНА (c учетом скидок)��6"   $
��Bold"�6L   6`   �� 5R      -   5        $ lResult��5R      $��16(�6&   $�� ��65   6B   5S      �� 5T   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5U      �� -   5        $+��%Добавить 1 ед. товара��5U      $��30��65   $��0,0,5,0q�6Y   �� 5V      -   5        $'��!Отнять 1 ед. товара��5V      $��30��63   $��0,0,5,0q�6Z   �� 5W      -   5        $	��140��5W      $!��Оформить заказ��6!   $��30��6:   $��18(�6F   $��0,0,5,0q�6n   6�   5X      �� 5Y   
   $��2��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�5Z      �� $��9��6   $��0��6%   $��Пункт выдачи:��65   $��20(�6J   $��Center=�6X   �� 5[      -   5         ��Name$ cmbdDeliveryPoint��5[      $��9��5\       �� DisplayMemberPath$
 Name��5]       �� SelectedIndex$ 0��5_      $��1��5`      $	��150��6+   $��30��67   5b      5c      5e      5f      