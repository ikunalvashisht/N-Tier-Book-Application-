<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookdetails.aspx.cs" Inherits="Employee_N_Tier.bookdetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


               <fieldset style="width:470px">
    <legend>3 tier example to insert and bind book details</legend>
    <table>
        <tr><td>Book Name * : </td><td>
            <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvBookName" runat="server"
                ErrorMessage="Book Name can't be left blank" ControlToValidate="txtBookName"
                Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td></tr>
        <tr><td>Author * : </td><td>
        <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvAuthor" runat="server"
                ErrorMessage="Author Name can't be left blank" ControlToValidate="txtAuthor"
                Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td></tr>
        <tr><td>Publisher * : </td><td>
        <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvPublisher" runat="server"
                ErrorMessage="Publisher Name can't be left blank" ControlToValidate="txtPublisher"
                Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td></tr>
        <tr><td>Price * : </td><td>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvPrice" runat="server"
                ErrorMessage="Price can't be left blank" ControlToValidate="txtPrice"
                Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rgePrice" runat="server"
                ControlToValidate="txtPrice" Display="Dynamic"
                ErrorMessage="Enter Numeric only" ForeColor="Red" SetFocusOnError="True"
                ValidationExpression="^\d*[0-9](|.\d*[0-9]|)*$"></asp:RegularExpressionValidator>
        </td></tr>
        <tr><td></td><td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                onclick="btnSubmit_Click" /></td></tr>
                <tr><td colspan="2"><asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td></tr>
    </table>   
        <br />   
    <asp:GridView ID="grdBookDetails" runat="server" DataKeyNames="BookId"
        AutoGenerateColumns="False"
        onpageindexchanging="grdBookDetails_PageIndexChanging"
        onrowcancelingedit="grdBookDetails_RowCancelingEdit"
        onrowdeleting="grdBookDetails_RowDeleting"
        onrowediting="grdBookDetails_RowEditing"
        onrowupdating="grdBookDetails_RowUpdating" AllowPaging="True" PageSize="5"
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
    <asp:TemplateField HeaderText="Book Name">
    <ItemTemplate>
        <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtBookNameEdit" runat="server" Text='<%#Eval("BookName")%>'></asp:TextBox></EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Author">
    <ItemTemplate>
        <asp:Label ID="lblAuthor" runat="server" Text='<%#Eval("Author")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtAuthorEdit" runat="server" Text='<%#Eval("Author")%>'></asp:TextBox>
    </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Publisher">
    <ItemTemplate>
        <asp:Label ID="lblPublisher" runat="server" Text='<%#Eval("Publisher")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtPublisherEdit" runat="server" Text='<%#Eval("Publisher")%>'></asp:TextBox>
     </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Price">
    <ItemTemplate>
        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtPriceEdit" runat="server" Text='<%#Eval("Price")%>'></asp:TextBox>
    </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.jpg" CommandName="Edit" CausesValidation="false"/>
    </ItemTemplate>
    <EditItemTemplate>
    <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false"></asp:LinkButton>
    <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
    </EditItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.jpg" CommandName="Delete" CausesValidation="false" onclientclick="return confirm('Are you sure you want to delete?')" />
    </ItemTemplate>
    <EditItemTemplate>       
    </EditItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
    </asp:TemplateField>
    </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </fieldset>


        </div>
    </form>
</body>
</html>
