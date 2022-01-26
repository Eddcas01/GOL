using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GLNO.Conexion
{
    public class Conexiona
    {

        public string cadenadeconexiongeneral() {


            string connectionstring = @"server=PGDESARROLLO02;database=PruebaGLN;Trusted_Connection=True;integrated security = true";


            return connectionstring; 
        
        }

        public void conectarse(string qry) {

            using (SqlConnection connection = new  SqlConnection(cadenadeconexiongeneral())) {

                try
                {
                    connection.Open();

                    SqlCommand comm = new SqlCommand(qry, connection);
                    comm.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e) {

                    Console.WriteLine("no se conecto" + e);
                
                
                }
            
            
            }
        
        
        }

    }
}