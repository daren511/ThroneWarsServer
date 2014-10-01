<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="SiteWebThroneWars.Stats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>Throne Wars -Projet FinDec - Stats</title>
    <link rel="stylesheet" type="text/css" href="FinDec.css"/>
</head>
<body>
    <div class="Entete">
        <img src="./Images/Logo_Grand.png" style="max-height:100%; max-width:100%;"/>
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
        <form action="sumbit" autocomplete="on">
            <label>Nom d'utilisateur</label>
            <input type="text" name="username" autocomplete="off"/><br>
            <input type="submit"/>
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
        <form>
            <label>Nom utilisateur</label>
            <input type="text" name="Username" disabled/>
            <label>XP</label>
            <input type="text" name="XP" disabled/></br></br></br>
        		<label>Personnage 1</label>
            <input type="text" name="Player1" disabled/>
            <label>Niveau</label>
            <input type="Number" name="LVPlayer1" disabled/><br>
            <label>Personnage 2</label>
            <input type="text" name="Player2" disabled/>
            <label>Niveau</label>
            <input type="Number" name="LVPlayer2" disabled/><br>
            <label>Personnage 3</label>
            <input type="text" name="Player3" disabled/>
            <label>Niveau</label>
            <input type="Number" name="LVPlayer3" disabled/><br>
            <label>Personnage 4</label>
            <input type="text" name="Player4" disabled/>
            <label>Niveau</label>
            <input type="Number" name="LVPlayer4" disabled/><br>
        </form>
    </div>
</body>
</html>
