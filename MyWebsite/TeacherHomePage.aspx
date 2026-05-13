<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherHomePage.aspx.cs" Inherits="MyWebsite.TeacherHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="teacher-info">
    <h2>ברוך הבא, <asp:Label ID="lblTeacherNameTitle" runat="server"></asp:Label>!</h2>
    
    <div class="info-row">
        <strong>שם מלא:</strong>
        <asp:Label ID="lblFullName" runat="server"></asp:Label>
    </div>
    <div class="info-row">
        <strong>שם משתמש:</strong>
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
    </div>
    <div class="info-row">
        <strong>דוא"ל:</strong>
        <asp:Label ID="lblEmail" runat="server"></asp:Label>
    </div>
    <div class="info-row">
        <strong>תאריך תחילת עבודה:</strong>
        <asp:Label ID="lblStartWorkDate" runat="server"></asp:Label>
    </div>
    <div class="students-section">
    <h2>רשימת התלמידים שלך</h2>
    <asp:GridView ID="gvStudents" runat="server" CssClass="grid-view" AutoGenerateColumns="true">
        <EmptyDataTemplate>
            לא נמצאו תלמידים במערכת.
        </EmptyDataTemplate>
    </asp:GridView>
</div>
</div>
    </form>



</body>
</html>
