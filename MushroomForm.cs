namespace Lab2App;

public class MushroomForm : Form
{
    // NOTE: replace the rules with the ones from your Lab 1 console code
    ComboBox cmbColor = new ComboBox { Left = 130, Top = 20, Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };
    CheckBox chkSpots = new CheckBox { Text = "Has spots", Left = 130, Top = 60, AutoSize = true };
    CheckBox chkGills = new CheckBox { Text = "Has gills", Left = 130, Top = 90, AutoSize = true };

    public MushroomForm()
    {
        Text = "Mushroom Identification";
        ClientSize = new Size(330, 230);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        cmbColor.Items.AddRange(new object[] { "Red", "White", "Brown", "Yellow" });

        var btnId = Nav.Btn("Identify", 130, 130, 100);
        var btnBack = Nav.Btn("Back", 30, 180, 100);
        var btnLogout = Nav.Btn("Logout", 200, 180, 100);

        btnId.Click += BtnIdentify_Click;
        btnBack.Click += (s, e) => Nav.Go(this, new ChooseForm());
        btnLogout.Click += (s, e) => Nav.Go(this, new LoginForm());

        Controls.AddRange(new Control[] {
            Nav.Lbl("Cap colour:", 20, 23), cmbColor, chkSpots, chkGills,
            btnId, btnBack, btnLogout });
    }

    void BtnIdentify_Click(object s, EventArgs e)
    {
        if (cmbColor.SelectedItem == null)
        {
            MessageBox.Show("Please choose the cap colour.", "Invalid input",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string color = cmbColor.SelectedItem.ToString();
        bool spots = chkSpots.Checked, gills = chkGills.Checked;
        string result; MessageBoxIcon icon = MessageBoxIcon.Information;

        if (color == "Red" && spots)            { result = "Fly Agaric - POISONOUS"; icon = MessageBoxIcon.Warning; }
        else if (color == "White" && gills)     { result = "Destroying Angel / Death Cap - DEADLY"; icon = MessageBoxIcon.Stop; }
        else if (color == "Brown" && !gills)    { result = "Porcini - Edible"; }
        else if (color == "Yellow" && gills)    { result = "Chanterelle - Edible"; }
        else                                    { result = "Unknown mushroom - do NOT eat it!"; icon = MessageBoxIcon.Warning; }

        MessageBox.Show(result, "Result", MessageBoxButtons.OK, icon);
    }
}
