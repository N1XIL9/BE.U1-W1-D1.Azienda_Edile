<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AggiungiImpiegato.aspx.cs" Inherits="BE.U1_W1_D1.Azienda_Edile.AggiungiImpiegato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="container">
            <div class="text-center " runat="server" id="lblMessaggio" visible="false">
                <asp:Label ID="lblInserito" runat="server" Text="" visible="false"></asp:Label>
                <asp:Label ID="lblErrore" runat="server" Text="" visible="false"></asp:Label>
            </div>
        </div>

        <h2> Aggiungi Impiegato</h2>
        <div class="mb-3">
            <label class="form-label">Nome</label>
            <asp:TextBox ID="TextNome" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Cognome</label>
            <asp:TextBox ID="TextCognome" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Indirizzo</label>
            <asp:TextBox ID="TextIndirizzo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

         <div class="mb-3">
            <label class="form-label">Codice Fiscale</label>
            <asp:TextBox ID="TextCf" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
             <label class="form-label"> Coniugato </label>
             <div class=" form-control">
                <asp:CheckBox ID="CkbSi" runat="server" Text="Si"/>
                <asp:CheckBox ID="CkbNo" runat="server" Text="No"/>
             </div>
         </div>
        
        <div class="mb-3">
            <label class="form-label"> Figli a carico</label>
            <asp:TextBox ID="TextFigli" runat="server" TextMode="Number" Min="0" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Mansione</label>
            <asp:TextBox ID="TextMansione" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Stipendio Mensile</label>
            <asp:TextBox ID="TextStipendio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="AggiungiImp" runat="server" Text="Aggiungi Impiegato" Onclick="AggiungiImp_Click" CssClass="btn-outline-primary" />

    </div>
</asp:Content>
