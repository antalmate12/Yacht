using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace Yacht
{
    internal class LoginSql
    {
        //Connection String
        //------------------------
        private static readonly string Fullpath = Path.GetFullPath(@"../../DBYacht.mdf");
        public SqlConnection Con =
            new SqlConnection(
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Fullpath};Integrated Security=True");
        //------------------------

        //LoggedinUser
        //------------------------
        public static string Loggedinuser;        
        public string GetLoggedinUser()
        {
            return Loggedinuser;
        }
        //------------------------

        //Bejelentkezés
        //------------------------
        public bool Login(string username, string pass, string query)
        {
            Con.Open();
            var dt = new DataTable();
            var sda = new SqlDataAdapter(query, Con);
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            sda.SelectCommand.Parameters["@username"].Value = username;
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@pass", SqlDbType.VarChar);
            sda.SelectCommand.Parameters["@pass"].Value = pass;
            //------------------------
            sda.Fill(dt);
            //Ha sikerült a bejelentkezés
            if (dt.Rows[0][0].ToString() == "1")
            {
                Con.Close();
                Loggedinuser = username;
                return true;
            }
            //Ha nem sikerült
            else
            {
                Con.Close();
                MessageBox.Show("Nem sikerült bejelentkezni. Valamit elírtál?","", MessageBoxButton.OK);
                return false;
            }
            //------------------------
        }
        //------------------------

        //Admin <> Tag?
        //------------------------
        public string CheckIfAdmin(string username)
        {
            Con.Open();
            const string query = "SELECT Admin FROM Login WHERE username=@UserName;";
            var cmd = new SqlCommand(query, Con);
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            cmd.Parameters["@UserName"].Value = username;
            try
            {
                var admin = cmd.ExecuteScalar().ToString();
                Con.Close();
                return admin;
            }
            catch (Exception ex)
            {
                Con.Close();
                return (ex.Message);
            }
        }
        //------------------------

        //UserName Taken?
        //------------------------
        public bool IsUsernameAlreadyTaken(string username)
        {
            var sda = new SqlDataAdapter("SELECT count(*) FROM Login WHERE username='" + username + "'", Con);
            var dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                dt.Clear();
                return true;
            }
            else
            {
                dt.Clear();
                return false;
            }
        }
        //------------------------

        #region Register
        //Register User
        //------------------------
        public void RegUser(string username, string pass, byte admin)
        {
            Con.Open();
            var reg = new SqlCommand(
                "INSERT INTO Login (username,Password,Admin) VALUES (@username,@Password,@Admin)",
                Con);
            //SQL Injection Protection
            reg.Parameters.Add("@username", SqlDbType.VarChar);
            reg.Parameters["@username"].Value = username;
            //SQL Injection Protection
            //reg.Parameters.Add("@FullName", SqlDbType.VarChar);
            //reg.Parameters["@FullName"].Value = name;
            //SQL Injection Protection
            reg.Parameters.Add("@Password", SqlDbType.VarChar);
            reg.Parameters["@Password"].Value = pass;
            //SQL Injection Protection
            reg.Parameters.Add("@Admin", SqlDbType.VarChar);
            reg.Parameters["@Admin"].Value = admin;
            //--
            reg.ExecuteNonQuery();
            Con.Close();
        }
        //------------------------

        //Register Ship
        //------------------------
        public void RegHajo(int tulajid, string hajonev)
        {
            Con.Open();
            var reg = new SqlCommand("INSERT INTO Hajok (TulajId,HajoNev) VALUES (@tulajid,@hajonev)", Con);
            //SQL Injection Protection
            reg.Parameters.Add("@tulajid", SqlDbType.Int);
            reg.Parameters["@tulajid"].Value = tulajid;
            //SQL Injection Protection
            reg.Parameters.Add("@hajonev", SqlDbType.VarChar);
            reg.Parameters["@hajonev"].Value = hajonev;
            //------------------------
            reg.ExecuteNonQuery();
            Con.Close();
        }
        //------------------------

        //Register Treler
        //------------------------
        public void RegTreler(int tulaj)
        {
            Con.Open();
            var reg = new SqlCommand("INSERT INTO Treler (TulajId) VALUES (@tulajid)", Con);
            //SQL Injection Protection
            reg.Parameters.Add("@tulajid", SqlDbType.VarChar);
            reg.Parameters["@tulajid"].Value = tulaj;
            //------------------------
            reg.ExecuteNonQuery();
            Con.Close();
        }
        //------------------------
        #endregion

        //Profil Adatmódosítás
        //------------------------
        public void ChangeUserData(string name, string about)
        {
            Con.Open();
            const string query1 = "UPDATE Login SET FullName = @name WHERE username = @username ";
            const string query2 = "UPDATE Login SET Leiras = @about WHERE username = @username ";

            var rename = new SqlCommand(query1, Con);
            //--
            rename.Parameters.Add("@name", SqlDbType.VarChar);
            rename.Parameters["@name"].Value = name;
            //--
            rename.Parameters.Add("@username", SqlDbType.VarChar);
            rename.Parameters["@username"].Value = GetLoggedinUser();
            //-
            rename.ExecuteNonQuery();
            //------------------------


            rename = new SqlCommand(query2, Con);
            //--
            rename.Parameters.Add("@about", SqlDbType.VarChar);
            rename.Parameters["@about"].Value = about;
            //--
            rename.Parameters.Add("@username", SqlDbType.VarChar);
            rename.Parameters["@username"].Value = GetLoggedinUser();
            //-
            rename.ExecuteNonQuery();
            //--
            Con.Close();
        }
        //------------------------

        //static Program p = new Program();
        /*static string checklogin = "SELECT count(*) FROM Login WHERE username=@username AND Password=@pass;";
        private static string select;
        string name, email, username, pass;

        public DataTable datatable = new DataTable();

        
        #endregion

        #region login

        //Bejelentkezés elkezdése
        //------------------------
        public void StartLogin()
        {
            try
            {
                //Csatlakozás az adatbázishoz
                p.Con.Open();
            }
            catch
            {
                //Ha nem tud csatlakozni
                Console.WriteLine("Nem sikerült csatlakozni az adatbázishoz :'(");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            select = "login";
            m.ArraySelect(select);
        }


        //Bejelentkezés
        //------------------------
        public void DoLogin()
        {
            select = null;
            username = null;
            pass = null;
            datatable.Clear();
            Console.WriteLine("Bejelentkezés...\n");

            //Felhasználónév
            //------------------------
            Console.WriteLine("Felhasználónév:");
            while (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                username = Console.ReadLine();
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nFelhasználónév:");
                }
            }
            //------------------------

            //Jelszó
            //------------------------
            Console.WriteLine("Jelszó:");
            while (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
            {
                pass = Orb.App.Console.ReadPassword();

                if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nJelszó:");
                }
            }
            //------------------------

            //Bejelentkezés SQl
            //------------------------
            loggedinusername = username;
            p.Setlgduser(loggedinusername);
            var sda = new SqlDataAdapter(checklogin, p.Con);
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            sda.SelectCommand.Parameters["@username"].Value = username;
            //SQL Injection Protection
            sda.SelectCommand.Parameters.AddWithValue("@pass", SqlDbType.VarChar);
            sda.SelectCommand.Parameters["@pass"].Value = pass;
            //------------------------
            sda.Fill(datatable);
            //Ha sikerült a bejelentkezés
            if (datatable.Rows[0][0].ToString() == "1")
            {
                p.Con.Close();
                select = "menu";
                //Főmenü
                m.ArraySelect(select);
            }
            //Ha nem sikerült
            else
            {
                select = "badlogin";
                //Újrapróbálkozós-Regisztráció menü
                m.ArraySelect(select);
            }
            //------------------------
        }
        //------------------------

        //Regisztráció
        //------------------------
        public void DoReg()
        {
            select = null;
            username = null;
            pass = null;
            datatable.Clear();
            Console.WriteLine("Regisztráció...");

            //Mindent ellenőrzötten kérünk be. Nem lehet null vagy whitespace.
            //Nem lehet már használatban lévő felhasználónév

            //Felhasználónév megadása
            //------------------------
            Console.WriteLine("Adjon meg egy felhasználónevet:");
            while (string.IsNullOrEmpty(username) || IsUsernameAlreadyTaken(username) || string.IsNullOrWhiteSpace(username))
            {
                username = Console.ReadLine();
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nAdjon meg egy felhasználónevet:");
                }
                if (IsUsernameAlreadyTaken(username) && !string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Ez a név már foglalt. \nAdjon meg egy másik felhasználónevet:");
                }
            }
            //------------------------

            //Vezetéknév megadása
            //------------------------
            string vnev = null, knev = null;
            Console.WriteLine("Adja meg a vezetéknevét:");
            while (string.IsNullOrEmpty(vnev) || string.IsNullOrWhiteSpace(vnev))
            {
                vnev = Console.ReadLine();
                if (string.IsNullOrEmpty(vnev) || string.IsNullOrWhiteSpace(vnev))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nAdja meg a vezetéknevét:");
                }
            }
            //------------------------

            //Keresztnév megadása
            //------------------------
            Console.WriteLine("Adja meg a keresztnevét:");
            while (string.IsNullOrEmpty(knev) || string.IsNullOrWhiteSpace(knev))
            {
                knev = Console.ReadLine();
                if (string.IsNullOrEmpty(knev) || string.IsNullOrWhiteSpace(knev))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nAdja meg a keresztnevét:");
                }
            }
            //------------------------

            //Email megadás
            //------------------------
            Console.WriteLine("Adja meg az email címét:");
            while (string.IsNullOrEmpty(email) || IsValidEmail(email) == false)
            {
                email = Console.ReadLine();

                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nAdja meg az email címét:");
                }
                //Plusz ellenőrzés. Valós formátumú email cím-e
                if (IsValidEmail(email) == false && !string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Hibás formátumú email cím. \nAdja meg az email címét:");
                }
            }
            //------------------------

            //Jelszó megadása
            //------------------------
            Console.WriteLine("Adjon meg egy jelszót:");
            while (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
            {
                pass = Orb.App.Console.ReadPassword();
                if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
                {
                    Console.WriteLine("Ez a mező nem lehet üres. \nAdjon meg egy jelszót:");
                }
            }
            //------------------------


            //TELJES NÉV FORMÁZÁSA
            //------------------------
            //mindenből kisbetű
            /*vnev = vnev.ToLower();
            knev = knev.ToLower();
            //első betűkből nagybetű
            var sb1 = new StringBuilder(vnev);
            var sb2 = new StringBuilder(knev);
            sb1[0] = char.ToUpper(vnev[0]);
            sb2[0] = char.ToUpper(knev[0]);
            vnev = sb1.ToString();
            knev = sb2.ToString();
            name = vnev + " " + knev;*/
        //------------------------
        /*
        //Regisztráció SQL kód
        //------------------------
        #region register sql
        var reg = new SqlCommand("INSERT INTO Login (username,Name,Email,Password) VALUES (@username,@name,@email,@pass)", p.Con);
        //SQL Injection Protection
        reg.Parameters.Add("@username", SqlDbType.VarChar);
        reg.Parameters["@username"].Value = username;
        //SQL Injection Protection
        reg.Parameters.Add("@name", SqlDbType.VarChar);
        reg.Parameters["@name"].Value = name;
        //SQL Injection Protection
        reg.Parameters.Add("@email", SqlDbType.VarChar);
        reg.Parameters["@email"].Value = email;
        //SQL Injection Protection
        reg.Parameters.Add("@pass", SqlDbType.VarChar);
        reg.Parameters["@pass"].Value = pass;
        //--
        reg.ExecuteNonQuery();
        Console.WriteLine("Sikeres Regisztráció!");

        #endregion
        //------------------------

        username = null;
        name = null;
        pass = null;
        email = null;

        Thread.Sleep(1000);
        Console.Clear();
        //Bejelentkezés a sikeres regisztráció után
        DoLogin();
    }

    #endregion
*/
    }
}
