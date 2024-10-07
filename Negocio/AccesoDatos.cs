﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{

    public class AccesoDatos

    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            //Pedro
            //conexion = new SqlConnection("Server=localhost,1433; Database=PROMOS_DB; User Id=sa; Password=17513169Marie..; TrustServerCertificate=True;");

            //Lu
            conexion = new SqlConnection("server=.\\LABORATORIO3; database=PROMOS_DB; integrated security=true");

            //Maxi
            //conexion = new SqlConnection("server=.\\SQLExpress; database=PROMOS_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object ejecutarEscalar()
        {
            object resultado = null;

            try
            {
                // Ejecuta la consulta y devuelve el primer valor de la primera fila del resultado
                resultado = comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta escalar", ex);
            }

            return resultado;
        }

        public void setearParametro(string nombre, object valor)
        {

            comando.Parameters.AddWithValue(nombre, valor);


        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();

        }
    }
}
