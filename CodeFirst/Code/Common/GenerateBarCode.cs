using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code.Common
{
    public static class GenerateBarCode
    {
        public static string[] Generate(string oldBarCode, int titleID, bool type)
        {
            string barCodeFull = null;

            if (oldBarCode == null)
                barCodeFull = GenerateBarCodeKey(oldBarCode, titleID, type);
            else
                barCodeFull = oldBarCode;


            string barCodeKey = null;
            string barCodeID = null;
            string regex = @"(?<key>^\d{5})0*(?<barcode>[^0]\d{0,3}$)";

            MatchCollection matchCollection = Regex.Matches(barCodeFull, regex);

            foreach (Match match in matchCollection)
            {
                barCodeKey = match.Groups["key"].ToString();
                barCodeID = match.Groups["barcode"].ToString();
            }

            StringBuilder builder = new StringBuilder(barCodeKey);
            if (type)
                builder[0] = '1';
            else
                builder[0] = '0';

            barCodeKey =  builder.ToString();
           
            if (barCodeID == "1" && oldBarCode == null)
                barCodeID = "0";

            return new string[] { barCodeKey , barCodeID };
        } 

        public static string GenerateBarCodeKey(string oldBarCode, int titleID,bool type)
        {
            string barCodeFull = null;

            if(oldBarCode == null)
            {
                string barCodeKey = "0";
               

                if (titleID.ToString().Length == 1)
                    barCodeKey = barCodeKey + titleID + "000";
                else if (titleID.ToString().Length == 2)
                    barCodeKey = barCodeKey + titleID + "00";
                else if (titleID.ToString().Length == 3)
                    barCodeKey = barCodeKey + titleID + "0";
                else if (titleID.ToString().Length == 4)
                    barCodeKey = barCodeKey + titleID;

                barCodeFull = barCodeKey + "0001";
            }

            return barCodeFull;
        }

        public static string CustomBarCodeID(string barCodeKey,string barCodeID)
        {

            int length = barCodeID.Length;
            if (length == 1)
                barCodeID = "000" + barCodeID;
            else if(length == 2)
                barCodeID = "00" + barCodeID;
            else if (length == 3)
                barCodeID = "0" + barCodeID;

            return barCodeKey + barCodeID;
        }
    }
}
