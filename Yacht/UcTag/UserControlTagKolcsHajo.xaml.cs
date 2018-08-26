using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Yacht.UcTag
{
    /// <summary>
    /// Interaction logic for UserControlTagKolcsHajo.xaml
    /// </summary>
    public partial class UserControlTagKolcsHajo
    {
        // ReSharper disable once InconsistentNaming
        DataTable dt = new DataTable();

        // ReSharper disable once InconsistentNaming
        private int selectedindex;
        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();       
        //--

        public UserControlTagKolcsHajo()
        {
            InitializeComponent();
        }

        private void ButtonList_OnClick(object sender, RoutedEventArgs e)
        {
            const string query =
                "SELECT * FROM Hajok WHERE SzabadTol<@SzabadTol AND SzabadIg>@SzabadIg";

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
            DataGridHajo.ItemsSource = dt.DefaultView;
            DataGridHajo.Columns.RemoveAt(8);
        }

        private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedindex = DataGridHajo.SelectedIndex;
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            //HAJÓK TÁBLA UPDATE
            //------------------------
            #region update_hajok

            var cmd = new SqlCommand("UPDATE Hajok SET SzabadTol = null, SzabadIg = null " +
                                            "WHERE HajoId = @HajoId AND TulajId = @TulajId " +
                                            "AND SzabadTol = @Mettol AND SzabadIg = @Meddig", _l.Con);
            //--
            int a, b;
            a = (Int32) dt.Rows[selectedindex][0];
            b = (Int32) dt.Rows[selectedindex][1];

            //c = _sql.HajoIdFromNevnTulaj(dt.Rows[selectedindex][2].ToString(), (Int32) dt.Rows[selectedindex][1]);
            //--

            //--
            var d = (DateTime) dt.Rows[selectedindex][5];
            var valami = (DateTime) dt.Rows[selectedindex][6];
            //--

            //--
            cmd.Parameters.Add("@HajoId", SqlDbType.Int);
            cmd.Parameters["@HajoId"].Value = a;
            //--
            cmd.Parameters.Add("@TulajId", SqlDbType.Int);
            cmd.Parameters["@TulajId"].Value = b;
            //--
            cmd.Parameters.Add("@Mettol", SqlDbType.Date);
            cmd.Parameters["@Mettol"].Value = d;
            //--
            cmd.Parameters.Add("@Meddig", SqlDbType.Date);
            cmd.Parameters["@Meddig"].Value = valami;
            //--
            _l.Con.Open();
            cmd.ExecuteNonQuery();
            _l.Con.Close();

            #endregion
            //------------------------

            //KÖLCSÖNZÉSEK TÁBLA UPDATE
            //------------------------
            #region update_kolcs

            cmd = new SqlCommand(
                "INSERT INTO Kolcsonzes (HajoId,BerloId,TulajId,Mettol,Meddig,Honnan,Hova,Elfogadva)" +
                                "VALUES (@HajoId,@BerloId,@TulajId,@Mettol,@Meddig,@Honnan,@Hova,@Elfogadva)",_l.Con);
            //--
            cmd.Parameters.Add("@HajoId", SqlDbType.Int);
            cmd.Parameters["@HajoId"].Value = (Int32) dt.Rows[selectedindex][0];
            //--
            cmd.Parameters.Add("@BerloId", SqlDbType.Int);
            cmd.Parameters["@BerloId"].Value = _sql.GetUserId(_l.GetLoggedinUser());
            //--
            cmd.Parameters.Add("@TulajId", SqlDbType.Int);
            cmd.Parameters["@TulajId"].Value = (Int32)dt.Rows[selectedindex][1];
            //--
            cmd.Parameters.Add("@Mettol", SqlDbType.Date);
            cmd.Parameters["@Mettol"].Value = Convert.ToDateTime(DpMettol.Text);
            //--
            cmd.Parameters.Add("@Meddig", SqlDbType.Date);
            cmd.Parameters["@Meddig"].Value = Convert.ToDateTime(DpMeddig.Text);
            //--
            cmd.Parameters.Add("@Honnan", SqlDbType.VarChar);
            cmd.Parameters["@Honnan"].Value = dt.Rows[selectedindex][4].ToString();
            //--
            cmd.Parameters.Add("@Hova", SqlDbType.VarChar);
            cmd.Parameters["@Hova"].Value = TbHova.Text;
            //--
            cmd.Parameters.Add("@Elfogadva", SqlDbType.VarChar);
            cmd.Parameters["@Elfogadva"].Value = 0;
            //--
            _l.Con.Open();
            cmd.ExecuteNonQuery();
            _l.Con.Close();

            #endregion
            TbHova.Text = "";
            //------------------------
        }
    }
}