using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newResumefolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(EmpNumberBox.Text == String.Empty || int.TryParse(EmpNumberBox.Text, out int n)))
            {
                MessageBox.Show("Employee Number can only include digits");
                EmpNumberBox.Focus();
                return;
            }
            if (!comboBox1.Items.Contains(comboBox1.Text))
            {
                MessageBox.Show("Invalid office selection");
                comboBox1.Focus();
                return;
            }
            NewDirectory createdDirectory = new NewDirectory(FirstNameBox.Text, LastNameBox.Text, comboBox1.SelectedItem.ToString(),EmpNumberBox.Text);

            if (createdDirectory.CreateDirectories())
                MessageBox.Show($"Successfully created folders for {FirstNameBox.Text} {LastNameBox.Text}");
            else
                MessageBox.Show($"Folders for {FirstNameBox.Text} {LastNameBox.Text} already exist");
            ClearForm();

        }
        private void ClearForm()
        {
            FirstNameBox.Text = String.Empty;
            LastNameBox.Text = String.Empty;
            comboBox1.SelectedItem = null;
            EmpNumberBox.Text = String.Empty;
            SendKeys.Send("{TAB}");
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() => { MessageBox.Show("Directory Builder v1.0\nAuthor: Ralston Lawson\n\u00A9 2017", "About"); }));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() => { MessageBox.Show("Directory Builder v1.0\nAuthor: Ralston Lawson\n\u00A9 2017", "About"); }));
        }

    }
}
