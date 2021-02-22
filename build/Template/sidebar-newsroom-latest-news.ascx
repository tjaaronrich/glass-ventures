<h2>Latest News</h2>
<asp:GridView showheader="false" ID="GridViewRecentNews" gridlines="none" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_RecentNews" DataKeyNames="nNum"
            width=100%
            CellPadding="0" 
            CellSpacing="0"
            Border="0"
            ForeColor="#FFFFFF"  
            Font-Names="Arial" 
            Font-Size="11px">
  <%--<Headerstyle BackColor="#897b23" ForeColor="#ffffff" Font-Name="Arial" Font-Size="11 px" HorizontalAlign="left" Font-Bold="True" ></Headerstyle>
    <AlternatingRowStyle BackColor="#e5e5e5" ForeColor="#000000" Font-Name="Arial" Font-Size="11 px" HorizontalAlign="left"></AlternatingRowStyle>
    <PAGERSTYLE backcolor="#cccccc" forecolor="Black" Font-Size="10 px" Font-Names="arial" horizontalalign="Left"></PAGERSTYLE>--%>
  <Columns>
    <asp:TemplateField HeaderText="Jobs">  
    <ItemTemplate>

<p style="display: block; margin: 10px; margin-left:0px; padding: 0px; padding-bottom:10px; padding-top:10px; border-bottom: 1px solid #ddd; font-size:18px;"><a href="Newsroom-News-Detail.aspx?nNum=<%#Eval("nNum")%>" class="Green"><%#Eval("Title")%></a><br /><%#Eval("ItemDate")%><br />1:00pm</p>

    </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ODS_RecentNews" runat="server" SelectMethod="GetActiveNews" TypeName="DAL_NewsFTB" DataObjectTypeName="PC_NewsFTB" ></asp:ObjectDataSource>

<a href="Newsroom-News.aspx" style="display: block; margin: 10px; margin-left:0px; padding: 0px; padding-bottom:10px; padding-top:10px;">View all news</a>
<p>&nbsp;</p>