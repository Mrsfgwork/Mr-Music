   M S B A M L   `   `   `  ����C  ?Mr Music, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5   	       MusicPlayer.AddFolder   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MusicPlayer     5   	     � Title$  
Add Folder��5   	   $��316.15��6   $��567.271��6,    � WindowStyle$
 None=�6<    � AllowsTransparency . $��Center=�6    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   ��6i   Z� .��5	      � $��14q�6   
������� J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6      	Direction$	 280Q�6/      ShadowDepth$ 0Q�6?   	   Opacity$		 0.6Q�6O   
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   $��21��6*   �� 5      .+�5   
   �� -   5         ��Name$ toolbar��5      ���	#FF80D8FF66   A� 5   
   -   5         A�Name$ close��5      ���	#FFEF5350$��16��62   $��Right=�6=   $��0,0,2,0q�6Y    � Cursor$
 Hand��6�    � ToolTip$ Close��6�   $��16��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ 
AddressBar��5      $
��Left=�6&   $��45��6A    �� TextWrapping$
 Wrap=�6M   $��Address��6a   $	��Top=�6p   $	��396��6�   $��	27,57,0,0q�6�   $��1��6�   $��10q�6�   $��16(�6�   ���	#FFF9F9F9���	#FF57BAFF{�.  6�   �� 5   
   -   5         ��Name$ addfolder_btn��5      $��1q�6(   $��Right=�6<   $��45��6X   $	��Top=�6d   $��84��6|   $��	0,57,27,0q�6�   $��1��6�    �� CornerRadius$ 6��6�   
������._�5      �� $��Choose��6   $��Center=�6%   $��Center=�6G   $��16(�6k   
�������$
��Bold"�6�   $
 Hand��6�   $��Center=�6�   $��Center=�6�   5      �� 5   
   $��Choose music folder��6   $
��Left=�6.   $	��Top=�6I   $��1��6a   $��	27,24,0,0q�6n   $��16(�6�   � 5   
   -   5         �Name$ 	colorgrid��5      $��1��6"   $��Bottom=�6/   $��Center=�6J   $��0,0,0,10q�6g   .+�5      �� -   5        $ color1��5      $
 Hand��6%   ���	#FF1E90FF$��1��6J   $��40��6W   $��40��6b   $
��Left=�6n   $��Bottom=�6�   $��
130,0,0,62q�6�   $ 10��6�   6  �� 5      -   5        $ color2��5      $
 Hand��6%   ���	#FFD32F2F$��1��6J   $��40��6W   $��40��6b   $
��Left=�6n   $��Bottom=�6�   $��
130,0,0,17q�6�   $ 10��6�   6  �� 5      -   5        $ color3��5      $
 Hand��6%   ���	#FFFFA726$��1��6J   $��40��6W   $��40��6b   $
��Left=�6n   $��Bottom=�6�   $��
175,0,0,62q�6�   $ 10��6�   6  �� 5      -	   5        $ color4��5      $
 Hand��6%   ���	#FF66BB6A$��1��6J   $��40��6W   $��40��6b   $
��Left=�6n   $��Bottom=�6�   $��
175,0,0,17q�6�   $ 10��6�   6  �� 5      -
   5        $ color5��5      $
 Hand��6%   ���	#FF9C27B0$��1��6J   $��40��6W   $��40��6b   $
��Left=�6n   $��Bottom=�6�   $��
220,0,0,62q�6�   $ 10��6�   6  �� 5      -   5        $ color6��5      $
 Hand��6%   ���	#FFD81B60$��1��6J   $��40��6W   $��40��6b   $
��Left=�6n   $��Bottom=�6�   $��
220,0,0,17q�6�   $ 10��6�   6  �� 5      $��App color : ��6   $
��Left=�6+   $��Bottom=�6F   $��1��6a   $��	27,0,0,46q�6n   $��16(�6�   5       5!      5"      