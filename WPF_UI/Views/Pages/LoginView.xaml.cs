using Pro_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace Pro_WPF.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
   
       public partial class LoginView : INavigableView<ViewModels.LoginViewModel>
        {
            public ViewModels.LoginViewModel ViewModel { get; }

            public LoginView(ViewModels.LoginViewModel LoginViewModel)
            {
                ViewModel = LoginViewModel;
                DataContext = this;

                InitializeComponent();
            }
        }


    }
