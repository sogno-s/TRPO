   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  5	   	   "    kursach.View.AdminAddProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aMmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   (localclr-namespace:kursach.View   5   	   HmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   1	viewmodelclr-namespace:kursach.ViewModel   5	   	   -   5        $��AddProd��5   $     � Title$)  #Добавление товаров��6	   $	��450��63   $	��800��6@    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source �� 
TargetType   MaterialDesignTextBox	 �� BasedOn
 �� Property �� Value  MaterialDesignComboBox�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %  '��       7   '�� s     7  �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      �� 5      " ��6   8	   .�5      �� 
 � ��$	 0 8q�6+   �� 5      
 � ��$	 250��6*   5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   .+�5'   
   �� $��0��6   ���#41024D.+�5(      �� $-��'Добавление продуктов��6   $��Center=�64   $��20(�6Q   
�������6_   5)      �� 5*   
   $��30��6   $��30��6j   $
��Left=�6u   $	��Top=�6�     MaterialDesignIconButton#��[ 6�   ��6   �� *	ExitBtn+��69   ��  �� ElementName$ AddProd�� � ToolTip 5+      _� 5,      $��
Выход��6   .��5.      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftBold=�6+   
�������6@   5/      �� 50   
   $��1��6   .��51      �� $��16q�6   .+�52      �� .+�53      �� 
�������$��Категория��67   $
��Bold"�6H   $��18(�6Z   $
��0 16q�6h   �� 54       �� DisplayMemberPath$ Namingcategory��6   $��16(�6B   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$@ :Выбрать существующую категорию��6�    �� MaxDropDownHeight$	 150��6�   ��6P   �� *CategoryName+ �� SelectedItem 6u   �� *SelectedCategory+6�   �� 55       �� Orientation$ 
Horizontal=�6!   .+�56      �� $��16(�6"   $��	250 0 0 0q�60   $4 .Добавить новую категорию��6d   ��6C   �� *NewCategoryName+6d   �� 57      $��30��6!   $��10 0 0 0q�6-   $��30��6c   $��Center=�6n   $��Center=�6�   #��[ 6�   ��6?   �� *AddNewCategory+ 58      _� 59   "   $��
Выход��6*   .��5;        $	 Add=�6;   
��� d �6F   5<      5=      5>      �� 5@      .+�5A      �� 
�������$"��Номер на складе��68   $
��Bold"�6O   $��18(�6a   $
��0 16q�6o   �� 5B      $ Inventorynumber��6   $��16(�6C   $5 /Инвентаризационный номер��6�   $	 150��6�   ��6Q   �� *InventoryNumbers+ 6z   �� *SelectedInventoryNumber+6�   �� 5C      $ 
Horizontal=�6!   .+�5D      �� $��16(�6"   $��	250 0 0 0q�60   $, &Добавить новый номер��6g   ��6C   �� *NewNumberInventory+6g   �� 5E      $��30��6!   $��10 0 0 0q�6-   $��30��6a   $��Center=�6l   $��Center=�6�   #��[ 6�   ��6?   �� *AddNewNumber+ 5F      _� 5G   "   $��
Выход��6*   .��5I        $	 Add=�6;   
��� d �6F   5J      5K      5L      �� 5N      .+�5O      �� 
�������$��Информация��68   $
��Bold"�6J   $��16(�6\   $
��0 16q�6j   �� 5P      $��16(�6   $ Название��6I   ��6,   �� *ProductName+6I   �� 5Q      $��16(�6   $  Произдодитель��6J   ��6,   �� *Manufacturer+6J   �� 5R      $��16(�6   $ Цена��6C   ��6,   �� *Price+6C   �� 5S      $��16(�6   $ Описание��6I   ��6,   �� *Description+6I   5T      �� 5V      $��Добавить��6   $
��0 16q�6S   ��6,   �� *AddProductCommand+6S   �� 5X      $��2��6   $��Center=�6*   $��Bottom=�6G   .+�5Y      �� $��© 2023 HouseM��6    
�������65   5Z      5[      5\      5]      5^      