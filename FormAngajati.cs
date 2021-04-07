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
    /// Form class that shows the "Angajati"(Employees) Table and its options. 
    /// </summary>
    public partial class FormAngajati : Form
    {
        private ContextMenuStrip contextMenuForDataGrid = new ContextMenuStrip();
        private int cod_departament;
        private int cellClickEmployeeCode;
        private string connectionString = "Server=DESKTOP-UL5OO6V\\BOGDAN;Database=depozit2;Integrated Security=true";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds = new DataSet();

        /// <summary>
        /// Constructor with a parameter.
        /// </summary>
        /// <param name="cod_departament">determines which employees to show = int</param>
        public FormAngajati(int cod_departament)
        {
            InitializeComponent();
            this.cod_departament = cod_departament;
        }

        /// <summary>
        /// Event handler for the form that connects to the server and shows the desired elements in <see cref="dataGridView1"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void FormAngajati_Load(object sender, EventArgs e)
        {
            var deleteItem = contextMenuForDataGrid.Items.Add("Stergere angajat");
            deleteItem.Click += contextMenuDelete_Click;
            var updateItem = contextMenuForDataGrid.Items.Add("Update angajat");
            updateItem.Click += contextMenuUpdate_Click;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Angajati WHERE Angajati.cod_departament=@departmentCode;", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@departmentCode", this.cod_departament);
                    adapter.Fill(ds, "Departament");
                    dataGridView1.DataSource = ds.Tables["Departament"];
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Event handler for the cell click event on dataGridView1 that shows the <see cref="contextMenuForDataGrid"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    this.cellClickEmployeeCode = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["cod_angajat"].Value);
                    contextMenuForDataGrid.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Apasati pe o inregistrare valida!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Event handler for the click event on the first option of <see cref="contextMenuForDataGrid"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void contextMenuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM Angajati WHERE Angajati.cod_angajat=@employeeCode;", connection);
                    deleteCommand.Parameters.AddWithValue("@employeeCode", this.cellClickEmployeeCode);
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Event handler for the click event on the second option of <see cref="contextMenuForDataGrid"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void contextMenuUpdate_Click(object sender, EventArgs e)
        {
            FormUpdateEmployee fU = new FormUpdateEmployee(cellClickEmployeeCode);
            fU.Show();
        }

        /// <summary>
        /// Event handler for the closing event of this Form.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void FormAngajati_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            FormDepartament fD = new FormDepartament();
            fD.Show();
        }

        /// <summary>
        /// Event handler for the click event on button1, event that refreshes the data in <see cref="dataGridView1"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter.SelectCommand.Connection = connection;
                    ds.Tables[0].TableName = "Angajati";
                    ds.Tables["Angajati"].Clear();
                    adapter.Fill(ds, "Angajati");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
