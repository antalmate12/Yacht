   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      	 Yacht   Yacht.UcKozos.ucKimutatas   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dwpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      $	��540��5      $
��1020��6,   
�������.��5	      � -   5        $��15, 20, 15, 15q�5	      $	��350��6#   $	��400��63     J� Effect  5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6      	Direction$	 -90Q�6/      RenderingBias$ Quality=�6?      Opacity$ .2Q�6W      ShadowDepth$ 1Q�6d    J� OpacityMask 5   
   !� 5       !� Visual 6   ��  �� ElementName$ Border2��	 � 	Resources	 5   
   !   LiveCharts.Wpf.ColumnSeries
 �� 
TargetType   LiveCharts.Wpf.Series �� Property �� Value   LiveCharts.Wpf.Axis �� Triggers P� Property P� Value   LiveCharts.Wpf.Separator��%v  '        '  �     '  .    �� 5      "
  6   .�5      ��  �@ StrokeThickness$ 0Q�64   6@   �� 5       �@ Stroke
 �����6;   �� 5       �@ Fill
 �����69   �� 5       �@ MaxColumnWidth$ 5Q�63   6?   5      �� 5      "
  6   .�5      ��  �@ FontSize$ 12Q�6-   6:   �� 5       �@ 
Foreground �	#64FFFFFF6C    5      P� 5       �@ AxisOrientation$ y=�69   . �5      ��  �@ IsMerged .  6E   �� 5       MaxValue�� �@ MaxValue$ 10Q�6G   6T   5"      5$      �� 5%      "
  6   .�5&      ��  �@ StrokeThickness$ 1Q�64   6@   �� 5'       �@ Stroke �	#4BFFFFFF6?    5(      P� 5)       �@ AxisOrientation$ X=�69   . �5*      ��  � {� .  6F   �� 5+       �@ Step$ 1Q�61   6=   5,      5.      5/       � RowDefinitions 50   
   �� 51      $
��Auto �6   6,   �� 52      $
��Auto �6   6,   �� 53      $
��.50* �6   6,   .+�55   
   �� -   5         ��Name$ Border2��55      $��0��6"   $��3��6/    �� CornerRadius$ 10��6@   
�������6R   �� 57   
   $��0��6   $��3��6   ���#2196f36G   �� 59   
   $��
Time Power��6   $��0��6&    �� TextAlignment$ Center=�63    �� Padding$ 10, 10, 0, 5q�6J   
�������$��24(�5:      #   LiveCharts.Wpf.CartesianChart  5<   
   -   5        $��TimePowerChart��5<      $��2��63   $��10, 0, 10, 20q�6@   &    LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     DataTooltip 5=      Z�    Series 5?        -   5          Name$ Adatok��5?   #      Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 	1,5,8,2,9 63   5A      5C      5D      