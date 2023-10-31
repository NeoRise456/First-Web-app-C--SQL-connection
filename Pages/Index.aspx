<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="intento4.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    UPC database test
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de estudiantes</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="clo aling-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-sucsess form-control" Text="Create" OnClick="BtnCreate_Click"/>
                </div>
                <div class="BUSCADOR">
                     <asp:TextBox runat="server" CssClass="buscador-control" ID="tbuscador"></asp:TextBox>
                    <asp:Button runat="server" ID="BtnSearch" CssClass="btn btn-sucsess form-control" Text="Search" OnClick="BtnSearch_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container search">
            <div class="table small">
                <asp:GridView runat="server" ID="gvsearch" class="table table-botderless table-hover">

                </asp:GridView>
            </div>
        </div>

        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-botderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones de Administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" CssClass="btn form-control btn-info" ID="BtnRead" OnClick="BtnRead_Click"/>
                                 <asp:Button runat="server" Text="Update" CssClass="btn form-control btn-info" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                 <asp:Button runat="server" Text="Delete" CssClass="btn form-control btn-info" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>


                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
