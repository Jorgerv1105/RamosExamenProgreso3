using System.Windows.Input;
using RamosExamenProgreso3.Models;
using RamosExamenProgreso3.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RamosExamenProgreso3.ViewModels
{
    public class ContactoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _nombre = string.Empty;
        private string _correo = string.Empty;
        private string _telefono = string.Empty;
        private bool _favorito;

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                _correo = value;
                OnPropertyChanged();
            }
        }

        public string Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                OnPropertyChanged();
            }
        }

        public bool Favorito
        {
            get => _favorito;
            set
            {
                _favorito = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }

        public ContactoViewModel()
        {
            GuardarCommand = new Command(async () => await GuardarAsync());
        }

        private async Task GuardarAsync()
        {
            if (!Telefono.StartsWith("+593"))
            {
                await Shell.Current.DisplayAlert("Error", "El teléfono debe iniciar con +593", "OK");
                return;
            }

            var nuevoContacto = new Contacto
            {
                Nombre = this.Nombre,
                Correo = this.Correo,
                Telefono = this.Telefono,
                Favorito = this.Favorito
            };

            await App.Database.SaveContactoAsync(nuevoContacto);
            await LogService.AppendLogAsync(Nombre);

            await Shell.Current.DisplayAlert("Éxito", "Contacto guardado correctamente", "OK");

 
            Nombre = string.Empty;
            Correo = string.Empty;
            Telefono = string.Empty;
            Favorito = false;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
