using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stampanti_Xml_Passepartout
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            txtServer.Text = System.Configuration.ConfigurationManager.AppSettings["Server"];
            txtDatabase.Text = System.Configuration.ConfigurationManager.AppSettings["Database"];
            txtUsername.Text = System.Configuration.ConfigurationManager.AppSettings["Username"];
            txtPassword.Text = System.Configuration.ConfigurationManager.AppSettings["Password"];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationManager.AppSettings["Server"] = txtServer.Text;
            System.Configuration.ConfigurationManager.AppSettings["Database"] = txtDatabase.Text;
            System.Configuration.ConfigurationManager.AppSettings["Username"] = txtUsername.Text;
            System.Configuration.ConfigurationManager.AppSettings["Password"] = txtPassword.Text;
            /*System.Configuration.ConfigurationManager.ConnectionStrings["Bluetech"]. =
                String.Format(@"Data Source={0};Initial Catalog={1};User Id={2};Password={3};MultipleActiveResultSets=False"
                , txtServer
                , txtDatabase
                , txtUsername
                , txtPassword);*/
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Server"].Value = txtServer.Text;
            config.AppSettings.Settings["Database"].Value = txtDatabase.Text;
            config.AppSettings.Settings["Username"].Value = txtUsername.Text;
            config.AppSettings.Settings["Password"].Value  = txtPassword.Text;
            config.ConnectionStrings.ConnectionStrings["Bluetech"].ConnectionString = String.Format(@"Data Source={0};Initial Catalog={1};User Id={2};Password={3};MultipleActiveResultSets=False"
                , txtServer.Text
                , txtDatabase.Text
                , txtUsername.Text
                , txtPassword.Text);
             config.Save();
            System.Configuration.ConfigurationManager.RefreshSection("AppSettings");
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            this.Close();
        }
    }
}
