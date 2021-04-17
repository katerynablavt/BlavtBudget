using BudgetsWPF.Navigation;
using Models;
using Prism.Commands;
using Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetsWPF.Authentication
{
    public class SignInViewModel : INotifyPropertyChanged, INavigatable<AuthNavigetableTypes>
    {
        private AuthUser _authUser = new AuthUser();
        private Action _goToSignUp;
        private Action _goToWallets;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool _isEnabled =true;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
        public AuthNavigetableTypes Type
        {
            get
            {
                return AuthNavigetableTypes.SignIn;
            }
        }
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

        public DelegateCommand SingUpCommand { get; }


        public SignInViewModel(Action goToSignUp, Action goToWallets)
        {
            SingInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _goToSignUp = goToSignUp;
            SingUpCommand = new DelegateCommand(_goToSignUp);
            _goToWallets=goToWallets;
        }

        private bool IsSignInEnabled()
        {
            if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(Login))
                return false;
            else
               return true;
        }

        private async void SignIn()
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
                    IsEnabled = false;
                    user = await authService.Authenticate(_authUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed: {ex.Message}");
                    return;
                }
                finally
                {
                    IsEnabled=true;
                }
                MessageBox.Show($"Signed in was susceessful for user {user.FirstName} {user.LastName}");
                //TODO navigate to main view
                _goToWallets.Invoke();
            }
        }
        public void Update()
        {
        }
        public void ClearSensitiveData()
        {
            Password = "";
        }
    }
}
