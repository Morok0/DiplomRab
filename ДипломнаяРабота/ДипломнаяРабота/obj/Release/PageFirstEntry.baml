   M S B A M L   `   `   `  ���� Y  UДипломнаяРабота, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ДипломнаяРаботаДипломнаяРабота  3    -ДипломнаяРабота.PageFirstEntry   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:ДипломнаяРабота       N� Title$  PageFirstEntry�� � 	Resources 8   2ДипломнаяРабота.ДипломDataSet   дипломDataSet & "пользовательViewSource �� Source �� Source��%M   &	        &	      7     ��  �� *Пользователь+8   .��� .+��� 
�������$
��Left=�$	��395��$��	120,0,0,0q�
���   �$	��Top=�$	��583���� $����  Здравствуйте! Рады приветствовать вас в нашем 
  приложении. Так как вход в приложение был 
  осуществлён впервые, то далее необходимо 
  зарегистрировать первого пользовотеля.
  Просим вас учесть что при первой регистрации 
  пользователь автоматически становится администратором!��$
��Left=�$��120,0,0,277q�$��20(�$	��583�����	#FF83E9F9� -    �Name$ grid1�� � DataContext# [ $
��Left=�$��147,203,0,0q�$	��Top=�$	��394��$��43�� � ColumnDefinitions �� $
��Auto ��� $
��Auto � � RowDefinitions �� $
��Auto �.+��� $��Логин:��$��1��$
��Left=�$��2,5,0,4q�$��0��$��Center=�$	��125��$��20(��� -    ��Name$ логинTextBox��$��1��$
��Left=�$��38��$��127,5,-262,3q�$��0��$��Center=�$	��266��$
��Bold"�
���   ����� *
Логин+	 �� Mode$	 TwoWay=�
 �� NotifyOnValidationError
 .  �� ValidatesOnExceptions . � -   $ grid2��# [ $
��Left=�$��147,268,0,0q�$	��Top=�$	��394�� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Пароль:��$��0��$
��Left=�$��3,3,0,3q�$��0��$��Center=�$��20(�$��2��$	��126���� -   $ парольTextBox��$��1��$
��Left=�$��40��$��130,3,-262,0q�$��0��$��Center=�$	��263��
���   ����� *Пароль+$	 TwoWay=�
 .  . �� -    ��Name$ Enter��$&�� Зарегистрировать��$
��Left=�$��486,334,0,0q�$	��Top=�$	��288�����	#FF83E9F9$��86��$��30(� J� RenderTransformOrigin$ 0.5,0.5&�$
��Bold"�z�V� .~��� ��  �� AngleX$	 -10Q��� T� 