﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetsWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        private SignInViewModel _viewModel;
        public SignInView(Action goToSignUp, Action gotoWallets)
        {
            InitializeComponent();
            _viewModel = new SignInViewModel(goToSignUp, gotoWallets);
            this.DataContext = _viewModel;
        }

        private void TbPasword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = TbPasword.Password;
        }
    }
}
