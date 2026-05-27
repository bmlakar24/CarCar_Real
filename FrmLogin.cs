using System;
using System.Windows.Forms;
using DBLayer;

namespace CarCar
{
    public partial class FrmLogin : Form
    {
        string username_admin= "admin";
        string password_admin = "admin";
        string username_zap = "zaposlenik";
        string password_zap = "zaposlenik";

        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DB.SetConfiguration("PI2526_bmlakar24_DB", "PI2526_bmlakar24", "|7Qpe;.NZ!}Fj[sj");
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Korisničko ime nije uneseno!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Lozinka nije unesena!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtUsername.Text == username_admin && txtPassword.Text == password_admin)
                {
                    FrmAdmin frmAdmin = new FrmAdmin();
                    Hide();
                    frmAdmin.ShowDialog();
                    Close();
                }
                else if (txtUsername.Text == username_zap && txtPassword.Text == password_zap)
                {
                    FrmZaposlenik frmZaposlenik = new FrmZaposlenik();
                    Hide();
                    frmZaposlenik.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Krivi podaci!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
