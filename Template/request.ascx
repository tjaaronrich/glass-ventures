<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.Odbc" %>
<%@ import namespace="System.Data.SqlClient" %>
<%@ import Namespace="System" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Net.Mail" %>
<%@ import Namespace="System.IO" %>

<!-- Email Form -->
<script runat="server">
Sub submit_Click(sender As Object, e As EventArgs)

Dim mail As New MailMessage()

mail.From = New MailAddress("DONOTREPLY@mkweber.com")
'mail.To.Add("info@SwissWineFestival.org")
'mail.To.Add("kelliemitchum@knology.net")
mail.To.Add("mike@mkweber.com")
mail.To.Add("aaron@aaronrich.com")
'mail.To.Add("info@bicpc.org")
'mail.BCC.Add("aaron@aaronrich.com")

mail.Subject = "Site Feedback: MK Weber"
mail.IsBodyHtml = True
Mail.Body = "<strong>Name: </strong>" & fName.text & " " & lName.text & "<br>" & _
"<strong>Email: </strong>" & emailAddress.text & "<br>" &  _
"<strong>Phone: </strong>" & phone.text & "<br>" &  _
"<strong>Comments: </strong>" & comments.Text
 
Dim smtp As New SmtpClient("relay-hosting.secureserver.net")

Try
smtp.Credentials = New NetworkCredential("DONOTREPLY@mkweber.com", "000215")
smtp.Send(mail)
Response.Redirect("Thanks.aspx")
Catch ehttp As System.Web.HttpException 
Response.Redirect("Error.aspx")
End Try

End Sub 
</script>

<h3>Contact MK Weber</h3>
                  <p>&nbsp;</p>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            
                                            <tr>
                                              <td width="210" valign="top"><font size="2">
                                              <asp:textbox ID="fName" placeholder="First name" runat="server" Width="100%" style="font-size:11pt; padding:8px; outline:none; border-left:5px solid #ef4941;" required></asp:textbox>
                                              </font></td>
                                              <td width="10"></td>
                                              <td width="210"><font size="2">
                                                <asp:TextBox ID="lName" placeholder="Last Name" runat="server" Width="100%" style="font-size:11pt; padding:8px;"></asp:TextBox>
                                              </font></td>
                                            </tr>
                                            
                                            <tr>
                                              <td colspan="3" height="10px"></td>
                                            </tr>
                                            
                                            <tr>
                                              <td valign="top"><font size="2">
                                              <asp:textbox ID="emailAddress" placeholder="Email" runat="server" Width="100%" style="font-size:11pt; padding:8px;outline:none; border-left:5px solid #ef4941;" required></asp:textbox>
                                              </font></td> 
                                              <td width="10"></td>
                                        <td width="210" valign="top"><font size="2">
                                                <asp:textbox ID="phone" placeholder="Phone Number" runat="server" Width="100%" style="font-size:11pt; padding:8px;"></asp:textbox>
                                              </font></td>
                                            </tr>
                                            <tr>
                                              <td colspan="3" height="10px"></td>
                                            </tr>
                                            <tr>
                                              <td colspan="3" height="10px"><div id="comment_form">
                                                <asp:TextBox ID="comments" placeholder="Message" runat="server" TextMode="MultiLine" Height="75px" Width="100%" Font-Name="Arial" style="outline:none; border-left:5px solid #ef4941; padding:8px;" required></asp:TextBox>
                                              </div> </td>
                                            </tr>
                                            <tr>
                                              <td colspan="3"><p><font size="2">
                                              <div style="float:left">
                                                <p>&nbsp;</p>
                                                <p><img src="Graphics/required.png"></p>
                                              </div>
                                              <div align="right" style="float:right;">
                                                 <p>&nbsp;</p> 
                                                   <asp:ImageButton ID="submit" OnClick="submit_Click" onmouseover="this.src='Graphics/Btn-Submit-01-Hover.jpg'" onmouseout="this.src='Graphics/Btn-Submit-01.jpg'" ImageUrl="../Graphics/Btn-Submit-01.jpg" Runat="server" />      
                                                                                                                                             
</p> 
                                              </div>                                         
                                              <div align="right">
                                              <%--<div style="margin-right:0px; margin-top:80px;" class="g-recaptcha" data-sitekey="6Lc8fhQTAAAAAFPDdt-PxFMjkiofg2Wd9sL0yc-d"></div>
                                              </div>--%>
                                               </p>
                                                <p><font size="2">
                                                 <asp:requiredfieldvalidator ID="RFV11" runat="server" ControlToValidate="emailAddress" ErrorMessage="Email is required" Font-Name="Arial" Font-Size="8"> </asp:requiredfieldvalidator>
                                                  &nbsp;
                                                  <asp:regularexpressionvalidator ID="revEmail" runat="server" ErrorMessage="Invalid email" ControlToValidate="emailAddress" ValidationExpression="\S+@\S+\.\S{2,3}" Font-Name="Arial" Font-Size="8"></asp:regularexpressionvalidator>
                                                  
                                                </font></p></td>
                                            </tr>
              </table>