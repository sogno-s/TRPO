   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   1clr-namespace:kursach.Moduleskursach.Modules  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  5	   	   $    kursach.View.AdminEditEmployee   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aMmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   (localclr-namespace:kursach.View   5   	   ,local1clr-namespace:kursach.Modules   5   	   1	viewmodelclr-namespace:kursach.ViewModel   5	   	   HmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5
   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5        $��AdmEdit��5   +     � Title$7  1Редактирование информации��6	   $	��450��6:   $	��800��6G    � WindowStartupLocation$ CenterScreen=�6S    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source �� 
TargetType   MaterialDesignTextBox	 �� BasedOn
 �� Property �� Value  MaterialDesignComboBox�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %  '��       7   '�� s     7  �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      5       .��5"      �  � ColumnDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $
��Auto �6   �� 5&      $��* �6    � RowDefinitions 5(   
   �� 5)      .+�5,   
   �� ���#41024D$��30��6+   $	��Top=�67   .+�5-      �� $��Редактор��6   $��Center=�6(   $��20(�6E   
�������6S   5.      �� 51   
   -   5         ��Name$ SearchTextBox��51       $��16(�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ Поиск по фамилии��6x   $	��200��6�   $��30��6�   $��0 30 0 0q�6�   $	��Top=�6�   $��0��6�   ��67   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 52   
   $��80��63   $	��Top=�6>   $��Right=�6V   $��0 30 0 0q�6r     MaterialDesignFlatButton#��[ 6�   ��6   �� *SearchCommand+ � ToolTip 53      _� 54      $��
Найти��6   .��56      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6+   ���#41024D6:   57      � 59   
   $��0��6   .+�5:      �� $��0,65,0,0q�6c   ��6   �� *	Employees+ �� SelectedItem 69   �� *SelectedEmployee+��5;      �� 5<      " ��6   .�5=      �� 
 � ��
 �����68   �� 5>      
 � ��$ 2q�6<   �� 5?      
 � ��$ 2q�64   �� 5@      
 � ��
 �����67   �� 5A      
 � �� 5B      �� 5C   "    �� 
TargetType" ��62   .R�5D   &   ��  ��Name$ Border��6-   #��z��6=   #��z��6i    �� CornerRadius$ 5��6�   #��z��6�   ._�5E   *   �� 5F   '    �� Triggers 5G   &   P� 5H   *    P� Property �@��
IsSelected P� Value$
 True��6H   . �5I   .   ��  �� 
TargetName$ Border��65   
 � �� �#EDE1F36_   5K   +   5M   #   5O      5P      ��5R      �� 5S      .R�5T      �  5U      �� 5V   "   $��* �63   �� 5W   "   $
��Auto �63   .+�5Y      �� $��10q�6*   $��0��66   .+�5Z   "   �� $
��Bold"�6J   $��18(�6\   $��0 10 0 4q�6j   ��6,   ��  �� Path$ Surname�6j   �� 5[   "   $��16(�6L   $��0 5 0 4q�6Z   ��6,   �� $ 	Firstname�6Z   �� 5\   "   $��16(�6K   ��6,   �� $ Lastname�6K   �� 5]   "   $��16(�6Q   ��6,   �� $ Dateofbirthday�6Q   5`      �� 5a      $��1��6)   $��Right=�69   $��Center=�6U   .+�5b   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5c   &   �� $��30��6-   $��30��6:     MaterialDesignIconButton#��[ 6�   ��6E   �� *DataContext.DeleteCommand+ �� RelativeSource ��  �� AncestorType ListBox 5d   *   _� 5e   .   $��Удалить��66   .��5g   *     $ Delete=�6G   
���   �6U   5h   '   5i   #   5j      5k      5l      5n      5o      �� 5s   
   $��2��6   .��5u      ��  � DataContext 6   �� *SelectedEmployee+.+�5v      �� 
�������$2��,Информация о сотруднике��63   $
��Bold"�6R   $��16(�6d   $��0 0 0 16q�6r   �� 5w      -   5        $��16(�5w      $! Серия паспорта��6�   $��0 0 0 8q�6�   ��6T   �� *IdpasportNavigation.Seria+  �� Mode$  TwoWay=�.��6�   5y      �� 5z      -   5        $��16(�5z      $! Номер паспорта��6�   $��0 0 0 8q�6�   ��6U   �� *IdpasportNavigation.Numberp+$  TwoWay=�6�   �� 5{      -   5        $��16(�5{      $ Фамилия��6�   $��0 0 0 8q�6�   ��6\   �� *	Surname+$  TwoWay=�.��6�   5}      �� 5~      -   5        $��16(�5~      $ Имя��6�   $��0 0 0 8q�6�   ��6\   �� *	Firstname+$  TwoWay=�6�   �� 5      -   5        $��16(�5      $ Отчество��6�   $��0 0 0 8q�6�   ��6\   �� *
Lastname+$  TwoWay=�6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  5�      $��Center=�6%   $��16(�6B   $! Номер телефона��6z   !   Mask$! 0 (000) 000 0000��5�      $	��247��61   ��5�   P   �� *Phonenumber+$  TwoWay=�5�   1   �� 5�      $��Center=�6   $ 
Horizontal=�6:   .+�5�      �� -   5        $��16(�5�   Q   $ Email��6_   .��6�   ��5�      �� 5�      " ��6$   #	 [  69   .�5�   "   �� 
 � ��$	 0 8q�6;   �� 5�   "   
 � ��$	 250��6:   " �� Triggers" 5�   "   �� 5�   &   # �� Binding# 62   �� *SelectedEmployee.Email+$ PropertyChanged=�$ �� NotifyOnValidationError$
$ True��$  TwoWay=�% �� Value% True6�   .a�5�   *   �� 
 �@=�ErrorTemplate 5�   .   �� 5�   2   .R�5�   6   ]� $
��True��6@   .+�5�   :   �� 
���  ��$��Right=�6R   $��10��6i   �� 5�   :   5�   7   5�   3   5�   +   5�   '   5�      .��5�   )   ��5�      �� 5�      $ Email�6&   $ PropertyChanged=�63   $
$ True��6Y   & �� ValidationRules& 5�   "   )   #kursach.Modules.EmailValidationRule  5�   &   '   ErrorMessage$1' +Неправильный формат email��6A   -   'kursach.Modules.MaxLengthValidationRule  5�   &   (   	MaxLength$( 20��6E   )   ErrorMessage$E) ?Email должен быть не более 20 символов��6T   5�      .��5�   (   5�      5�      �� 5�      -	   5        $��16(�5�      $  Специализация��6�   $��0 0 0 8q�6�   ��6Z   �� *Idspecialization+$  TwoWay=�6�   �� 5�      -
   5        $��16(�5�      $ 
Логин��6~   $��0 0 0 8q�6�   ��6(   �� *Login+$  TwoWay=�6�   �� 5�      -   5        $��16(�5�      $ Пароль��6�   $��0 0 0 8q�6�   ��6(   �� *	Passworde+$  TwoWay=�6�   5�      5�      �� 5�      $��2��6   $��Bottom=�6-   .+�5�      �� $��Сохранить��6   $��0 16 0 0q�6Y   $	��100��6k   $��25��6w   ��61   �� *SaveEmployeeCommand+6w   5�      �� 5�   
   $��0��6   $��30��6   $��30��6w   $
��Left=�6�   $	��Top=�6�   #��[ 6�   ��6*   �� *	ExitBtn+��6F   �� * �� ElementName$* AdmEdit�� 5�      _� 5�      $��
Выход��6   .��5�        $ ArrowLeftBold=�6+   
�������6@   5�      5�      5�      