using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Gestion_Familiar.Clases;
using Windows.UI.Popups;


// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Gestion_Familiar
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Login : Gestion_Familiar.Common.LayoutAwarePage
    {
        public Login()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
           // Conexion.AbrirConexion();
            btCancelar.IsEnabled = false;
            btIniciar.IsEnabled = false;

          //  MySqlCommand preguntar = new MySqlCommand("SELECT id FROM usuarios WHERE nombre='" + tbNombre.Text + "' AND contrasena='" + pwContrasena.Password + "'", Conexion.varConexion);
          //  MySqlDataReader data = preguntar.ExecuteReader();

           
            if (tbNombre.Text=="cesar"&&pwContrasena.Password=="123")//data.Read())
            {
               // MainScreen uno = new MainScreen();
                
                Frame.Navigate(typeof(MainScreen));
           //     Conexion.IdEntradaSistema = Convert.ToInt32(data.GetString(0));
            //    Conexion.CerrarConexion();

              
            }
            else
            {
                MessageDialog msgDialog = new MessageDialog("Error", " usuario y/o contraseña no son correctos ");

                msgDialog.ShowAsync();
                //data.Close();
                btCancelar.IsEnabled = true;
                btIniciar.IsEnabled = true;
            }

         //   Conexion.CerrarConexion();

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainScreen));
        }

       
    }
}
