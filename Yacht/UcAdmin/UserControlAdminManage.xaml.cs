using System.Windows;
using System.Data;
using System.Collections.Generic;
using System;
using System.Collections;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// ReSharper disable once CheckNamespace
namespace Yacht
{
    /// <summary>
    /// Interaction logic for UserControlHome.xaml
    /// </summary>
    public partial class UserControlAdminManage
    {
        private SqlQuerys _sql = new SqlQuerys();
        //private LoginSql _l = new LoginSql();
        private List<byte[]> kepekList;
        DataTable dt = new DataTable();
        public UserControlAdminManage()
        {
            InitializeComponent();
        }

        //private static BitmapImage LoadImage(byte[] ImageData)
        //{
        //    if (ImageData == null || ImageData.Length == 0) return null;
        //    var image = new BitmapImage();
        //    using (var mem = new MemoryStream(ImageData))
        //    {
        //        mem.Position = 0;
        //        image.BeginInit();
        //        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.UriSource = null;
        //        image.StreamSource = mem;
        //        image.EndInit();
        //    }
        //    image.Freeze();
        //    return image;
        //}

        //private void Feltolt(int i)
        //{
        //    var asdf = (DateTime)dt.Rows[i][5];
        //    var asdf2 = Convert.ToDateTime(dt.Rows[i][6]);
        //    HajokAdmin.Add(new HajokAdmin
        //    {
        //        HajoId = (int)dt.Rows[i][0],
        //        TulajId=(int)dt.Rows[i][1],
        //        HajoNev=dt.Rows[i][2].ToString(),
        //        Ferohely= (int)dt.Rows[i][3],
        //        HolVan= dt.Rows[i][4].ToString(),
        //        SzabadTol = asdf,
        //        SzabadIg =asdf2,
        //        Kep =LoadImage(dt.Rows[i][7] as byte[])
        //    }
        //        );
        //}

           

        //DataGridek Feltöltése
        //------------------------
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var dt2 =new DataTable();
            _sql.ListUsers(dt2);
            MyDataGridTag.ItemsSource = dt2.DefaultView;
            //--
            var dt3 = new DataTable();
            _sql.ListKolcs(dt3);
            MyDataGridKolcs.ItemsSource = dt3.DefaultView;
            //--
            _sql.ListShips(dt);
            //--
            MyDataGridHajo.ItemsSource = dt.DefaultView;
            MyDataGridHajo.Columns.RemoveAt(8);
            //--
        }
        //------------------------

        //Menügombok
        //------------------------
        #region Menu
        private void BtTagok_Click(object sender, RoutedEventArgs e)
        {
            MyDataGridHajo.Visibility = Visibility.Hidden;
            MyDataGridTag.Visibility = Visibility.Visible;
            MyDataGridKolcs.Visibility = Visibility.Hidden;
            //--
            TbHajok.Visibility = Visibility.Hidden;
            TbTagok.Visibility = Visibility.Visible;
            TbKolcs.Visibility = Visibility.Hidden;
        }

        private void BtHajok_Click(object sender, RoutedEventArgs e)
        {
            MyDataGridHajo.Visibility = Visibility.Visible;
            MyDataGridTag.Visibility = Visibility.Hidden;
            MyDataGridKolcs.Visibility = Visibility.Hidden;
            //--
            TbHajok.Visibility = Visibility.Visible;
            TbTagok.Visibility = Visibility.Hidden;
            TbKolcs.Visibility = Visibility.Hidden;
        }

        private void BtKolcs_Click(object sender, RoutedEventArgs e)
        {
            MyDataGridHajo.Visibility = Visibility.Hidden;
            MyDataGridTag.Visibility = Visibility.Hidden;
            MyDataGridKolcs.Visibility = Visibility.Visible;
            //--
            TbHajok.Visibility = Visibility.Hidden;
            TbTagok.Visibility = Visibility.Hidden;
            TbKolcs.Visibility = Visibility.Visible;
        }
        #endregion
        //------------------------
    }
}
