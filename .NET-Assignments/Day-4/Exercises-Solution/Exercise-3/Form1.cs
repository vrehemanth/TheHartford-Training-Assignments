using System;
using System.Windows.Forms;

namespace Exercise_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnRemoveState_Click_1(object sender, EventArgs e)
        {
            if (comboBoxState.SelectedItem != null)
            {
                comboBoxState.Items.Remove(comboBoxState.SelectedItem);
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                CountryView.Items.Add(txtCountry.Text);
                txtCountry.Clear();
            }

            if (!string.IsNullOrWhiteSpace(txtState.Text))
            {
                comboBoxState.Items.Add(txtState.Text);
                txtState.Clear();
            }
        }

        private void btnShowDetails_Click_1(object sender, EventArgs e)
        {
            if ((chkEmail.Checked || chkPostal.Checked) && rbMale.Checked)
            {
                MessageBox.Show(
                    "Hello Mr, you will be contacted by either USPS or Email",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if ((chkEmail.Checked || chkPostal.Checked) && rbFemale.Checked)
            {
                MessageBox.Show(
                    "Hello Madam, you will be contacted by either USPS or Email",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Please select contact method and gender",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveCountry_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in CountryView.CheckedItems)
            {
                CountryView.Items.Remove(item);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
