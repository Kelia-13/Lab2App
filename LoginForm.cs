namespace Lab2App;

public class LoginForm : Form
{
    TextBox txtUser = Nav.Txt(110, 30), txtPass = Nav.Txt(110, 70);

    public LoginForm()
    {
        Text = "Login";
        ClientSize = new Size(320, 170);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        txtPass.UseSystemPasswordChar = true;

        var btnLogin = Nav.Btn("Login", 110, 115);
        btnLogin.Click += BtnLogin_Click;
        AcceptButton = btnLogin;

        Controls.AddRange(new Control[] {
            Nav.Lbl("Username:", 25, 33), txtUser,
            Nav.Lbl("Password:", 25, 73), txtPass, btnLogin });
    }

    void BtnLogin_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
        {
            MessageBox.Show("Username and Password cannot be empty.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        MessageBox.Show($"Welcome, {txtUser.Text.Trim()}!", "Login");
        Nav.Go(this, new ChooseForm());
    }
}
