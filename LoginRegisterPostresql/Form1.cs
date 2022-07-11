namespace LoginRegisterPostresql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LoginRegisterPstgre conexion = new LoginRegisterPstgre();

        private void btn_login_Click(object sender, EventArgs e)
        {
            conexion.Login(txtBox_usuario.Text, txtBox_clave.Text);
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            conexion.Register(txtBox_usuario.Text, txtBox_clave.Text);
        }
    }
}