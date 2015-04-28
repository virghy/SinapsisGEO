using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporting
{
    public class Utility
    {
        public static string HoraString(int? hora)
        {
            String sHora = "";
            if (hora.HasValue)
            {
                String cHora;
                String cMin;
                cHora = (Decimal.Floor(hora.Value / 60).ToString().PadLeft(2, '0') + ":");
                cMin = Decimal.Remainder(hora.Value, 60).ToString().PadLeft(2, '0');
                sHora= cHora + cMin;
            }
            return sHora;


        }
        public static double MinutosTrans(int? hora)
        {
            DateTime hr = DateTime.Now;
            if (hora.HasValue)
            {
                hr = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.Now.Day, (int)Decimal.Floor(hora.Value / 60),
                    (int)Decimal.Remainder(hora.Value, 60),
                    0);
            }

            return (DateTime.Now - hr).TotalMinutes;
            

        }
        //public string HoraString(DBNull hora)
        //{
        //    return "";

        //}

        //public static object HoraString(int? nullable)
        //{
        //    throw new NotImplementedException();
        //}

        public static object HoraString(string p)
        {
            throw new NotImplementedException();
        }

        public static string GetMessageError(Exception ex)
        {
            string msg = "";
            while (ex != null)
            {
                msg += "<br />&bull; " + ex.Message + "<br />";
                ex = ex.InnerException;

            }
            return msg;

        }
    }
}