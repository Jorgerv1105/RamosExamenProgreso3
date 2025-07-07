using RamosExamenProgreso3.Services;

namespace RamosExamenProgreso3;

public partial class App : Application
{
    public static ContactoDatabase Database { get; private set; }

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contatos.db3");
        Database = new ContactoDatabase(dbPath);
    }
}
