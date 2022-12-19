<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BE.U1_W1_D1.Azienda_Edile.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fuid">

      
            <div class="text-center " runat="server" id="lblMessaggio" visible="false">
                <asp:Label ID="lblErrore" runat="server" Text="" visible="false"></asp:Label>
            </div>
     

        <asp:GridView ID="GridViewDipendenti" runat="server"
            CssClass="table table-bordered"
            ItemType="BE.U1_W1_D1.Azienda_Edile.Classi.Dipendente"
            AutoGenerateColums="true">
            <Columns>

                <asp:TemplateField HeaderText="ID Dipendente">
                    <ItemTemplate>
                        <p><%# Item.Id %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <p><%# Item.Nome %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cognome">
                    <ItemTemplate>
                        <p><%# Item.Cognome %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Mansione">
                    <ItemTemplate>
                        <p><%# Item.Mansione %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Stipendio Mensile">
                    <ItemTemplate>
                        <p><%# Item.StipendioMensile %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ultimo pagamento">
                    <ItemTemplate>
                        <p><%# Item.TipoStipendio %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Importo pagamento">
                    <ItemTemplate>
                        <p><%# Item.ImportoPagamento %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Importo ">
                    <ItemTemplate>
                        <p><%# Item.UltimoStipendio() %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SchedaCliente">
                    <ItemTemplate>
                        <div class="text-center">
                            <asp:LinkButton ID="SchedaDip" runat="server" PostBackUrl="SchedaDipendenti.aspx?Id= <%# Item.Id %> "><i class="bi bi-info-circle"></i></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
