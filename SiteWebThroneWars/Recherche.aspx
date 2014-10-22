<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="SiteWebThroneWars.Stats2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                <li><a href="Connexion.aspx">Connexion</a></li>
                <li><a href="Recherche.aspx">Recherche Joueur</a></li>
                <li><a href="Media.aspx">Média</a></li>
            </li>
        </ul>
    </div>

    <form id="form1" runat="server">
        <div class="FormRecherche">
            <label>Nom d'utilisateur</label>
            <asp:TextBox ID="TB_UsernameSearch" TextMode="SingleLine" runat="server" /><br />
            <asp:Button Text="Rechercher" runat="server" OnClick="Rechercher_Click" />
        </div>
        <div class="Leaderboard">
            <asp:Table ID="table" runat="server" GridLines="Both">
                <asp:TableHeaderRow runat="server" ForeColor="Red">
                    <asp:TableHeaderCell>Position</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nom d'utilisateur</asp:TableHeaderCell> 
                    <asp:TableHeaderCell>Victoires</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Défaites</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div class="Stats">
            <asp:Label runat="server">Nom utilisateur</asp:Label>
            <input type="text" name="Username" disabled="disabled" />
            <asp:Label runat="server">XP</asp:Label>
            <input type="text" name="XP" disabled="disabled" /><br />
            <br />
            <br />
            <label>Personnage 1</label>
            <input type="text" name="Player1" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer1" disabled="disabled" /><br />
            <label>Personnage 2</label>
            <input type="text" name="Player2" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer2" disabled="disabled" /><br />
            <label>Personnage 3</label>
            <input type="text" name="Player3" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer3" disabled="disabled" /><br />
            <label>Personnage 4</label>
            <input type="text" name="Player4" disabled="disabled" />
            <label>Niveau</label>
            <input type="number" name="LVPlayer4" disabled="disabled" /><br />
        </div>


    </form>
</body>
</html>
