using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Drawing;
using System.Activities.Expressions;
using System.Text.RegularExpressions;

namespace eadLab5
{
    public partial class ResetPass : System.Web.UI.Page
    {

        static string finalHash;
        static string Salt;
        byte[] Key;
        byte[] IV;
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EADPConnectionString2"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPasswordResetLinkValid())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password Reset link has expired or is invalid";
                }
            }
        }

        






        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string pwd = txtNewPassword.Text.ToString().Trim(); ;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];
            rng.GetBytes(saltByte);
            Salt = Convert.ToBase64String(saltByte);
            SHA512Managed hashing = new SHA512Managed();
            string pwdWithSalt = pwd + Salt;
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            finalHash = Convert.ToBase64String(hashWithSalt);
            RijndaelManaged cipher = new RijndaelManaged();
            cipher.GenerateKey();
            Key = cipher.Key;
            IV = cipher.IV;
            

            if (ChangeUserPassword())
            {
                lblMessage.Text = "Password is the work manmanman";
                Response.Redirect("ResetPass.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password Reset link has expired or is invalid";
            }

        }

        private bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
        {
            string CS = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(SPName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in SPParameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                con.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        private bool IsPasswordResetLinkValid()
        {
            List<SqlParameter> paramList = new List<SqlParameter>()
        {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        }
        };

            return ExecuteSP("spIsPasswordResetLinkValid", paramList);
        }



        private bool ChangeUserPassword()
        {

            List<SqlParameter> paramList = new List<SqlParameter>()
        {
            new SqlParameter()
            {
                ParameterName = "@GUID",
                Value = Request.QueryString["uid"]
            },
            new SqlParameter()
            {
                ParameterName = "@Password",
                Value = finalHash
            },
            new SqlParameter()
            {
                ParameterName = "@Salt",
                Value = Salt
            }
        };

            return ExecuteSP("spChangePassword1", paramList);
        }



        private int GetPasswordStrength(string password)
        {
            int Marks = 0;
            // here we will check password strength
            if (password.Length < 6)
            {
                // Very Week
                return 1;
            }
            else
            {
                Marks = 1;
            }
            if (Regex.IsMatch(password, "[a-z]"))
            {
                // 2    week
                Marks++;
            }
            if (Regex.IsMatch(password, "[A-Z]"))
            {
                // 3    medium
                Marks++;
            }
            if (Regex.IsMatch(password, "[0-9]"))
            {
                //4     strong
                Marks++;
            }
            if (Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
            {
                //5     very strong
                Marks++;
            }
            return Marks;

        }

        
    }
}