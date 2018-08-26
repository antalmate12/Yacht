using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Yacht
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow
    {
        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();

        public ConfirmWindow()
        {
            InitializeComponent();
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            
            var query = "SELECT * " +
                        "FROM Kolcsonzes " +
                        "WHERE Elfogadva = 0";
            var dt = new DataTable();
            dt.Clear();
            var sda = new SqlDataAdapter(query, _l.Con);

            _l.Con.Open();
            sda.Fill(dt);
            _l.Con.Close();
            int db = dt.Rows.Count;
            //--
            for (var i = 0; i < db; i++)
            {
                var name = i + 1;
                ListBoxKolcs.Items.Add(name);
            }
            dt.Clear();
        }
        private void ListBoxKolcs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int item = (Int32) ListBoxKolcs.SelectedItem-1;
            /*const string query = "SELECT * " +
                                 "FROM Kolcsonzes " +
                                 "WHERE HajoId = @HajoId " +
                                 "AND BerloId = @BerloId AND TulajId = @TulajId AND Mettol = @Mettol " +
                                 "AND Meddig = @Meddig AND Honnan = @Honnan AND AND Hova = @Hova " +
                                 "AND Elfogadva = @Elfogadva";*/
            const string query = "SELECT * FROM Kolcsonzes WHERE TulajId = @TulajId";
            var dt = new DataTable();
            var sda = new SqlDataAdapter(query, _l.Con);
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@TulajId", SqlDbType.Int);
            sda.SelectCommand.Parameters["@TulajId"].Value = _sql.GetUserId(_l.GetLoggedinUser());
            //--

            sda.Fill(dt);
            //--
            TbHajoNev.Text = _sql.HajoNevFromId((int)dt.Rows[item][0]);
            TbKolcsNev.Text = _sql.GetUserName((int) dt.Rows[item][1]);
            TbKolcsAbout.Text = _sql.GetUserAbout(_sql.GetUserName((int)dt.Rows[item][1]));
            DpMettol.Text = dt.Rows[item][3].ToString();
            DpMeddig.Text = dt.Rows[item][4].ToString();
            TbHonnan.Text = dt.Rows[item][5].ToString();
            TbHova.Text = dt.Rows[item][6].ToString();
            //--

            //TbHajoHelyek.Text = dt.Rows[0][3].ToString();
            //TbHajoHolvan.Text = dt.Rows[0][4].ToString();
            //DpTol.Text = dt.Rows[0][5].ToString();
            //DpIg.Text = dt.Rows[0][6].ToString();
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            const string query = "UPDATE Kolcsonzes SET Elfogadva = 1" +
                                 "WHERE HajoId = @HajoId " +
                                 "AND BerloId = @BerloId AND TulajId = @TulajId AND Mettol = @Mettol " +
                                 "AND Meddig = @Meddig AND Honnan = @Honnan AND Hova = @Hova " +
                                 "AND Elfogadva = 0";
            var update = new SqlCommand(query, _l.Con);
            //--
            update.Parameters.Add("@HajoId", SqlDbType.Int);
            update.Parameters["@HajoId"].Value = _sql.HajoIdFromNevnTulaj(TbHajoNev.Text, _sql.GetUserId(_l.GetLoggedinUser()));
            //--
            update.Parameters.Add("@BerloId", SqlDbType.Int);
            update.Parameters["@BerloId"].Value = _sql.GetUserId(TbKolcsNev.Text);
            //--
            update.Parameters.Add("@TulajId", SqlDbType.Int);
            update.Parameters["@TulajId"].Value = _sql.GetUserId(_l.GetLoggedinUser());
            //--
            update.Parameters.Add("@Mettol", SqlDbType.Date);
            update.Parameters["@Mettol"].Value = DpMettol.Text;
            //--
            update.Parameters.Add("@Meddig", SqlDbType.Date);
            update.Parameters["@Meddig"].Value = DpMeddig.Text;
            //--
            update.Parameters.Add("@Honnan", SqlDbType.VarChar);
            update.Parameters["@Honnan"].Value = TbHonnan.Text;
            //--
            update.Parameters.Add("@Hova", SqlDbType.VarChar);
            update.Parameters["@Hova"].Value = TbHova.Text;
            //--
            _l.Con.Open();
            update.ExecuteNonQuery();
            _l.Con.Close();
            RefreshGrid();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            const string query = "UPDATE Kolcsonzes SET Elfogadva = -1" +
                                 "WHERE HajoId = @HajoId " +
                                 "AND BerloId = @BerloId AND TulajId = @TulajId AND Mettol = @Mettol " +
                                 "AND Meddig = @Meddig AND Honnan = @Honnan AND Hova = @Hova " +
                                 "AND Elfogadva = 0";
            var update = new SqlCommand(query, _l.Con);
            //--
            update.Parameters.Add("@HajoId", SqlDbType.Int);
            update.Parameters["@HajoId"].Value = _sql.HajoIdFromNevnTulaj(TbHajoNev.Text, _sql.GetUserId(_l.GetLoggedinUser()));
            //--
            update.Parameters.Add("@BerloId", SqlDbType.Int);
            update.Parameters["@BerloId"].Value = _sql.GetUserId(TbKolcsNev.Text);
            //--
            update.Parameters.Add("@TulajId", SqlDbType.Int);
            update.Parameters["@TulajId"].Value = _sql.GetUserId(_l.GetLoggedinUser());
            //--
            update.Parameters.Add("@Mettol", SqlDbType.Date);
            update.Parameters["@Mettol"].Value = DpMettol.Text;
            //--
            update.Parameters.Add("@Meddig", SqlDbType.Date);
            update.Parameters["@Meddig"].Value = DpMeddig.Text;
            //--
            update.Parameters.Add("@Honnan", SqlDbType.VarChar);
            update.Parameters["@Honnan"].Value = TbHonnan.Text;
            //--
            update.Parameters.Add("@Hova", SqlDbType.VarChar);
            update.Parameters["@Hova"].Value = TbHova.Text;
            //--
            _l.Con.Open();
            update.ExecuteNonQuery();
            _l.Con.Close();
            RefreshGrid();
        }
    }
}
