using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using FirebirdSql.Data.FirebirdClient;
namespace PH
{
	public class Operaciones
	{
		public PH.SP_COMANDA SP_GG_COMANDA_ADD(PH.PHEntities Entidad, Nullable<int> iDSUCURSAL, string hEADER, string dETAILS, string cLIENTE, Nullable<int> iDPEDIDO)
		{
		   string spName = ConfigurationManager.AppSettings["SP_NAME_COMANDA"];
		   return Entidad.SP_COMANDA.SqlQuery(spName, iDSUCURSAL, hEADER, dETAILS, cLIENTE, iDPEDIDO).FirstOrDefault();

			//return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_COMANDA>("SP_GG_COMANDA_ADD_EH", mergeOption, iDSUCURSALParameter, hEADERParameter, dETAILSParameter, cLIENTEParameter, iDPEDIDOParameter);
		}
		
		public PH.SP_COMANDA SP_GG_COMANDA_ADD(Nullable<int> iDSUCURSAL, string hEADER, string dETAILS, string cLIENTE, Nullable<int> iDPEDIDO)
		{
			PH.SP_COMANDA cm = null;
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				FbTransaction t;
				cn.Open();
				t = cn.BeginTransaction();
				try
				{
					
					string spName = ConfigurationManager.AppSettings["SP_NAME_COMANDA"];
					// declare command
					
					FbCommand readCommand =
					  new FbCommand(spName, cn,t);
				   // new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					readCommand.Parameters.Add(new FbParameter("@IDSucursal", iDSUCURSAL));
					readCommand.Parameters.Add(new FbParameter("@Header", hEADER));
					readCommand.Parameters.Add(new FbParameter("@Details", dETAILS));
					readCommand.Parameters.Add(new FbParameter("@Cliente", cLIENTE));
					readCommand.Parameters.Add(new FbParameter("@IdPedido", iDPEDIDO));
					FbDataReader myreader = readCommand.ExecuteReader();
					if (myreader.Read())
					{
						// load the combobox with the names of the people inside.
						// myreader[0] reads from the 1st Column
						//DeleteComboBox.Items.Add(myreader[0]);
						cm = new SP_COMANDA();
						cm.IDCOMANDA = myreader.GetInt32(0);
						cm.IDCLIENTE = myreader.GetInt32(1);
						cm.IDDIRECCION = myreader.GetInt32(2);
						cm.ESTADO = myreader.GetInt32(3);
						//return cm;
						t.Commit();
					}
					myreader.Close(); // we are done with the reader
				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					t.Rollback();
					throw x;
				}
				finally
				{
				   
					cn.Close();
				}

			}

			return cm;
		}

		public List<PH.Entidades.SP_CALL_PRECIO> SP_CALL_PRECIO(string IdProducto)
		{
			PH.Entidades.SP_CALL_PRECIO cm = null;
			List<PH.Entidades.SP_CALL_PRECIO> lista = new List<Entidades.SP_CALL_PRECIO>();
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				try
				{
					cn.Open();
					string spName = "Select * FROM SP_CALL_PRECIO p where p.IDARTICULO = ?";
					// declare command
					FbCommand readCommand =
					  new FbCommand(spName, cn);
					// new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					readCommand.Parameters.Add(new FbParameter("@IDARTICULO", IdProducto));

					FbDataReader myreader = readCommand.ExecuteReader();
					while (myreader.Read())
					{
						// load the combobox with the names of the people inside.
						// myreader[0] reads from the 1st Column
						//DeleteComboBox.Items.Add(myreader[0]);
						cm = new PH.Entidades.SP_CALL_PRECIO();
						cm.IDARTICULO = myreader.GetString(0);
						cm.PRECIO = myreader.GetDecimal(1);
						cm.IDLISTA = myreader.GetInt32(2);
						cm.LISTA = myreader.GetString(3);
						
						lista.Add(cm);

					}
					myreader.Close(); // we are done with the reader
				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					throw x;
				}
				finally
				{
					cn.Close();
				}

			}

			return lista;
		}

		public List<PH.Entidades.SP_CALL_COMBO> SP_CALL_COMBO(string IdProducto)
		{
			PH.Entidades.SP_CALL_COMBO cm = null;
			List<PH.Entidades.SP_CALL_COMBO> lista = new List<Entidades.SP_CALL_COMBO>();
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				try
				{
					cn.Open();
					string spName = "Select * FROM SP_CALL_COMBO p where p.IDPROMO = ?";
					// declare command
					FbCommand readCommand =
					  new FbCommand(spName, cn);
					// new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					readCommand.Parameters.Add(new FbParameter("@IDPROMO", IdProducto));

					FbDataReader myreader = readCommand.ExecuteReader();
					while (myreader.Read())
					{
						// load the combobox with the names of the people inside.
						// myreader[0] reads from the 1st Column
						//DeleteComboBox.Items.Add(myreader[0]);

						cm = new PH.Entidades.SP_CALL_COMBO();
						cm.IDPROMO = myreader.GetString(0);
						cm.PROMO = myreader.GetString(1);
						cm.IDDEFINICION_PROMO = myreader.GetInt32(2);
						cm.DEFINICION_PROMO = myreader.GetString(3);
						cm.CANTIDAD_DEFINICION= myreader.GetInt32(4);
						cm.IDPRODUCTO_CMB= myreader.GetInt32(5);
						cm.IDPRODUCTO = myreader.GetString(6);
						cm.PRODUCTO = myreader.GetString(7);
                        if (!myreader.IsDBNull(8))
                        {
                            cm.CANTIDAD = myreader.GetDecimal(8);
                        }
                        else
                        {
                            cm.CANTIDAD = 0;
                        }
						
						cm.PREDETERMINADO=myreader.GetInt32(9);

						if (!myreader.IsDBNull(10))
						{
							 cm.ESTADO=myreader.GetInt32(10);
						}
						if (!myreader.IsDBNull(11) )
						{
							 cm.COMBINACIONES=myreader.GetInt32(11);
						}
						if (!myreader.IsDBNull(12))
						{
							 cm.AGRANDADO=myreader.GetString(12);
						}
						 if (!myreader.IsDBNull(13))
						{
							 cm.IDART_COSTO_AGRANDADO=myreader.GetString(13);
						}
						  

						lista.Add(cm);

					}
					myreader.Close(); // we are done with the reader
				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					throw x;
				}
				finally
				{
					cn.Close();
				}

			}

			return lista;
		}

		public List<PH.Entidades.SP_CALL_PRODUCTO> SP_CALL_PRODUCTO(string IdProducto)
		{
			
			List<PH.Entidades.SP_CALL_PRODUCTO> lista = new List<Entidades.SP_CALL_PRODUCTO>();
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				try
				{
					cn.Open();
					string spName = ConfigurationManager.AppSettings["SP_CALL_PRODUCTO"]; 
					// declare command
					FbCommand readCommand =
					  new FbCommand(spName, cn);
					// new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					// readCommand.Parameters.Add(new FbParameter("@IDPROMO", IdProducto));
					readCommand.Parameters.Add(new FbParameter("@IDARTICULO", IdProducto));

					FbDataReader myreader = readCommand.ExecuteReader();
					while (myreader.Read())
					{


						PH.Entidades.SP_CALL_PRODUCTO cm ;
						cm = ReaderToProducto(myreader);

						lista.Add(cm);

					}
					myreader.Close(); // we are done with the reader
				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					throw x;
				}
				finally
				{
					cn.Close();
				}

			}

			return lista;
		}

        public List<PH.Entidades.SP_CALL_PRODUCTO> SP_CALL_INSUMO(string IdProducto)
        {

            List<PH.Entidades.SP_CALL_PRODUCTO> lista = new List<Entidades.SP_CALL_PRODUCTO>();
            using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    string spName = ConfigurationManager.AppSettings["SP_CALL_INSUMO"];
                    // declare command
                    FbCommand readCommand =
                      new FbCommand(spName, cn);
                    // new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
                    // readCommand.Parameters.Add(new FbParameter("@IDPROMO", IdProducto));
                    readCommand.Parameters.Add(new FbParameter("@IDARTICULO", IdProducto));

                    FbDataReader myreader = readCommand.ExecuteReader();
                    while (myreader.Read())
                    {


                        PH.Entidades.SP_CALL_PRODUCTO cm;
                        cm = ReaderToProducto(myreader);

                        lista.Add(cm);

                    }
                    myreader.Close(); // we are done with the reader
                }
                catch (Exception x)
                {
                    //MessageBox.Show(x.Message);
                    throw x;
                }
                finally
                {
                    cn.Close();
                }

            }

            return lista;
        }

		public List<PH.Entidades.SP_CALL_PRODUCTO> SP_CALL_PRODUCTO_FULL(String Tipo)
		{

			List<PH.Entidades.SP_CALL_PRODUCTO> lista = new List<Entidades.SP_CALL_PRODUCTO>();
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				try
				{
					cn.Open();
                    string spName;
                  if (Tipo=="P")
                  {
                      spName = ConfigurationManager.AppSettings["SP_CALL_PRODUCTO_FULL"];
                  }
                  else
                  {
                      spName = ConfigurationManager.AppSettings["SP_CALL_INSUMOS_FULL"];
                  }
					
					// declare command
					FbCommand readCommand =
					  new FbCommand(spName, cn);
					// new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					// readCommand.Parameters.Add(new FbParameter("@IDPROMO", IdProducto));
					//readCommand.Parameters.Add(new FbParameter("@IDARTICULO", IdProducto));

					FbDataReader myreader = readCommand.ExecuteReader();
					while (myreader.Read())
					{


                        PH.Entidades.SP_CALL_PRODUCTO cm = ReaderToProducto(myreader);

						lista.Add(cm);

					}
					myreader.Close(); // we are done with the reader
				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					throw x;
				}
				finally
				{
					cn.Close();
				}

			}

			return lista;
		}

		private PH.Entidades.SP_CALL_PRODUCTO ReaderToProducto(FbDataReader myreader)
		{
			PH.Entidades.SP_CALL_PRODUCTO cm = new PH.Entidades.SP_CALL_PRODUCTO();

			cm.IDARTICULO = myreader.GetString(0);

			if (!myreader.IsDBNull(1))
			{
				cm.IDGRUPO = myreader.GetInt32(1);
			}
			if (!myreader.IsDBNull(2))
			{
				cm.GRUPO = myreader.GetString(2);
			}
			if (!myreader.IsDBNull(3))
			{
				cm.IDMEDIDA = myreader.GetInt32(3);
			}
			if (!myreader.IsDBNull(4))
			{
				cm.IDLINEA = myreader.GetInt32(4);
			}

			if (!myreader.IsDBNull(5))
			{
				cm.LINEA = myreader.GetString(5);
			}

			if (!myreader.IsDBNull(6))
			{
				cm.ARTICULO = myreader.GetString(6);
			}

			if (!myreader.IsDBNull(7))
			{
				cm.ESTADO = myreader.GetString(7);
			}
			if (!myreader.IsDBNull(8))
			{
				cm.DESCRIPCION_CORTA = myreader.GetString(8);
			}
			if (!myreader.IsDBNull(9))
			{
				cm.IDIMPUESTO = myreader.GetInt32(9);
			}

			if (!myreader.IsDBNull(10))
			{
				cm.IDFAMILIA = myreader.GetInt32(10);
			}
			if (!myreader.IsDBNull(11))
			{
				cm.FAMILIA = myreader.GetString(11);
			}
			if (!myreader.IsDBNull(12))
			{
				cm.IDMARCA = myreader.GetInt32(12);
			}
			if (!myreader.IsDBNull(13))
			{
				cm.IDCOLECCION = myreader.GetInt32(13);
			}
			if (!myreader.IsDBNull(14))
			{
				cm.COMBO = myreader.GetInt32(14);
			}

			if (!myreader.IsDBNull(15))
			{
				cm.PRODUCCION = myreader.GetInt32(15);
			}
			if (!myreader.IsDBNull(16))
			{
				cm.IDFRANQUICIA = myreader.GetInt32(16);
			}
			if (!myreader.IsDBNull(17))
			{
				cm.FRANQUICIA = myreader.GetString(17);
			}

			if (!myreader.IsDBNull(18))
			{
				cm.DESCRIPCION_WEB = myreader.GetString(18);
			}
            
			return cm;
		}
		public void SP_TEST(int IdModelo, string Descripcion)
		{
			PH.Entidades.SP_CALL_PRECIO cm = null;
			List<PH.Entidades.SP_CALL_PRECIO> lista = new List<Entidades.SP_CALL_PRECIO>();
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				try
				{
					cn.Open();
					string spName = "INSERT INTO MODELO(IDMODELO,DESCRIPCION) VALUES(?,?)";
					// declare command
					FbCommand readCommand =
					  new FbCommand(spName, cn);
					// new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					readCommand.Parameters.Add(new FbParameter("@IDMODELO", IdModelo));
					readCommand.Parameters.Add(new FbParameter("@DESCRIPCION", Descripcion));


					FbDataReader myreader = readCommand.ExecuteReader();
					while (myreader.Read())
					{
						//// load the combobox with the names of the people inside.
						//// myreader[0] reads from the 1st Column
						////DeleteComboBox.Items.Add(myreader[0]);
						//cm = new PH.Entidades.SP_CALL_PRECIO();
						//cm.IDARTICULO = myreader.GetString(0);
						//cm.PRECIO = myreader.GetDecimal(1);
						//cm.IDLISTA = myreader.GetInt32(2);
						//cm.LISTA = myreader.GetString(3);

						//lista.Add(cm);

					}
					myreader.Close(); // we are done with the reader
				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					throw x;
				}
				finally
				{
					cn.Close();
				}

			}

		   
		}

		public void SP_TEST_WITH_T(int IdModelo, string Descripcion)
		{
			PH.Entidades.SP_CALL_PRECIO cm = null;
			List<PH.Entidades.SP_CALL_PRECIO> lista = new List<Entidades.SP_CALL_PRECIO>();
			using (FirebirdSql.Data.FirebirdClient.FbConnection cn = new FbConnection(ConfigurationManager.ConnectionStrings["PHConnection"].ConnectionString))
			{
				try
				{
					cn.Open();
					string spName = "INSERT INTO MODELO(IDMODELO,DESCRIPCION) VALUES(?,?)";
					// declare command
					FbTransaction t = cn.BeginTransaction();
					FbCommand readCommand =
					  new FbCommand(spName, cn,t);
					// new FbCommand("Select * From " + spName + "(@IDSucursal,@Header,@Details,@Cliente,@IdPedido)", cn);
					readCommand.Parameters.Add(new FbParameter("@IDMODELO", IdModelo));
					readCommand.Parameters.Add(new FbParameter("@DESCRIPCION", Descripcion));

				   
					FbDataReader myreader = readCommand.ExecuteReader();
					while (myreader.Read())
					{
						//// load the combobox with the names of the people inside.
						//// myreader[0] reads from the 1st Column
						////DeleteComboBox.Items.Add(myreader[0]);
						//cm = new PH.Entidades.SP_CALL_PRECIO();
						//cm.IDARTICULO = myreader.GetString(0);
						//cm.PRECIO = myreader.GetDecimal(1);
						//cm.IDLISTA = myreader.GetInt32(2);
						//cm.LISTA = myreader.GetString(3);

						//lista.Add(cm);

					}
					t.Commit();
					myreader.Close(); // we are done with the reader

				}
				catch (Exception x)
				{
					//MessageBox.Show(x.Message);
					throw x;
				}
				finally
				{
					cn.Close();
				}

			}


		}
	}
}


