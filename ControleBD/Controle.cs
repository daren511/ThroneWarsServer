using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;
using Oracle.DataAccess.Client;

namespace ControleBD
{

    
    public class Controle
    {
        private static int SaltValueSize = 16;

        public static bool confirmAccount(int jid)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlconfirmation = "update joueurs set CONFIRMED=:CONFIRMED where jid=:jid";

            try
            {
                OracleCommand oraUpdate = new OracleCommand(sqlconfirmation, conn);

                OracleParameter OraParamConfirmed = new OracleParameter(":CONFIRMED", OracleDbType.Char, 1);
                OracleParameter OraParamJid = new OracleParameter(":jid", OracleDbType.Int32);

                OraParamConfirmed.Value = 'T';
                OraParamJid.Value = jid;

                oraUpdate.Parameters.Add(OraParamConfirmed);
                oraUpdate.Parameters.Add(OraParamJid);

                oraUpdate.ExecuteNonQuery();

                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        //TEMPORAIRE VERIFIER Si jid ou USERNAME
        public static bool updatePlayer(int jid,string username,string email,string password)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlupdate = "update joueurs set email=:EMAIL,Hash_KEY=:Hash_KEY where jid=:jid";

            try
            {

                OracleCommand oraUpdate = new OracleCommand(sqlupdate, conn);

                //OracleParameter OraParaUsername = new OracleParameter(":username", OracleDbType.Varchar2, 40);
                OracleParameter OraParamEmail = new OracleParameter(":EMAIL", OracleDbType.Varchar2, 40);
                OracleParameter OraParamHashKey = new OracleParameter(":Hash_KEY", OracleDbType.Char, 75);  //Ajout
                OracleParameter OraParamJid = new OracleParameter(":jid", OracleDbType.Int32);

                //OraParaUsername.Value = username;
                OraParamEmail.Value = email;
                OraParamHashKey.Value = Controle.HashPassword(password, null, System.Security.Cryptography.SHA256.Create());
                OraParamJid.Value = jid;


                //oraUpdate.Parameters.Add(OraParaUsername);
                oraUpdate.Parameters.Add(OraParamEmail);
                oraUpdate.Parameters.Add(OraParamHashKey);
                oraUpdate.Parameters.Add(OraParamJid);

                oraUpdate.ExecuteNonQuery();

                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool insertplayer(string username,string email,string password)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlAjout = "insert into joueurs (username,EMAIL,Hash_KEY)" +
                    " VALUES(:username,:EMAIL,:Hash_KEY)";
            try
            {

                OracleCommand oraAjout = new OracleCommand(sqlAjout, conn);

                OracleParameter OraParaUsername = new OracleParameter(":username", OracleDbType.Varchar2, 40);
                OracleParameter OraParamEmail = new OracleParameter(":EMAIL", OracleDbType.Varchar2, 40);
                OracleParameter OraParamHashKey = new OracleParameter(":Hash_KEY", OracleDbType.Char, 75);  //Ajout

                OraParaUsername.Value = username;
                OraParamEmail.Value = email;
                OraParamHashKey.Value = Controle.HashPassword(password, null, System.Security.Cryptography.SHA256.Create());


                oraAjout.Parameters.Add(OraParaUsername);
                oraAjout.Parameters.Add(OraParamEmail);
                oraAjout.Parameters.Add(OraParamHashKey);

                oraAjout.ExecuteNonQuery();

                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool deleteplayer(int JID)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqldelete = "delete cascade from joueurs where JID = " + JID;

            try 
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);

                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }

        }

        public static bool deletePerso(int GUID)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqldelete = "delete cascade from Personnages where GUID = " + GUID;

            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);

                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool deleteItem(int IID)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqldelete = "delete cascade from Items where IID = " + IID;

            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);

                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool deleteHabiite(int HID)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqldelete = "delete cascade from Items where HID = " + HID;

            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);

                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool deleteHabiite(int HID)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqldelete = "delete cascade from Items where HID = " + HID;

            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);

                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool AjoutMoneyToJoueurs(int JID , int montant)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlupdate = "update joueurs set money=:montant where jid= "+JID;

            try
            {
                OracleCommand oraUpdate = new OracleCommand(sqlupdate, conn);
                
                OracleParameter OraParaMoney = new OracleParameter(":montant", OracleDbType.Int32);

                OraParaMoney.Value = montant;
                oraUpdate.Parameters.Add(OraParaMoney);
                oraUpdate.ExecuteNonQuery();

                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool deleteHabiite(int HID)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqldelete = "delete cascade from Items where HID = " + HID;

            try
            {

                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);

                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }








        private static string GenerateSaltValue()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();

            if (utf16 != null)
            {
                    string saltValueString = "DECDEADDEAD";
                    return saltValueString;
            }

            return null;
        }

        public static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();

            if (clearData != null && hash != null && encoding != null)
            {
                // If the salt string is null or the length is invalid then
                // create a new valid salt value.

                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = GenerateSaltValue();
                }

                // Convert the salt string and the password string to a single
                // array of bytes. Note that the password string is Unicode and
                // therefore may or may not have a zero in every other byte.

                byte[] binarySaltValue = new byte[SaltValueSize];

                binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                byte[] valueToHash = new byte[SaltValueSize + encoding.GetByteCount(clearData)];
                byte[] binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, SaltValueSize);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                string hashedPassword = saltValue;

                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.

                return hashedPassword;
            }

            return null;
        }


    }
}
