   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  5	   	   5clr-namespace:kursach.Converterkursach.Converter  5
   	       kursach.View.DetailsPay   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   (localclr-namespace:kursach.View   5   	   1	viewmodelclr-namespace:kursach.ViewModel   5	   	   0convert1clr-namespace:kursach.Converter   5
   	   -   5        $��PaymentDetailsWindow��5        � Title$  Детали оплаты��6	   $	��470��6;   $	��800��6H    � WindowStartupLocation$ CenterScreen=�6T    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source)  #kursach.Converter.ConvertDatePicker   ConvertDatePicker�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %   &	          5      6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   �� $��0��6   ���#41024D$��0 0 0 1q�67   .+�5!      �� $��Center=�6   $	��Top=�65   $��Детали оплаты��6M   $��20(�6b   
�������6p   5"      �� 5$   
   $��1��6   $��0,30,0,0q�6$   $
��Auto=�66   .��5&      � $��16q�6    5'      �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    �� 5-      $��45 �6    �� 5.      $
��Auto �6    .+�51      �� $��16(�6   $��0��6&   $$��Фамилия клиента:��63   $
��Bold"�6K   �� 52      $��16(�6   $��0��6$   $��15q�6Q   ��61   �� *ClientLastName+6Q   �� 54      $��16(�6   $��1��6&   $��Имя клиента:��63   $
��Bold"�6G   �� 55      $��16(�6   $��1��6$   $��10q�6M   ��61   �� *
ClientName+6M   �� 57      $��16(�6   $��2��6%   $��Доставка��62   $
��Bold"�6z   $��10q�6�   	 d� 	IsChecked	 6E   �� *IsDeliveryChecked+
 �� Mode$
 TwoWay=�6�   �� 58      $��16(�6   $��3��6&   $"��Адрес доставки:��63   $
��Bold"�6J   �� 59      $��16(�6   $��3��6$   $��10q�6R   ��61   �� *DeliveryAddress+6R   �� 5:      $��16(�6   $��4��6&   $ ��Дата доставки:��63   $
��Bold"�6I   (  "System.Windows.Controls.DatePicker  5;      $��Bottom=�6   $��16(�64   $��4��6B   $��18q�6�      SelectedDate 6O   �� *DeliveryDate+$
 TwoWay=�6�   �� 5<      $y�Hidden=�6   $��16(�6,   $��5��6:   $��10q�6�   ��6G   �� *DeliveryDateOnly+ �� StringFormat$ 
yyyy-MM-dd��6�   �� 5=      $��16(�6   $��6��6#   $��
Поиск��60   $��10,10,634,10q�6b   ��6@   �� *SearchCommand+6b   �� 5?      $��16(�6   $��6��6#   $��Сохранить��60   $��157,10,487,9q�6�   ��6D   �� *SaveCommand+��6d   ��  �� ElementName$ PaymentDetailsWindow��6�   �� 5A      $��16(�6   $��6��6#   $%��Добавить клиента��60   $��312,10,273,9q�6�   ��6K   �� *
AddCommand+��6j   �� $ PaymentDetailsWindow��6�   �� 5C      $��5��6   $
��Bold"�6D   
���  ��$��10q�6g   ��6%   �� *ResultMessage+6g   5D      5E      �� 5G   
   $��35��6k   $��30��6w   $
��Left=�6�   $	��Top=�6�     MaterialDesignIconButton#��[ 6�   ��6   �� *	ExitBtn+��6-   �� $ PaymentDetailsWindow�� � ToolTip 5H      _� 5I      $��Вернуться��6   .��5K      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftBold=�6+   
�������6@   5L      �� 5O   
   $��2��6   $��Center=�6"   $��Bottom=�6?   .+�5P      �� $��© 2023 HouseM��6   
�������6-   5Q      5R      5S      