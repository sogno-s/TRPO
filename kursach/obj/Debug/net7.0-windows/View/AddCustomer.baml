   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5	   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  62       kursach.View.AddCustomer   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4:
extToolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   &localclr-namespace:kursach.View  5	   	   /	viewmodelclr-namespace:kursach.ViewModel  62   -   5        $��AddWnd��5   "     � Title$%  Добавить клиента��6	   $	��450��60   $	��800��6=    � WindowStartupLocation$ CenterScreen=�6I    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#41024D$��0 0 0 1q�67   .+�5      �� $��Center=�6   $	��Top=�65   $%��Добавить клиента��6M   $��20(�6e   
�������6s   5      �� 5    
   $��1��6   .��5!      � $��16q�6    5"      �� 5#      $
��Auto �6$   �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$   �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      $
��Auto �6$   �� 5,      $
��Auto �6$   .+�5/      �� $��16(�6   $��0��6*   $��Фамилия:��67   $
��Bold"�6G   �� 50      $��16(�6   $��0��6C   $��10q�6P   ��6(   �� *	TbSurname+6P   �� 52      $��16(�6   $��1��6*   $��Имя:��67   $
��Bold"�6C   �� 53      $��16(�6   $��1��6@   $��10q�6M   ��6(   �� *TbName+6M   �� 55      $��16(�6   $��2��6*   $��Отчество:��67   $
��Bold"�6H   �� 56      $��16(�6   $��2��6D   $��10q�6Q   ��6(   �� *
TbLastName+6Q   �� 58      $��16(�6   $��3��6*   $"��Номер телефона:��67   $
��Bold"�6N   �� 59      $��16(�6   $��3��6B   $��10q�6O   ��6(   �� *
TbNumber+6O   �� 5;      $��16(�6   $��4��6*   $"��Серия паспорта:��67   $
��Bold"�6N   �� 5<      $��16(�6   $��4��6E   $��10q�6R   ��6(   �� *TbSeriaPass+6R   �� 5>      $��16(�6   $��5��6*   $"��Номер паспорта:��67   $
��Bold"�6N   �� 5?      $��16(�6   $��5��6F   $��10q�6S   ��6(   �� *TbNumberPass+6S   �� 5A      $��16(�6   $��6��6*   $��Регион:��67   $
��Bold"�6F   �� 5B      $��16(�6   $��6��6B   $��10q�6O   ��6(   �� *
TbRegion+6O   �� 5D      $��16(�6   $��7��6*   $��Город:��67   $
��Bold"�6E   �� 5E      $��16(�6   $��7��6@   $��10q�6M   ��6(   �� *TbCity+6M   �� 5G      $��16(�6   $��8��6*   $��Улица:��67   $
��Bold"�6E   �� 5H      $��16(�6   $��8��6B   $��10q�6O   ��6(   �� *
TbStreet+6O   �� 5J      $��16(�6   $��9��6*   $��Номер дома:��67   $
��Bold"�6J   �� 5K      $��16(�6   $��9��6G   $��10q�6T   ��6(   �� *TbNumberHouse+6T   5N      5O      �� 5P   
   $��Right=�6   $	��Top=�6-   $��30��6E   $��30��6Q      MaterialDesignIconButton#��[  6�   ��6\   �� *SaveCommand+��6|   �� 	 �� ElementName$	 AddWnd��
 � ToolTip
 5Q      _� 5R      $��Сохранить��6   .��5T      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=�6+   
�������6>   5U      �� 5W   
   $��35��6]   $��30��6i   $
��Left=�6t   $	��Top=�6�   #��[  6�   ��6   �� *	ExitBtn+��6-   �� $	 AddWnd��
 5X      _� 5Y      $��Вернуться��6   .��5[        $ ArrowLeftBold=�6+   
�������6@   5\      5_      5`      