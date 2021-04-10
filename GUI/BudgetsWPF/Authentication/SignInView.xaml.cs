using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetsWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
       
        public SignInView()
        {
            InitializeComponent();
            
        }

        private void TbPasword_PasswordChanged(object sender, RoutedEventArgs e)
        {
           ((SignInViewModel)DataContext).Password = TbPasword.Password;
        }
    }
}
