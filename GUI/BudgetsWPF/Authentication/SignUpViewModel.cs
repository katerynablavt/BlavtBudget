using BudgetsWPF.Navigation;
using Models;
using Prism.Commands;
using Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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

        public string LoginErr { get; set; }
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

        public string PasswordErr { get; set; }
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
        public string NameErr { get; set; }
        public string Name
        {
            get { return _regUser.Name; }
            set
            {
                if (_regUser.Name != value)
                {
                    _regUser.Name = value;
                    OnPropertyChanged();
                    SingUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string LastErr { get; set; }
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
        public string EmailErr { get; set; }
        public string Email
        {
            get
            {
                return _regUser.Email;
            }
            set
            {
                if (_regUser.Email != value)
                {
                    _regUser.Email = value;
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
            SingUpCommand = new DelegateCommand(SignUp, Validation);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _gotoSignIn = gotoSignIn;
            SingInCommand = new DelegateCommand(_gotoSignIn);
        }

        private bool Validation()
        {
            bool valid = true;
            if (String.IsNullOrWhiteSpace(Login))
            {
                LoginErr = "Login can't be empty";
                OnPropertyChanged(nameof(LoginErr));
                valid = false;
            }
            else
            if (Login.Length < 3)
            {
                LoginErr = "Login can't be less than 3 symbols";
                OnPropertyChanged(nameof(LoginErr));
                valid = false;
            }
            else
            if (Login.Length > 10)
            {
                LoginErr = "Login can't be more than 10 symbols";
                OnPropertyChanged(nameof(LoginErr));
                valid = false;
            }
            else
            {
                LoginErr = "";
                OnPropertyChanged(nameof(LoginErr));
            }

            if (String.IsNullOrWhiteSpace(Password))
            {
                PasswordErr = "Password can't be empty";
                OnPropertyChanged(nameof(PasswordErr));
                valid = false;
            }
            else
            if (Password.Length < 6)
            {
                PasswordErr = "Password can't be less than 6 symbols";
                OnPropertyChanged(nameof(PasswordErr));
                valid = false;
            }
            else
            if (Password.Length > 20)
            {
                PasswordErr = "Password can't be more than 20 symbols";
                OnPropertyChanged(nameof(PasswordErr));
                valid = false;
            }
            else
            {
                PasswordErr = "";
                OnPropertyChanged(nameof(PasswordErr));
            }

            if (String.IsNullOrWhiteSpace(Name))
            {
                NameErr = "Name can't be empty";
                OnPropertyChanged(nameof(NameErr));
                valid = false;
            }
            else
            if (Name.Length > 20)
            {
                NameErr = "Name can't be more than 20 symbols";
                OnPropertyChanged(nameof(NameErr));
                valid = false;
            }
            else
            if (Regex.IsMatch(Name, "[^a-zA-Z]+"))
            {
                NameErr = "Name can contains only latin letters";
                OnPropertyChanged(nameof(NameErr));
                valid = false;
            }
            else
            {
                NameErr = "";
                OnPropertyChanged(nameof(NameErr));
            }


            if (String.IsNullOrWhiteSpace(LastName))
            {
                LastErr = "Surname can't be empty";
                OnPropertyChanged(nameof(LastErr));
                valid = false;
            }
            else
            if (LastName.Length > 20)
            {
                LastErr = "Surname can't be more than 20 symbols";
                OnPropertyChanged(nameof(LastErr));
                valid = false;
            }
            else
            if (Regex.IsMatch(LastName, "[^a-zA-Z]+"))
            {
                LastErr = "Surname can contains only latin letters";
                OnPropertyChanged(nameof(LastErr));
                valid = false;
            }
            else
            {
                LastErr = "";
                OnPropertyChanged(nameof(LastErr));
            }


            if (String.IsNullOrWhiteSpace(Email))
            {
                EmailErr = "Email can't be empty";
                OnPropertyChanged(nameof(EmailErr));
                valid = false;
            }
            else
            if (Email.Length > 30)
            {
                EmailErr = "Email can't be more than 30 symbols";
                OnPropertyChanged(nameof(EmailErr));
                valid = false;
            }
            else
            if (!Regex.IsMatch(Email, ".+@.+"))
            {
                EmailErr = "Email can contains only latin letters and need to have @ symbol inside";
                OnPropertyChanged(nameof(EmailErr));
                valid = false;
            }
            else
            {
                EmailErr = "";
                OnPropertyChanged(nameof(EmailErr));
            }
            return valid;
        }

        private async void SignUp()
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
                  await  authService.RegisterUser(_regUser);
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

        public void Update()
        {
        }
    }
}
