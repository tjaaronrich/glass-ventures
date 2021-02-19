<h2>Hot Jobs</h2>
<asp:GridView showheader="false" ID="GridViewHotJobs" gridlines="none" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_HotJobs" DataKeyNames="jNum"
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

<p style="display: block; margin: 10px; margin-left:0px; padding: 0px; padding-bottom:10px; padding-top:10px; border-bottom: 1px solid #ddd;"><strong><%#Eval("Title")%></strong><br />#<%#Eval("jDescription")%><br /><%#Eval("PayRate")%></p>

    </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ODS_HotJobs" runat="server" SelectMethod="GeActiveJobsRand3" TypeName="DAL_JobOpportunities" DataObjectTypeName="PC_JobOpportunities" ></asp:ObjectDataSource>

<a href="job-seekers-hot-jobs-hiring-events.aspx" style="display: block; margin: 10px; margin-left:0px; padding: 0px; padding-bottom:10px; padding-top:10px; ">View all job listings</a>
<p>&nbsp;</p>