   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.Converterkursach.Converter  5	   	   5clr-namespace:kursach.Converterkursach.Converter  5
   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  5   	       kursach.View.Products   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:kursach.View     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   3converters1clr-namespace:kursach.Converter   5	   	   3converters2clr-namespace:kursach.Converter   5
   	   1	viewmodelclr-namespace:kursach.ViewModel   5   	   -   5        $��
WndProduct��5        � Title$  Товары��6	   $	��500��6*   $	��930��67    � WindowStartupLocation$ CenterScreen=�6C    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source!  kursach.Converter.Converter   	Converter.   (kursach.Converter.StockQuantityConverter  StockQuantityConverter�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %:   &	        &	        5      68     5      6R   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5%   
   �� $��0��6   ���#41024D$��0 0 0 1q�67   .+�5&      �� $��Center=�6   $	��Top=�65   $'��!Каталог продуктов��6M   $��20(�6f   
�������6t   5'      �� 5*   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��16q�6;   .+�5+      �� $��16(�6   $��Сортировка:��6&   $��Center=�69   $��0 0 8 0q�6T    " MaterialDesignCaptionTextBlock#��[ 6e   �� 5,      $��16(�6   
 �� DisplayMemberPath$
 DisplayName��6I   $	��200��6�   $��0 0 16 0q�6�     MaterialDesignComboBox#��[ 6�   ��6%   �� *SortOptions+ �� SelectedItem 6i   �� *SelectedSortOption+6�   �� 5-      $��16(�6   $��Категория:��6&   $��Center=�68   $��0 0 8 0q�6S   #��[ 6d   �� 5.      $��16(�6   $
 Namingcategory��6r   $	��200��6�   $��0 0 16 0q�6�   #��[ 6�    �� MaxDropDownHeight$	 150��6�   ��6%   �� *
Categories+ 6H   �� *SelectedCategory+6�   �� 5/      $��16(�6   $	��200��6e   $��0 0 16 0q�6q     MaterialDesignTextBox#��[ 6�   ��6$   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 50      $��80��67   $��0 0 16 0q�6B     MaterialDesignFlatButton#��[ 6T   ��6   �� *SearchCommand+ � ToolTip 51      _� 52      $��
Найти��6   .��54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6/   ���#41024D6>   55      56      �� 58      $��3��6   $��16q�6p   ��6#   �� *LstProducts+ 6G   �� *SelectedProduct+��59      �� 5:       �� 
TargetType" ��6   .�5;      ��  �� Property � �� �� Value
 �����68   �� 5<       � ��$ 2q�6<   �� 5=       � ��$ 4q�64   �� 5>       � ��
 �����67   �� 5?       � �� 5@      �� 5A   "    �� 
TargetType" ��62   .R�5B   &   ��  ��Name$ Border��6-   #��z��6=   #��z��6i    �� CornerRadius$ 5��6�   #��z��6�   ._�5C   *   �� 5D   '    �� Triggers 5E   &   P� 5F   *    P� Property �@��
IsSelected P� Value$
 True��6H   . �5G   .   ��  �� 
TargetName$ Border��65    � �� �#EDE1F36_   5I   +   5K   #   5M      5N      ��5P      �� 5Q      .R�5R      �  � ColumnDefinitions 5S      �� 5T   "   $��* �63   �� 5U   "   $
��Auto �63   .+�5X      �� $��0��6)   $��10q�69   .+�5Y   "   �� $
��Bold"�6I   $��18(�6[   $��0 0 0 4q�6i   ��6,   ��  �� Path$ Naming�6i   �� 5Z      $��16(�6(   $��0 0 0 4q�66   �� 5[   "   $�
Цена: ��6&   $
��Bold"�64    �� 5\   "   �6&   �� $ Price�5]      �� 5^      $��16(�6(   $��CharacterEllipsis=�67   �� 5_   "   $�Описание: ��6&   $
��Bold"�68    �� 5`   "   �6&   �� $ Description�5a      �� 5b      $��16(�6(   $��CharacterEllipsis=�67   �� 5c   "   $.�(Количество на складе: ��6&   $
��Bold"�6D    �� 5d   "   �6&   �� $ Stockquantity� �� 	Converter# [ ��5e   "   �� 5f   &   " ��6,   .�5g   *   ��  � ��
 �   �6G    �� Triggers 5h   *   �� 5i   .    �� Binding 6:   �� $ Stockquantity� �� Value 06a   .a�5j   2   ��  � ��
 �  ��6O   5k   /   5m   '   5o      5p      �� 5r      $��1��6)   $��Right=�69   $��Center=�6U   .+�5s   "   �� $	 
Horizontal=�6-   .+�5t   &   �� )  #MaterialDesignThemes.Wpf.HintAssist    Hint$  0��6.   ! �� TextAlignment$! Center=�6�   $��60��6�   ��6Q   �� *DataContext.TbCount+" �� RelativeSource" �� # �� AncestorType# ListBox6�   �� 5u   &   #��[ 6�   ��6/   �� *DataContext.BtnAddToCart+" �� # ListBox 5v   *   _� 5w   .   $(��"Добавить в корзину��66   .��5y   *     $ CartAdd=�6G   $��30��6V   $��30��6a   ���#41024D6m   5z   '   5{   #   5|      5}      5~      5�      �� 5�   
   $��35��6a   $��30��6m   $
��Left=�6x   $	��Top=�6�     MaterialDesignIconButton#��[ 6�   ��6   �� *	ExitBtn+��6-   �� $ �� ElementName$$ 
WndProduct�� 5�      _� 5�      $��Вернуться��6   .��5�        $ ArrowLeftBold=�6+   
�������6@   5�      �� 5�   
   $��35��6e   $��35��6q   $��Right=�6|   $��Center=�6�   #��[ 6�   ��6   �� *GoToCartBtn+��61   �� $$ 
WndProduct�� 5�      _� 5�      $&�� Перейти в корзину��6   .��5�      � .+�5�        $ 	CartCheck=�6/   
�������6@   �� 5�      
�������$��Center=�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $��0,19,0,0q�6�   ��6   �� *$"DataContext.SelectedProducts.Count+" �� 
# Window6�   5�      5�      �� 5�   
   $��3��6   $��Center=�6"   $��Bottom=�6?   .+�5�      �� $��© 2023 HouseM��6   
�������6-   5�      5�      5�      