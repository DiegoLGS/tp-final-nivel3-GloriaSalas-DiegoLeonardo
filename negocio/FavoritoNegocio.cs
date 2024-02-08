using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritoNegocio
    {
        public List<int> listar(int idUsuario)
        {
            List<int> lista = new List<int>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdArticulo FROM FAVORITOS WHERE IdUser = @IdUser");
                datos.setearParametro("@IdUser", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idArticulo = (int)datos.Lector["IdArticulo"];

                    lista.Add(idArticulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int idArticulo, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdArticulo = @IdArticulo AND IdUser = @IdUser");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@IdUser", idUsuario);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(int idArticulo, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS (idUser, IdArticulo) VALUES (@idUser, @IdArticulo)");
                datos.setearParametro("@idUser", idUsuario);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
