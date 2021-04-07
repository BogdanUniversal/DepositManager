using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab2._1
{
    /// <summary>
    /// Form class that shows the add menu.
    /// </summary>
    public partial class FormAddEmployee : Form
    {
        private int departmentCode;
        private int okSubmit = 0;
        private string newName;
        private string newBirthDate;
        private string newPosition;
        private string connectionString = "Server=DESKTOP-UL5OO6V\\BOGDAN;Database=depozit2;Integrated Security=true";
        private SqlDataAdapter adapter = new SqlDataAdapter();

        /// <summary>
        /// Constructor with a parameter which determines to which department to add the employee.
        /// </summary>
        /// <param name="departmentCode">determines to which department to add = int</param>
        public FormAddEmployee(int departmentCode)
        {
            InitializeComponent();
            this.departmentCode = departmentCode;
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Event handler for the click event on <see cref="buttonName"/> that automatically adds the employee to the table if all the data has been completed.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonName_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                okSubmit++;
                newName = textBox1.Text;
                label1.Hide();
                buttonName.Hide();
                textBox1.Hide();
            }
            else
                MessageBox.Show("Nu ati introdus date!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (okSubmit == 3)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("INSERT INTO Angajati(nume_angajat, data_nasterii, post, cod_departament) VALUES (@newName, @newBirthDate, @newPosition, @departmentCode);", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@DepartmentCode", departmentCode);
                        updateCommand.ExecuteNonQuery();
                        connection.Close();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Event handler for the click event on <see cref="buttonBirthDate"/> that automatically adds the employee to the table if all the data has been completed.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonBirthDate_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                okSubmit++;
                newBirthDate = textBox2.Text;
                label2.Hide();
                buttonBirthDate.Hide();
                textBox2.Hide();
            }
            else
                MessageBox.Show("Nu ati introdus date!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (okSubmit == 3)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("INSERT INTO Angajati(nume_angajat, data_nasterii, post, cod_departament) VALUES (@newName, @newBirthDate, @newPosition, @departmentCode);", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@DepartmentCode", departmentCode);
                        updateCommand.ExecuteNonQuery();
                        connection.Close();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Event handler for the click event on <see cref="buttonPosition"/> that automatically adds the employee to the table if all the data has been completed.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonPosition_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != null)
            {
                okSubmit++;
                newPosition = textBox3.Text;
                label3.Hide();
                buttonPosition.Hide();
                textBox3.Hide();
            }
            else
                MessageBox.Show("Nu ati introdus date!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (okSubmit == 3)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("INSERT INTO Angajati(nume_angajat, data_nasterii, post, cod_departament) VALUES (@newName, @newBirthDate, @newPosition, @departmentCode);", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@DepartmentCode", departmentCode);
                        updateCommand.ExecuteNonQuery();
                        connection.Close();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Event handler for the closing event of this Form.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void FormAddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
