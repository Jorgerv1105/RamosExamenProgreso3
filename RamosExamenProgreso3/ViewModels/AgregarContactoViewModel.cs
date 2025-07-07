using System.Collections.ObjectModel;
using System.Windows.Input;
using RamosExamenProgreso3.Models;
using RamosExamenProgreso3.Services;

namespace RamosExamenProgreso3.ViewModels
{
    public class ContactoViewModel : BaseViewModel
    {
        public ObservableCollection<Contacto> Contactos { get; set; } = new();
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Favorito { get; set; }

        public ICommand GuardarCommand { get; }

        public ContactoViewModel()
        {
            GuardarCommand = new Command(async () => await Guardar());
        }

        async Task Guardar()
        {
            if (!Telefono.StartsWith("+593"))
            {
                await Shell.Current.DisplayAlert("Error", "El teléfono debe iniciar con +593", "OK");
                return;
            }

            var nuevo = new Contacto { Nombre = Nombre, Correo = Correo, Telefono = Telefono, Favorito = Favorito };
            await App.Database.SaveContactoAsync(nuevo);
            await LogService.AppendLogAsync(Nombre);
            await Shell.Current.DisplayAlert("Éxito", "Contacto guardado correctamente", "OK");
        }
    }
}
