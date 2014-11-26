<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOBILEMagasin.aspx.cs" Inherits="SiteWebThroneWars.MOBILEMagasin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="FinDec_Mobile.css"/>
<link rel="stylesheet" type="text/css" href="/sweet-alert.css"/>
<link rel="shortcut icon" href="/Images/Icon.png" />
<script src="/sweet-alert.min.js"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="/Menu/jquery.mmenu.min.js" type="text/javascript"></script>
<link href="/Menu/jquery.mmenu.css" type="text/css" rel="stylesheet" />
    <title></title>
</head>
<body>
   <script type="text/javascript">
    $(document).ready(function () {
                $('#TB_Quantite').keyup(function () {
                    calculate();
                });
            });
            function calculate(e) {
                $('#TB_Total').val($('#TB_Quantite').val() * $('#TB_Prix').val());
            }
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Achat réussi !", type: "success", confirmButtonText: "Ok" });
                });
            }
            $(document).ready(function () {
                $("#my-menu").mmenu();
            });
            $("#my-button").click(function () {
                $("#my-menu").trigger("open.mm");
            });
            $(document).ready(function () {
                $("#my-menu").mmenu();
                $("#my-button").click(function () {
                    $("#my-menu").trigger("close.mm");
                });
            });
        </script>
    <form id="form1" runat="server">
    <nav id="my-menu">
            <ul>
                
                <li><a href="MOBILEdefault.aspx">Accueil</a></li>
                <li><a href="MOBILEInscription.aspx">Inscription</a></li>
                <li><a href="MOBILEConnexion.aspx">Connexion</a></li>
                <li><a href="MOBILERecherche.aspx">Classement</a></li>
                <li><a href="MOBILEMedia.aspx">Média</a></li>
                <li><a href="MOBILEMagasin.aspx">Magasin</a></li>
                <li><a href="#my-page">Close the menu</a></li>
            </ul>
        </nav>
        <div id="menu">
                <a href="#my-menu"><img src="./Images/menu.png" width="100" height="100" /></a>
            </div>
        <div class="Entete_Mobile">
            <img src="./Images/Logo_Grand.png" style="max-height: 80%; max-width: 80%;" />
            <br />
            
            <!-- A checker les dimensions ou plus grosse image -->
        </div>
        <br />
        <br />
     <div id="MagasinGV_Mobile">
            <asp:Label ID="usernameLB" runat="server">Nom d'utilisateur</asp:Label><br />
            <asp:TextBox ID="username" TextMode="SingleLine" runat="server" Enabled="false" style="width: 38%; font-size:30px;"/><br />
            <asp:Label ID="Label3" runat="server">Monnaie</asp:Label><br />
            <asp:TextBox ID="TB_Monnaie"  TextMode="SingleLine" runat="server" Enabled="false" style="width: 38%; font-size:30px;" /><br />

            <asp:GridView runat="server" ID="GV_Magasin" OnSelectedIndexChanged="GV_Magasin_SelectedIndexChanged" OnRowDataBound="GV_Magasin_RowDataBound">
            </asp:GridView>

        </div>
        <div id="MagasinInfo_Mobile">

            <asp:Label ID="Label1" runat="server">Quantité</asp:Label><br />
            <asp:TextBox ID="TB_Quantite" TextMode="SingleLine" runat="server" style="width: 38%; font-size:30px;"/><br />
            <asp:RangeValidator ID="RangeValidator1" Type="Integer" MinimumValue="1"
                MaximumValue="99" ControlToValidate="TB_Quantite" runat="server"
                ErrorMessage="La quanité doit être entre 1 et 99"></asp:RangeValidator><br />

            <asp:Label ID="Label5" runat="server">Prix</asp:Label><br />
            <asp:TextBox ID="TB_Prix" TextMode="Number" runat="server" Enabled="false" style="width: 38%; font-size:30px;"/><br />

            <asp:Label ID="Label2" runat="server">Total</asp:Label><br />
            <asp:TextBox ID="TB_Total" name="Total" TextMode="Number" runat="server" Enabled="false" style="width: 38%; font-size:30px;"/><br />
            <br />
            <asp:Button Text="Acheter" ID="BTN_Acheter" OnClick="Acheter_Click" runat="server"  style="width:31%; font-size:35px;"/><br />
        </div>
    </form>
</body>
</html>
