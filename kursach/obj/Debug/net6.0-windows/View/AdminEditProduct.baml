   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  5   W   #    kursach.View.AdminEditProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:kursach.View     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   1	viewmodelclr-namespace:kursach.ViewModel   6W   -   5        $��EditWnd��5
   +     � Title$7  1Редактирование информации��6	   $	��450��6:   $	��800��6G    � WindowStartupLocation$ CenterScreen=�6T    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source �� 
TargetType   MaterialDesignTextBox	 �� BasedOn
 �� Property �� Value  MaterialDesignComboBox�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %  '��       7   '�� s     7  �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      5      .��5      �  � ColumnDefinitions 5    
   �� 5!      $��* �6   �� 5"      $
��Auto �6   .+�5&   
   �� ���#41024D$��30��6+   $	��Top=�67   .+�5'      �� $��Редактор��6   $��Center=�6(   $��20(�6E   
�������6S   5(      �� 5*   
   -   5         ��Name$ SearchTextBox��5*      $��16                  (�6k   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$&  Поиск по названию��5+      $	��200��6G   $��30��6S   $��	40 30 0 0q�6_   $	��Top=�6r   $
��Left=�6�   ��5*   *   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5+   �   �� 5,   
   $��80��63   $	��Top=�6>   $��Center=�6V   $��0 30 0 0q�6s     MaterialDesignFlatButton#��[ 6�   ��6   �� *SearchCommand+ � ToolTip 5-      _� 5.      $��
Найти��6   .��50      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6+   ���#41024D6:   51      �� 54   
   $��0��6   $��10,70,10,10q�6l   ��6"   �� *
Products+ �� SelectedItem 6C   �� *SelectedProduct+��55      �� 56      " ��6   .�57      �� 
 � ��
 �����64   �� 58      
 � ��$ 2q�68   �� 59      
 � ��$ 2q�60   �� 5:      
 � ��
 �����63   �� 5;      
 � �� 5<      �� 5=       �� 
TargetType" ��6.   .R�5>   "   ��  ��Name$ Border��6)   #��z��69   #��z��6e    �� CornerRadius$ 5��6�   #��z��6�   ._�5?   &   �� 5@   #    �� Triggers 5A   "   P� 5B   &    P� Property �@��
IsSelected P� Value$
 True��6D   . �5C   *   ��  �� 
TargetName$ Border��61   
 � �� �#EDE1F36[   5E   '   5G      5I      5J      ��5L      �� 5M      .R�5N      �  5O      �� 5P      $
��Auto �6/   �� 5Q      $��* �6/   .+�5S      �� $��10q�6%   .+�5T      �� $
��Bold"�6E   $��18(�6W   $��0 0 0 4q�6e   ��6(   ��  �� Path$ Naming�6e   �� 5U      $��14(�6K   $��0 0 0 4q�6Y   ��6(   �� $ Manufacturer�6Y   �� 5V      $��14(�6D   $��0 0 0 4q�6R   ��6(   �� $ Price�6R   5W      �� 5X      $��1��6%   $��Right=�65   $��Center=�6Q   .+�5Y      ��  �� Orientation$ 
Horizontal=�6)   .+�5Z   "   �� $��30��6)   $��30��66     MaterialDesignIconButton#��[ 6�   ��6A   �� *DataContext.DeleteCommand+ �� RelativeSource ��  �� AncestorType ListBox 5[   &   _� 5\   *   $��Удалить��62   .��5^   &     $ Delete=�6C   
���   �6Q   5_   #   5`      5a      5b      5d      5f      �� 5i   
   $��1��6    � DataContext 6%   �� *SelectedProduct+.+�5j      �� 
�������$*��$Информация о товаре��6/   $
��Bold"�6J   $��18(�6\   $��0 0 0 16q�6j   �� 5k      $��16(�6   $ Категория��6f   $��0 0 0 8q�6�   ��6$   �� *%#IdcategoryNavigation.Namingcategory+ �� Mode$ TwoWay=�6�   �� 5l      $��16(�6   $5 /Инвентаризационный номер��6h   $��0 0 0 8q�6�   ��6$   �� *'%IdwarehouseNavigation.Inventorynumber+$ TwoWay=�6�   �� 5m      $��16(�6   $ Название��6I   $��0 0 0 8q�6s   ��6$   �� *Naming+$ TwoWay=�6s   �� 5n      $��16(�6   $  Производитель��6P   $��0 0 0 8q�6   ��6%   �� *Manufacturer+$ TwoWay=�6   �� 5o      $��16(�6   $ Цена��6H   $��0 0 0 8q�6n   ��6$   �� *Price+$ TwoWay=�6n   �� 5p      $��16(�6   $ Описание��6N   $��0 0 0 8q�6x   ��6$   �� *Description+$ TwoWay=�6x   5q      �� 5r   
   $��16(�6   $��Сохранить��6   $��1��6Z   $��	0 150 0 0q�6j   $	��200��6}   ��63   �� *SaveProductCommand+6}   �� 5t   
   $��0��6   $��30��6   $��30��6w   $��Right=�6�   $	��Top=�6�   #��[ 6�   ��6*   �� *	ExitBtn+��6F   ��   �� ElementName$  EditWnd�� 5u      _� 5v      $��
Выход��6   .��5x        $ 	ExitToApp=�6+   
�������6<   5y      5z      5{      