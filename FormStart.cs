using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2._1
{
    /// <summary>
    /// Form class that is the main menu.
    /// </summary>
    public partial class FormStart : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FormStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the form.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void FormStart_Load(object sender, EventArgs e)
        {
        }
       
        /// <summary>
        /// Event handler for the click event on button1.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDepartament fD = new FormDepartament();
            fD.Show();
        }

        /// <summary>
        /// Event handler for the closing of the Form.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
