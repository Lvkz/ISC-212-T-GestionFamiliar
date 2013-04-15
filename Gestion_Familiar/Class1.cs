using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Gestion_Familiar
{
    class usuarios
    {
        #region Propiedades
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int Tipo { get; set; }
        public string Foto { get; set; }
        #endregion
       

    }
    public class Categorias
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        public string Categoria { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Categoria);
        }
    }
    class Productos
    {
 
        #region Propiedades
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public int tipo { get; set; }
        public string Usuario { get; set; }
        public string Producto { get; set; }
        public string Fecha { get; set; }
        public int Precio { get; set; }
        public string Sitio { get; set; }
        public string FechaVencimiento { get; set; }
        public string Articulo { get; set; }
        public string LugarCompra { get; set; }
        public string Caracteristicas { get; set; }
        public int Cantidad { get; set; }


        #endregion
        #region Constructores
  
        
        #endregion
        #region Metodos

        #endregion

    }
}
