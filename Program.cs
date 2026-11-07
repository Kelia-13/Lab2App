namespace Lab2App;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Nav.Show(new LoginForm());   // first form
        Application.Run();           // ends when the last form closes
    }
}

// Helper for moving from one form to another
static class Nav
{
    public static void Show(Form f)
    {
        f.StartPosition = FormStartPosition.CenterScreen;
        f.FormClosed += (s, e) => { if (Application.OpenForms.Count == 0) Application.Exit(); };
        f.Show();
    }

    public static void Go(Form from, Form to)
    {
        Show(to);
        from.Close();
    }

    // Small helpers so forms stay short
    public static Label Lbl(string text, int x, int y) =>
        new Label { Text = text, Left = x, Top = y, AutoSize = true };

    public static TextBox Txt(int x, int y, int w = 180) =>
        new TextBox { Left = x, Top = y, Width = w };

    public static Button Btn(string text, int x, int y, int w = 100) =>
        new Button { Text = text, Left = x, Top = y, Width = w, Height = 30 };
}
