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
using SQLite;
using System.Xml;
using Windows.Storage;
using Windows.Storage.Streams;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Gestion_Familiar
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class pageCocinar : Gestion_Familiar.Common.LayoutAwarePage
    {
        public class TipoAlimento
        {
            [AutoIncrement, PrimaryKey]
            public int ID { get; set; }
            public string tipoAlimento { get; set; }

            public override string ToString()
            {
                return string.Format("{0}", tipoAlimento);
            }
        }

        public class listaProducto
        {
            [AutoIncrement, PrimaryKey]
            public int ID { get; set; }
            public string tipoAlimento { get; set; }
            public string unidadAlimeto { get; set; }

            public override string ToString()
            {
                return string.Format("{0}", tipoAlimento);
            }
        }

        public pageCocinar()
        {
            this.InitializeComponent();

            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "path.db");

            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                comboboxTipoAlimento.ItemsSource = db.Table<TipoAlimento>();
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
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtbxCantidad.Text = "";
            tbProducto.Text = "";
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listviewProductos_Changed(object sender, SelectionChangedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "path.db");

            using (var db = new SQLite.SQLiteConnection(dbpath))
            {
                comboboxTipoAlimento.ItemsSource = db.Table<listaProducto>();
            }
        }
    }
}
