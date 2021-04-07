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
    /// Form class that shows the Department Table and its options.
    /// </summary>
    public partial class FormDepartament : Form
    {
        private ContextMenuStrip contextMenuForDataGrid = new ContextMenuStrip();
        private int cod_departament;
        //Replace "DESKTOP-UL5OO6V\\BOGDAN" with desired server.
        private string connectionString = "Server=DESKTOP-UL5OO6V\\BOGDAN;Database=depozit2;Integrated Security=true";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds = new DataSet();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FormDepartament()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the form that connects to the server and shows all the elements in <see cref="dataGridView1"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void FormDepartament_Load(object sender, EventArgs e)
        {
            var showItem = contextMenuForDataGrid.Items.Add("Afiseaza angajatii departamentului");
            showItem.Click += contextMenuShow_Click;
            var updateItem = contextMenuForDataGrid.Items.Add("Adauga un angajat la departament");
            updateItem.Click += contextMenuAdd_Click;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Departament;", connection);
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
        /// Event handler for the cell click event on the dataGridView1 that shows the <see cref="contextMenuForDataGrid"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    contextMenuForDataGrid.Show(Cursor.Position.X, Cursor.Position.Y);
                    cod_departament = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["cod_departament"].Value);
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
        private void contextMenuShow_Click(object sender, EventArgs e)
        {
            FormAngajati fA = new FormAngajati(cod_departament);
            fA.Show();
            this.Dispose();
        }

        /// <summary>
        /// Event handler for the click event on the second option of <see cref="contextMenuForDataGrid"/>.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void contextMenuAdd_Click(object sender, EventArgs e)
        {
            FormAddEmployee fAdd = new FormAddEmployee(cod_departament);
            fAdd.Show();
        }

        /// <summary>
        /// Event handler for the closing event of this Form.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void FormDepartament_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            FormStart fS = new FormStart();
            fS.Show();
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
                    ds.Tables["Departament"].Clear();
                    adapter.Fill(ds, "Departament");
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
