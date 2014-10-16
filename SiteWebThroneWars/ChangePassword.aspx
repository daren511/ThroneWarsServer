<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SiteWebThroneWars.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <title>Throne Wars -Projet FinDec - Changer son mot de passe</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Entete">
            <img src="./Images/Logo_Grand.png" style="max-height: 100%; max-width: 100%;" />
        </div>
        <br />
        <br />
        <div class="Table">
            <ul id="menu-bar">
                <li class="active">
                    <li><a href="Page Principale.aspx">Accueil</a></li>
                    <li><a href="Inscription.aspx">Inscription</a></li>
                    <li><a href="Connexion.aspx">Connexion</a></li>
                    <li><a href="Stats2.aspx">Recherche Joueur</a></li>
                    <li><a href="Media.aspx">Média</a></li>
                </li>
            </ul>
        </div>

        <div class="Inscription">
            <label id="OldPass">Ancien mot de passe</label>
                <asp:TextBox id="apassword" TextMode="password" runat="server"/><br/>
  			<label id="NewPass">Nouveau mot de passe</label>
                <asp:TextBox id="npassword" TextMode="password" runat="server"/><br />
            <label id="cNewPass">Confirmer nouveau mot de passe</label>
                <asp:TextBox id="ncpassword" TextMode="password" runat="server"/><br />
            <asp:Button Text="Valider" onClick="ChangePassword_Click" runat="server"/>

        </div>
    </form>
</body>
</html>
