using System.Collections.ObjectModel;
using RamosExamenProgreso3.Services;

namespace RamosExamenProgreso3.ViewModels
{
    public class LogsViewModel : BaseViewModel
    {
        public ObservableCollection<string> Registros { get; set; } = new();

        public LogsViewModel()
        {
            CargarLogs();
        }

        public async void CargarLogs()
        {
            var lines = await LogService.LeerLogsAsync();
            Registros.Clear();
            foreach (var line in lines)
                Registros.Add(line);
        }
    }
}
