using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Hospital
    {
        private CD_Hospital_tblHospital objetoCD = new CD_Hospital_tblHospital();

        public DataTable MostrarProd() {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string nombre, string apellido, DateTime ingreso, int altas, string consultas, string analisis, string procedimientos)
        {

            objetoCD.Insertar(nombre, apellido, ingreso, altas, consultas,analisis,procedimientos); 
    }

        public void EditarProd(string nombre, string apellido, string ingreso, int altas, string consultas, string analisis, string procedimientos,string id)
        {
            objetoCD.Editar(nombre, apellido, Convert.ToDateTime(ingreso), altas, consultas, analisis, procedimientos, Convert.ToInt32(id));
        }

        public void EliminarPRod(string id) {

            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
