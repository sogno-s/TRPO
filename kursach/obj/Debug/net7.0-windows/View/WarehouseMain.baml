   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  62        kursach.View.WarehouseMain   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   (localclr-namespace:kursach.View   5   	   1	viewmodelclr-namespace:kursach.ViewModel   62   -   5        $��WarWnd��5
        � Title$  
Склад��6	   $	��450��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6?    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#41024D.+�5      �� $��Прием товаров��6   $��Center=�6-   $��20(�6J   
�������6X   5      �� 5    
   $��30��6   $��30��6i   $
��Left=�6t   $	��Top=�6�      MaterialDesignIconButton#��[  6�   ��6   �� *	ExitBtn+��69   �� 	 �� ElementName$	 WarWnd��
 � ToolTip
 5!      _� 5"      $��
Выход��6   .��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftBold=�6+   
�������6@   5%      � 5'   
   $��1��6   .+�5)      ]� $
��True��6   .+�5*      �� $	��Top=�6   $��Center=�62   $	��200��6O   
������� �� Orientation$ Vertical=�6r   .+�5+      �� $��Принять��6   $��16 25 16 16q�6/   ��6D   �� *AcceptProductCommand+5,      �� 5-      $��Right=�6   $��16q�64   $	��300��6@   .+�5.      ��  �� MaxDropDownHeight$	 150��6    $��16(�6Z    �� DisplayMemberPath$ Naming��6h   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Выбор поставщика��6�   ��68   �� *	Suppliers+ �� SelectedItem 6�   �� *SelectedSupplier+6�   �� 5/      $��16(�6B   $	��0 8q�6P    �� 
IsReadOnly$
 True��6]   $G AФамилия ответственного за поставку��6o   ��6   �� *ResponsibleSurname+6o   �� 50      $	 150��6   $��16(�6_   $ Inventorynumber��6m   $5 /Инвентаризационный номер��6�   ��67   �� *InventoryNumber+ 6�   �� *SelectedNumber+6�   �� 51      $	��0 8q�6>   $��16(�6K   $# Название товара��6Y   ��6   �� *NewProductName+6Y   �� 52      $	��0 8q�68   $��16(�6E   $ Количество��6S   ��6   �� *
Quantity+6S   53      54      55      �� 58   
   $��2��6   $��Center=�6"   $��Bottom=�6?   .+�59      �� $��© 2023 HouseM��6   
�������6-   5:      5;      5<      