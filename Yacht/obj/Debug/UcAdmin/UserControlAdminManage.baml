   M S B A M L   `   `   `  ����	  Yacht"    Yacht.UserControlAdminManage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��540��5      $
��1020��6,   .��5
      � -   5        
�������.+�5   
   �� -   5          ��Name$  TbTagok��5      $��Felhasználók listája��6%   
�������$��36(�6T   $	��Top=�6b   $��Stretch=�5      ���	#FF31577E �� TextAlignment$
 Left=�6I   �� 5   
   -   5        $  TbHajok��5      $��Hajók listája��6&   
�������$��36(�6N   $	��Top=�6\   $��Stretch=�5      ���	#FF31577E$ Center=�6I   $y�Hidden=�6`   �� 5   
   -   5        $  TbKolcs��5      $��Kölcsönzések listája��6%   
�������$��36(�6T   $	��Top=�5      $��Stretch=�5      ���	#FF31577E$ Center=�6I   $y�Hidden=�6`   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MyDataGridTag��5      $
��Left=�6*   $	��433��6E   $��Bottom=�6R   $
��1020��5         
IsReadOnly . 5        5   
   -   5        $ MyDataGridKolcs��5      $
��Left=�6,   $	��433��6G   $��Bottom=�6T   $
��1020��5       . $y�Hidden=�5   %     5   
   -   5        $ MyDataGridHajo��5      $
��Left=�6+   $	��433��6F   $��Bottom=�6S   $
��1020��5       . $y�Hidden=�62      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$
 Kép��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 67      MinWidth$ 64Q�6D      CellTemplate 5!      �� 5"      .R�5#      �� ��6$   �� *Kep+5$      5&      5(      o� 5*   
   $��54��6   $
��Left=�6   $	��Top=�66   $��0,53,0,0q�6N   .@�5+      �� -   5        $��Tagok��5+      6%   �� 5,      -	   5        $��Hajók��5,      6%   �� 5-      -
   5        $��Kölcsönzések��5-      6,   5.      50      51      