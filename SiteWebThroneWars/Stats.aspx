<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="SiteWebThroneWars.Stats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Throne Wars -Projet FinDec - Stats</title>
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
</head>
<body runat="server">
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
                <li><a href="Stats.aspx">Statistiques</a></li>
                <li><a href="Media.aspx">Média</a></li>
            </li>
        </ul>
    </div>

    <div class="FormRecherche">
        <form method="post" action="Stats.aspx" autocomplete="on">
            <label>Nom d'utilisateur</label>
            <asp:Textbox ID="TB_UsernameSearch" TextMode="SingleLine" runat="server"/><br />
            <asp:Button Text="Rechercher" OnClick="Rechercher_Click" runat="server"/>
        </form>
    </div>

    <div class="Leaderboard">
        <div class="LeaderboardTable">
            <table>
                <thead>
                    <tr>
                        <th># Position</th>
                        <th>Nom Utilisateur</th>
                        <th>XP</th>
                    </tr>
                </thead>
                <tbody>
                    <tr bgcolor="#FF0000">
                        <td>1</td>
                        <td>Hcfranck</td>
                        <td>1561861561</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Hcfranck</td>
                        <td>1561861561</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Hcfranck</td>
                        <td>1561861561</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Hcfranck</td>
                        <td>1561861561</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Hcfranck</td>
                        <td>1561861561</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>TheFallenGod</td>
                        <td>121545</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Gnouppie</td>
                        <td>69</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>



    <div class="Stats">
        <form method="post" action="Stats.aspx">
            <label>Nom utilisateur</label>
            <asp:Label ID="LB_UsernameStats" TextMode="SingleLine" runat="server" /><br />
            <label>XP</label>
            <asp:Label ID="LB_XPStats" TextMode="Number" runat="server" /><br/><br/><br/><br/>
        		<label>Personnage 1</label>
            <asp:Label ID="LB_Player1" TextMode="SingleLine" runat="server" />
            <label>Niveau</label>
            <asp:Label ID="LB_LVP1" TextMode="Number" runat="server" /><br/>
            <label>Personnage 2</label>
            <asp:Label ID="LB_Player2" TextMode="SingleLine" runat="server" />
            <label>Niveau</label>
            <asp:Label ID="LB_LVP2" TextMode="Number" runat="server" />
            <label>Personnage 3</label>
            <asp:Label ID="LB_Player3" TextMode="SingleLine" runat="server" />
            <label>Niveau</label>
            <asp:Label ID="LB_LVP3" TextMode="Number" runat="server" />
            <label>Personnage 4</label>
            <asp:Label ID="LB_Player4" TextMode="SingleLine" runat="server" />
            <label>Niveau</label>
            <asp:Label ID="LB_LVP4" TextMode="Number" runat="server" />
        </form>
    </div>
</body>
</html>
