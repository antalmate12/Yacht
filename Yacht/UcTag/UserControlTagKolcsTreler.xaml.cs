using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Yacht.UcTag
{
    /// <summary>
    /// Interaction logic for UserControlTagKolcsTreler.xaml
    /// </summary>
    public partial class UserControlTagKolcsTreler
    {
        private LoginSql _l  = new LoginSql();
        // ReSharper disable once InconsistentNaming
        private DataTable dt = new DataTable();
        // ReSharper disable once InconsistentNaming
        private int selectedindex;
        private SqlQuerys _sql = new SqlQuerys();

        public UserControlTagKolcsTreler()
        {
            InitializeComponent();
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            //HAJÓK TÁBLA UPDATE
            //------------------------
            #region update_treler
            var cmd = new SqlCommand("UPDATE Treler SET SzabadTol = null, SzabadIg = null " +
                                     "WHERE Id = @Id AND TulajId = @TulajId " +
                                     "AND SzabadTol = @Mettol AND SzabadIg = @Meddig", _l.Con);
            //--
            var a = (Int32)dt.Rows[selectedindex][0];
            var b = (Int32)dt.Rows[selectedindex][1];
            //--
            var c = (DateTime)dt.Rows[selectedindex][2];
            var d = (DateTime)dt.Rows[selectedindex][3];
            //--
            cmd.Parameters.Add("@Id", SqlDbType.Int);
            cmd.Parameters["@Id"].Value = a;
            //--
            cmd.Parameters.Add("@TulajId", SqlDbType.Int);
            cmd.Parameters["@TulajId"].Value = b;
            //--
            cmd.Parameters.Add("@Mettol", SqlDbType.Date);
            cmd.Parameters["@Mettol"].Value = c;
            //--
            cmd.Parameters.Add("@Meddig", SqlDbType.Date);
            cmd.Parameters["@Meddig"].Value = d;
            //--
            _l.Con.Open();
            cmd.ExecuteNonQuery();
            _l.Con.Close();
            #endregion
            //------------------------

            //KÖLCSÖNZÉSEK TÁBLA UPDATE
            //------------------------
            #region update_TrelerKolcs
            
            cmd = new SqlCommand(
                "INSERT INTO TrelerKolcs (TrelerId,TulajId,BerloId,Mettol,Meddig)" +
                "VALUES (@TrelerId,@TulajId,@BerloId,@Mettol,@Meddig)", _l.Con);
            //--
            cmd.Parameters.Add("@TrelerId", SqlDbType.Int);
            cmd.Parameters["@TrelerId"].Value = (Int32)dt.Rows[selectedindex][0];
            //--
            cmd.Parameters.Add("@TulajId", SqlDbType.Int);
            cmd.Parameters["@TulajId"].Value = (Int32)dt.Rows[selectedindex][1];
            //--
            cmd.Parameters.Add("@BerloId", SqlDbType.Int);
            cmd.Parameters["@BerloId"].Value = _sql.GetUserId(_l.GetLoggedinUser());
            //--
            cmd.Parameters.Add("@Mettol", SqlDbType.Date);
            cmd.Parameters["@Mettol"].Value = c;
            //--
            cmd.Parameters.Add("@Meddig", SqlDbType.Date);
            cmd.Parameters["@Meddig"].Value = d;
            //--
            _l.Con.Open();
            cmd.ExecuteNonQuery();
            _l.Con.Close();
            #endregion
            //------------------------

        }

        private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedindex = DataGridTreler.SelectedIndex;
        }

        private void ButtonList_OnClick(object sender, RoutedEventArgs e)
        {
            const string query =
                "SELECT * FROM Treler WHERE SzabadTol<@SzabadTol AND SzabadIg>@SzabadIg";

            var sda = new SqlDataAdapter(query, _l.Con);

            var date1 = Convert.ToDateTime(DpMettol.Text);
            var date2 = Convert.ToDateTime(DpMeddig.Text);

            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@SzabadTol", SqlDbType.Date);
            sda.SelectCommand.Parameters["@SzabadTol"].Value = date1;
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@SzabadIg", SqlDbType.Date);
            sda.SelectCommand.Parameters["@SzabadIg"].Value = date2;
            //--
            _l.Con.Open();
            sda.Fill(dt);
            _l.Con.Close();
            //--
            DataGridTreler.ItemsSource = dt.DefaultView;            
        }
    }
}

