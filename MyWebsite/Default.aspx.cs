using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            // יצירת אובייקט עם הנתונים שהמשתמש הזין בתיבות הטקסט
            Teacher teacher = new Teacher
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            // פנייה לשירות הרשת (API)
            await GenericApiClient.PostAsync<Teacher, Teacher>("api/Teacher/Login", teacher).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // במקרה של שגיאה - נציג הודעה למשתמש
                    var errorMessage = task.Exception?.GetBaseException().Message ?? "שגיאה בחיבור לשרת.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{errorMessage}');", true);
                }
                else
                {
                    // שמירת הנתונים ב-Session ומעבר דף

                    if (task.Result != null)
                    {
                        Session.Add("teacher", task.Result);
                        Response.Redirect("TeacherHomePage.aspx");
                    }
                    else
                        lbErrorMessage.Text = "שם המשתמש או הסיסמא אינם נכונים";
                }
            });

        }
    }
}