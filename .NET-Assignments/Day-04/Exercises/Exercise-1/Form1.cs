namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Investments");
            comboBox1.Items.Add("Savings");
            comboBox1.Items.Add("Insurance");
            comboBox1.Items.Add("Trading");
            comboBox1.SelectedIndex = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Name: " + textBox1.Text;
            str += "\nFather's Name: " + textBox2.Text;
            str += "\nDate of Birth: " + dateTimePicker1.Text;
            str += "\nPreferences in Life: " + comboBox1.Text;
            MessageBox.Show(str);
        }
    }
}
