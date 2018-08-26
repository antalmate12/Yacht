using System.Windows;

namespace Yacht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private Window1 _w1 = new Window1();
        private Window2 _w2 = new Window2();
        static LoginSql _l = new LoginSql();
        public static string Checklogin = "SELECT COUNT(*) FROM Login WHERE username=@username AND Password=@pass;";


        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\antal\Desktop\Yacht\Yacht\DBYacht.mdf;Integrated Security=True");


        // private static readonly string Fullpath = Path.(@"../../login.mdf");
        //public SqlConnection Con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
        //                                               {Fullpath};Integrated Security=True");
        //
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TbUserName.Text != "")
            {
                var username = TbUserName.Text;
                if (TbPass.Password != "")
                {
                    var pass = TbPass.Password;

                    //Sikeres bejelentkezés
                    //-------------------------------------
                    if (_l.Login(username, pass, Checklogin))
                    {
                        //Admin belépés
                        //-------------------------------------
                        if (_l.CheckIfAdmin(username) == "True"){Close();_w2.Show();}
                        //Tag belépés
                        //-------------------------------------
                        else{Close();_w1.Show();}
                        //-------------------------------------
                    }
                    //-------------------------------------
                    else
                    {
                        TbUserName.Text = "";
                        TbPass.Password = "";
                    }
                }
                else
                {
                    MessageBox.Show("A jelszavad ne legyen már üres légyszi.");
                    TbUserName.Text = "";
                    TbPass.Password = "";
                }
            }
            else
            {
                MessageBox.Show("A felhasználóneved ne legyen már üres légyszi.");
                TbUserName.Text = "";
                TbPass.Password = "";
            }
        }
        //------------------------

        //Kilépés
        //-------------------------------------
        private void BtLoginExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //-------------------------------------
    }
}

