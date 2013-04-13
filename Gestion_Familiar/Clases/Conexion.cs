using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Threading.Tasks;


namespace Gestion_Familiar.Clases
{
    abstract class Conexion
    {
        /// <summary>
        /// Variable para coenctar con la base de datos...
        /// </summary>
     //   public static MySqlConnection varConexion = new MySqlConnection("Server=localhost;Database=gestionfamiliar;Uid=root; Pwd='' ");
   //     public static int IdEntradaSistema { get; set; }
        /// <summary>
        /// Abrir conexion
        /// </summary>
        public static void AbrirConexion()
        {
       //     varConexion.Open();
        }
        /// <summary>
        /// Cerrar conexion 
        /// </summary>
        public static void CerrarConexion()
        {
       //     varConexion.Close();
        }
    }
}
