using System.Data;
using System.Windows;

namespace Yacht.UcTag
{
    /// <summary>
    /// Interaction logic for UserControlKolcsonzeseim.xaml
    /// </summary>
    public partial class UserControlKolcsonzeseim
    {
        private SqlQuerys _sql = new SqlQuerys();
        private LoginSql _l = new LoginSql();

        public UserControlKolcsonzeseim()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var dt = new DataTable();
            _sql.ListKolcsUser(dt,_sql.GetUserId(_l.GetLoggedinUser()));
            DgKolcs.ItemsSource = dt.DefaultView;           
            DgKolcs.Columns.RemoveAt(1);
        }
    }
}
