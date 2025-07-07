using RamosExamenProgreso3.ViewModels;

namespace RamosExamenProgreso3.Views;

public partial class ListadoContactosPage : ContentPage
{
    ListadoContactosViewModel vm;

    public ListadoContactosPage()
    {
        InitializeComponent();
        vm = new ListadoContactosViewModel();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.CargarContactos(); 
    }
}
