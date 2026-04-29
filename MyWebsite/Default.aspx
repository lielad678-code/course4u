<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebsite.Default" Async="true" %>

<!DOCTYPE html>
<html lang="he" dir="rtl">
<head runat="server">
    <meta charset="utf-8" />
    <title>דף התחברות</title>

    <!-- Bootstrap RTL -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.rtl.min.css" rel="stylesheet" />

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@300;400;600&display=swap" rel="stylesheet">

    <style>
        body {
            font-family: 'Heebo', sans-serif;
            background: linear-gradient(135deg, #f0f2f5, #d9e4f5);
            height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .login-card {
            width: 100%;
            max-width: 400px;
            border-radius: 15px;
            box-shadow: 0 10px 25px rgba(0,0,0,0.1);
        }

        .login-title {
            font-weight: 600;
            text-align: center;
            margin-bottom: 10px;
        }

        .login-subtitle {
            text-align: center;
            color: #666;
            margin-bottom: 20px;
            line-height: 1.6;
        }

        .btn-login {
            border-radius: 10px;
            padding: 10px;
            font-weight: 500;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card login-card p-4">

            <h2 class="login-title">ברוכים הבאים</h2>

            <div class="login-subtitle">
                שלום לכולם!<br />
                ברוכים הבאים לדף האינטרנט הראשון שלי.<br />
                כדי להמשיך, אנא הזינו אימייל וסיסמה.
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">אימייל</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="הכנס אימייל" required="required"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtPassword" class="form-label">סיסמה</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="הכנס סיסמה" required="required"></asp:TextBox>
            </div>

            <div class="d-grid">
                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="התחברות" CssClass="btn btn-primary btn-login" />
            </div>

            <div>
                <asp:Label ID="lbErrorMessage" runat="server" ForeColor="red" ></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>