﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace BudgetsWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
       
        public SignUpView()
        {
            InitializeComponent();
        }

        private void TbPasword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((SignUpViewModel)DataContext).Password = TbPasword.Password;
        }
    }
}
