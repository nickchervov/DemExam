   M S B A M L   `   `   `  ����C  ?Session1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Session1.PagesSession1.Pages  5      3clr-namespace:Session1.HelpersSession1.Helpers  62   9!clr-namespace:Session1.ConvertresSession1.Convertres  5	      !    Session1.Pages.ProductsList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Session1.Pages     5      1local1clr-namespace:Session1.Helpers     62   4local2!clr-namespace:Session1.Convertres     5	        N� Title$  ProductsList��5
       � 	Resources 5      5   /Session1.Convertres.DiscountBackgroundConverter   	Converter3   -Session1.Convertres.DiscountTotalSumConverter  DiscountConverter2   ,Session1.Convertres.DiscountVisibleConverter  DiscountVisibleConverter9   3Session1.Convertres.DiscountTextDecorationConverter # DiscountTextDecorationConverter��%t   &	        &	      &	 &     &	 9       5   
   6-     5   
   6+     5   
   6*     5   
   61   5      .��5      � -   5         J� RenderTransformOrigin$ 0.499,0.488&�5       � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��25* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $
��Left=�6#   .+�5      �� $��30��6   $��0,20,0,0q�6%    �� Orientation$ 
Horizontal=�67   .+�5      �� -   5         ��Name$ sorting��5       �� Text$ Сортировать��6,   $
��Left=�6?   $��16(�6Z   $��10,0,0,0q�6h   $	��180��6z   
���  �����	#FF370303.@�5      �� $!��Без сортировки��6#    �� 
IsSelected . {�.  $y�	Collapsed=�6`   �� 5      -   5         ��Name$ S2��5   #   $��От А до Я��6/   �� 5      -   5        $ S3��5   #   $��От Я до А��6/   5      �� 5       -   5        $ filter��5       $
��Left=�6+   $��16(�6F   $��	10,00,0,0q�6T   $	��193��6g   .@�5!      �� $!��Без фильтрации��6#    . {�.  $y�	Collapsed=�6`   �� 5"      -   5        $ F1��5"   #   $'��!Отмена фильтрации��60   �� 5#      -   5        $ F2��5#   #   $��Твердое��60   �� 5$      -   5        $ F3��5$   #   $��Жидкое��60   �� 5%      -	   5        $ F4��5%   #   $��Газообразное��60   �� 5&      -
   5        $ F5��5&   #   $%��Скидка от 0% до 9,99%��60   �� 5'      -   5        $ F6��5'   #   $(��"Скидка от 10% до 14,99% ��6/   �� 5(      -   5        $ F7��5(   #   $��Скидка от 15% ��6/   5)      5*      �� 5+      .+�5,      �� $��	10,00,0,0q�6   $ 
Horizontal=�60   .+�5-      �� $��Показано��6   $��16(�6/   $
��Bold"�6=   �� 5.      -   5        	 ��Name$	 	lCountNow��5.      $��16(�6/   $�� ��6=   $
��Bold"�6H   �� 5/      $��товаров из��6   $��16(�61   $
��Bold"�6?   �� 50      -   5        $	 lCountTotal��50      $��16(�61   $�� ��6A   $
��Bold"�6M   $��0,0,60,0q�6_   51      52      53      �� 54   
   $��0��6   $ 
Horizontal=�6#   $��Right=�6=   .+�55      �� $��0��6   $
��Wrap=�6'   $��16(�6;   $��
Поиск��6J   
 �� TextAlignment$
 Center=�6W    �� 
LineHeight$ 18��6n   $��17��6~   $	��Top=�6�   $
��Left=�6�   $��48��6�   $��	0,30,10,0q�6�   �� 56      -   5         ��Name$ tSearch��56   M   $��0��6   $��40��6#   $	��250��6/   $��20(�6>    �� TextWrapping$
 Wrap=�6^   $��	0, 0,20,0q�6�   57      �� 58   
   -   5        $��MatView��58      $��1��6#   $��Hidden=�6]   ��59      �� 5:      .R�5;      � ��6   �� *
Discount+ �� 	Converter# [  ��6b   �� *ActualWidth+ �� ElementName$ MatView�� �� Mode$ OneWay=� 5<      �� 5=      $	��210 �6,    � ColumnDefinitions 5?      �� 5@      $	��260 �6/   �� 5A      $
��auto �6/   .+�5C      �� $��0��6    $
��Left=�60   $	��194��6K   $	��Top=�6X   $	��239��6p   $��0��6}   ��5D      �� 5E   "    �� Path$ Image�6*    �� TargetNullValue 5F   &   ��5G   *   *&pack://application:,,,/Images/none.jpg��6^   5I   #   5K      �� 5L      $��1��6%   $��0��65   $��	0 0 230 0q�6B   .+�5M      �� $��20(�6=   $
��Bold"�6K   ��6$   �� *Name+6_   �� 5N      $ 
Horizontal=�6)   .+�5O   "   �� $��
Цена: ��6(   $��26(�69   6I   �� 5P   "   $��0 5 0 0q�6�   $��26(�6�   ��6,   �� *ID+# [ ��6�   �� *Price+6�   5Q      �� 5R      $ 
Horizontal=�6)   .+�5S   "   �� $��Скидка: ��6(   $��26(�6;   6K   �� 5T   "   $��26(�6E   ��6(   �� *
Discount+6U   5U      �� 5V      $ 
Horizontal=�6)   y�6C   �� *ID+# [ .+�5W   "   �� $,��&Цена с учетом скидки:��6(   $��24(�6H   6X   �� 5X   "   $��24(�6m   ��6(   �� *ID+# [ 6}   5Y      �� 5Z      $ 
Horizontal=�6)   .+�5[   "   �� $'��!Кол-во в магазине: ��6(   $��20(�6F   6V   �� 5\   "   $��20(�6C   ��6(   �� *Count+6S   �� 5]   "   $�� шт.��6(   $��20(�68   6H   5^      5_      5`      5a       � ContextMenu 5c      �� 5d      .@�5e      m� -   5        $&�� Добавить к заказу��5e      6:   m� 5f      -   5         m�Name$ ChangeProductButton��5f      $/��)Отредактировать товар��6<   6[   m� 5g      -   5        $ RemoveProductButton��5g      $��Удалить товар��6<   6S   5h       5j       �� 
TargetType �� Property �� Value��%T   '�       �� 5k      " �6   .�5l      ��  � ��
 �����63   5m      5n      5o      �� 5p   
   $ 
Horizontal=�6   $��0,0,0,0q�6/   $��2��6@   $	��Top=�6M   $��Right=�6e   .+�5q      �� -   5         ��Name$ AddProductButton��5q      $��0 0 10 0q�60   $,��&Добавить новый товар��6B   $
��Bold"�6a   $��30��6t   6�   5r      �� 5s   
   $ 
Horizontal=�6   $��0,0,0,0q�60   $��2��6A   $	��Top=�6N   $
��Left=�6f   .+�5t      �� -   5        $ 
ExitButton��5t      $$��Вернуться в меню��6*   $��2��6E   $��30��6R   $	��150��6^   $��1,0,10,1q�6j   $
��Bold"�6�   ���	#FFF1A6A6$
��Left=�6�   5u      5v      5w      