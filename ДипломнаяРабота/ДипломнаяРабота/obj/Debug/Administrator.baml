   M S B A M L   `   `   `  ����Y  UДипломнаяРабота, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ДипломнаяРаботаДипломнаяРабота  5      2    ,ДипломнаяРабота.Administrator   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ДипломнаяРабота     5        N� Title$  Administrator��5	       � 	Resources 5
      8   2ДипломнаяРабота.ДипломDataSet   дипломDataSet   сотрудникViewSource �� Source �� Source��%c   &	        &	      7     5   
   6   �� 5   
    6;   �� *Сотрудник+8   5      .��5      � $	��750��6   $	��Top=�6   $
��Left=�60   $
��1600��6K   .+�5   
   � -   5         �Name$ grid1��5       � DataContext# [ 6   $
��Left=�6Q   $��
228,31,0,0q�6l   $	��Top=�6�   $	��350��6�    � ColumnDefinitions 5      �� 5      $��2 �6#   �� 5      $��40 �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    .+�5      �� $��Имя:��6   $��1��6$   $
��Left=�64   $��1,3,0,3q�6O   $��0��6`   $��Center=�6m    J� RenderTransformOrigin$ -5.986,0.404&�6�   $��20(�6�   $��2��6�   $��63��6�   �� 5      -   5        	 ��Name$	 имяTextBox��5      $��2��6*   $
��Left=�6:   $��30��6U   $��96,13,-89,0q�6a   $��0��6v   $��Center=�6�   $	��200��6�   ��6�   �� *Имя+
 �� Mode$
 TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   5      � 5   
   -   5        $ grid2��5      # [ 6   $
��Left=�6Q   $��
228,69,0,0q�6l   $	��Top=�6�   $	��350��6�    5      �� 5       $
��Auto �6#   �� 5!      $
��Auto �6#    5#      �� 5$      $
��Auto �6    .+�5&      �� $��Фамилия:��6   $��0��6'   $
��Left=�67   $��3q�6R   $��0��6]   $��Center=�6j   $��20(�6�   �� 5'      -   5        $	 фамилияTextBox��5'      $��1��6.   $
��Left=�6>   $��30��6Y   $��36,10,-27,3q�6e   $��0��6z   $��Center=�6�   $	��200��6  ��6�   �� *Фамилия+$
 TwoWay=� .  . 6  5(      � 5)   
   -   5        $ grid3��5)      # [ 6   $
��Left=�6Q   $��228,105,0,0q�6l   $	��Top=�6�   $	��350��6�    5*      �� 5+      $
��Auto �6#   �� 5,      $
��Auto �6#    5.      �� 5/      $
��Auto �6    .+�51      �� $��Отчество:��6   $��0��6(   $
��Left=�68   $��3q�6S   $��0��6^   $��Center=�6k   $��20(�6�   �� 52      -   5        $	 отчествоTextBox��52      $��1��6/   $
��Left=�6?   $��30��6Z   $��34,10,-25,3q�6f   $��0��6{   $��Center=�6�   $	��200��6  ��6�   �� *Отчество+$
 TwoWay=� .  . 6  53      � 54   
   -   5        $ grid4��54      # [ 6   $
��Left=�6Q   $��228,141,0,0q�6l   $	��Top=�6�   $	��350��6�    55      �� 56      $
��Auto �6#   �� 57      $
��Auto �6#    59      �� 5:      $
��Auto �6    .+�5<      �� $��Телефон:��6   $��0��6'   $
��Left=�67   $��3q�6R   $��0��6]   $��Center=�6j   $��20(�6�   �� 5=      -   5        $	 телефонTextBox��5=      $��1��6.   $
��Left=�6>   $��30��6Y   $��40,10,-28,3q�6e   $��0��6z   $��Center=�6�   $	��200��6  ��6�   �� *Телефон+$
 TwoWay=� .  . 6  5>      � 5?   
   -	   5        $ grid5��5?      # [ 6   $
��Left=�6Q   $��228,175,0,0q�6l   $	��Top=�6�   $	��350��6�    5@      �� 5A      $
��Auto �6#   �� 5B      $
��Auto �6#    5D      �� 5E      $
��Auto �6    .+�5G      �� $��Паспорт:��6   $��0��6'   $
��Left=�67   $��3q�6R   $��0��6]   $��Center=�6j   $��20(�6�   �� 5H      -
   5        $	 паспортTextBox��5H      $��1��6.   $
��Left=�6>   $��30��6Y   $��42,10,-32,3q�6e   $��0��6z   $��Center=�6�   $	��200��6  ��6�   �� *Паспорт+$
 TwoWay=� .  . 6  5I      � 5J   
   -   5        $ grid6��5J      # [ 6   $
��Left=�6Q   $��228,217,0,0q�6l   $	��Top=�6�   $	��350��6�    5K      �� 5L      $
��Auto �6#   �� 5M      $
��Auto �6#    5O      �� 5P      $
��Auto �6    .+�5R      �� $��Снилс:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��0��6[   $��Center=�6h   $��20(�6�   �� 5S      -   5        $	 снилсTextBox��5S      $��1��6,   $
��Left=�6<   $��30��6W   $��63,3,-53,10q�6c   $��0��6x   $��Center=�6�   $	��200��6�   ��6�   �� *
Снилс+$
 TwoWay=� .  . 6�   5T      �� 5U   
   
�������$
��Left=�6!   $	��140��6<   $��	49,33,0,0q�6I   
���   �$	��Top=�6k   $	��140��6�   �� 5V   
   
�������$
��Left=�6!   $	��177��6<   $��
35,310,0,0q�6I   
���   �$	��Top=�6l   $	��396��6�   5Y      5Z      