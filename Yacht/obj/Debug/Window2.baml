   M S B A M L   `   `   `  ����	  Yacht    Yacht.Window2   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Yacht - Admin��5      $	��600��60   $
��1080��6=    � 
ResizeMode$ NoResize=�6J    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   
������� � 	Resources 5
         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��5   ,   .\�5        $ 0��6'   $ 60Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��5   ,   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 60Q�69   5      5      5      	 � Triggers	 5      :� 5   
   
 :� RoutedEvent$
 ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $
 ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5      �� #��[ 6   5       .��5"      � -   5         �Name$ GridFull��5"      
�������.+�5#   
   � -   5        $ GridMain��5#      $��Right=�6!   $��Bottom=�6=   $	��540��6X   $
��1020��6e   � 5$   
   $��60��6   $	��Top=�6   ���	#FF31577E J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5(      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5*      �� -   5         ��Name$ TbMyName��5*      $��Menu#2��6.   $��Center=�6<   $��16(�6W   5+      '  !MaterialDesignThemes.Wpf.PopupBox  5-         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen . $��10q�6d      PopupContent. 5.      �� $	��150��6!   .+�5/      �� -   5        $��Profil��5/   !   62   �� 50      �� 51      -   5        $��	Kilépés��51   !   63   52      53      54      �� 55      $��Center=�6   $��Center=�65   $��22(�6P   Yacht - Admin6m   56      � 57   
   -   5        $ GridMenu��57      $��60��6!   $
��Left=�6,   ���	#FF31577E 58        59      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5;      �� .+�5<      � $	��150��6   ���	#FF31577E J� RenderTransformOrigin$ 0.5,0.5&�6;   z�5=      V� 5>      .~�5?      �� �� 5@      �� 5A      T� 5B      5C      .+�5E      �� -   5         ��Name$ ButtonOpenMenu��5E      $��60��65   $��60��6A   $��Right=�6L   $	��Top=�5F       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5G      
���������6c   Z� ��5H      Z� .��5I      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�62   $��25��6>   $��25��6I   5J      �� 5K      -   5        $ ButtonCloseMenu��5K      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��Right=�5L      $	��Top=�69   #��[ 5M      
���������6c   Z� ��5N      Z� .��5O        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5P      5S      �� 5T      -	   5         ��Name$ ListViewMenu��5T      
�������$��Disabled=�5U      .@�5W      �� -
   5         ��Name$ ItemHome��5W   #   $��60��65   .��5X      �� $ 
Horizontal=�6%   .+�5Y        $ ViewDashboard=�66   $��25��6K   $��25��6W   $��10q�6b   �� 5Z      $��Adatok Listázása��6(   $��Center=�6@   $��20 10q�6[   5[      5\      �� 5]      
�������6    �� 5^      -   5        $ 
ItemCreate��5^   #   $��60��67   .��5_      �� $ 
Horizontal=�6%   .+�5`        $ Pencil=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5a      $��Regisztráció��6(   $��Center=�6<   $��20 10q�6W   5b      5c      �� 5d      
�������6    �� 5e      $��60��6#   .��5f      �� $ 
Horizontal=�6%   .+�5g        $ Ticket=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5h      $��Kölcsönzések��6(   $��Center=�6<   $��20 10q�6W   5i      5j      �� 5k      
�������6    �� 5l      -   5        $ ItemKimutatas��5l   #   $��60��6:   .��5m      �� $ 
Horizontal=�6%   .+�5n        $ ChartBar=�66   $��25��6F   $��25��6R   $��10q�6]   �� 5o      $��Kimutatások��6(   $��Center=�6;   $��20 10q�6V   5p      5q      5r      5s      5t      5u      5v      