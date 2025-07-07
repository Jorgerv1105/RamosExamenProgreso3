using System.Collections.ObjectModel;
using RamosExamenProgreso3.Models;
using RamosExamenProgreso3.Services;

namespace RamosExamenProgreso3.ViewModels
{
    public class ListadoContactosViewModel : BaseViewModel
    {
        public ObservableCollection<Contacto> Contactos { get; set; } = new();

        public ListadoContactosViewModel()
        {
            CargarContactos();
        }

        public async void CargarContactos()
        {
            var lista = await App.Database.GetContactosAsync();
            Contactos.Clear();
            foreach (var c in lista)
                Contactos.Add(c);
        }
    }
}
