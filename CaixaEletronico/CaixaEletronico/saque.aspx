<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saque.aspx.cs" Inherits="CaixaEletronico.saque" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Caixa Eletrônico - Saque</title>
</head>
<body>
    <form id="formSaque" runat="server">
        <div>
            <asp:Label ID="lblNotasDisponiveis" runat="server" ForeColor="red" Text="* Notas disponíveis de R$ 100,00, R$ 50,00, R$ 20,00 e R$ 10,00"></asp:Label>
            <br /><br />

            <asp:Label ID="lblSaque" runat="server" Text="Digite o valor do saque:"></asp:Label>
            <br />
            <asp:TextBox ID="txtValorSaque" runat="server"></asp:TextBox>
            <asp:Button ID="btnSaque" runat="server" OnClick="BtnSaque_Click" Text="Saque" />
            <asp:Label ID="lblErro" ForeColor="Red" runat="server" Text=""></asp:Label>
            <br /><br />
            <asp:Button ID="btnContinuar" Visible="false" runat="server" OnClick="BtnContinuar_Click" Text="Continuar Saque" />
            <asp:Button ID="btnVoltar" Visible="false" runat="server" OnClick="BtnVoltar_Click" Text="Voltar" />
            <% 
                if (btnContinuar.Visible)
                {
                    Response.Write("<br /><br />");
                }
            %>            
            <asp:Label ID="lblResultado" ForeColor="DarkBlue" runat="server" Text=""></asp:Label>             
        </div>
    </form>
</body>
</html>
