   M S B A M L   `   `   `  ���� Y  UДипломнаяРабота, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ДипломнаяРаботаДипломнаяРабота  2    ,ДипломнаяРабота.Administrator   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:ДипломнаяРабота       N� Title$  Administrator�� � 	Resources 8   2ДипломнаяРабота.ДипломDataSet   дипломDataSet   сотрудникViewSource �� Source �� Source��%G   &	        &	      7     ��  �� *Сотрудник+8   .��� $	��450��$	��Top=�$
��Left=�$
��1000��.+�� -    �Name$ grid1�� � DataContext# [ $
��Left=�$��
407,27,0,0q�$	��Top=� � ColumnDefinitions �� $��2 ��� $��40 ��� $
��Auto � � RowDefinitions �� $
��Auto �.+��� $��Имя:��$��1��$
��Left=�$��1,3,0,3q�$��0��$��Center=��� -    ��Name$ имяTextBox��$��2��$
��Left=�$��30��$��3,4,0,4q�$��0��$��Center=�$	��140������ *Имя+	 �� Mode$	 TwoWay=�
 �� NotifyOnValidationError
 .  �� ValidatesOnExceptions . � -   $ grid2��# [ $
��Left=�$��
381,63,0,0q�$	��Top=� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Фамилия:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -   $ фамилияTextBox��$��1��$
��Left=�$��30��$��3q�$��0��$��Center=�$	��140������ *Фамилия+$	 TwoWay=�
 .  . � -   $ grid3��# [ $
��Left=�$��380,101,0,0q�$	��Top=� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Отчество:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -   $ отчествоTextBox��$��1��$
��Left=�$��30��$��3q�$��0��$��Center=�$	��140������ *Отчество+$	 TwoWay=�
 .  . � -   $ grid4��# [ $
��Left=�$��383,137,0,0q�$	��Top=� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Телефон:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -   $ телефонTextBox��$��1��$
��Left=�$��30��$��3q�$��0��$��Center=�$	��140������ *Телефон+$	 TwoWay=�
 .  . � -	   $ grid5��# [ $
��Left=�$��384,175,0,0q�$	��Top=� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Паспорт:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -
   $ паспортTextBox��$��1��$
��Left=�$��30��$��3q�$��0��$��Center=�$	��140������ *Паспорт+$	 TwoWay=�
 .  . � -   $ grid6��# [ $
��Left=�$��397,211,0,0q�$	��Top=� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Снилс:��$��0��$
��Left=�$��3q�$��0��$��Center=��� -   $ снилсTextBox��$��1��$
��Left=�$��30��$��3q�$��0��$��Center=�$	��140������ *
Снилс+$	 TwoWay=�
 .  . �� 
�������$
��Left=�$	��140��$��
200,26,0,0q�
���   �$	��Top=�$	��140���� 
�������$
��Left=�$	��177��$��200,252,0,0q�
���   �$	��Top=�$	��396��