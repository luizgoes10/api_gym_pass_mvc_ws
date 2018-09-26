using ApiGymPassMVC.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace ApiGymPassMVC.Models.Services
{
    public static class BackEnd
    {
        public static List<Empresa> GetEmpresaByIdLocalizacao(int id)
        {
            List<Empresa> listEmpresas = null;

            List<Box> listBox = null;

            List<Periodo> listPeriodo = null;

            SqlDataReader reader = null;

            try
            {
                ConnectionUtil.CMD_SELECT_EMPRESA_ID_LOCALIZACAO.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_SELECT_EMPRESA_ID_LOCALIZACAO.Parameters.Add("@IdLocalizacao", SqlDbType.Int).Value = id;

                reader = ConnectionUtil.CMD_SELECT_EMPRESA_ID_LOCALIZACAO.ExecuteReader();

                listEmpresas = new List<Empresa>();

                listBox = new List<Box>();

                listPeriodo = new List<Periodo>();

                while (reader.Read())
                {
                    listEmpresas.Add(new Empresa
                    {
                        IdEmpresa =
                        Convert.ToInt32(reader["IdEmpresa"]),
                        NmEmpresa = reader["nmEmpresa"].ToString(),
                        ImgLogo = reader["imgLogo"].ToString(),
                        AddrEndereco = reader["addrEndereco"].ToString(),
                        TelTelefone = reader["telTelefone"].ToString(),
                        BoolGostei = Convert.ToBoolean(reader["boolGostei"]),
                        TxtSobre = reader["txtSobre"].ToString(),
                        TxtCortesia = reader["txtCortesia"].ToString(),
                        TxtLocalizacao = reader["txtLocalizacao"].ToString(),
                        IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"]),
                        VlrMinPreco = Convert.ToDecimal(reader["vlrMinPreco"]),
                        VlrMaxPreco = Convert.ToDecimal(reader["vlrMaxPreco"]),
                    });
                }

                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_BOX.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_BOX.ExecuteReader();
                while (reader.Read())
                {
                    listBox.Add(new Box
                    {
                        IdBox = Convert.ToInt32(reader["IdBox"]),
                        NmBox = reader["NmBox"].ToString(),
                        imgFoto = reader["ImgFoto"].ToString(),
                        TxtAmbiente = reader["TxtAmbiente"].ToString(),
                        TxtInfo = reader["TxtInfo"].ToString(),
                        TxtDescParceiro1Oferta = reader["TxtDescParc1Oferta"].ToString(),
                        TxtDescParceiro2Oferta = reader["TxtDexParc2Oferta"].ToString(),
                        LnkParceiro1 = reader["LnkParceiro1"].ToString(),
                        LnkParceiro2 = reader["LnkParceiro2"].ToString(),
                        IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                        NmInfoImportante = reader["NmInfoImportante"].ToString()
                    });
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_PERIODO.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_PERIODO.ExecuteReader();
                while (reader.Read())
                {
                    listPeriodo.Add(new Periodo
                    {
                        IdPeriodo = Convert.ToInt32(reader["IdPeriodo"]),
                        NmDescricao = reader["NmPeriodo"].ToString(),
                        VlrPeriodo = Convert.ToDecimal(reader["VlrPeriodo"]),
                        IdBox = Convert.ToInt32(reader["IdBox"])
                    });
                }
                foreach (var emp in listEmpresas)
                {
                    emp.Box = listBox.Where(lb => lb.IdEmpresa == emp.IdEmpresa).ToList();
                }
                foreach (var b in listBox)
                {
                    b.Periodo = listPeriodo.Where(lp => lp.IdBox == b.IdBox).ToList();
                }
                ConnectionUtil.CMD_SELECT_EMPRESA_ID_LOCALIZACAO.Parameters.Clear();
                ConnectionSettings.FecharConexao();

                return listEmpresas;

            }catch(SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
            }



            return listEmpresas;
        }

        public static object[] PostLocalizacao(Localizacao localizacao)
        {
            try
            {
                ConnectionUtil.CMD_INSERT_LOCALIZACAO.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_INSERT_LOCALIZACAO.Parameters.Add("@NmLocalizacao", SqlDbType.NVarChar).Value = localizacao.NmLocalizacao;
                ConnectionUtil.CMD_INSERT_LOCALIZACAO.Parameters.Add("@IdEstado", SqlDbType.Int).Value = localizacao.IdEstado;
                ConnectionUtil.CMD_INSERT_LOCALIZACAO.ExecuteNonQuery();
                ConnectionUtil.CMD_INSERT_LOCALIZACAO.Parameters.Clear();
                ConnectionSettings.FecharConexao();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro" + ex.Message);
                ConnectionSettings.FecharConexao();
                return new object[] { "Houve um erro:", ex.Message };
            }

            return new object[] { "sucesso em salvar dados:", localizacao };

        }
        public static List<Regiao> GetObjetos()
        {

            SqlDataReader reader = null;

            List<Empresa> listEmpresa = null;

            List<Box> listBox = null;

            List<Regiao> listRegiao = null;

            List<Estado> listEstado = null;

            List<Localizacao> listLocalizacao = null;

            List<Periodo> listPeriodo = null;

            List<ImagemBox> listImagemBox = null;

            try
            {
                ConnectionUtil.CMD_SELECT_EMP.Connection = ConnectionSettings.AbrirConexao();

                listEmpresa = new List<Empresa>();

                listBox = new List<Box>();

                listRegiao = new List<Regiao>();

                listEstado = new List<Estado>();

                listLocalizacao = new List<Localizacao>();

                listPeriodo = new List<Periodo>();

                listImagemBox = new List<ImagemBox>();

                reader = ConnectionUtil.CMD_SELECT_EMP.ExecuteReader();

                while (reader.Read())
                {
                    listEmpresa.Add(new Empresa
                    {
                        IdEmpresa =
                        Convert.ToInt32(reader["IdEmpresa"]),
                        NmEmpresa = reader["nmEmpresa"].ToString(),
                        ImgLogo = reader["imgLogo"].ToString(),
                        AddrEndereco = reader["addrEndereco"].ToString(),
                        TelTelefone = reader["telTelefone"].ToString(),
                        BoolGostei = Convert.ToBoolean(reader["boolGostei"]),
                        TxtSobre = reader["txtSobre"].ToString(),
                        TxtCortesia = reader["txtCortesia"].ToString(),
                        TxtLocalizacao = reader["txtLocalizacao"].ToString(),
                        IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"]),
                        VlrMinPreco = Convert.ToDecimal(reader["vlrMinPreco"]),
                        VlrMaxPreco = Convert.ToDecimal(reader["vlrMaxPreco"]),
                    });
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_BOX.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_BOX.ExecuteReader();
                while (reader.Read())
                {
                    listBox.Add(new Box
                    {
                        IdBox = Convert.ToInt32(reader["IdBox"]),
                        NmBox = reader["NmBox"].ToString(),
                        imgFoto = reader["ImgFoto"].ToString(),
                        TxtAmbiente = reader["TxtAmbiente"].ToString(),
                        TxtInfo = reader["TxtInfo"].ToString(),
                        TxtDescParceiro1Oferta = reader["TxtDescParc1Oferta"].ToString(),
                        TxtDescParceiro2Oferta = reader["TxtDexParc2Oferta"].ToString(),
                        LnkParceiro1 = reader["LnkParceiro1"].ToString(),
                        LnkParceiro2 = reader["LnkParceiro2"].ToString(),
                        IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                        NmInfoImportante = reader["NmInfoImportante"].ToString()
                    });
                }

                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_REGIAO.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_REGIAO.ExecuteReader();
                while (reader.Read())
                {
                    listRegiao.Add(new Regiao
                    {
                        IdRegiao = Convert.ToInt32(reader["IdRegiao"]),
                        NmRegiao = reader["NmRegiao"].ToString()
                    });
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_ESTADO.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_ESTADO.ExecuteReader();
                while (reader.Read())
                {
                    listEstado.Add(new Estado
                    {
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        NmEstado = reader["NmEstado"].ToString(),
                        IdRegiao = Convert.ToInt32(reader["IdRegiao"])
                    });
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_LOCALIZACAO.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_LOCALIZACAO.ExecuteReader();
                while (reader.Read())
                {
                    listLocalizacao.Add(new Localizacao
                    {
                        IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"]),
                        NmLocalizacao = reader["NmLocalizacao"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    });
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_PERIODO.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_PERIODO.ExecuteReader();
                while (reader.Read())
                {
                    listPeriodo.Add(new Periodo
                    {
                        IdPeriodo = Convert.ToInt32(reader["IdPeriodo"]),
                        NmDescricao = reader["NmPeriodo"].ToString(),
                        VlrPeriodo = Convert.ToDecimal(reader["VlrPeriodo"]),
                        IdBox = Convert.ToInt32(reader["IdBox"])
                    });
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_IMG_BOX.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_IMG_BOX.ExecuteReader();
                while (reader.Read())
                {
                    listImagemBox.Add(new ImagemBox
                    {
                        IdImagem = Convert.ToInt32(reader["IdImagem"]),
                        NmDescricao = reader["NmDescricao"].ToString(),
                        IdBox = Convert.ToInt32(reader["IdBox"])
                    });
                }
                foreach (var r in listRegiao)
                {
                    r.Estado = listEstado.Where(le => le.IdRegiao == r.IdRegiao).ToList();
                }
                foreach (var e in listEstado)
                {
                    e.Localizacao = listLocalizacao.Where(ll => ll.IdEstado == e.IdEstado).ToList();
                }
                foreach (var l in listLocalizacao)
                {
                    l.Empresa = listEmpresa.Where(lem => lem.IdLocalizacao == l.IdLocalizacao).ToList();
                }
                foreach (var emp in listEmpresa)
                {
                    emp.Box = listBox.Where(lb => lb.IdEmpresa == emp.IdEmpresa).ToList();
                }
                foreach (var b in listBox)
                {
                    b.Periodo = listPeriodo.Where(lp => lp.IdBox == b.IdBox).ToList();
                }
                foreach(var b in listBox)
                {
                    b.ImagemBox = listImagemBox.Where(li => li.IdBox == b.IdBox).ToList();
                }
                return listRegiao;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
                ConnectionSettings.FecharConexao();
                return listRegiao;
            }
        }

        public static object[] PostEmpresa(Empresa empresa)
        {
            SqlConnection connect = null;

            SqlCommand sqlCommand = null;

            string cmd = "insert into tbEmpresa values" +
                "(@ImgLogo,@NmEmpresa,@AddrEndereco,@TelTelefone,@BoolGostei," +
                "@VlrMinPreco,@VlrMaxPreco,@TxtSobre,@TxtCortesia,@TxtLocalizacao,@IdLocalizacao)";

            using (connect = new SqlConnection())
            {
                try
                {
                    connect.ConnectionString = ConfigurationManager.ConnectionStrings["apiGymConn"].ConnectionString;
                    connect.Open();
                    sqlCommand = new SqlCommand(cmd, connect);
                    sqlCommand.Parameters.Add("@ImgLogo", SqlDbType.NVarChar).Value = empresa.ImgLogo;
                    sqlCommand.Parameters.Add("@NmEmpresa", SqlDbType.NVarChar).Value = empresa.NmEmpresa;
                    sqlCommand.Parameters.Add("@AddrEndereco", SqlDbType.NVarChar).Value = empresa.AddrEndereco;
                    sqlCommand.Parameters.Add("@TelTelefone", SqlDbType.NVarChar).Value = empresa.TelTelefone;
                    sqlCommand.Parameters.Add("@BoolGostei", SqlDbType.Int).Value = Convert.ToInt32(empresa.BoolGostei);
                    sqlCommand.Parameters.Add("@VlrMinPreco", SqlDbType.Decimal).Value = empresa.VlrMinPreco;
                    sqlCommand.Parameters.Add("@VlrMaxPreco", SqlDbType.Decimal).Value = empresa.VlrMaxPreco;
                    sqlCommand.Parameters.Add("@TxtSobre", SqlDbType.NVarChar).Value = empresa.TxtSobre;
                    sqlCommand.Parameters.Add("@TxtCortesia", SqlDbType.NVarChar).Value = empresa.TxtCortesia;
                    sqlCommand.Parameters.Add("@TxtLocalizacao", SqlDbType.NVarChar).Value = empresa.TxtLocalizacao;
                    sqlCommand.Parameters.Add("@IdLocalizacao", SqlDbType.Int).Value = empresa.IdLocalizacao;

                    sqlCommand.ExecuteNonQuery();

                    connect.Close();

                    return new object[] { "mensagem:", "sucesso em salvar dados.", empresa };
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Houve um erro:" + ex.Message);
                    connect.Close();
                    return new object[] { "mensagem:", "Houve um erro ->" + ex.Message };
                }
            }

        }

        public static object[] PostBox(Box box)
        {

            try
            {


                ConnectionUtil.CMD_INSERT_BOX.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@NmBox", SqlDbType.NVarChar).Value = box.NmBox;
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@TxtAmbiente", SqlDbType.NVarChar).Value = box.TxtAmbiente;
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@TxtInfo", SqlDbType.NVarChar).Value = box.TxtInfo;
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = box.IdEmpresa;
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@TxtDescParc1Oferta", SqlDbType.NVarChar).Value = "Verificar oferta do parceiro. Guia de Motéis.";
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@TxtDexParc2Oferta", SqlDbType.NVarChar).Value = "Verificar oferta do parceiro. Bons de Cama. ";
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@LnkParceiro1", SqlDbType.NVarChar).Value = "https://www.guiademoteis.com.br";
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@LnkParceiro2", SqlDbType.NVarChar).Value = "https://www.bonsdecama.com.br";
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@imgFoto", SqlDbType.NVarChar).Value = box.imgFoto;
                ConnectionUtil.CMD_INSERT_BOX.Parameters.Add("@NmInfoImportante", SqlDbType.NVarChar).Value = box.NmInfoImportante;

                ConnectionUtil.CMD_INSERT_BOX.ExecuteNonQuery();

                ConnectionUtil.CMD_INSERT_BOX.Parameters.Clear();

                ConnectionSettings.FecharConexao();


            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro" + ex.Message);
                ConnectionSettings.FecharConexao();
                return new object[] { "Houve um erro:", ex.Message };

            }
            return new object[] { "sucesso em salvar dados:", box };
        }

        static object[] AplicaDesconto(Box box)
        {
            decimal valorH = 0;
            decimal valorP = 0;
            int id = 0;
            SqlDataReader reader = null;
            ConnectionUtil.CMD_SELECT_BOX.Connection = ConnectionSettings.AbrirConexao();
            ConnectionUtil.CMD_SELECT_BOX.Parameters.Add("@NmBox", SqlDbType.NVarChar).Value = box.NmBox;
            reader = ConnectionUtil.CMD_SELECT_BOX.ExecuteReader();
            while (reader.Read())
            {
                valorH = Convert.ToDecimal(reader["VlrQuatroHoras"]);
                valorP = Convert.ToDecimal(reader["VlrPernoite"]);
                id = Convert.ToInt32(reader["IdBox"]);
            }
            ConnectionSettings.FecharConexao();
            ConnectionUtil.CMD_INSERT_DESC.Connection = ConnectionSettings.AbrirConexao();
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@DtDataHoje", SqlDbType.DateTime).Value = DateTime.Now;
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@VlrDescQuatroHoras", SqlDbType.Decimal).Value = CalculoUtil.CalculaQuinzePorCento(valorH);
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@VlrDescPernoite", SqlDbType.Decimal).Value = CalculoUtil.CalculaQuinzePorCento(valorP);
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@LnkParceiro1", SqlDbType.NVarChar).Value = "https://www.guiademoteis.com.br";
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@LnkParceiro2", SqlDbType.NVarChar).Value = "https://www.bonsdecama.com.br";
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@IdBox", SqlDbType.Int).Value = id;
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@VlrDescQH20", SqlDbType.Decimal).Value = CalculoUtil.CalculaVintePorCento(valorH);
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@VlrDescPernoite20", SqlDbType.Decimal).Value = CalculoUtil.CalculaVintePorCento(valorP);
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@TxtDescParceiro1", SqlDbType.NVarChar).Value = "Economize até R$ " + CalculoUtil.CalculaQuinzePorCentoDesc(valorP).ToString() + " De R$ " + valorP.ToString() + " por R$ " + CalculoUtil.CalculaQuinzePorCento(valorP).ToString() + ". Guia de Motéis.";
            ConnectionUtil.CMD_INSERT_DESC.Parameters.Add("@TxtDescParceiro2", SqlDbType.NVarChar).Value = "Economize até R$ " + CalculoUtil.CalculaVintePorCentoDesc(valorP).ToString() + " De R$ " + valorP.ToString() + " por R$ " + CalculoUtil.CalculaVintePorCento(valorP).ToString() + ". Bons de Cama";
            ConnectionUtil.CMD_INSERT_DESC.ExecuteNonQuery();
            ConnectionSettings.FecharConexao();

            return new object[] { "sucesso em salvar dados:", box, "descontos salvos:", "R$", CalculoUtil.CalculaQuinzePorCento(valorP), "R$", CalculoUtil.CalculaQuinzePorCento(valorP) };
        }

        public static Box GetBoxByNm(string nmBox)
        {
            Box box = null;
            List<Periodo> listPeriodo = null;
            SqlDataReader reader = null;
            try
            {
                box = new Box();
                listPeriodo = new List<Periodo>();
                ConnectionUtil.CMD_SELECT_BOX_BY_NMBOX.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_SELECT_BOX_BY_NMBOX.Parameters.Add("@NmBox", SqlDbType.NVarChar).Value = nmBox;
                reader = ConnectionUtil.CMD_SELECT_BOX_BY_NMBOX.ExecuteReader();
                while (reader.Read())
                {
                    box.IdBox = Convert.ToInt32(reader["IdBox"]);
                    box.NmBox = reader["NmBox"].ToString();
                    box.imgFoto = reader["ImgFoto"].ToString();
                    box.TxtAmbiente = reader["TxtAmbiente"].ToString();
                    box.TxtInfo = reader["TxtInfo"].ToString();
                    box.TxtDescParceiro1Oferta = reader["TxtDescParc1Oferta"].ToString();
                    box.TxtDescParceiro2Oferta = reader["TxtDexParc2Oferta"].ToString();
                    box.LnkParceiro1 = reader["LnkParceiro1"].ToString();
                    box.LnkParceiro2 = reader["LnkParceiro2"].ToString();
                    box.IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]);
                }
                ConnectionSettings.FecharConexao();
                reader = null;
                ConnectionUtil.CMD_SELECT_PERIODO.Connection = ConnectionSettings.AbrirConexao();
                reader = ConnectionUtil.CMD_SELECT_PERIODO.ExecuteReader();
                while (reader.Read())
                {
                    listPeriodo.Add(new Periodo
                    {
                        IdPeriodo = Convert.ToInt32(reader["IdPeriodo"]),
                        NmDescricao = reader["NmPeriodo"].ToString(),
                        VlrPeriodo = Convert.ToDecimal(reader["VlrPeriodo"]),
                        IdBox = Convert.ToInt32(reader["IdBox"])
                    });
                }

                box.Periodo = listPeriodo.Where(p => p.IdBox == box.IdBox).ToList();

                ConnectionUtil.CMD_SELECT_BOX_BY_NMBOX.Parameters.Clear();

                ConnectionSettings.FecharConexao();

                return box;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
            }
            return box;
        }

        public static object[] PostTime(Periodo periodo)
        {
            try
            {
                ConnectionUtil.CMD_INSERT_PERIODO.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_INSERT_PERIODO.Parameters.Add("@NmPeriodo", SqlDbType.NVarChar).Value = periodo.NmDescricao;
                ConnectionUtil.CMD_INSERT_PERIODO.Parameters.Add("@VlrPeriodo", SqlDbType.Decimal).Value = periodo.VlrPeriodo;
                ConnectionUtil.CMD_INSERT_PERIODO.Parameters.Add("@IdBox", SqlDbType.Int).Value = periodo.IdBox;
                ConnectionUtil.CMD_INSERT_PERIODO.ExecuteNonQuery();
                ConnectionUtil.CMD_INSERT_PERIODO.Parameters.Clear();
                ConnectionSettings.FecharConexao();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro" + ex.Message);
                ConnectionSettings.FecharConexao();
                return new object[] { "Houve um erro:", ex.Message };
            }

            return new object[] { "sucesso em salvar dados:", periodo };
        }

        public static Periodo PutTime(Periodo periodo)
        {
            Periodo p = null;
            try
            {
                ConnectionUtil.CMD_UPDATE_PERIODO.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_UPDATE_PERIODO.Parameters.Add("@NmPeriodo", SqlDbType.NVarChar).Value = periodo.NmDescricao;
                ConnectionUtil.CMD_UPDATE_PERIODO.Parameters.Add("@VlrPeriodo", SqlDbType.Decimal).Value = periodo.VlrPeriodo;
                ConnectionUtil.CMD_UPDATE_PERIODO.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = periodo.IdPeriodo;
                ConnectionUtil.CMD_UPDATE_PERIODO.ExecuteNonQuery();
                ConnectionUtil.CMD_UPDATE_PERIODO.Parameters.Clear();
                ConnectionSettings.FecharConexao();
                p = GetTimeById(periodo.IdPeriodo);
                return p;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
            }
            return p;
        }
        public static bool DeleteTime(int? id)
        {
            try
            {
                ConnectionUtil.CMD_DELETE_PERIODO.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_DELETE_PERIODO.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = id;
                ConnectionUtil.CMD_DELETE_PERIODO.ExecuteNonQuery();
                ConnectionUtil.CMD_DELETE_PERIODO.Parameters.Clear();
                ConnectionSettings.FecharConexao();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
            }
            return false;
        }
        public static Periodo GetTimeById(int? id)
        {
            SqlDataReader reader = null;
            Periodo periodo = null;
            try
            {
                periodo = new Periodo();
                ConnectionUtil.CMD_SELECT_PERIODO_BY_ID.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_SELECT_PERIODO_BY_ID.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = id;
                reader = ConnectionUtil.CMD_SELECT_PERIODO_BY_ID.ExecuteReader();
                while (reader.Read())
                {
                    periodo.IdPeriodo = Convert.ToInt32(reader["IdPeriodo"]);
                    periodo.NmDescricao = reader["NmPeriodo"].ToString();
                    periodo.VlrPeriodo = Convert.ToDecimal(reader["VlrPeriodo"]);
                    periodo.IdBox = Convert.ToInt32(reader["IdBox"]);
                }
                ConnectionUtil.CMD_SELECT_PERIODO_BY_ID.Parameters.Clear();
                ConnectionSettings.FecharConexao();
                return periodo;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
            }
            return periodo;
        }

        public static List<Empresa> GetEmpresaByNm(string nmEmpresa)
        {
            List<Empresa> listEmpresa = null;
            SqlDataReader reader = null;

            try
            {
                listEmpresa = new List<Empresa>();
                ConnectionUtil.CMD_SELECT_EMPRESA_BY_NM.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_SELECT_EMPRESA_BY_NM.Parameters.Add("@NmEmpresa", SqlDbType.NVarChar).Value = nmEmpresa;
                reader = ConnectionUtil.CMD_SELECT_EMPRESA_BY_NM.ExecuteReader();
                while (reader.Read())
                {
                    listEmpresa.Add(new Empresa
                    {
                        IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                        NmEmpresa = reader["nmEmpresa"].ToString(),
                        ImgLogo = reader["imgLogo"].ToString(),
                        TelTelefone = reader["telTelefone"].ToString(),
                        TxtCortesia = reader["txtCortesia"].ToString(),
                        AddrEndereco = reader["addrEndereco"].ToString(),
                        BoolGostei = Convert.ToBoolean(reader["boolGostei"]),
                        VlrMaxPreco = Convert.ToDecimal(reader["vlrMaxPreco"]),
                        VlrMinPreco = Convert.ToDecimal(reader["vlrMinPreco"]),
                        TxtLocalizacao = reader["txtLocalizacao"].ToString(),
                        TxtSobre = reader["txtSobre"].ToString(),
                        IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"])
                    });
                }
                ConnectionUtil.CMD_SELECT_EMPRESA_BY_NM.Parameters.Clear();
                ConnectionSettings.FecharConexao();
                return listEmpresa;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
                ConnectionSettings.FecharConexao();
            }
            return listEmpresa;
        }

        public static Empresa GetEmpresaById(int? id)
        {
            Empresa empresa = null;
            SqlDataReader reader = null;
            try
            {
                empresa = new Empresa();
                ConnectionUtil.CMD_SELECT_EMPRESA_BY_ID.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_SELECT_EMPRESA_BY_ID.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = id;
                reader = ConnectionUtil.CMD_SELECT_EMPRESA_BY_ID.ExecuteReader();
                while (reader.Read())
                {
                    empresa.IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]);
                    empresa.NmEmpresa = reader["nmEmpresa"].ToString();
                    empresa.ImgLogo = reader["imgLogo"].ToString();
                    empresa.TelTelefone = reader["telTelefone"].ToString();
                    empresa.TxtCortesia = reader["txtCortesia"].ToString();
                    empresa.AddrEndereco = reader["addrEndereco"].ToString();
                    empresa.BoolGostei = Convert.ToBoolean(reader["boolGostei"]);
                    empresa.VlrMaxPreco = Convert.ToDecimal(reader["vlrMaxPreco"]);
                    empresa.VlrMinPreco = Convert.ToDecimal(reader["vlrMinPreco"]);
                    empresa.TxtLocalizacao = reader["txtLocalizacao"].ToString();
                    empresa.TxtSobre = reader["txtSobre"].ToString();
                    empresa.IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"]);
                }
                ConnectionUtil.CMD_SELECT_EMPRESA_BY_ID.Parameters.Clear();
                ConnectionSettings.FecharConexao();
                return empresa;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
                ConnectionSettings.FecharConexao();
            }
            return empresa;
        }

        public static bool PutEmpresa(Empresa empresa)
        {
            try
            {
                ConnectionUtil.CMD_UPDATE_EMPRESA.Connection = ConnectionSettings.AbrirConexao();
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@NmEmpresa", SqlDbType.NVarChar).Value = empresa.NmEmpresa;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = empresa.IdEmpresa;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@TxtLocalizacao", SqlDbType.NVarChar).Value = empresa.TxtLocalizacao;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@TxtSobre", SqlDbType.NVarChar).Value = empresa.TxtSobre;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@VlrMinPreco", SqlDbType.Decimal).Value = empresa.VlrMinPreco;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@VlrMaxPreco", SqlDbType.Decimal).Value = empresa.VlrMaxPreco;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@TxtCortesia", SqlDbType.NVarChar).Value = empresa.TxtCortesia;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@ImgLogo", SqlDbType.NVarChar).Value = empresa.ImgLogo;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@AddrEndereco", SqlDbType.NVarChar).Value = empresa.AddrEndereco;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@TelTelefone", SqlDbType.NVarChar).Value = empresa.TelTelefone;
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Add("@BoolGostei", SqlDbType.Int).Value = Convert.ToInt32(empresa.BoolGostei);
                ConnectionUtil.CMD_UPDATE_EMPRESA.ExecuteNonQuery();
                ConnectionUtil.CMD_UPDATE_EMPRESA.Parameters.Clear();
                ConnectionSettings.FecharConexao();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Houve um erro:" + ex.Message);
                ConnectionSettings.FecharConexao();
            }
            return false;
        }
    }


}