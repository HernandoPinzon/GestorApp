using Gestor.models;
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
    public partial class PageGestor : ContentPage
    {
        int posActual;
        public PageGestor(int father)
        {
            InitializeComponent();
            posActual = father;
            PaginaX.Title = "CarpetaID: " + father;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadItems();
        }

        private async void loadItems()
        {
            //var items = await App.Context.ObtenerItemsAsync();
            var items = await App.Context.PruebaAsync(posActual);
            listaArchivos.ItemsSource = items;
        }

        private async void AddFileBtn_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new AddFile(posActual));
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmacion","Esta seguro de eliminar este archivo?","Si","No"))
            {
                var item = (Archivo)(sender as MenuItem).CommandParameter;
                var result = await App.Context.EliminarItemAsync(item);
                if (result==1)
                {
                    loadItems();
                }
            }
        }

        private async void listaArchivos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Archivo;
            if (item.TypeFile=="carpeta0")
            {
                await Navigation.PushAsync(new PageGestor(item.Id));
            }
            else
            {
                await DisplayAlert("Informacion", item.ToString(), "ok");
            }
        }

        private async void BtnOptions_Clicked(object sender, EventArgs e)
        {
            //a
            await Navigation.PushAsync(new PageOptions());
        }
    }
}