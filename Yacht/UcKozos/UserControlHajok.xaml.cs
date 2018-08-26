using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

// ReSharper disable once CheckNamespace
namespace Yacht.UcTag
{
    /// <summary>
    /// Interaction logic for UserControlTagHajok.xaml
    /// </summary>
    public partial class UserControlTagHajok
    {
        private string oldname;

        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();

        public UserControlTagHajok()
        {
            InitializeComponent();
        }

        private void BtPic_Click(object sender, RoutedEventArgs e)
        {
            //Create OpenFileDialog
            var dlg = new OpenFileDialog
            {
                //Set filters
                //Display OFD by calling ShowDialog method
                DefaultExt = ".jpg",
                Filter =
                    "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|ALL Files (*.*)|*.*"
            };

            Nullable<bool> result = dlg.ShowDialog();
            //Get the selected file name in a TextBox
            if (result == true)
            {
                //Open document
                var filename = dlg.FileName;
                TbPic.Text = filename;
            }
            //ImgShip.Source = filename as ImageSource;
        }

        private void Sp_Loaded(object sender, RoutedEventArgs e)
        {
            var query = "SELECT * FROM Hajok WHERE TulajId = @tulajid";

            var dt = new DataTable();
            var sda = new SqlDataAdapter(query, _l.Con);
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@tulajid", SqlDbType.Int);
            sda.SelectCommand.Parameters["@tulajid"].Value = _sql.GetUserId(_l.GetLoggedinUser());

            _l.Con.Open();
            sda.Fill(dt);
            _l.Con.Close();
            int db = dt.Rows.Count;           

            for (int i = 0; i < db; i++)
            {
                if (dt.Rows[i][2].ToString() == "")
                {
                    ListBoxHajo.Items.Add("Névtelen Hajó");
                }
                else
                {
                    ListBoxHajo.Items.Add(dt.Rows[i][2].ToString());
                }
            }
            //--

        }

        private void ListBoxHajo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var shipname = ListBoxHajo.SelectedItem.ToString();
            var id = _sql.HajoIdFromNevnTulaj(shipname, _sql.GetUserId(_l.GetLoggedinUser()));
            const string query = "SELECT * FROM Hajok WHERE HajoId = @id";
            var dt = new DataTable();
            var sda = new SqlDataAdapter(query, _l.Con);
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@id", SqlDbType.Int);
            sda.SelectCommand.Parameters["@id"].Value = id;
            sda.Fill(dt);
            //--
            TbHajoNev.Text = dt.Rows[0][2].ToString();
            TbHajoHelyek.Text = dt.Rows[0][3].ToString();
            TbHajoHolvan.Text = dt.Rows[0][4].ToString();
            //--
            var src = dt.Rows[0][7].ToString();
            //if (src != "")
            //{
            try
            {
                byte[] im = dt.Rows[0][7] as byte[];
                ImgShip.Source=LoadImage(im);
                //var img = new BitmapImage(new Uri(dt.Rows[0][7].ToString()));
                //ImgShip
            }
            catch (Exception exception)
            {
                ImgShip.Source = null;
            }
                
            //}
            //else
            //{
                //ImgShip.Source = null;
            //}
            TbHajoHelyek.Text = dt.Rows[0][3].ToString();
            TbHajoHolvan.Text = dt.Rows[0][4].ToString();
            DpTol.Text = dt.Rows[0][5].ToString();
            DpIg.Text = dt.Rows[0][6].ToString();

        }
        //--
        private static BitmapImage LoadImage(byte[] ImageData)
        {
            if (ImageData == null || ImageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(ImageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        //--

        //Módosított adatok lementése
        //------------------------
        private void BtEditDone_OnClick(object sender, RoutedEventArgs e)
        {
            BtEditDone.Visibility = Visibility.Hidden;
            BtCancel.Visibility = Visibility.Hidden;
            BtEditData.Visibility = Visibility.Visible;
            //--
            BtPic.Visibility = Visibility.Hidden;
            //--
            TbHajoNev.IsReadOnly = true;
            TbHajoHelyek.IsReadOnly = true;
            TbHajoHolvan.IsReadOnly = true;
            TbPic.Visibility = Visibility.Hidden;
            TbPic.Text = "";
            
            //--
            #region query
            string query = "UPDATE Hajok SET HajoNev=@HajoNev, Ferohely=@Ferohely, HolVan=@HolVan, " +
                                                "SzabadTol=@SzabadTol, SzabadIg=@SzabadIg, Kep=@Kep " +
                           "WHERE TulajId=@TulajId AND HajoNev=@OldHajoName";
            var cmd = new SqlCommand(query, _l.Con);
            byte[] image = null;
            FileStream Stream = new FileStream(TbPic.Text,FileMode.Open,FileAccess.Read);
            BinaryReader brs = new BinaryReader(Stream);
            image = brs.ReadBytes((int) Stream.Length);            
            //--
            int hely = Convert.ToInt32(TbHajoHelyek.Text);
            //--
            cmd.Parameters.Add("@HajoNev", SqlDbType.VarChar);
            cmd.Parameters["@HajoNev"].Value = TbHajoNev.Text;
            //--
            cmd.Parameters.Add("@Ferohely", SqlDbType.Int);
            cmd.Parameters["@Ferohely"].Value = hely;
            //--
            cmd.Parameters.Add("@TulajId", SqlDbType.Int);
            cmd.Parameters["@TulajId"].Value = _sql.GetUserId(_l.GetLoggedinUser());
            //--
            cmd.Parameters.Add("@HolVan", SqlDbType.VarChar);
            cmd.Parameters["@HolVan"].Value = TbHajoHolvan.Text;
            //--
            cmd.Parameters.Add("@SzabadTol", SqlDbType.Date);
            cmd.Parameters["@SzabadTol"].Value = DpTol.Text;
            //--
            cmd.Parameters.Add("@SzabadIg", SqlDbType.Date);
            cmd.Parameters["@SzabadIg"].Value = DpIg.Text;
            //--
            cmd.Parameters.Add("@Kep", SqlDbType.Image);
            cmd.Parameters["@Kep"].Value = image;
            //--
            cmd.Parameters.Add("@OldHajoName", SqlDbType.VarChar);
            cmd.Parameters["@OldHajoName"].Value = oldname;
            //--
            _l.Con.Open();
            cmd.ExecuteNonQuery();
            _l.Con.Close();
            #endregion
        }
        //------------------------

        //Mégse
        //------------------------
        private void BtCancel_OnClick(object sender, RoutedEventArgs e)
        {
            BtEditDone.Visibility = Visibility.Hidden;
            BtCancel.Visibility = Visibility.Hidden;
            BtEditData.Visibility = Visibility.Visible;
            BtPic.Visibility = Visibility.Hidden;
            //--
            TbHajoNev.IsReadOnly = true;
            TbHajoHelyek.IsReadOnly = true;
            TbHajoHolvan.IsReadOnly = true;
            TbPic.Visibility = Visibility.Hidden;
            TbPic.Text = "";
            //--
            TbHajoNev.Text = "";
            TbHajoHelyek.Text = "";
            TbHajoHolvan.Text = "";
        }
        //------------------------

        //Szerkesztés
        //------------------------
        private void BtEditData_OnClick(object sender, RoutedEventArgs e)
        {
            BtEditDone.Visibility = Visibility.Visible;
            BtCancel.Visibility = Visibility.Visible;
            BtEditData.Visibility = Visibility.Hidden;
            BtPic.Visibility = Visibility.Visible;
            //--
            TbPic.Visibility = Visibility.Visible;            
            TbHajoNev.IsReadOnly = false;
            oldname = TbHajoNev.Text;
            TbHajoHelyek.IsReadOnly = false;
            TbHajoHolvan.IsReadOnly = false;
            TbPic.IsReadOnly = false;
        }
        //------------------------

    }
}

