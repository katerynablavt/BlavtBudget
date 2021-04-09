using Prism.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BudgetsWPF.Authentication
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        private AuthUser _authUser = new AuthUser();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Login
        {
            get
            {
                return _authUser.Login;
            }
            set
            {
                if (_authUser.Login != value)
                {
                    _authUser.Login = value;
                    OnPropertyChanged();
                    SingInCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public string Password
        {
            get
            {
                return _authUser.Password;
            }
            set
            {
                if (_authUser.Password != value)
                {
                    _authUser.Password = value;
                    OnPropertyChanged();
                    SingInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SingInCommand { get;  }
        public DelegateCommand CloseCommand { get; }
        public SignInViewModel()
        {
            SingInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
        }

        private bool IsSignInEnabled()
        {
            if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(Login))
                return false;
            else
               return true;
        }

        private void SignIn()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
            {

                MessageBox.Show("Login or passwors is empty.");
            }
            else
            {
                
                var authService = new AuthService();
                User user = null;
                try
                {
                    user = authService.Authenticate(_authUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed: {ex.Message}");
                    return;
                }
                MessageBox.Show($"Signed in was susceessful for user {user.FirstName} {user.LastName}");
                //TODO navigate to main view
            }
        }
    }
}
