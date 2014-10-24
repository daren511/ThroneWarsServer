using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using Oracle.DataAccess.Client;
using System.Data;
using Emails;

namespace ControleBD
{


    public class Controle
    {
        private static int SaltValueSize = 16;

        

        public static bool deletePerso(int GUID)
        {
            OracleConnection conn = Connection.GetInstance().conn;
            string sqldelete = "delete cascade from Personnages where GUID =:GUID";
            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);
                OracleParameter OraParaGUID = new OracleParameter(":GUID", OracleDbType.Int32);
                oraDelete.Parameters.Add(OraParaGUID);
                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }



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

        //-------------------------------------INSERT / UPDATE / DELETE PLAYER-------------------------------------------

        public static bool insertPlayer(string username, string email, string password)
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


        //TEMPORAIRE VERIFIER Si jid ou USERNAME
        public static bool updatePlayer(int jid, string username, string email, string password)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlupdate = "update joueurs set email=:EMAIL,Hash_KEY=:Hash_KEY where jid=:jid";

            try
            {

                OracleCommand oraUpdate = new OracleCommand(sqlupdate, conn);

                OracleParameter OraParamEmail = new OracleParameter(":EMAIL", OracleDbType.Varchar2, 40);
                OracleParameter OraParamHashKey = new OracleParameter(":Hash_KEY", OracleDbType.Char, 75);  //Ajout
                OracleParameter OraParamJid = new OracleParameter(":jid", OracleDbType.Int32);

                OraParamEmail.Value = email;
                OraParamHashKey.Value = Controle.HashPassword(password, null, System.Security.Cryptography.SHA256.Create());
                OraParamJid.Value = jid;


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


        public static bool deletePlayer(int JID)
        {
            OracleConnection conn = Connection.GetInstance().conn;
            string sqldelete = "delete cascade from joueurs where JID =:JID ";
            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);
                OracleParameter OraParaJID = new OracleParameter(":JID", OracleDbType.Int32);
                oraDelete.Parameters.Add(OraParaJID);
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
            string sqldelete = "delete cascade from Items where IID =:IID ";
            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);
                OracleParameter OraParaIID = new OracleParameter(":IID", OracleDbType.Int32);
                oraDelete.Parameters.Add(OraParaIID);
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
            string sqldelete = "delete cascade from Items where HID =:HID ";
            try
            {
                OracleCommand oraDelete = new OracleCommand(sqldelete, conn);
                OracleParameter OraParaHID = new OracleParameter(":HID", OracleDbType.Int32);
                oraDelete.Parameters.Add(OraParaHID);
                oraDelete.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }


        public static bool AjoutMoneyJoueur(int JID, int montant)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlupdate = "update joueurs set money=:montant where jid=:JID ";

            try
            {
                OracleCommand oraUpdate = new OracleCommand(sqlupdate, conn);
                OracleParameter OraParaJID = new OracleParameter(":JID", OracleDbType.Int32);
                OracleParameter OraParaMoney = new OracleParameter(":montant", OracleDbType.Int32);
                OraParaJID.Value = JID;
                OraParaMoney.Value = montant;
                oraUpdate.Parameters.Add(OraParaJID);
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

        public static bool AjoutXPPersonnage(int GUID, int XP)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlupdate = "update Personnages set XP=:xp where guid=:GUID";

            try
            {
                OracleCommand oraUpdate = new OracleCommand(sqlupdate, conn);
                OracleParameter OraParaGUID = new OracleParameter(":GUID", OracleDbType.Int32);
                OracleParameter OraParaXP = new OracleParameter(":XP", OracleDbType.Int32);
                OraParaGUID.Value = GUID;
                OraParaXP.Value = XP;
                oraUpdate.Parameters.Add(OraParaGUID);
                oraUpdate.Parameters.Add(OraParaXP);
                oraUpdate.ExecuteNonQuery();
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



        /// <summary>
        /// Add the 4 remaining players in the match
        /// </summary>
        /// <param name="mID">Match ID</param>
        /// <param name="jID">Player ID</param>
        /// <param name="guID1">Character1 ID</param>
        /// <param name="guID2">Character2 ID</param>
        /// <param name="guID3">Character3 ID</param>
        /// <param name="guID4">Character4 ID</param>
        /// <returns>True if the function worked</returns>
        private static bool addPlayer(int mID, int jID, int guID1, int guID2, int guID3, int guID4)
        {
            OracleConnection conn = Connection.GetInstance().conn;
            try
            {
                OracleCommand oraAdd = new OracleCommand("PACK_MATCHS", conn);
                oraAdd.CommandText = "PACK_MATCHS.ADD_PLAYER_IN_MATCH";
                oraAdd.CommandType = CommandType.StoredProcedure;

                OracleParameter oraParamMID = new OracleParameter("pMID", OracleDbType.Int32);
                oraParamMID.Direction = ParameterDirection.Input;
                oraParamMID.Value = mID;
                oraAdd.Parameters.Add(oraParamMID);

                OracleParameter oraParamJID = new OracleParameter("pJID", OracleDbType.Int32);
                oraParamJID.Direction = ParameterDirection.Input;
                oraParamJID.Value = jID;
                oraAdd.Parameters.Add(oraParamJID);

                OracleParameter oraParamGUID1 = new OracleParameter("pGUID1", OracleDbType.Int32);
                oraParamGUID1.Direction = ParameterDirection.Input;
                oraParamGUID1.Value = guID1;
                oraAdd.Parameters.Add(oraParamGUID1);

                OracleParameter oraParamGUID2 = new OracleParameter("pGUID2", OracleDbType.Int32);
                oraParamGUID2.Direction = ParameterDirection.Input;
                oraParamGUID2.Value = guID2;
                oraAdd.Parameters.Add(oraParamGUID2);

                OracleParameter oraParamGUID3 = new OracleParameter("pGUID3", OracleDbType.Int32);
                oraParamGUID3.Direction = ParameterDirection.Input;
                oraParamGUID3.Value = guID3;
                oraAdd.Parameters.Add(oraParamGUID3);

                OracleParameter oraParamGUID4 = new OracleParameter("pGUID4", OracleDbType.Int32);
                oraParamGUID4.Direction = ParameterDirection.Input;
                oraParamGUID4.Value = guID4;
                oraAdd.Parameters.Add(oraParamGUID4);

                oraAdd.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        //----------------------------------------------------CREATE / UPDATE MATCH

        /// <summary>
        /// Create the match and insert the first 4 players in it
        /// </summary>
        /// <param name="mID">Match ID</param>
        /// <param name="jID">Player ID</param>
        /// <param name="map">Map ID</param>
        /// <param name="guID1">Character1 ID</param>
        /// <param name="guID2">Character2 ID</param>
        /// <param name="guID3">Character3 ID</param>
        /// <param name="guID4">Character4 ID</param>
        /// <returns>True if the function worked</returns>
        private static bool createMatch(int mID, int jID, int map, int guID1, int guID2, int guID3, int guID4)
        {
            OracleConnection conn = Connection.GetInstance().conn;
            try
            {
                OracleCommand oraCreate = new OracleCommand("PACK_MATCHS", conn);
                oraCreate.CommandText = "PACK_MATCHS.CREATE_MATCH";
                oraCreate.CommandType = CommandType.StoredProcedure;

                OracleParameter oraParamMID = new OracleParameter("pMID", OracleDbType.Int32);
                oraParamMID.Direction = ParameterDirection.Input;
                oraParamMID.Value = mID;
                oraCreate.Parameters.Add(oraParamMID);

                OracleParameter oraParamJID = new OracleParameter("pJID", OracleDbType.Int32);
                oraParamJID.Direction = ParameterDirection.Input;
                oraParamJID.Value = jID;
                oraCreate.Parameters.Add(oraParamJID);

                OracleParameter oraParamMap = new OracleParameter("pMAP", OracleDbType.Int32);
                oraParamMap.Direction = ParameterDirection.Input;
                oraParamMap.Value = map;
                oraCreate.Parameters.Add(oraParamMap);

                OracleParameter oraParamGUID1 = new OracleParameter("pGUID1", OracleDbType.Int32);
                oraParamGUID1.Direction = ParameterDirection.Input;
                oraParamGUID1.Value = guID1;
                oraCreate.Parameters.Add(oraParamGUID1);

                OracleParameter oraParamGUID2 = new OracleParameter("pGUID2", OracleDbType.Int32);
                oraParamGUID2.Direction = ParameterDirection.Input;
                oraParamGUID2.Value = guID2;
                oraCreate.Parameters.Add(oraParamGUID2);

                OracleParameter oraParamGUID3 = new OracleParameter("pGUID3", OracleDbType.Int32);
                oraParamGUID3.Direction = ParameterDirection.Input;
                oraParamGUID3.Value = guID3;
                oraCreate.Parameters.Add(oraParamGUID3);

                OracleParameter oraParamGUID4 = new OracleParameter("pGUID4", OracleDbType.Int32);
                oraParamGUID4.Direction = ParameterDirection.Input;
                oraParamGUID4.Value = guID4;
                oraCreate.Parameters.Add(oraParamGUID4);

                oraCreate.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Update the stats for the players' characters
        /// </summary>
        /// <param name="mID">Match ID</param>
        /// <param name="winner">Winner ID</param>
        /// <param name="jID1">Player1 ID</param>
        /// <param name="guID1">Character1 ID</param>
        /// <param name="kills1">Character1 kills</param>
        /// <param name="isDead1">If player1's first character is dead</param>
        /// <param name="guID2">Character2 ID</param>
        /// <param name="kills2">Character2 kills</param>
        /// <param name="isDead2">If player1's second character is dead</param>
        /// <param name="guID3">Character3 ID</param>
        /// <param name="kills3">Character3 kills</param>
        /// <param name="isDead3">If player1's third character is dead</param>
        /// <param name="guID4">Character4 ID</param>
        /// <param name="kills4">Character4 kills</param>
        /// <param name="isDead4">If player1's fourth character is dead</param>
        /// <param name="jID2">Player2 ID</param>
        /// <param name="guID5">Character5 ID</param>
        /// <param name="kills5">Character5 kills</param>
        /// <param name="isDead5">If player2's first character is dead</param>
        /// <param name="guID6">Character6 ID</param>
        /// <param name="kills6">Character6 kills</param>
        /// <param name="isDead6">If player2's second character is dead</param>
        /// <param name="guID7">Character7 ID</param>
        /// <param name="kills7">Character7 kills</param>
        /// <param name="isDead7">If player2's third character is dead</param>
        /// <param name="guID8">Character8 ID</param>
        /// <param name="kills8">Character8 kills</param>
        /// <param name="isDead8">If player2's fourth character is dead</param>
        /// <returns>True if the function worked</returns>
        private static bool updateMatch(int mID, int winner,
                                        int jID1,
                                        int guID1, int kills1, char isDead1,
                                        int guID2, int kills2, char isDead2,
                                        int guID3, int kills3, char isDead3,
                                        int guID4, int kills4, char isDead4,
                                        int jID2,
                                        int guID5, int kills5, char isDead5,
                                        int guID6, int kills6, char isDead6,
                                        int guID7, int kills7, char isDead7,
                                        int guID8, int kills8, char isDead8)
        {
            OracleConnection conn = Connection.GetInstance().conn;
            try
            {
                OracleCommand oraAdd = new OracleCommand("PACK_MATCHS", conn);
                oraAdd.CommandText = "PACK_MATCHS.UPDATE_MATCH";
                oraAdd.CommandType = CommandType.StoredProcedure;

                OracleParameter oraParamMID = new OracleParameter("pMID", OracleDbType.Int32);
                oraParamMID.Direction = ParameterDirection.Input;
                oraParamMID.Value = mID;
                oraAdd.Parameters.Add(oraParamMID);

                OracleParameter oraParamWinner = new OracleParameter("pWINNER", OracleDbType.Int32);
                oraParamWinner.Direction = ParameterDirection.Input;
                oraParamWinner.Value = winner;
                oraAdd.Parameters.Add(oraParamWinner);

                // ---------- PLAYER 1 ---------- //
                OracleParameter oraParamJID1 = new OracleParameter("pJID1", OracleDbType.Int32);
                oraParamJID1.Direction = ParameterDirection.Input;
                oraParamJID1.Value = jID1;
                oraAdd.Parameters.Add(oraParamJID1);
                // Character 1
                OracleParameter oraParamGUID1 = new OracleParameter("pGUID1", OracleDbType.Int32);
                oraParamGUID1.Direction = ParameterDirection.Input;
                oraParamGUID1.Value = guID1;
                oraAdd.Parameters.Add(oraParamGUID1);

                OracleParameter oraParamKills1 = new OracleParameter("pKILLS1", OracleDbType.Int32);
                oraParamKills1.Direction = ParameterDirection.Input;
                oraParamKills1.Value = kills1;
                oraAdd.Parameters.Add(oraParamKills1);

                OracleParameter oraParamIsDead1 = new OracleParameter("pISDEAD1", OracleDbType.Char, 1);
                oraParamIsDead1.Direction = ParameterDirection.Input;
                oraParamIsDead1.Value = isDead1;
                oraAdd.Parameters.Add(oraParamIsDead1);
                ////////////////////////////////////
                // Character 2
                OracleParameter oraParamGUID2 = new OracleParameter("pGUID2", OracleDbType.Int32);
                oraParamGUID2.Direction = ParameterDirection.Input;
                oraParamGUID2.Value = guID2;
                oraAdd.Parameters.Add(oraParamGUID2);

                OracleParameter oraParamKills2 = new OracleParameter("pKILLS2", OracleDbType.Int32);
                oraParamKills2.Direction = ParameterDirection.Input;
                oraParamKills2.Value = kills2;
                oraAdd.Parameters.Add(oraParamKills2);

                OracleParameter oraParamIsDead2 = new OracleParameter("pISDEAD2", OracleDbType.Char, 1);
                oraParamIsDead2.Direction = ParameterDirection.Input;
                oraParamIsDead2.Value = isDead2;
                oraAdd.Parameters.Add(oraParamIsDead2);
                ////////////////////////////////////
                // Character 3
                OracleParameter oraParamGUID3 = new OracleParameter("pGUID3", OracleDbType.Int32);
                oraParamGUID3.Direction = ParameterDirection.Input;
                oraParamGUID3.Value = guID3;
                oraAdd.Parameters.Add(oraParamGUID3);

                OracleParameter oraParamKills3 = new OracleParameter("pKILLS3", OracleDbType.Int32);
                oraParamKills3.Direction = ParameterDirection.Input;
                oraParamKills3.Value = kills3;
                oraAdd.Parameters.Add(oraParamKills3);

                OracleParameter oraParamIsDead3 = new OracleParameter("pISDEAD3", OracleDbType.Char, 1);
                oraParamIsDead3.Direction = ParameterDirection.Input;
                oraParamIsDead3.Value = isDead3;
                oraAdd.Parameters.Add(oraParamIsDead3);
                ////////////////////////////////////
                // Character 4
                OracleParameter oraParamGUID4 = new OracleParameter("pGUID4", OracleDbType.Int32);
                oraParamGUID4.Direction = ParameterDirection.Input;
                oraParamGUID4.Value = guID4;
                oraAdd.Parameters.Add(oraParamGUID4);

                OracleParameter oraParamKills4 = new OracleParameter("pKILLS4", OracleDbType.Int32);
                oraParamKills4.Direction = ParameterDirection.Input;
                oraParamKills4.Value = kills4;
                oraAdd.Parameters.Add(oraParamKills4);

                OracleParameter oraParamIsDead4 = new OracleParameter("pISDEAD4", OracleDbType.Char, 1);
                oraParamIsDead4.Direction = ParameterDirection.Input;
                oraParamIsDead4.Value = isDead4;
                oraAdd.Parameters.Add(oraParamIsDead4);
                ////////////////////////////////////

                // ---------- PLAYER 2 ---------- //
                OracleParameter oraParamJID2 = new OracleParameter("pJID2", OracleDbType.Int32);
                oraParamJID2.Direction = ParameterDirection.Input;
                oraParamJID2.Value = jID2;
                oraAdd.Parameters.Add(oraParamJID2);
                // Character 5
                OracleParameter oraParamGUID5 = new OracleParameter("pGUID5", OracleDbType.Int32);
                oraParamGUID5.Direction = ParameterDirection.Input;
                oraParamGUID5.Value = guID5;
                oraAdd.Parameters.Add(oraParamGUID5);

                OracleParameter oraParamKills5 = new OracleParameter("pKILLS5", OracleDbType.Int32);
                oraParamKills5.Direction = ParameterDirection.Input;
                oraParamKills5.Value = kills5;
                oraAdd.Parameters.Add(oraParamKills5);

                OracleParameter oraParamIsDead5 = new OracleParameter("pISDEAD5", OracleDbType.Char, 1);
                oraParamIsDead5.Direction = ParameterDirection.Input;
                oraParamIsDead5.Value = isDead5;
                oraAdd.Parameters.Add(oraParamIsDead5);
                ////////////////////////////////////
                // Character 6
                OracleParameter oraParamGUID6 = new OracleParameter("pGUID6", OracleDbType.Int32);
                oraParamGUID6.Direction = ParameterDirection.Input;
                oraParamGUID6.Value = guID6;
                oraAdd.Parameters.Add(oraParamGUID6);

                OracleParameter oraParamKills6 = new OracleParameter("pKILLS6", OracleDbType.Int32);
                oraParamKills6.Direction = ParameterDirection.Input;
                oraParamKills6.Value = kills6;
                oraAdd.Parameters.Add(oraParamKills6);

                OracleParameter oraParamIsDead6 = new OracleParameter("pISDEAD6", OracleDbType.Char, 1);
                oraParamIsDead6.Direction = ParameterDirection.Input;
                oraParamIsDead6.Value = isDead6;
                oraAdd.Parameters.Add(oraParamIsDead6);
                ////////////////////////////////////
                // Character 7
                OracleParameter oraParamGUID7 = new OracleParameter("pGUID7", OracleDbType.Int32);
                oraParamGUID7.Direction = ParameterDirection.Input;
                oraParamGUID7.Value = guID7;
                oraAdd.Parameters.Add(oraParamGUID7);

                OracleParameter oraParamKills7 = new OracleParameter("pKILLS7", OracleDbType.Int32);
                oraParamKills7.Direction = ParameterDirection.Input;
                oraParamKills7.Value = kills7;
                oraAdd.Parameters.Add(oraParamKills7);

                OracleParameter oraParamIsDead7 = new OracleParameter("pISDEAD7", OracleDbType.Char, 1);
                oraParamIsDead7.Direction = ParameterDirection.Input;
                oraParamIsDead7.Value = isDead7;
                oraAdd.Parameters.Add(oraParamIsDead7);
                ////////////////////////////////////
                // Character 8
                OracleParameter oraParamGUID8 = new OracleParameter("pGUID8", OracleDbType.Int32);
                oraParamGUID8.Direction = ParameterDirection.Input;
                oraParamGUID8.Value = guID8;
                oraAdd.Parameters.Add(oraParamGUID8);

                OracleParameter oraParamKills8 = new OracleParameter("pKILLS8", OracleDbType.Int32);
                oraParamKills8.Direction = ParameterDirection.Input;
                oraParamKills8.Value = kills8;
                oraAdd.Parameters.Add(oraParamKills8);

                OracleParameter oraParamIsDead8 = new OracleParameter("pISDEAD8", OracleDbType.Char, 1);
                oraParamIsDead8.Direction = ParameterDirection.Input;
                oraParamIsDead8.Value = isDead8;
                oraAdd.Parameters.Add(oraParamIsDead8);
                ////////////////////////////////////

                oraAdd.ExecuteNonQuery();
                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        //-----------------------------------------  FONCTIONS SITE WEB ---------------------------------------------
        
        public static bool PasswordRecovery(string username)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlSelect = "select username,email from joueurs where username = :username";
            string result = "";
            string resultemail = "";
            try
            {
                OracleCommand oraSelect = new OracleCommand(sqlSelect, conn);
                oraSelect.CommandType = CommandType.Text;

                OracleDataReader objRead = oraSelect.ExecuteReader();
                while (objRead.Read())
                {
                    result = objRead.GetString(0);
                    resultemail = objRead.GetString(1);
                }
                objRead.Close();
                

                
                if (result != null)
                {
                    string UserHash = Controle.HashPassword(result, null, System.Security.Cryptography.SHA256.Create());
                    string Subject = "Changement de mot de passe -Throne Wars";
                    string BodyResetPass = "Pour changer votre mot de passe, veuillez visiter"+
                                            " ce lien et suivre les indications www.thronewars.com/ResetPassword?"+UserHash;
                   //Reset password
                   //Emails.sendMail(resultemail,Subject,BodyResetPass);
                }
                return true;

            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }

        public static bool UsernameRecovery(string email)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlSelect = "select username from joueurs where email = :email";
            string result = "";
            try
            {
                OracleCommand oraSelect = new OracleCommand(sqlSelect, conn);
                oraSelect.CommandType = CommandType.Text;

                OracleDataReader objRead = oraSelect.ExecuteReader();
                while (objRead.Read())
                {
                    result = objRead.GetString(0);
                }
                objRead.Close();

                if (result != null)
                {
                    //envoie un email au courriel correspondant du username

                }
                return true;

            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// Retourne true quand le user et le password sont correspondant , retourne false sinon
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool UserPassCorrespondant(string user,string password)
        {
            // Variable pour le password Hashé
            string passHash = password;
            bool correspondant = false;
            // Hash le password passé en parametre
            passHash = Controle.HashPassword(password, null, System.Security.Cryptography.SHA256.Create());

            OracleConnection conn = Connection.GetInstance().conn;
            string sqlSelect = "select Username,Hash_Key from joueurs where username = :user and Hash_key = :passHash";
            string resultUser = "";
            string resultHash = "";

            OracleCommand oraSelect = new OracleCommand(sqlSelect, conn);
            oraSelect.CommandType = CommandType.Text;

            OracleDataReader objRead = oraSelect.ExecuteReader();
            while (objRead.Read())
            {
                resultUser = objRead.GetString(0);
                resultHash = objRead.GetString(1);

            }
            objRead.Close();
            if (resultUser != null && resultHash != null)
            {
                correspondant = true;
                return correspondant;
            }
            else
                return correspondant;
        }
        /// <summary>
        /// Changer le mot de passe d'un joueur
        /// </summary>
        /// <param name="username"></param>
        /// <param name="PassHash"></param>
        /// <returns></returns>
        public static bool UpdatePassword(string username,string PassHash)
        {
            OracleConnection conn = Connection.GetInstance().conn;

            string sqlconfirmation = "update joueurs set HASH_KEY =:PassHash where Username=:username";

            try
            {
                OracleCommand oraUpdate = new OracleCommand(sqlconfirmation, conn);

                OracleParameter OraParamPassHash = new OracleParameter(":HASH_KEY", OracleDbType.Char, 75);
                OracleParameter OraParamUsername = new OracleParameter(":Username", OracleDbType.Varchar2,32);

                OraParamPassHash.Value = PassHash;
                OraParamUsername.Value = username;

                oraUpdate.Parameters.Add(OraParamPassHash);
                oraUpdate.Parameters.Add(OraParamUsername);

                oraUpdate.ExecuteNonQuery();

                return true;
            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
                return false;
            }
        }
        /// <summary>
        /// Retourne les stats des personnages du username en paramètre
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string[] ReturnStats(string username)
        {
            string[] Stats = null;

            OracleConnection conn = Connection.GetInstance().conn;
            string sqlSelect = "select Username from joueurs where JID = :username";
            string result = "";

            OracleCommand oraSelect = new OracleCommand(sqlSelect, conn);
            oraSelect.CommandType = CommandType.Text;

            OracleDataReader objRead = oraSelect.ExecuteReader();
            while (objRead.Read())
            {
                result = objRead.GetString(0);
            }
            objRead.Close();



            return Stats;
        }



    }
}
