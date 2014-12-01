<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Magasin.aspx.cs" Inherits="SiteWebThroneWars.Magasin" EnableEventValidation="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta charset="UTF-8" />
    <link rel="shortcut icon" href="/Images/Icon.png" />
    <link rel="stylesheet" type="text/css" href="FinDec.css" />
    <link rel="stylesheet" type="text/css" href="/sweet-alert.css" />
    <script src="/sweet-alert.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                $('#TB_Quantite').keyup(function () {
                    calculate();
                });
            });
            function calculate(e) {
                var Total = $('#TB_Total').val($('#TB_Quantite').val() * $('#TB_Prix').val());
            }
            function MessageBoxReussi() {
                $(document).ready(function () {
                    swal({ title: "Bravo! ", text: "Achat réussi !", type: "success", confirmButtonText: "Ok" });
                });
            }
            function MessageBoxErreur(textadaptatif) {
                $(document).ready(function () {
                    swal({ title: "Échec! ", text: textadaptatif, type: "error", confirmButtonText: "Ok" });
                });
            }
            function MessageBoxWarning(textadaptatif) {
                $(document).ready(function () {
                    swal({ title: "Attention! ", text: textadaptatif, type: "warning", confirmButtonText: "Ok" }, function () { window.location.assign("Connexion.aspx"); });
                });
            }
        </script>
        <div class="Entete">
            <img src="./Images/Logo_Grand.png" style="max-height: 100%; max-width: 100%;" />
            <!-- A checker les dimensions ou plus grosse image -->
        </div>
        <br />
        <br />
        <div class="Table">
            <ul id="menu-bar">
                <li class="active">
                    <li><a href="default.aspx">Accueil</a></li>
                    <li><a href="Inscription.aspx">Inscription</a></li>
                    <li><a href="Connexion.aspx">Connexion</a></li>
                    <li><a href="Recherche.aspx">Classement</a></li>
                    <li><a href="Media.aspx">Média</a></li>
                    <li><a href="Magasin.aspx">Magasin</a></li>
                </li>
            </ul>
        </div>
        <div id="MagasinGV">
            <asp:Label ID="usernameLB" runat="server">Nom d'utilisateur :</asp:Label>
            <asp:Label ID="User_Set" runat="server" Font-Bold="true"></asp:Label>
            <asp:Label ID="MoneyLB" runat="server" >Monnaie :</asp:Label>
            <asp:Label ID="Money_Set" runat="server" Font-Bold="true" ></asp:Label><br />
            <asp:Button Text="Items" ID="BTN_Items" OnClick="BTN_Items_Click" runat="server"  />
            <asp:Button Text="Potions" ID="BTN_Potions" OnClick="BTN_Potions_Click" runat="server"  /><br />

            <asp:GridView runat="server" ID="GV_Magasin" OnSelectedIndexChanged="GV_Magasin_SelectedIndexChanged" 
                OnRowDataBound="GV_Magasin_RowDataBound"   AllowPaging ="true" OnPageIndexChanging="GV_Magasin_PageIndexChanging" 
                PageSize = "25">
                <RowStyle HorizontalAlign="Center"/>
            </asp:GridView>
        </div>
        <div id="MagasinInfo">

            <asp:Label ID="Label1" runat="server">Quantité</asp:Label><br />
            <asp:TextBox ID="TB_Quantite" TextMode="SingleLine" runat="server" ClientIDMode="Static" /><br />
            <asp:RangeValidator ID="RangeValidator1" Type="Integer" MinimumValue="1"
                MaximumValue="99" ControlToValidate="TB_Quantite" runat="server"
                ErrorMessage="La quanité doit être entre 1 et 99"></asp:RangeValidator><br />

            <asp:Label ID="Label5" runat="server">Prix</asp:Label><br />
            <asp:TextBox ID="TB_Prix" TextMode="Number" runat="server" Enabled="false" ClientIDMode="Static"/><br />

            <asp:Label ID="Label2" runat="server">Total</asp:Label><br />
            <% TB_Total.Attributes.Add("readonly", "readonly"); %>
            <asp:TextBox ID="TB_Total" name="Total" runat="server" ClientIDMode="Static"/><br />
            <br />
          
            <asp:Button Text="Acheter" ID="BTN_Acheter" OnClick="Acheter_Click" runat="server"  /><br />
        </div>
    </form>
</body>
</html>
