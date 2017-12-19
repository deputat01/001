using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=localhost;DATABASE=menu;UID=root;password=c_ronaldo";
            MySqlConnection connection = new MySqlConnection(connectionString);
            //MySqlCommand cmd = new MySqlCommand("select * from users where user_login='" + user_name.Text + "' and user_password='" + user_password.Password + "';", connection);
            //connection.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //connection.Close();
            //MainMenuWindow mainMenuWindow = new MainMenuWindow();
            //mainMenuWindow.mainMenu.DataContext = dt;
            //this.Close();
            //mainMenuWindow.Show();
            

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                MySqlCommand cmd = new MySqlCommand("select * from users where name='" + user_name.Text + "' and password='" + user_password.Password + "';", connection);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    
                    MainMenuWindow mainMenuWindow = new MainMenuWindow();
                    mainMenuWindow.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("Пароль или логин неверный!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);



            }
            finally
            {
                connection.Close();
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            this.Close();
            registration.Show();
        }
    }
}
