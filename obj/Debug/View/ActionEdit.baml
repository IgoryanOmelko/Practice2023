   M S B A M L   `   `   `  ����C  ?GiveGood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GiveGood.ViewGiveGood.View  5   	       GiveGood.View.ActionEdit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GiveGood.View     5   	   -   5          � Title$  
ActionEdit��5   	   $	��550��6   $	��650��6)   $	��550��65   $	��650��6E   .��5	      � -   5        $��MainContainer��5	       � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   � -   5        $��
MainHeader��5      $��0��6!   
����ح�$��2��6E    5      �� 5      $��50 �6#   �� 5      $��3* �6#   �� 5      $��2* �6#   .+�5      �� -   5         ��Name$
 Logo��5      $��0��6"   5      �� 5       �� Orientation$ Vertical=�6   $��2��60   $��1��6@   $��Center=�6M   .+�5      �� -   5         ��Name$	 Fio��5      $��Center=�6)   $��Center=�6D   ФИО6f   �� 5      -   5         ��Name$ buttonAction��5   .   ���#FFFFFF$��2��6D   $��1��6T   $	��100��6a   $��Center=�6m   $��Center=�6�   $��14(�6�   .��6�   
Назад6�   5      �� 5       -   5        $ 
HeaderText��5       $��1��6,   $��1��6<   $��Center=�6I   $��Center=�6d   $��16(�6�   Изменение акции6�   5!      � 5"   
   -   5        $��MainContent��5"      $��1��6"   
�������$��2��6F    5#      �� 5$      $��* �6#   �� 5%      $��2* �6#   �� 5&      $��2* �6#    5(      �� 5)      $��* �6    �� 5*      $��3* �6    �� 5+      $��3* �6    .+�5-      �� ���#FFFFFF
���   �$��1q�6>   $��0��6R   $��0��6_   $��3��6o   $��	10,5,10,5q�6�   ._�5.      � -	   5         �Name$ IDName��5.       5/      �� 50      $��* �6+   �� 51      $��4* �6+    53      �� 54      $��* �6(   �� 55      $��* �6(   .+�57      �� $��	10,5,10,5q�6    $��0��63   $��0��6C   $
��Left=�6P   $��Center=�6k   $��14(�6�   Идентификатор6�   �� 58      $��	10,5,10,5q�6    $��0��63   $��1��6C   $
��Left=�6P   $��Center=�6k   $��14(�6�   Наименование6�   �� 59      -
   5         ��Name$ ActionID��59      $��	10,0,10,0q�60   $��1��6C   $��0��6S   $��Stretch=�6`   $��Center=�6~   $��14(�6�   $��	sdfsdfsdf��6�   	 �� 
IsReadOnly	 . 6�   �� 5:      -   5        $ 
ActionName��5:      $��	10,0,10,0q�62   $��1��6E   $��1��6U   $��Stretch=�6b   $��Center=�6�   $��14(�6�   $��	sdfsdfsdf��6�   6�   5;      5<      �� 5=      ���#FFFFFF
���   �$��1q�6>   $��1��6R   $��0��6_   $��3��6o   $��	10,5,10,5q�6�   ._�5>      � -   5        $ Description��5>       5?      �� 5@      $��* �6+   �� 5A      $��4* �6+    5C      �� 5D      $��* �6(   �� 5E      $��* �6(   .+�5G      �� $��	10,5,10,5q�6    $��0��63   $��0��6C   $
��Left=�6P   $��Stretch=�6k   $��14(�6�   Описание6�   �� 5H      -   5        $ ActionDescription��5H      $��	10,5,10,5q�69   $��1��6L   $��0��6\   $��2��6i   $��Stretch=�6z   $��Stretch=�6�   $��14(�6�   $��	sdfsdfsdf��6�   
 �� AcceptsReturn
 .  �� 
AcceptsTab .  �� TextWrapping$
 Wrap=�6�   6  5I      5J      �� 5K      ���#FFFFFF
���   �$��1q�6>   $��2��6R   $��0��6_   $��3��6o   $��	10,5,10,5q�6�   ._�5L      � -   5        $
 Data��5L       5M      �� 5N      $��* �6+   �� 5O      $��* �6+   �� 5P      $��* �6+   �� 5Q      $��* �6+    5S      �� 5T      $��* �6(   �� 5U      $��* �6(   �� 5V      $��* �6(   �� 5W      $��2* �6(   .+�5Y      �� $��	10,5,10,5q�6    $��0��63   $��0��6C   $
��Left=�6P   $��Stretch=�6k   $��14(�6�   
Район6�   �� 5Z      $��	10,5,10,5q�6    $��0��63   $��1��6C   $
��Left=�6P   $��Stretch=�6k   $��14(�6�   Тип6�   �� 5[      $��	10,5,10,5q�6    $��0��63   $��2��6C   $
��Left=�6P   $��Stretch=�6k   $��14(�6�   Статус6�   �� 5\      $��	10,5,10,5q�6    $��0��63   $��3��6C   $
��Left=�6P   $��Stretch=�6k   $
��Wrap=�6�   DBМаксимальное количество участников6�   �� 5]      -   5        $ ActionDistrict��5]      $��1��66   $��0��6F   $��Stretch=�6S   $	��top=�6q   $��14(�6�   $��	sdfsdfsdf��6�   	 . 6�   �� 5^      -   5         ��Name$ 
ActionType��5^      $��1��63   $��1��6C   $	��Top=�6P   $��14(�6h   6v   �� 5_      -   5        $ ActionStatus��5_      $��1��65   $��2��6E   $	��Top=�6R   $��14(�6j   6x   �� 5`      -   5        $ ActionMaxPart��5`      $��1��65   $��3��6E   $	��Top=�6R   $��14(�6j   6x   �� 5a      $��	10,5,10,5q�6    $��2��63   $��0��6C   $
��Left=�6P   $��Stretch=�6k   $��14(�6�   !Дата регистрации6�   �� 5b      $��	10,5,10,5q�6    $��2��63   $��1��6C   $
��Left=�6P   $��Stretch=�6k   $��14(�6�   Дата начала6�   �� 5c      -   5         ��Name$ 	IsEndDate��5c      $��	10,5,10,5q�62   $��2��6E   $��2��6U   $
��Left=�6b   $��Stretch=�6}   $��14(�6�   .��6�   Дата окончания6�   (  "System.Windows.Controls.DatePicker  5d      -   5          Name$ ActionRegDate��5d   !   $��3��68   $��0��6H   $��Stretch=�6U   $	��Top=�6s   $��14(�6�   6�     5e      -   5        $ ActionStartDate��5e   !   $��3��6:   $��1��6J   $��Stretch=�6W   $	��Top=�6u   $��14(�6�   6�     5f      -   5        $ ActionEndDate��5f   !   $��3��68   $��2��6H   $��Stretch=�6U   $	��Top=�6s   $��14(�6�   6�   �� 5g      -   5        $ 
ButtonSave��5g      $��3��61   $��3��6A   $��Stretch=�6N   $	��Top=�6l   $��14(�6�   .��6�   Сохранить6�   �� 5h      -   5        $ ButtonDelete��5h   A   
���  ��
�������$��2��6W   $��3��6g   $��Stretch=�6t   $	��Top=�6�   $��14(�6�   .��6�   Удалить6�   5i      5j      5k      � 5l   
   -   5        $��
MainFooter��5l      $��2��6!   
����ح�$��2��6E    5m      �� 5n      $��50 �6#   �� 5o      $��3* �6#   �� 5p      $��* �6#   5r      5s      5t      