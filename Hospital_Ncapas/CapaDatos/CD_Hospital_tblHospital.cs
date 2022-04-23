using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Hospital_tblHospital
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar() { 
       
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrartblHospital";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
            
        }

        public void Insertar(string nombre, string apellido, DateTime ingreso,int altas,string consultas, string analisis, string procedimientos ) {
            //PROCEDIMNIENTO
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetartblHosptal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@ingreso", ingreso);
            comando.Parameters.AddWithValue("@altas", altas);
            comando.Parameters.AddWithValue("@consultas", consultas);
            comando.Parameters.AddWithValue("@analisis", analisis);
            comando.Parameters.AddWithValue("@procedimientos", procedimientos);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        
        }

        public void Editar(string nombre, string apellido, DateTime ingreso, int altas, string consultas, string analisis, string procedimientos,int id)
        {
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditartblHosptal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@ingreso", ingreso);
            comando.Parameters.AddWithValue("@altas", altas);
            comando.Parameters.AddWithValue("@consultas", consultas);
            comando.Parameters.AddWithValue("@analisis", analisis);
            comando.Parameters.AddWithValue("@procedimientos", procedimientos);
            comando.Parameters.AddWithValue("@id",id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Eliminar(int id) {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminartblHosptal";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro",id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        private bool Contraseña(string password)
        {
           bool mayuscula = false, minuscula = false, numero = false, carespecial = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password, i))
                {
                    mayuscula = true;
                }
                else if (Char.IsLower(password, i))
                {
                    minuscula = true;
                }
                else if (Char.IsDigit(password, i))
                {
                    numero = true;
                }
                else
                {
                    carespecial = true;
                }
            }
            if (mayuscula && minuscula && numero && carespecial && password.Length >= 8)
            {
                return true;
            }
            return false;
        }
    }
}
