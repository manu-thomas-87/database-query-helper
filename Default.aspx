<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DatabaseQuery._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Database Query Helper</h1>
        <p class="lead">This app can be used only for the Dev/QA purpose </p>
    </div>
    <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
    <div class="dropdown">
        <label>Choose Database :</label>
        <asp:DropDownList class="btn btn-secondary dropdown-toggle" ID="ddlDataBaseConenctions" runat="server"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label>Query</label>
        <textarea rows="4" class="form-control" runat="server" id="txtQuery"></textarea>
    </div>
    <button runat="server" class="btn btn-dark" id="btnExecute" onserverclick="btnExecute_ServerClick">Execute</button>
    <asp:GridView runat="server" ID="gvResults" PageSize="25"></asp:GridView>
</asp:Content>
