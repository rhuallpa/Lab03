using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab03
{
    /// <summary>
    /// Lógica de interacción para DataReaderDesconectado.xaml
    /// </summary>
    public partial class DataReaderDesconectado : Window
    {
        public DataReaderDesconectado()
        {
            InitializeComponent();

            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS; Initial Catalog=LAB03HUALLPA; User Id=USERHUALLPA; " +
               "Password=123456";

            List<Estudiante> estudiantes = new List<Estudiante>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM STUDENTS", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader.GetString(reader.GetOrdinal("FirtsName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                            estudiantes.Add(new Estudiante { StudentId = studentId, FirstName = firstName, LastName = lastName });
                        }
                    }
                }

                dataGridEstudiantes.ItemsSource = estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
