using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Popups;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Streams;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Gestion_Familiar
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AgregarUsuario : Gestion_Familiar.Common.LayoutAwarePage
    {
        string Variable;
        public AgregarUsuario()
        {
            this.InitializeComponent();

            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "path.db");

            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                listadoUsuarios.ItemsSource = db.Table<usuarios>().OrderBy(d => d.Nombre).ToList();
            }
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
        /// 



        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }

        private async void CapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                CameraCaptureUI dialog = new CameraCaptureUI();
                Size aspectRatio = new Size(16, 9);
                dialog.PhotoSettings.CroppedAspectRatio = aspectRatio;

                StorageFile file = await dialog.CaptureFileAsync(CameraCaptureUIMode.Photo);
                if (file != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                    {
                        bitmapImage.SetSource(fileStream);
                        Variable = Convert.ToString(fileStream);
                    }

                    CapturedPhoto.Source = bitmapImage;
                }
                else
                {
                    MessageDialog msgDialog1 = new MessageDialog("No photo", "Error");
                    msgDialog1.ShowAsync();
                   
                }
            }
            catch (Exception ex)
            {
                MessageDialog msgDialog = new MessageDialog(ex.Message, "Error");
                msgDialog.ShowAsync();
            }

        }

        private void botonAgregar_Click(object sender, RoutedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "path.db");

            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                db.CreateTable<usuarios>();

                db.RunInTransaction(() =>
                {
                    db.Insert(new usuarios()
                    {
                        Nombre = textboxNombre.Text,
                        Contrasena = textboxContraseña.Text,
                        Tipo = Convert.ToInt32(toogleAdulto.ActualHeight),
                        Foto = Variable


                    });
                });
                MessageDialog msgDialog = new MessageDialog("Usuario registrado", "Agregar Usuario");
                msgDialog.ShowAsync();
               
            }
        }

        private void botonEliminar_Click(object sender, RoutedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "path.db");

            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                db.CreateTable<usuarios>();

                db.RunInTransaction(() =>
                {
                    db.Delete(new usuarios()
                    {
                        Nombre = textboxNombre.Text,
                        Contrasena = textboxContraseña.Text,
                        Tipo = Convert.ToInt32(toogleAdulto.ActualHeight)
                    });
                });

                listadoUsuarios.ItemsSource = db.Table<usuarios>().OrderBy(d => d.Nombre).ToList();
            }
        }



        private void listadoUsuarios_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "path.db");

            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                // db.CreateTable<usuarios>();

                // db.RunInTransaction(() =>
                //{
                //    textboxNombre = db.Table<usuarios>().OrderBy(d=> d.Nombre);

                //});
            }
        }

        private void listadoUsuarios_SelecctionChanged(object sender, SelectionChangedEventArgs e)
        {
            textboxNombre.Text = listadoUsuarios.SelectedItem.ToString();
            
        }
    }
    }
