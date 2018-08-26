using System;
using System.Windows;

// ReSharper disable once CheckNamespace
namespace Yacht
{
    /// <summary>
    /// Interaction logic for UserControlAdminReg.xaml
    /// </summary>
    public partial class UserControlAdminReg
    {
        private LoginSql _l = new LoginSql();
        private SqlQuerys _sql = new SqlQuerys();

        public UserControlAdminReg()
        {
            InitializeComponent();            
        }

        //Felhasználó regisztráció
        //------------------------
        private void BtStartReg_Click(object sender, RoutedEventArgs e)
        {
            var username = TbRegUsername.Text;
            //string fullname = TbRegFullname.Text;
            var pass = TbRegPass.Password;

            //Hülye volt-e?
            //------------------------
            bool un, ps;

            if (!(string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username)))
            {
                if (!(_l.IsUsernameAlreadyTaken(username)))
                {
                    un = true;
                }
                else
                {
                    un = false;
                    MessageBox.Show("Ez a felhasználónév már foglalt.", "Hülye vagy");
                    TbRegUsername.Text = "";
                    TbRegPass.Password = "";
                    CbRegAdmin.IsChecked = false;
                }
            }
            else
            {
                un = false;
                MessageBox.Show("Ez a felhasználónév nem feltétlenül jó.", "Hülye vagy");
                TbRegUsername.Text = "";
                TbRegPass.Password = "";
                CbRegAdmin.IsChecked = false;
            }

            if (!(string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass)))
            {
                ps = true;
            }
            else
            {
                ps = false;
                MessageBox.Show("Ez aztán az erős jelszó...", "Hülye vagy");
                TbRegUsername.Text = "";
                TbRegPass.Password = "";
                CbRegAdmin.IsChecked = false;
            }
            //------------------------

            //Admin vagy tag?
            //------------------------
            byte admin;
            // ReSharper disable once PossibleInvalidOperationException
            if ((bool)CbRegAdmin.IsChecked)
            {
                admin = 1; //Admin
            }
            else
            {
                admin = 0; //Tag
            }
            //------------------------

            //Regisztráció
            //------------------------
            if (un && ps)
            {
                _l.RegUser(username, pass, admin);
                //TbRegFullname.Text = "";
                TbRegUsername.Text = "";
                TbRegPass.Password = "";
                CbRegAdmin.IsChecked = false;
            }
            //------------------------
        }
        //------------------------

        //Hajó regisztrálása
        //------------------------
        private void BtStartRegHajo_Click_1(object sender, RoutedEventArgs e)
        {
            string tulajun = TbRegHajoTulaj.Text;
            string hajonev = TbRegHajoNev.Text;
            int tulajid = 0;
                
            //Hülye volt-e?
            //------------------------
            bool ti = false,hn = false;

            //Tulaj felhasználóneve jó-e?
            //------------------------
            if (!(string.IsNullOrEmpty(tulajun) || string.IsNullOrWhiteSpace(tulajun)))
            {
                if (_sql.IsValidUserName(tulajun))
                {
                    ti = true;
                    tulajid = Convert.ToInt32(_sql.GetUserId(tulajun));
                    //------------------------
                    //HajóNév Jó-e?
                    //------------------------
                    if (!(string.IsNullOrEmpty(hajonev) || string.IsNullOrWhiteSpace(hajonev)))
                    {
                        if (!_sql.IsShipNameTaken(tulajun, hajonev))
                        {
                            hn = true;
                        }
                        else
                        {
                            hn = false;
                            MessageBox.Show("Ennek a felhasználónak már van egy ilyen nevü hajója", "Hülye vagy");
                            TbRegHajoNev.Text = "";
                            TbRegHajoTulaj.Text = "";
                        }
                        //hn = true;
                    }
                    else
                    {
                        hn = false;
                        MessageBox.Show("Érdekes hajónév...gratulálok hozzá", "Hülye vagy");
                        TbRegHajoNev.Text = "";
                        TbRegHajoTulaj.Text = "";
                    }
                    //------------------------
                }
                else
                {
                    ti = false;
                    MessageBox.Show("Nincs ilyen felhasználónév.", "Hülye vagy");
                    TbRegHajoNev.Text = "";
                    TbRegHajoTulaj.Text = "";

                }
            }
            if (string.IsNullOrEmpty(tulajun) || string.IsNullOrWhiteSpace(tulajun))
            {
                ti = false;
                MessageBox.Show("Ez a felhasználónév nem feltétlenül jó.", "Hülye vagy");
                TbRegHajoNev.Text = "";
                TbRegHajoTulaj.Text = "";                
            }
            //------------------------


            //Regisztráció
            //------------------------
            if (ti && hn)
            {
                _l.RegHajo(tulajid, hajonev);
                TbRegHajoNev.Text = "";
                TbRegHajoTulaj.Text = "";
            }
            //------------------------
        }
        //------------------------

        //Tréler regisztrálása
        //------------------------
        private void BtStartRegTreler_Click_1(object sender, RoutedEventArgs e)
        {
            string tulajun = TbRegTrelerTulaj.Text;
            bool un;
            int tulajid = 0;
            if (!(string.IsNullOrEmpty(tulajun) || string.IsNullOrWhiteSpace(tulajun)))
            {
                if (_sql.IsValidUserName(tulajun))
                {
                    un = true;
                    tulajid = Convert.ToInt32(_sql.GetUserId(tulajun));

                }
                else
                {
                    un = false;
                    MessageBox.Show("Nincs ilyen felhasználónév.", "Hülye vagy");
                }
            }
            else
            {
                un = false;
                MessageBox.Show("Ez a felhasználónév nem feltétlenül jó.", "Hülye vagy");
            }

            //Regisztráció
            //------------------------
            if (un)
            {
                _l.RegTreler(tulajid);
                TbRegTrelerTulaj.Text = "";
            }
            //------------------------
        }
        //------------------------
    }
}
