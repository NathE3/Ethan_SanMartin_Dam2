   M S B A M L   `   `   `  ����I  ECapturaPokemon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CapturaPokemon.ServiceCapturaPokemon.Service  5      C&clr-namespace:CapturaPokemon.ViewModelCapturaPokemon.ViewModel  5      '    !CapturaPokemon.View.HistoricoView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CapturaPokemon.Service     5      <	viewmodel&clr-namespace:CapturaPokemon.ViewModel     5      
���   �.��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5      $��0��5         AutoGenerateColumns$
 True��5      $��10q�5         CanUserResizeColumns$
 True��5         CanUserResizeRows$ False��5      $	��Top=�5      $
��Left=�5         MinRowHeight$ 25Q�5      $	��400��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5      $
��Auto=�5      $
��Auto=�5       ��5      �� *
Pokemons+5       �� 5"      $��1��6   $
��Save��6   $	��100��6O   $��50��6[   ��6)   �� *SaveToFileCommand+6[   5#      5$      