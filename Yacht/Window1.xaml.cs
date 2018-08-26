using System.Windows;
using System.Windows.Controls;
using Yacht.UcKozos;
using Yacht.UcTag;

namespace Yacht
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();

        public Window1()
        {
            InitializeComponent();            
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
                    usc = new UserControlTagHajok();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemHajoKolcs":
                    usc = new UserControlTagKolcsHajo();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemKolcs":
                    usc = new UserControlKolcsonzeseim();
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
        
        private void TbMyName_Loaded_1(object sender, RoutedEventArgs e)
        {
            TbMyName.Text = _sql.GetUserFullName(_l.GetLoggedinUser());

            if (_sql.ConfirmRent(_l.GetLoggedinUser()))
            {
                var cw = new ConfirmWindow();
                cw.Show();
            }
}

        private void BtTagProfil_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new UserControlTagProfil();
            GridMain.Children.Add(usc);            
        }

        private void BtPopupKolcs_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new UserControlTagProfil();
            GridMain.Children.Add(usc);
        }
    }
}
