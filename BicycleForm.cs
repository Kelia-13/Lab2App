namespace Lab2App;

public class BicycleForm : Form
{
    // NOTE: replace rates/discount with the ones from your Lab 1 console code
    static readonly Dictionary<string, decimal> Rates = new()
    {
        ["City"] = 500m, ["Mountain"] = 800m, ["Electric"] = 1500m   // per hour
    };
    const int DiscountHours = 5;
    const decimal DiscountRate = 0.10m;

    TextBox txtName = Nav.Txt(130, 20), txtHours = Nav.Txt(130, 100, 80), txtTotal = Nav.Txt(130, 205, 120);
    ComboBox cmbType = new ComboBox { Left = 130, Top = 60, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
    decimal total = 0;

    public BicycleForm()
    {
        Text = "Bicycle Renting";
        ClientSize = new Size(340, 320);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        cmbType.Items.AddRange(Rates.Keys.ToArray());
        txtTotal.ReadOnly = true;
        txtTotal.Text = "0";

        var btnRent = Nav.Btn("Rent", 130, 145, 100);
        var btnBack = Nav.Btn("Back", 30, 260, 100);
        var btnLogout = Nav.Btn("Logout", 210, 260, 100);

        btnRent.Click += BtnRent_Click;
        btnBack.Click += (s, e) => Nav.Go(this, new ChooseForm());
        btnLogout.Click += (s, e) => Nav.Go(this, new LoginForm());

        Controls.AddRange(new Control[] {
            Nav.Lbl("Customer name:", 20, 23), txtName,
            Nav.Lbl("Bicycle type:", 20, 63), cmbType,
            Nav.Lbl("Hours:", 20, 103), txtHours,
            btnRent,
            Nav.Lbl("Total:", 20, 208), txtTotal,
            btnBack, btnLogout });
    }

    void BtnRent_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        { Warn("Please enter the customer name."); return; }
        if (cmbType.SelectedItem == null)
        { Warn("Please choose a bicycle type."); return; }
        if (!int.TryParse(txtHours.Text, out int hours) || hours <= 0)
        { Warn("Hours must be a whole number greater than 0."); txtHours.Focus(); return; }

        decimal fee = Rates[cmbType.SelectedItem.ToString()] * hours;
        string note = "";
        if (hours >= DiscountHours)
        {
            fee -= fee * DiscountRate;
            note = $"\n(10% discount applied for {DiscountHours}+ hours)";
        }

        total += fee;
        txtTotal.Text = total.ToString("N0");
        MessageBox.Show($"Customer: {txtName.Text.Trim()}\nBicycle: {cmbType.SelectedItem}\nHours: {hours}\nFee: {fee:N0}{note}",
            "Rental Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);

        txtName.Clear(); txtHours.Clear(); cmbType.SelectedIndex = -1; txtName.Focus();
    }

    static void Warn(string msg) =>
        MessageBox.Show(msg, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
