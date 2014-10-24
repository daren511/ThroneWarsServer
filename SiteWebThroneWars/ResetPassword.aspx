﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="SiteWebThroneWars.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                <li><a href="Recherche.aspx">Recherche Joueur</a></li>
                <li><a href="Media.aspx">Média</a></li>
            </li>
        </ul>
    </div>
    <div class="FormRecherche">
            <label>Nouveau mot de passe</label><br />
            <asp:TextBox ID="TB_NewPassord" TextMode="SingleLine" runat="server" /><br />
            <label>Confirmer mot de passe</label><br />
            <asp:TextBox ID="TB_ConfirmPass" TextMode="SingleLine" runat="server" /><br />
            <asp:Button Text="Valider" runat="server" OnClick="ResetPass_Click" />
        </div>
    </form>
</body>
</html>
