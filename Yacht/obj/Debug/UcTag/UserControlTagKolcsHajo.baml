   M S B A M L   `   `   `  ����	  Yacht)    #Yacht.UcTag.UserControlTagKolcsHajo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��540��5      $
��1020��6,   .��5      � 
�������.+�5	   
   �� $��Hajó Kölcsönzése��6   ���	#FF31577E
�������$��36(�6V   $	��Top=�5
      $��Stretch=�6,   � 5   
   ���	#FF31577E$	��410��6&   $��70��62   $	��Top=�6>   $
��Left=�6V   $��	10,60,0,0q�5      .+�5      � 
�������$	��400��6&   $��60��62   $��Center=�6>   $��Center=�6Y     � ColumnDefinitions  5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      .+�5      �� ���	#FF31577E$��
Mikortól?��63   $��0��6D   $��0��6Q   
�������6a   �� 5      ���	#FF31577E$��Meddig?��63   $��1��6B   $��0��6O   
�������6_   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DpMettol��5      $��0��6/   $��1��6<   
���   �6L     5      -   5        $ DpMeddig��5      $��1��6/   $��1��6<   
���   �6L   5      5      �� 5   
   -   5         ��Name$ 
ButtonList��5   (   ���	#FF31577E$��
Listázás��6<   $
��Left=�6O   $��
425,98,0,0q�5       $	��Top=�6%   6=   � 5#   
   $
��1020��6   $	��405��6   $��Stretch=�6)   $��Bottom=�6G     5$      �� 5%      $��* �6#   �� 5&      $	��200 �6#   .+�5)      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridHajo��5)      $��0��6-   $   HorizontalScrollBarVisibility$ Visible=�5*      "   VerticalScrollBarVisibility$ Visible=�6?      Columns 5+      4  .System.Windows.Controls.DataGridTemplateColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$
 Kép��6-   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 200 6:   
   MinWidth$
 64Q�6F      CellTemplate 5-      �� 5.      .R�5/   "   �� ��6(   �� *Kep+50      52      54      �� 56      $
��Wrap=�6   $��Stretch=�6,   $P��JKölcsönzéshez válasszon hajót, majd uticélt éskattintson a pipára.��57      
���   �$��1��58      $��10,0,10,364q�6(   �� 59      $��1��6   $��Uticél��6(   
���   �$��10,46,10,332q�6I   �� 5:      -   5         ��Name$ TbHova��5:      $��Stretch=�6&   $��Center=�6D   $��10,0,10,224q�6_   
���   �$��1��5<      �� 5=      -   5        $ AcceptButton��5=   #   $
��10,0q�6   $��1��69   .��5>      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Check=�6*   $��Center=�67   5?      5A      5C      5D      