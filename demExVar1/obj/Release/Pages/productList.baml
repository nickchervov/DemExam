   M S B A M L   `   `   `  ���� D  @demExVar1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:demExVar1.PagesdemExVar1.Pages  !    demExVar1.Pages.productList   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:demExVar1.Pages       N� Title$  productList��.���  � RowDefinitions �� $��0.15* ��� �� $��0.15* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� $��Поиск: ���� -    ��Name$ tbSearch���� -    ��Name$ 	lvProduct��$��1��$��0q�$��Center=����� .R��� 
���   �$��1q� �� CornerRadius$ 10��$
��1000��._��� $ 
Horizontal=�$��Center=�.+��� .+��� $	��110��$	��110������ *ProductPhoto+�� $��Center=�$	��500��$��
100,0,10,0q�.+��� ���� *ProductName+�� ���� *ProductManufacturer+�� ���� *ProductDescription+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��	Цена:���� ���� *ProductCost+�� $ 
Horizontal=�.+��� $��Скидка:���� ���� *ProductDiscount+ � ContextMenu �� -   $��	cmProduct��.@�m� -    m�Name$ btnAddToOrder��$&�� Добавить к заказу���� $��2��$ 
Horizontal=�$��Center=�$��Center=�.+��� -    ��Name$ 	btnLogOut��$��
Выйти��$��0,0,10,0q��� -   $ btnDeleteProd��$��Удалить��$��0,0,10,0q��� -   $ btnAddProduct��$��Добавить��$��0,0,10,0q��� -   $ btnChangeProduct��$��Изменить��$��0,0,10,0q��� -	   $ 	btnOrders��$��Заказы��$��0,0,10,0q��� -
   $ btnOrderList��$��
Заказ��