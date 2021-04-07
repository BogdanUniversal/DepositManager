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
    /// Form class that shows the update menu.
    /// </summary>
    public partial class FormUpdateEmployee : Form
    {
        private int oldEmployeeCode;
        private string newName;
        private string newBirthDate;
        private string newPosition;
        private string newDepartmentCode;
        private int okSubmit = 0;
        private string connectionString = "Server=DESKTOP-UL5OO6V\\BOGDAN;Database=depozit2;Integrated Security=true";
        private SqlDataAdapter adapter = new SqlDataAdapter();

        /// <summary>
        /// Constructor with a parameter that determines which employee to update.
        /// </summary>
        /// <param name="employeeCode"></param>
        public FormUpdateEmployee(int employeeCode)
        {
            InitializeComponent();
            this.oldEmployeeCode = employeeCode;
        }

        private void FormSubmit_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Event handler for the click event on <see cref="buttonName"/> that automatically adds the employee to the table if all the data has been completed.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonName_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !=null)
            {
                okSubmit++;
                newName = textBox1.Text;
                label1.Hide();
                buttonName.Hide();
                textBox1.Hide();
            }
            else
                MessageBox.Show("Nu ati introdus date!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if(okSubmit==4)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("UPDATE Angajati SET nume_angajat=@newName, data_nasterii=@newBirthDate, post=@newPosition, cod_departament=@newDepartmentCode" +
                            "  WHERE cod_angajat=@oldEmployeeCode;", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@newDepartmentCode", newDepartmentCode);
                        updateCommand.Parameters.AddWithValue("@oldEmployeeCode", oldEmployeeCode);
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
        private void buttonBirthDate_Click_1(object sender, EventArgs e)
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
            if (okSubmit == 4)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("UPDATE Angajati SET nume_angajat=@newName, data_nasterii=@newBirthDate, post=@newPosition, cod_departament=@newDepartmentCode" +
                            "  WHERE cod_angajat=@oldEmployeeCode;", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@newDepartmentCode", newDepartmentCode);
                        updateCommand.Parameters.AddWithValue("@oldEmployeeCode", oldEmployeeCode);
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
            if (okSubmit == 4)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("UPDATE Angajati SET nume_angajat=@newName, data_nasterii=@newBirthDate, post=@newPosition, cod_departament=@newDepartmentCode" +
                            "  WHERE cod_angajat=@oldEmployeeCode;", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@newDepartmentCode", newDepartmentCode);
                        updateCommand.Parameters.AddWithValue("@oldEmployeeCode", oldEmployeeCode);
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
        /// Event handler for the click event on <see cref="buttonDepartmentCode"/> that automatically adds the employee to the table if all the data has been completed.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buttonDepartmentCode_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != null)
            {
                okSubmit++;
                newDepartmentCode = textBox4.Text;
                label4.Hide();
                buttonDepartmentCode.Hide();
                textBox4.Hide();
            }
            else
                MessageBox.Show("Nu ati introdus date!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (okSubmit == 4)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("UPDATE Angajati SET nume_angajat=@newName, data_nasterii=@newBirthDate, post=@newPosition, cod_departament=@newDepartmentCode" +
                            "  WHERE cod_angajat=@oldEmployeeCode;", connection);
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newBirthDate", newBirthDate);
                        updateCommand.Parameters.AddWithValue("@newPosition", newPosition);
                        updateCommand.Parameters.AddWithValue("@newDepartmentCode", newDepartmentCode);
                        updateCommand.Parameters.AddWithValue("@oldEmployeeCode", oldEmployeeCode);
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
    }
}
