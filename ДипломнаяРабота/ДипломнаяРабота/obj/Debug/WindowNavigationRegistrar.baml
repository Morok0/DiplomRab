   M S B A M L   `   `   `  ����Y  UДипломнаяРабота, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ДипломнаяРаботаДипломнаяРабота  5   	   >    8ДипломнаяРабота.WindowNavigationRegistrar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ДипломнаяРабота     5   	   $	��850��5   
   $
��1600��6     � WindowStartupLocation$  CenterScreen=�6$    � Icon$ image/Bitmap.bmp��6J    � 	Resources 5
      8   2ДипломнаяРабота.ДипломDataSet   дипломDataSet  пациентViewSource �� Source �� Source��%_   &	        &	      7     5   
   6   �� 5   
    69   �� *Пациент+8   5      .��5      � $��5,5,5,5q�6    � DataContext# [ 6   .+�5   
    � -   5          �Name$ FrameRegistrar��5        � NavigationUIVisibility$ Hidden=�6(   ���	#FFD8F1EE$��0,40,0,0q�6_   o� 5   
   -   5         o�Name$
 Menu��5      $
��Left=�6   $��40��68   $	��Top=�6D   $	��150��6\   ���	#FF83E9F9.@�5      m� -   5        $��22(�5      $��40��6'   $	��150��63   ��5      �� 5      $��Меню��6    $��Center=�6,   $��Center=�6I   	 J� RenderTransformOrigin$	 0.953,0.296&�6d   $��
36,0,-48,0q�6�   $��80��6�   .@�5      �� -   5        
 ��Name$
 Patient��5      $��Center=�6*   $��Center=�6G   $'��!Добавить пациента��6b   $	��500��6�   $��30��6�   ���	#FF83E9F96�   �� 5      -   5        $

 Make��5      $��Center=�6'   $��Center=�6D   $#��Запись пациента��6_   $	��500��6�   $��30��6�   ���	#FF83E9F96�   �� 5      -   5        $
 Verification_Patient��5      $��Center=�67   $��Center=�6T   $#��Проверка записи��6o   $	��500��6�   $��30��6�   ���	#FF83E9F96�   �� 5      -   5        $
 Verification_Doctor��5      $��Center=�66   $��Center=�6S   $*��$График работы врача��6n   $	��500��6�   $��30��6�   ���	#FF83E9F96�   5      5      5      5      