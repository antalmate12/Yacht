   M S B A M L   `   `   `  ����	  Yacht    Yacht.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Yacht - Tag��5      $	��600��6.   $
��1080��6;    � 
ResizeMode$ NoResize=�6H    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
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
 ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5      �� #��[ 6   5       .��5#      � -   5         �Name$ GridFull��5#      
�������.+�5$   
   � -   5        $ GridMain��5$      $��Right=�6!   $��Bottom=�6=   $	��540��6X   $
��1020��6e   � 5%   
   $��60��6   $	��Top=�6   ���	#FF31577E J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5)      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5+      �� -   5         ��Name$ TbMyName��5+      $��Menu#2��6.   $��Center=�6<   $��16(�6W   5,      '  !MaterialDesignThemes.Wpf.PopupBox  5.         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen . $��10q�6d      PopupContent. 5/      �� $	��150��6!   .+�50      �� -   5        $��Profil��50   !   62   �� 51      -   5        $��Kölcsönzéseim��51   !   69   �� 52      �� 53      -   5        $��	Kilépés��53   !   63   54      55      56      �� 57      $��Center=�6   $��Center=�65   $��22(�6P   Yacht - Tag6k   58      � 59   
   -   5        $ GridMenu��59      $��60��6!   $
��Left=�6,   ���	#FF31577E 5:        5;      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5=      �� .+�5>      � $	��150��6   ���	#FF31577E J� RenderTransformOrigin$ 0.5,0.5&�6;   z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C      T� 5D      5E      .+�5H      �� -   5         ��Name$ ButtonOpenMenu��5H      $��60��65   $��60��6A   $��Right=�6L   $	��Top=�5I       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5J      ���	#FF31577E��6c   Z� ��5K      Z� .��5L      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�62   $��25��6>   $��25��6I   
�������6U   5M      �� 5O      -	   5        $ ButtonCloseMenu��5O      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��Right=�5P      $	��Top=�69   #��[ 5Q      
���������5R      Z� ��63   Z� .��5T        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5U      5W      �� 5Y      -
   5         ��Name$ ListViewMenu��5Y      
�������$��Disabled=�5Z      .@�5]      �� -   5         ��Name$ ItemHome��5]   #   $��60��65   .��5^      �� $ 
Horizontal=�6%   .+�5_        $ 	ShipWheel=�66   $��25��6G   $��25��6S   $��10q�6^   �� 5`      $��Hajóim��6(   $��Center=�66   $��20 10q�6Q   5a      5b      �� 5c      �� 5d      -   5        $ ItemHajoKolcs��5d   #   $��60��6:   .��5e      �� $ 
Horizontal=�6%   .+�5f        $ Pencil=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5g      $��Hajó Kölcsönzés��6(   $��Center=�6?   $��20 10q�6Z   5h      5i      �� 5j      �� 5k      -   5        $ 	ItemKolcs��5k   #   $��60��66   .��5l      �� $ 
Horizontal=�6%   .+�5m        $ Ticket=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5n      $��Kölcsönzéseim��6(   $��Center=�6=   $��20 10q�6X   5o      5p      �� 5q      �� 5r      -   5        $ ItemKimutatas��5r   #   $��60��6:   .��5s      �� $ 
Horizontal=�6%   .+�5t        $ ChartBar=�66   $��25��6F   $��25��6R   $��10q�6]   �� 5u      $��Kimutatások��6(   $��Center=�6;   $��20 10q�6V   5v      5w      5~      5      5�      5�      5�      