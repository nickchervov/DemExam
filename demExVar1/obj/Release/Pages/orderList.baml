   M S B A M L   `   `   `  ���� D  @demExVar1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:demExVar1.PagesdemExVar1.Pages      demExVar1.Pages.orderList   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:demExVar1.Pages       N� Title$  	orderList��.���  � RowDefinitions �� �� $��0.70* �.+��� -    ��Name$ lvOrder��$��Center=�$��Center=�$��0q����� *ordPrd+���� .R��� 
���   �$��1q� �� CornerRadius$ 10��$
��1000��._���  �� Orientation$ 
Horizontal=�$��Center=�$��10q�.+��� $��Center=�.+��� $	��110��$	��110������ *Photo+�� $��Center=�$	��500��$��
100,0,10,0q�.+��� $ 
Horizontal=�.+��� $-��'Наименование товара: ���� ���� *ProductName+�� $ 
Horizontal=�.+��� $%��Описание товара: ���� ���� *ProductDescription+�� $ 
Horizontal=�.+��� $"��Производитель: ���� ���� *ProductManufacturer+�� $ 
Horizontal=�.+��� $��
Цена: ���� ���� *Price+�� $��Center=�$ 
Horizontal=�.+��� $��Center=����� *Count+�� $�� шт.���� $��1��$��Center=�.+��� $ 
Horizontal=�$��Center=�.+��� $��Пункт выдачи:��$��0,0,10,0q��� -    ��Name$ cbPickUpPoint��$	��300�� �� SelectedValuePath$ PickupPointID�� �� DisplayMemberPath$ PickupPointAdress���� $ 
Horizontal=�$��0,20,0,0q�$��Center=�.+��� $��Сумма:���� -    ��Name$ tbSum��$��
10,0,100,0q��� $��Скидка:��$��0,0,10,0q��� -   $ 
tbDiscount���� $ 
Horizontal=�$��0,20,0,0q�$��Center=�.+��� -   	 ��Name$	 btnBack��$��
Назад���� -   $	 btnAddOrder��$)��#Сформировать заказ��$��40��$	��180��$��50,0,0,0q��� -   $	 btnDeletePrd��$&�� Удалить из заказа��$��50,0,0,0q�