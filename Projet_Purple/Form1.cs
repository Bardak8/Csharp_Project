namespace Projet_Purple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Commencer_Click_1(object sender, EventArgs e)
        {
            //open new form
            Form2 f2 = new Form2();//Create the new form
            this.Hide();
            f2.Show();//display Form2 to the user
        }
    }
}