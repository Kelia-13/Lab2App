namespace Lab2App;

public class ChooseForm : Form
{
    public ChooseForm()
    {
        Text = "Choose";
        ClientSize = new Size(320, 120);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        var btnBike = Nav.Btn("Bicycle", 40, 40, 100);
        var btnMush = Nav.Btn("Mushroom", 180, 40, 100);
        btnBike.Click += (s, e) => Nav.Go(this, new BicycleForm());
        btnMush.Click += (s, e) => Nav.Go(this, new MushroomForm());

        Controls.AddRange(new Control[] { btnBike, btnMush });
    }
}
