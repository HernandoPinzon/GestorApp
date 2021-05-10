using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestor.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageOptions : ContentPage
    {
        public PageOptions()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadItems();
        }

        private async void loadItems()
        {
            //var items = await App.Context.ObtenerItemsAsync();
            var items = await App.Context.ObtenerItemsAsync();
            listaArchivos.ItemsSource = items;
        }


        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //ELIMINAR DATOS
            await App.Context.EliminarTodoAsync();
            await Navigation.PopAsync();
            await DisplayAlert("Atencion", "SE ELIMINARON TODOS LOS DATOS", "Aceptar");

        }
    }
}