   M S B A M L   `   `   `  ����B  >kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kursach.Viewkursach.View  5   	   )    #kursach.View.ReportGenerationWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   MmaterialDesignIcons1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   (localclr-namespace:kursach.View   5   	   -   5        $��RGWnd��5   "     � Title$%  Создание отчетов��6	   $	��450��6/   $	��800��6<    � WindowStartupLocation$ CenterScreen=�6H    � 	Resources 5       �� MergedDictionaries+  %MaterialDesignThemes.Wpf.BundledTheme   	BaseTheme   PrimaryColor   SecondaryColor �� Source�� 5   
    5        5      	 Light6.    
DeepPurple6@    Lime6Z   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $��* �6   �� 5!      $��* �6   .+�5#   
   �� $��0��6   ���#41024D.+�5$      �� $%��Создание отчетов��6   $��Center=�60   $��20(�6M   
�������6[   5%      �� 5&   
   $��16(�6   $��1��6!   $��10q�6.   $	��200��6:   ��5'      �� *ReportTypes+	 �� SelectedItem	 5(      �� *SelectedReportType+��5)      �� 5*      .R�5+      �� ��6    �� 5,      5.      (  "System.Windows.Controls.DatePicker  50   
   $��16(�6   $��2��6#   $��10q�60   $	��200��6<   
   SelectedDate
 51      �� *SelectedPeriodStartDate+ �� Mode$ TwoWay=��� 52   
   $��16(�6   $��2��6"   $	��100��6/   $��10q�6�   ��6;   �� *SelectedPeriodStartDateOnly+ �� StringFormat$ 
yyyy-MM-dd��6�     54   
   $��16(�6   $��3��6#   $��10q�60   $	��200��6<   
 55      �� *SelectedPeriodEndDate+$ TwoWay=�6S   �� 56   
   $��16(�6   $��3��6#   $	��100��60   $��10q�6�   ��6<   �� *SelectedPeriodEndDateOnly+$ 
yyyy-MM-dd��6�   �� 58   
   $��16(�6   $��4��6!   $��10q�6.   $	��200��6:   ��59      �� *ExportFormats+	 5:      �� *SelectedExportFormat+��5;      �� 5<      .R�5=      �� ��6    �� 5>      5@      �� 5B   
   $��5��6   $��10q�6   $	��100��6+   $��30��67   $��Сохранить��5C      ��6%   �� *GenerateReportCommand+�� 5E   
   $��35��6\   $��30��6h   $
��Left=�6s   $	��Top=�6�      MaterialDesignIconButton#��[  6�   ��6   �� *	ExitBtn+��6-   ��  �� ElementName$ RGWnd�� � ToolTip 5F      _� 5G      $��Вернуться��6   .��5I      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftBold=�6+   
�������6@   5J      �� 5L   
   $��7��6   $��Center=�6"   $��Bottom=�6?   .+�5M      �� $��© 2023 HouseM��6   
�������6.   5N      5O      5P      