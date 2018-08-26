using System.Windows;
using System.Windows.Controls;
using Yacht.UcKozos;
using Yacht.UcTag;

namespace Yacht
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2
    {
        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();

        public Window2()
        {
            InitializeComponent();
        }

        public void ShowFullName()
        {
            TbMyName.Text = _sql.GetUserFullName(_l.GetLoggedinUser());
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlAdminManage();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UserControlAdminReg();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemKimutatas":
                    usc = new ucKimutatas();
                    GridMain.Children.Add(usc);
                    break;
                // ReSharper disable once RedundantEmptySwitchSection
                default:
                    break;
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TbMyName_Loaded(object sender, RoutedEventArgs e)
        {
            ShowFullName();
        }

        private void BtTagProfil_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new UserControlTagProfil();
            GridMain.Children.Add(usc);
        }
    }
}
