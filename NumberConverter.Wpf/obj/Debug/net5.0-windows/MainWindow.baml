   M S B A M L   `   `   `  ����N  JNumberConverter.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NumberConverter.WpfNumberConverter.Wpf  5   	   $    NumberConverter.Wpf.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:NumberConverter.Wpf     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5         �Name$ chkCustomBase��5	      .+�5
   
   �� $��Om te zetten getal:��6   $
��Left=�6.   $��
84,221,0,0q�6I   $	��Top=�6]   $��40��6u   $	��149��6�   $��16(�6�   �� 5   
   -   5         ��Name$ txtToConvert��5      $
��Left=�6(   $��
83,261,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��150��6�   $	��137��6�   $��16(�6�   �� 5   
   -   5         ��Name$ 
btnConvert��5      $��Converteren��6%   $
��Left=�6;   $��316,252,0,0q�6V   $	��Top=�6k   $��50��6�   $	��130��6�   $��18(�6�   �� 5   
   -   5         ��Name$ 	lblResult��5      $��
Resultaat:��6#   $
��Left=�68   $��530,222,0,0q�6S   $	��Top=�6h   $	��150��6�   $��39��6�   $��16(�6�   �� 5   
   $��Huidig grondtal:��6   $
��Left=�6+   $��
244,49,0,0q�6F   $	��Top=�6Z   $��36��6r   $	��132��6~   $��16(�6�   �� 5   
   -   5        $ txtBase��5      $
��Left=�6#   $��
392,55,0,0q�6>   $
 Wrap=�6R   $	��Top=�6f   $��72��6~   $��25��6�   $��16(�6�   �� 5   
   -   5         ��Name$ cmbBase��5      $
��Left=�6$   $��
392,52,0,0q�6?   $	��Top=�6S   $��72��6k   $��30��6v   $��16(�6�   �� 5   
   $��Nieuw grondtal:��6   $
��Left=�6*   $��246,105,0,0q�6E   $	��Top=�6Z   $	��136��6r   $��36��6~   $��16(�6�   �� 5   
   -   5        $ 
txtNewBase��5      $
��Left=�6&   $��392,112,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $��72��6�   $��25��6�   $��16(�6�   �� 5   
   -	   5        $ 
cmbNewBase��5      $
��Left=�6'   $��392,109,0,0q�6B   $	��Top=�6W   $��72��6o   $��30��6z   $��16(�6�   �� 5   
   -
   5         ��Name$ chkToggleCustomBase��5      $��Vul zelf grondtal in��60   $
��Left=�6O   $��
596,33,0,0q�6j   $	��Top=�6~   $��21��6�   $	��167��6�   $��16(�6�   �� 5   
   -   5        $ 	txtResult��5      $
��Left=�6%   $��530,261,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��150��6�   $	��137��6�   $��16(�6�   5      5      