   M S B A M L   `   `   `  ����I  ECapturaPokemon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CapturaPokemon.ServiceCapturaPokemon.Service  5      C&clr-namespace:CapturaPokemon.ViewModelCapturaPokemon.ViewModel  5      $    CapturaPokemon.View.BattleView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6local$clr-namespace:CapturaPokemon.Service     5      5vm&clr-namespace:CapturaPokemon.ViewModel     5      ���#121212.��5      � .+�5   
   �� $��Center=�5      $	��Top=�5      $��100,50,100,120q�5      ��5      �� *Pokemon.ImagePath+  �� Mode$  TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��Center=�5      $	��Top=�5      $��20(�5      $
��Bold"�5      
��� ���$��45��5   $   $	��440��60   ��5      �� *Pokemon.PokemonName+$  TwoWay=�$ PropertyChanged=�5   0   �� 5   
   $��Center=�6   $��Bottom=�62   $��0,0,0,10q�6M   .+�5       ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   $��0,0,0,10q�6j   .+�5!      �� $��20(�5"      $��Attack��5#      $��50��5$      $	��150��5%      
����������#ff4c4c
�������$��2q�5)      $
��Bold"�5*      $��10q�5+      ��5!      �� *Attack_ClickCommand+5+      �� 5-      $��20(�5.      $��Capturar��5/      $��50��50      $	��150��51      
����������#4CAF50
�������$��2q�55      $
��Bold"�56      $��10q�57      ��5-      �� *CapturaCommand+57      �� 59      $��20(�5:      $
��Huir��5;      $��50��5<      $	��150��5=      
����������#ff9800
�������$��2q�5A      $
��Bold"�5B      $��10q�5C      ��59      �� *Huir_ClickCommand+5C      5D      � 5G      $	��440��6   $��20��6   $��
20,10,20,0q�6+   .+�5I      � ���#4CAF50
��� ���
�������$��1q�5L       � Minimum$ 0Q�5M       � Maximum 5N      �� *VidaUsuario+ � Value 5O      �� *
VidaActual+�� 5R      $��Center=�5S      $��Center=�5T      $��14(�5U      
���   ���5R      �� *VidaPorcentaje+5V      5W      5X      �� 5[   
   $
��Left=�6   $	��Top=�60   $��
50,100,0,0q�6H   .+�5\      �� $��35(�5]      $��Center=�5^      
�������$
��Bold"�5`      ��5\      �� *Pokemon.PokeAtaque+$  TwoWay=�$ PropertyChanged=�5`      �� 5a      $��Attack��6   $��25(�5b      $��Center=�5c      
��� ���$
��Bold"�5e      5f      �� 5h   
   $��Right=�6   $	��Top=�61   $��	0,50,10,0q�6I   .+�5j      � $	��150��6   $��50��6   .+�5l      � ���#4CAF50
��� ���
�������$��1q�5o      $��20��5p      $ 0Q�5q      $��Stretch=�5t      $��Center=�5u       5r      �� *VidaMaximaPokemon+ 5s      �� *VidaActualPokemon+5u      �� 5x      $��Center=�5y      $��Center=�5z      $��14(�5{      
���   ���5x      �� *VidaPorcentajePokemon+5|      5}      �� 5�      $��HP��6   $��25(�5�      $��Center=�5�      
���/���$
��Bold"�5�      5�      5�      5�      