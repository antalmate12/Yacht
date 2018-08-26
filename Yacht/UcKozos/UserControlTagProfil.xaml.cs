using System.Windows;

namespace Yacht.UcTag
{
    /// <summary>
    /// Interaction logic for UserControlTagProfil.xaml
    /// </summary>
    public partial class UserControlTagProfil
    {
        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();

        public UserControlTagProfil()
        {
            InitializeComponent();            
        }

        private void BtEditData_OnClick(object sender, RoutedEventArgs e)
        {
            Tb1.IsReadOnly = false;
            Tb2.IsReadOnly = false;

            BtEditData.Visibility = Visibility.Hidden;
            BtCancel.Visibility = Visibility.Visible;
            BtEditDone.Visibility = Visibility.Visible;
        }

        private void BtEditDone_OnClick(object sender, RoutedEventArgs e)
        {
            Tb1.IsReadOnly = true;
            Tb2.IsReadOnly = true;
            //--
            BtEditData.Visibility = Visibility.Visible;
            BtEditDone.Visibility = Visibility.Hidden;
            //--
            string name = Tb1.Text;
            string about = Tb2.Text;
            //--
            _l.ChangeUserData(name,about);
            
            Window2 wd = new Window2();
            wd.ShowFullName();
            //--
            //BUG NEM NEVEZI ÁT (Watchban igen, képen nem)
            //--
        }

        private void TbMyName_OnLoaded(object sender, RoutedEventArgs e)
        {
            Tb1.Text = _sql.GetUserFullName(_l.GetLoggedinUser());
            Tb2.Text = _sql.GetUserAbout(_l.GetLoggedinUser());
        }

        private void BtCancel_OnClick(object sender, RoutedEventArgs e)
        {
            BtCancel.Visibility = Visibility.Hidden;
            BtEditData.Visibility = Visibility.Visible;
            BtEditDone.Visibility = Visibility.Hidden;
            Tb1.Text = _sql.GetUserFullName(_l.GetLoggedinUser());
            Tb2.Text = _sql.GetUserAbout(_l.GetLoggedinUser());
            Tb1.IsReadOnly = true;
            Tb2.IsReadOnly = true;
        }
    }
}
