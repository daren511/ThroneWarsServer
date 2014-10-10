<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stats2.aspx.cs" Inherits="SiteWebThroneWars.Stats2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Throne Wars -Projet FinDec - Stats</title>
    <link rel="stylesheet" type="text/css" href="FinDec.css" />

</head>
<body>
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
                <li><a href="Stats2.aspx">Statistiques</a></li>
                <li><a href="Media.aspx">Média</a></li>
            </li>
        </ul>
    </div>

    <form id="form1" runat="server">
    <div class="FormRecherche">
            <label>Nom d'utilisateur</label>
            <asp:Textbox ID="TB_UsernameSearch" TextMode="SingleLine" runat="server"/><br />
            <asp:Button Text="Rechercher" runat="server" OnClick="Unnamed1_Click"/>
    </div>
    <div class="Leaderboard">
        <asp:Table ID="table" runat="server"></asp:Table>
    
    </div>
    </form>
</body>
</html>
