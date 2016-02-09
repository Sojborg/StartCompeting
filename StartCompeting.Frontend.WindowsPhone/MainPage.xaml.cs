using Microsoft.Phone.Controls;
using StartCompeting.Frontend.WindowsPhone.ViewModels;

namespace StartCompeting.Frontend.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent(); 
            this.DataContext = new MainPageViewModel(Map);
        }
    }
}