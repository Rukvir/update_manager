using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class NewCustomer : Form
    {
        public NewCustomer()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Хранилище для значений IDENTITY, возвращаемых из базы данных.
        private int parsedCustomerID;
        private int orderID;

        /// Проверяет, что текстовое поле имени клиента не пусто.
        private bool IsCustomerNameValid()
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите имя.");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// Проверяет, что идентификатор клиента и сумма заказа были предоставлены.
        private bool IsOrderDataValid()
        {
            // Проверяем, что CustomerID присутствует.
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Пожалуйста, создайте учетную запись клиента перед размещением заказа.");
                return false;
            }
            // Убеждаемся, что сумма не равна 0.
            else if ((numOrderAmount.Value < 1))
            {
                MessageBox.Show("Пожалуйста, укажите сумму заказа.");
                return false;
            }
            else
            {
                // Заказ можно отправить.
                return true;
            }
        }

        /// Очищает данные формы.
        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtCustomerID.Clear();
            dtpOrderDate.Value = DateTime.Now;
            numOrderAmount.Value = 0;
            this.parsedCustomerID = 0;
        }

        /// Создает нового клиента, вызывая хранимую процедуру Sales.uspNewCustomer
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (IsCustomerNameValid())
            {
                // Подключаемся.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.testConnectionString))
                {
                    // Создаёт SqlCommand и определяет его как хранимую процедуру.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspNewCustomer", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Добавляет входной параметр для хранимой процедуры и указывает, что использовать в качестве его значения.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;

                        // Добавляет выходной параметр.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();

                            // Идентификатор клиента — это значение IDENTITY из базы данных.
                            this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;

                            this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);
                        }
                        catch
                        {
                            MessageBox.Show("Идентификатор клиента не был возвращен. Аккаунт не удалось создать.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        /// Вызывает хранимую процедуру Sales.uspPlaceNewOrder для размещения заказа
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderDataValid())
            {
                // Подключаемся.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.testConnectionString))
                {
                    // Создаем SqlCommand и определяем его как хранимую процедуру.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspPlaceNewOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Добавляем входной параметр @CustomerID, полученный от uspNewCustomer.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Value = this.parsedCustomerID;

                        // Добавляем входной параметр @OrderDate.
                        sqlCommand.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@OrderDate"].Value = dtpOrderDate.Value;

                        // Добавляем  параметр ввода суммы заказа @Amount.
                        sqlCommand.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int));
                        sqlCommand.Parameters["@Amount"].Value = numOrderAmount.Value;

                        // Добавляем входной параметр статуса заказа @Status.
                        sqlCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Char, 1));
                        sqlCommand.Parameters["@Status"].Value = "O";

                        // Добавляем возвращаемое значение для хранимой процедуры, которое является ID заказа.
                        sqlCommand.Parameters.Add(new SqlParameter("@RC", SqlDbType.Int));
                        sqlCommand.Parameters["@RC"].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();

                            this.orderID = (int)sqlCommand.Parameters["@RC"].Value;
                            MessageBox.Show("Order number " + this.orderID + " has been submitted.");
                        }
                        catch
                        {
                            MessageBox.Show("Order could not be placed.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnAddFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
