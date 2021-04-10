using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetsWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        private SignUpViewModel _viewModel;
        public SignUpView(Action gotoSignIn)
        {
            InitializeComponent();
            _viewModel = new SignUpViewModel(gotoSignIn);
            this.DataContext = _viewModel;
        }

        private void TbPasword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = TbPasword.Password;
        }
    }
}
