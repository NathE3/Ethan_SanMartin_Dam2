   M S B A M L   `   `   `  ����I  ECapturaPokemon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CapturaPokemon.ViewCapturaPokemon.View  5      C&clr-namespace:CapturaPokemon.ViewModelCapturaPokemon.ViewModel  5      $    CapturaPokemon.View.ImportView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CapturaPokemon.View     5      <	viewmodel&clr-namespace:CapturaPokemon.ViewModel     5      .��5      � ��5   
   �� 5        �� 
StartPoint$	  0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #FFD700��6    � Offset$	 0.0Q�6/   � 5      $ #FF4500��6   $	 1.0Q�6/   5      .+�5   
   ��  �� CornerRadius$ 15��6   
���   �$��4q�67   
���   �$��20q�6^   ._�5      �� $��Center=�6   $��Center=�66   .+�5      �� $��Importar Datos Pokémon��6   $��28(�5      $
��Bold"�5      
������� �� TextAlignment$ Center=�5      �� 5       $#��/Resources/pokemonImagen.jpeg��6   $	��292��5!      $	��183��6$   $��Center=�61   �� 5#      $��Import��6   $	��150��5%      $��50��6%   ���#FF0000
�������$��16(�5(      $
��Bold"�5)      
�������$��3q�5+       � Cursor$
 Hand��5,      ��5$      �� *LoadFromFileCommand+ J� Effect 5-      3  -System.Windows.Media.Effects.DropShadowEffect  5.         Color$ Black��6+   	   
BlurRadius$	 10Q�69   
   ShadowDepth$
 5Q�6I   50      51      52      53      54      