using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Settings
{
    public static class CalculoUtil
    {
        public static decimal CalculaQuinzePorCento(decimal valor) => (valor - valor * 15 / 100);
        public static decimal CalculaVintePorCento(decimal valor) => (valor - valor * 20 / 100);

        public static decimal CalculaQuinzePorCentoDesc(decimal valor) => (valor * 15 / 100);

        public static decimal CalculaVintePorCentoDesc(decimal valor) => (valor * 20 / 100);
    }
}