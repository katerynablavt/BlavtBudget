using BudgetsWPF.Navigation;
using Models;
using Prism.Commands;
using Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BudgetsWPF.Authentication
{
    public class SignUpViewModel : INotifyPropertyChanged, INavigatable<AuthNavigetableTypes>
    {
        private RegistrationUser _regUser = new RegistrationUser();
        private Action _gotoSignIn;
        public event PropertyChangedEventHandler PropertyChanged;

        public AuthNavigetableTypes Type
        {
            get
            {
                return AuthNavigetableTypes.SignUp;
            }
        }
        public void ClearSensitiveData()
        {
            _regUser = new RegistrationUser();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Login
        {
            get
            {
                return _regUser.Login;
            }
            set
            {
                if (_regUser.Login != value)
                {
                    _regUser.Login = value;
                    OnPropertyChanged();
                    SingUpCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public string Password
        {
            get
            {
                return _regUser.Password;
            }
            set
            {
                if (_regUser.Password != value)
                {
                    _regUser.Password = value;
                    OnPropertyChanged();
                    SingUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return _regUser.LastName;
            }
            set
            {
                if (_regUser.LastName != value)
                {
                    _regUser.LastName = value;
                    OnPropertyChanged();
                    SingUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SingUpCommand { get;  }
        public DelegateCommand CloseCommand { get; }

        public DelegateCommand SingInCommand { get; }
        public SignUpViewModel(Action gotoSignIn)
        {
            SingUpCommand = new DelegateCommand(SignUp, IsSignUpEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _gotoSignIn = gotoSignIn;
            SingInCommand = new DelegateCommand(_gotoSignIn);
        }

        private bool IsSignUpEnabled()
        {
            if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(Login)|| String.IsNullOrWhiteSpace(LastName))
                return false;
            else
               return true;
        }

        private void SignUp()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
            {

                MessageBox.Show("Login or passwors is empty.");
            }
            else
            {
                
                var authService = new AuthService();
               
                try
                {
                    authService.RegisterUser(_regUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed: {ex.Message}");
                    return;
                }
                MessageBox.Show($"User sucsessfuly registered, please sign in");
                //TODO navigate to main view
                _gotoSignIn.Invoke();
            }
        }
    }
}
