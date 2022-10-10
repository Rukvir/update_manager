using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class FillOrCancel : Form
    {
        public FillOrCancel()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Хранение значения идентификатора заказа.
        private int parsedOrderID;

        private bool IsOrderIDValid()
        {
            // Проверяем ввод в текстовое поле «Идентификатор заказа».
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Укажите ID заказа.");
                return false;
            }

            // Проверка символов, отличных от целых чисел.
            else if (Regex.IsMatch(txtOrderID.Text, @"^\D*$"))
            {
                MessageBox.Show("ID клиента должен содержать только цифры.");
                txtOrderID.Clear();
                return false;
            }
            else
            {
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }

        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.testConnectionString))
                {
                    // Определяем строку запроса t-SQL с параметром для orderID.
                    const string sql = "SELECT * FROM Sales.Orders WHERE orderID = @orderID";

                    // Создаем объект SqlCommand.
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        // Определяем параметр @orderID и установим его значение.
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                DataTable dataTable = new DataTable();

                                dataTable.Load(dataReader);

                                this.dgvCustomerOrders.DataSource = dataTable;

                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Запрошенный заказ не может быть загружен в форму.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {

            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.testConnectionString))
                {
                    // Создаём объект SqlCommand и определите его как хранимую процедуру.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspCancelOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Операция отмены не была выполнена.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnFillOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.testConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspFillOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        sqlCommand.Parameters.Add(new SqlParameter("@FilledDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@FilledDate"].Value = dtpFillDate.Value;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Операция отмены не была выполнена.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnFinishUpdates_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
