   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   5clr-namespace:kursach.ViewModelkursach.ViewModel  62       kursach.View.CartWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   (localclr-namespace:kursach.View   5   	   1	viewmodelclr-namespace:kursach.ViewModel   62   -   5        $��CartWnd��5        � Title$  Корзина��6	   $	��450��6(   $	��800��65    � WindowStartupLocation$ CenterScreen=�6A    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source �� 
TargetType   MaterialDesignRaisedButton	 �� BasedOn  ContinueButtonStyle
 �� Property �� Value �� Triggers �� Binding �� Value�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %  '��       7   &	 "     7   �� 5      " ��6   8	   6(   �� 5      " ��6   8	   .�5      �� 
 � y�$ Visible=�6/    5      �� 5       6"   �� *	ShowPopup+ True6@   .a�5      �� 
 � y�$ 	Collapsed=�67   5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6    � ColumnDefinitions 5&   
   �� 5'      $��* �6   �� 5(      $
��Auto �6   .+�5+   
   �� $��0��6   $��2��6"   ���#41024D$��0 0 0 1q�6K   .+�5,      �� $��Center=�6   $	��Top=�65   $��Корзина��6M   $��20(�6\   
�������6j   5-      �� 5/   
   $��1��6   $��16q�6k   ��6   �� *	CartItems+ �� SelectedItem 6A   �� *SelectedCartItem+��50      �� 51      " ��6   .�52      �� 
 � ��
 �����64   �� 53      
 � ��$ 2q�68   �� 54      
 � ��$ 4q�60   �� 55      
 � ��
 �����63   �� 56      
 � �� 57      �� 58       �� 
TargetType" ��6.   .R�59   "   ��  ��Name$ Border��6)   #��z��69   #��z��6e    �� CornerRadius$ 5��6�   #��z��6�   ._�5:   &   �� 5;   #    �� Triggers 5<   "   P� 5=   &    P� Property �@��
IsSelected P� Value$
 True��6D   . �5>   *   ��  �� 
TargetName$ Border��61   
 � �� �#EDE1F36[   5@   '   5B      5D      5E      ��5G      �� 5H      .R�5I      �  5J      �� 5K      $��* �6/   �� 5L      $
��Auto �6/   �� 5M      $
��Auto �6/   .+�5P      �� $��0��6%   $��10q�65   .+�5Q      �� $
��Bold"�6C   $��18(�6U   $��0 0 0 4q�6c   ��6(   ��  �� Path$
 Name�6c   �� 5R      $��16(�6(   $��0 0 0 4q�66   �� 5S   "   $�
Цена: ��6&   $
��Bold"�64    �� 5T   "   �6&   �� $ Price�5U      �� 5V      $��16(�6(   $��CharacterEllipsis=�67   �� 5W   "   $�Количество: ��6&   $
��Bold"�6:    �� 5X   "   �6&   �� $ Count�5Y      5Z      �� 5\      $��1��6%   $��Right=�65   .+�5]      ��   MaterialDesignIconButton#��[ 6�   ��6%   �� *#!DataContext.RemoveCartItemCommand+ �� RelativeSource ��  �� AncestorType ListBox � ToolTip 5^   "   _� 5_   &   $��Удалить��6.   .��5a   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�6:   $��20��6H   $��20��6S   5b      5c      5d      5e      5g      �� 5i   
   
�������$��1��6-   $��2��6:   $��Right=�6J   $��Center=�6f   .+�5j      �� $��16(�6   $%��Оплата наличными��6z   $��16 25 16 16q�6�   ��6#   �� *PayWithoutCardBtn+��6I   ��  �� ElementName$ CartWnd����5k      �� 5l      " ��6   #	 [  60   .�5m      �� 
 � y�$ Visible=�67    5n      �� 5o       6*   �� *	ShowPopup+ True6H   .a�5p   "   �� 
 � y�$ 	Collapsed=�6?   5q      5s      5u      �� 5v      $��16(�6   $��Оплата картой��6v   $��16 25 16 16q�6�   ��6#   �� *PayWitCardBtn+��6E   �� $ CartWnd����5w      �� 5x      " ��6   #	 [  60   .�5y      �� 
 � y�$ Visible=�67    5z      �� 5{       6*   �� *	ShowPopup+ True6H   .a�5|   "   �� 
 � y�$ 	Collapsed=�6?   5}      5      5�      �� 5�      $
��Left=�6O   $��Center=�6j   $��16(�6�   $��0 0 16 0q�6�   $
��Bold"�6�   ��6   �� *
TotalPrice+ �� StringFormat$ Итого: {0}��6�   5�      �� 5�   
   $��35��6^   $��30��6j   $
��Left=�6u   $	��Top=�6�   #��[ 6�   ��6   �� *	ExitBtn+��6-   �� $ CartWnd�� 5�      _� 5�      $��Вернуться��6   .��5�        $ ArrowLeftBold=�6+   
�������6@   5�      � 5�   
   -   5          �Name$  popup��5�      $��Center=�6<   ��6   �� *	ShowPopup+.��5�      �� 
�������$��1q�6(   
�������$	��200��6O   $	��150��6[   $��Center=�6h   $��Center=�6�   ._�5�      �� $��10q�6   .+�5�      �� -   5        ! ��Name$! deliveryCheckbox��5�      $!��Нужна доставка��6m   $��10q�6�   " d� 	IsChecked" 69   �� *DeliveryCheckBox+# �� Mode$# TwoWay=�6�   �� 5�      $��Продолжить��6   $��10q�62   #��[  6�   ��6>   �� *ContinueCommand+��6b   �� $ CartWnd�� 5�      _� 5�      $��Продолжить��6&   5�      5�      5�      5�      �� 5�   
   $��2��6   $��Center=�6"   $��Bottom=�6?   .+�5�      �� $��© 2023 HouseM��6   
�������6-   5�      5�      5�      