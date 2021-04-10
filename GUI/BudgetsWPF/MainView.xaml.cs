using BudgetsWPF.Authentication;
using BudgetsWPF.Wallets;
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

namespace BudgetsWPF
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            Content = new SignInView(GoToSignUp, GoToWalletsView);
        }

        public void GoToSignUp()
        {
            Content = new SignUpView(GoToSignIn);
        }
        public void GoToSignIn()
        {
            Content = new SignInView(GoToSignUp, GoToWalletsView);
        }

        public void GoToWalletsView()
        {
            Content = new WalletsView();
        }
    }
}
