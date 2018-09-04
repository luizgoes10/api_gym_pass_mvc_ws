using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Settings
{
    public static class ConnectionUtil
    {
        public static string CONN_STRING = ConfigurationManager.ConnectionStrings["apiGymConn"].ConnectionString;

        public static SqlCommand CMD_SELECT_EMP = new SqlCommand("select *from dbo.tbEmpresa");

        public static SqlCommand CMD_SELECT_BOX = new SqlCommand("select *from dbo.tbBox");

        public static string CMD_INSERT_EMP = "insert into tbEmpresa values" +
                "(@ImgLogo,@NmEmpresa,@AddrEndereco,@TelTelefone,@BoolGostei," +
                "@VlrMinPreco,@VlrMaxPreco,@TxtSobre,@TxtCortesia,@TxtLocalizacao,@IdLocalizacao)";

        public static SqlCommand CMD_INSERT_BOX = new SqlCommand("insert into tbBox values" +
                "(@NmBox,@TxtAmbiente,@TxtInfo," +
                "@IdEmpresa,@TxtDescParc1Oferta,@TxtDexParc2Oferta,@LnkParceiro1,@LnkParceiro2,@imgFoto,@NmInfoImportante)");

        public static SqlCommand CMD_SELECT_BOX_NMBOX = new SqlCommand("select *from tbBox where NmBox = @NmBox");

        public static SqlCommand CMD_INSERT_DESC = new SqlCommand("insert into tbDesconto values(@DtDataHoje,@VlrDescQuatroHoras," +
                "@VlrDescPernoite,@LnkParceiro1,@LnkParceiro2,@TxtDescParceiro1," +
                "@TxtDescParceiro2,@IdBox,@VlrDescQH20,@VlrDescPernoite20)");

        public static SqlCommand CMD_SELECT_BOX_BY_NMBOX = new SqlCommand("select *from tbBox where NmBox = @NmBox");

        public static SqlCommand CMD_SELECT_REGIAO = new SqlCommand("select *from dbo.tbRegiao");

        public static SqlCommand CMD_SELECT_ESTADO = new SqlCommand("select *from dbo.tbEstado");

        public static SqlCommand CMD_SELECT_LOCALIZACAO = new SqlCommand("select *from dbo.tbLocalizacao");

        public static SqlCommand CMD_INSERT_PERIODO = new SqlCommand("insert into tbPeriodo values(@NmPeriodo,@VlrPeriodo,@IdBox)");

        public static SqlCommand CMD_SELECT_PERIODO = new SqlCommand("select *from tbPeriodo");

        public static SqlCommand CMD_SELECT_PERIODO_BY_ID = new SqlCommand("select *from tbPeriodo where IdPeriodo = @IdPeriodo");

        public static SqlCommand CMD_UPDATE_PERIODO = new SqlCommand("update tbPeriodo set NmPeriodo = @NmPeriodo, VlrPeriodo = @VlrPeriodo where IdPeriodo = @IdPeriodo");

        public static SqlCommand CMD_DELETE_PERIODO = new SqlCommand("delete from tbPeriodo where IdPeriodo = @IdPeriodo");

        public static SqlCommand CMD_SELECT_EMPRESA_BY_NM = new SqlCommand("select *from tbEmpresa where nmEmpresa like '%' + @NmEmpresa + '%' order by nmEmpresa");

        public static SqlCommand CMD_SELECT_EMPRESA_BY_ID = new SqlCommand("select *from dbo.tbEmpresa where IdEmpresa = @IdEmpresa");

        public static SqlCommand CMD_UPDATE_EMPRESA = new SqlCommand("update tbEmpresa set" +
            " txtLocalizacao = @TxtLocalizacao, vlrMinPreco = @VlrMinPreco, " +
            "vlrMaxPreco = @VlrMaxPreco, txtSobre = @TxtSobre, " +
            "txtCortesia = @TxtCortesia, imgLogo = @ImgLogo, " +
            "addrEndereco = @AddrEndereco, telTelefone = @TelTelefone," +
            " nmEmpresa = @NmEmpresa, boolGostei = @BoolGostei " +
            "where IdEmpresa = @IdEmpresa");
        public static SqlCommand CMD_INSERT_LOCALIZACAO = new SqlCommand("insert into tbLocalizacao values(@NmLocalizacao,@IdEstado)");

    }
}