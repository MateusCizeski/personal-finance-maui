using personal_finance_maui.Views;

namespace personal_finance_maui
{
    public partial class App : Application
    {
        public App(TransactionList listPage)
        {
            InitializeComponent();

            MainPage = new NavigationPage(listPage);
        }
    }
}