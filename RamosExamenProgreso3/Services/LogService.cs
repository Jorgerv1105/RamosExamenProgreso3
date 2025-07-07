namespace RamosExamenProgreso3.Services
{
    public static class LogService
    {
        public static async Task AppendLogAsync(string nombre)
        {
            string log = $"Se incluyó el registro [{nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            string filename = Path.Combine(FileSystem.AppDataDirectory, "Logs_Ramos.txt");
            await File.AppendAllTextAsync(filename, log + Environment.NewLine);
        }

        public static async Task<List<string>> LeerLogsAsync()
        {
            string filename = Path.Combine(FileSystem.AppDataDirectory, "Logs_Ramos.txt");
            if (!File.Exists(filename))
                return new List<string>();

            var lines = await File.ReadAllLinesAsync(filename);
            return lines.ToList();
        }
    }
}
