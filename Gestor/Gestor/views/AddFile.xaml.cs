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
    public partial class AddFile : ContentPage
    {
        int posicionActual;
        public AddFile(int father)
        {
            InitializeComponent();
            posicionActual = father;
            
        }

        private async void BtnCrear_Clicked(object sender, EventArgs e)
        {
            try
            {
                string rbnum = null;
                if (rbCarpeta.IsChecked)
                {
                    rbnum = "carpeta0";
                }
                else if (rbDocumento.IsChecked)
                {
                    rbnum = "documento1";
                }
                else if (rbImagen.IsChecked)
                {
                    rbnum = "imagen2";
                }
                else
                {
                    rbnum = "video3";
                }
                var archivo = new Archivo
                {
                    Name = NombreArchivo.Text,
                    Father = posicionActual,
                    TypeFile = rbnum.ToString()
                };
                //intento meterlo a la base de datos
                var result = await App.Context.InsertarItemAsync(archivo);
                if (result == 1)
                {
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "No se pudo crear el archivo", "Aceptar");
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "Aceptar");
            }


            


            
        }
    }
}