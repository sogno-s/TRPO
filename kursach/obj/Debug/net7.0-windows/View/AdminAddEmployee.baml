   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  5
   	   1clr-namespace:kursach.Moduleskursach.Modules  5   	   #    kursach.View.AdminAddEmployee   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aMmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   (localclr-namespace:kursach.View   5   	   HmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	   1	viewmodelclr-namespace:kursach.ViewModel   5
   	   9	controls1)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   *local1clr-namespace:kursach.Modules  5   	   -   5        $��AddEmployeeWnd��5   (     � Title$1  +Регистрация сотрудника��6	   $	��450��6>   $	��800��6K    � WindowStartupLocation$ CenterScreen=�6X    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source �� 
TargetType   MaterialDesignTextBox	 �� BasedOn
 �� Property �� Value(  "System.Windows.Controls.DatePicker  MaterialDesignDatePicker%  Xceed.Wpf.Toolkit.MaskedTextBox  MaterialDesignBody  MaterialDesignDivider �� 
TargetType �� CornerRadius ��Name�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %$  '��       7   '  s     7  '  �     7  7  �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      �� 5      "  6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5       �� 5!      "  6   .�5"      �� 
 � ��8   6/   �� 5#      
 � ��8  60   �� 5$      
 � ��$ 1q�64   �� 5%      
 � ��$ 8q�6,   �� 5&      
 � ��$ 14(�6-   �� 5'      
 � �� 5(      �� 5)      "  6*   .R�5*      � .+�5+   "   �� #��z��6)   #��z��5,      #��z��5-      $ 2��5.      ._�5/   &   � .+�50   *   �� $ PART_ContentHost��67   $��Stretch=�51   +   $��Center=�52   +   #��z��53   +   54   '   55   #   56      57      59      5:      5<      .��5>      � .+�5@   
   �� ���#41024D$��30��6+   $	��Top=�67   .+�5A      �� $/��)Добавление сотрудника��6   $��Center=�65   $��20(�6R   
�������6`   5B      �� 5C   
   $��0��6   $��30��6   $��30��6~   $
��Left=�6�   $	��Top=�6�     MaterialDesignIconButton#��[ 6�   ��6*   �� *	ExitBtn+��6F   ��  �� ElementName$ AddEmployeeWnd�� � ToolTip 5D      _� 5E      $��
Выход��6   .��5G      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftBold=�6+   
�������6@   5H      �� 5J   
   $��0,30,0,0q�6   $
��Auto=�6)   .��5K      � $��16q�6    � RowDefinitions 5L      �� 5M      $
��Auto �6$   �� 5N      $
��Auto �6$   �� 5O      $
��Auto �6$   .+�5R      �� $��0��6   .+�5S      �� 
�������$��Паспорт��68   $
��Bold"�6G   $��18(�6Y   $
��0 16q�6g   �� 5T       �� Orientation$ 
Horizontal=�6!   .+�5U      �� -   5         �� 	MaxLength$ 4��5U   O   $��16(�6]   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Серия��6�   ��6k   �� *PassportSeries+6�   �� 5V      -   5        $ 6��5V   O   $��16(�6]   $ 
Номер��6�   ��6k   �� *PassportNumber+6�   5W      5X      �� 5Z      $��1��6   .+�5[      �� 
�������$��Личные данные��68   $
��Bold"�6M   $��16(�6_   $
��0 16q�6m   �� 5\      -   5        $��16(�5\   R   $ Фамилия��6z   ��6`   �� *
LastName+6z   �� 5]      -   5        $��16(�5]   R   $ Имя��6{   ��6`   �� *	FirstName+6{   �� 5^      -   5        $��16(�5^   R   $ Отчество��6|   ��6`   �� *
MiddleName+6|     5_      $��16(�6!   $ Дата рождения��6T      SelectedDate 6/   �� *DateOfBirth+6T     5`      $��Center=�6)   $��16(�6F   $! Номер телефона��6q      Mask$ 8 (000) 000 0000��5a      $	��247��6-   ��5`   T   �� *PhoneNumber+5a   -   �� 5b      $��Center=�6!   $ 
Horizontal=�6>   .+�5c      �� -   5        $��16(�5c   T   $ Email��6b   .��6�   ��5d      �� 5e   "   " ��6(   #	 [  6=   .�5f   &   �� 
 � ��$	 0 8q�6?   �� 5g   &   
 � ��$	 250��6>    �� Triggers 5h   &   �� 5i   *    �� Binding 66   �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError$
 True�� �� Value True6�   .a�5j   .   �� 
 �@=�ErrorTemplate 5k   2   �� 5l   6   .R�5m   :   ]� $
��True��6D   .+�5n   >   �� 
���  ��$��Right=�6V   $��10��6m   �� 5o   >   5p   ;   5q   7   5s   /   5t   +   5v   #   .��5w   -   ��5x      �� 5y   "    �� Path$ Email�6*   $ PropertyChanged=�67   $
 True��6]    �� ValidationRules 5z   &   )   #kursach.Modules.EmailValidationRule  5{   *      ErrorMessage$1 +Неправильный формат email��6E   -   'kursach.Modules.MaxLengthValidationRule  5|   *       	MaxLength$  20��6I   !   ErrorMessage$E! ?Email должен быть не более 20 символов��6X   5~   #   .��5   ,   5�      5�      �� 5�      -   5        $��16(�5�   P   $1 +Название специализации��6~   ��6^   �� *Specialization+6~   �� 5�      -	   5        $��16(�5�      $ 
Логин��6u   ��6^   �� *Login+6u   �� 5�      -
   5        $��16(�5�      $ Пароль��6x   ��6^   �� *
Password+6x   �� 5�      $��2��6   $��16(�6&   $��Добавить��64   $
��0 16q�6n   ��6G   �� *AddEmployeeCommand+6n   �� 5�      $��2��6!   $��Center=�6.   $��Bottom=�6K   .+�5�      �� $��© 2023 HouseM��6$   
�������69   5�      5�      5�      5�      5�      5�      