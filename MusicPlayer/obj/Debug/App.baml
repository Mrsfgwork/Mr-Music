   M S B A M L   `   `   `  ����C  ?Mr Music, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  5      ?$clr-namespace:MusicPlayer.PropertiesMusicPlayer.Properties  5          MusicPlayer.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:MusicPlayer     5      ;
properties$clr-namespace:MusicPlayer.Properties     5        �� 	Resources  5         SliderRepeatButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius  SliderRepeatButton1 J� SnapsToDevicePixels%  MusicPlayer.Properties.Settings   Default	 �� Source
 �� Path �� Mode  SliderThumb A�Name 
 Slider � RowDefinitions ]�Name ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  Horizontal_Slider �� Triggers P� Property P� Value  ScrollThumbs �Name �� Triggers �� 
TargetName n�Name ��Name J� Opacity P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle��%�  &	        &	 s    &	 �    &	 8    7  7  7   &	 �    7  &	 6    '�� �	    �� 5	   
   " ��6+   .�5
      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       � �� .  6*   �� 5       � |� .  6*   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ full_bar��6!   ���	#FFD1D1D1$��6��6J   $ 2��6U   5      5      5      �� 5   
   " ��6,   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ back_bar��6!    . $��6��6�   $ 2��6�   ��6N   �� #	 Z $
 Theme�$ TwoWay=�6�   5      5       5!      �� 5#   
   " n�6$   .�5$      ��  �@J�SnapsToDevicePixels . 64   �� 5%       �@�OverridesDefaultStyle . 66   �� 5&       � �� 5'      �� 5(      " n�6&   .R�5)      A� $ 
circle_bar��6"   $��20��66   $��20��6B   
�������$��2��6�   ��6Z   �� #	 Z $
 Theme�$ TwoWay=�6�   5*      5,      5-      �� 5/   
   " ��6*   .R�50      �  51      �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   #��z��62   �� 54      $
��Auto �6$   .+�56      ]� $ 
PART_Track��6%   $��1��6    57      �� 58      8��  $��Slider.DecreaseLarge��6U    5:      n� 5;      8�� 6     5=      �� 5>      8�� $��Slider.IncreaseLarge��6S   5@      5A      5B      �� 5D   
   " ��6*   .�5E      ��  � |� .  6*   �� 5F       �@J�SnapsToDevicePixels . 64   �� 5G       �@�OverridesDefaultStyle . 66    5H      P� 5I       �@��Orientation$ 
Horizontal=�61   . �5J      ��  � ��$ 21��62   �� 5K       � ��$	 104��61   �� 5L       � ��8   61   5M      5O      �� 5R   
   " n�6%   .�5S      ��  � �� 5T      �� 5U      " n�6&   .R�5V      � $
 Grid��6   .+�5W      �� $��Stretch=�6(   $��Stretch=�6F   $
��Auto��6b   $
��Auto��6o   ��6}   Z� �� 5X      $ 
Rectangle1��6%   $ 4��69   $��Stretch=�6J   $��Stretch=�6h   $
��Auto��6�   $
��Auto��6�   ��6�   �� #	 Z $
 Theme�$ TwoWay=�5Y       5Z      P� 5[       �@�Tag$ 
Horizontal��65   . �5\   "   �� $ 
Rectangle1��6)    � ��$
 Auto��6R   �� 5]   "   $ 
Rectangle1��6)    � ��$ 7��6S   5^      5`      5b      5c      �� 5f   
   " ��6+   .�5g      ��  �@��IsFlicksEnabled .  67   �� 5h       � ��
 �����6+   �� 5i       � �� 6+   Z� �� 5j       � ��$ 10��6&   �� 5k       � �� 5l      �� 5m      " ��6&   .R�5n      � $ GridRoot��6   $��6��61   
������� 5o      �� 5p   "   $��0.00001* �60   .+�5s      ]� $ 
PART_Track��6$   $��0��68   ��. |�.   5t   "   n� 5u   &   $ Thumb��6,   #��z��6;   #���  6e    5w   "   �� 5x   &   $ PageUp��63   $��ScrollBar.PageDownCommand��6C   $ 0Q�6g   |�.  6s    5z   "   �� 5{   &   $ PageDown��63   $��ScrollBar.PageUpCommand��6E   $ 0Q�6g   |�.  6s   5}      5~       5�      P� 5�      $ Thumb��6&    �@J�IsMouseOver . . �5�   "   �� # �  6)   $ Thumb��6U    � ��6h   5�      P� 5�      $ Thumb��6&    �@n�
IsDragging . . �5�   "   �� # �  6)   $ Thumb��6M    � ��6`   5�      P� 5�       � {� .  . �5�   "   �� $ Thumb��6)    � y�$ 	Collapsed=�6R   5�      P� 5�       �@��Orientation$ 
Horizontal=�6=   . �5�   "   �� $ GridRoot��6)    �@�LayoutTransform 5�   &   �� 5�   *   $	 -90Q�6:   5�   #   �� 5�   "   $ 
PART_Track��6)    �@�LayoutTransform 5�   &   �� 5�   *   $	 -90Q�6:   5�   #   �� 5�   "    � ��$
 Auto��6:   �� 5�   "    � ��$ 12��6;   �� 5�   "   $ Thumb��6)    �@�Tag$ 
Horizontal��6K   �� 5�   "   $ PageDown��6)    � ��$ ScrollBar.PageLeftCommand��6R   �� 5�   "   $ PageUp��6)    � ��$  ScrollBar.PageRightCommand��6P   5�      5�      5�      5�      5�      5�      