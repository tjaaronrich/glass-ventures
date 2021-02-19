                        <p>&nbsp;</p>
                        <h6>Regional Economic Information</h6>
                        <p>&nbsp;</p>
                        
                        <asp:GridView showheader="false" ID="GridView5" gridlines="none" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Links05" DataKeyNames="linkNum"
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
                        <asp:TemplateField HeaderText="Links">  
                        <ItemTemplate>

                        <p><img src="Graphics/bullet-custom2.png" align="absmiddle" style="margin-top:5px; margin-bottom:5px"><a href=<%#Eval("URL")%> target=_blank class="Black" ><strong><%#Eval("linkName")%></strong></a></p>
                        </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_Links05" runat="server" SelectMethod="GetAllLinks05" TypeName="DAL_Links" DataObjectTypeName="PC_Links" ></asp:ObjectDataSource>
                          <p>&nbsp;</p>
                        <h6>State and National Data</h6>
                        <p>&nbsp;</p>
                        
                        <asp:GridView showheader="false" ID="GridView6" gridlines="none" AllowPaging="False" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Links06" DataKeyNames="linkNum"
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
                        <asp:TemplateField HeaderText="Links">  
                        <ItemTemplate>

                        <p><img src="Graphics/bullet-custom2.png" align="absmiddle" style="margin-top:5px; margin-bottom:5px"><a href=<%#Eval("URL")%> target=_blank class="Black" ><strong><%#Eval("linkName")%></strong></a></p>
                        </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODS_Links06" runat="server" SelectMethod="GetAllLinks06" TypeName="DAL_Links" DataObjectTypeName="PC_Links" ></asp:ObjectDataSource>
<p>&nbsp;</p>
                        <p>&nbsp;</p>
