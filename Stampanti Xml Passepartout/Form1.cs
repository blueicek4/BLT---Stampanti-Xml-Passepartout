using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Stampanti_Xml_Passepartout
{
    public partial class StampantiXml : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StampantiXml()
        {
            InitializeComponent();
        }

        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(selectAll.Checked)
            {
                gridStampanti.SelectAll();
            }
            else
            {
                gridStampanti.ClearSelection();
            }
        }

        public static DataTable SqlSelect(string query, object[] pars, string connectionName = null)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.SaveAs(exeConfigPath);
                //config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                log.DebugFormat("File Config caricato da file di Setup");

                if (String.IsNullOrEmpty(connectionName))
                {
                    connectionName = config.ConnectionStrings.ConnectionStrings["Bluetech"].Name;
                }
                //cmd1.SelectCommand.CommandTimeout = 300;
                SqlConnection con = new SqlConnection(config.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString);

                DataTable sqlquery = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd1.SelectCommand = cmd;
                if (pars != null)
                {
                    int i = 0;

                    foreach (object par in pars)
                    {
                        SqlParameter gp = new SqlParameter("@param" + i.ToString(), par);
                        cmd.Parameters.Add(gp);

                        i++;
                    }
                }
                //cmd1.SelectCommand.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlTimeout"]);

                cmd1.Fill(sqlquery);

                sqlquery.TableName = "SqlQuery";

                return sqlquery;
            }
            catch (Exception e)
            {
                log.ErrorFormat(@"{0} - Eccezione! - Riga: {1}\nStringa: {2}\nParametri: {3}\nConnessione: {4}\nErrore: {5}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.ToString().Substring(e.ToString().LastIndexOf(" ") + 1), query, pars.ToList().ToString(), connectionName, e.Message);
                return new DataTable();
            }

        }

        public static Int32 SqlUpdate(string query, object[] pars, string connectionName = null)
        {
            int res = 0;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.SaveAs(exeConfigPath);
                //config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                log.DebugFormat("File Config caricato da file di Setup");

                if (String.IsNullOrEmpty(connectionName))
                {
                    connectionName = config.ConnectionStrings.ConnectionStrings["Bluetech"].Name;
                }
                //cmd1.SelectCommand.CommandTimeout = 300;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                if (pars != null)
                {
                    int i = 0;

                    foreach (object par in pars)
                    {
                        SqlParameter gp = new SqlParameter("@param" + i.ToString(), par);
                        cmd.Parameters.Add(gp);

                        i++;
                    }
                }

                res = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                log.ErrorFormat("{0} - Aggiornamento Dati - Eccezione - Riga: {1} - Errore: {2}\nQuery: {3}\nParametri: {4}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.ToString().Substring(e.ToString().LastIndexOf(" ") + 1), e.Message, query, String.Join(" - ", (pars ?? new object[] { }).ToList().Select(p => p.ToString()).ToArray()));
                res = -1;
            }
            return res;
        }

        public static Int32 SqlInsert(string query, object[] pars, string connectionName = null)
        {
            int res = 0;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.SaveAs(exeConfigPath);
                //config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                log.DebugFormat("File Config caricato da file di Setup");

                if (String.IsNullOrEmpty(connectionName))
                {
                    connectionName = config.ConnectionStrings.ConnectionStrings["Bluetech"].Name;
                }
                //cmd1.SelectCommand.CommandTimeout = 300;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                if (pars != null)
                {
                    int i = 0;

                    foreach (object par in pars)
                    {
                        SqlParameter gp = new SqlParameter("@param" + i.ToString(), par);
                        cmd.Parameters.Add(gp);

                        i++;
                    }
                }

                res = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                log.ErrorFormat("{0} - Aggiornamento Dati - Eccezione - Riga: {1} - Errore: {2}\nQuery: {3}\nParametri: {4}", System.Reflection.MethodBase.GetCurrentMethod().Name, e.ToString().Substring(e.ToString().LastIndexOf(" ") + 1), e.Message, query, String.Join(" - ", (pars ?? new object[] { }).ToList().Select(p => p.ToString()).ToArray()));
                res = -1;
            }
            return res;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string textSql = @"SELECT 
                                  nome as Nome
                                  , isAttiva as Attiva
                                  ,CASE WHEN tipoStampante = 0 THEN 'GRAFICA' ELSE CASE WHEN tipoStampante = 1 THEN 'FISCALE' ELSE CASE WHEN  tipoStampante = 3 THEN 'TESTUALE' ELSE 'ALTRO' END END END AS Tipo
                                  --, layoutTestuale
                                  , nomeLayoutTestuale as NomeFile
                                  , dataUltimaModifica as UltimaModifica
                              FROM Stampante";
            var stampanti= SqlSelect(textSql, null);
            gridStampanti.DataSource = stampanti;
            gridStampanti.Update();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog() ;
            txtOpenFile.Text = openFileDialog1.FileName;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] xmlFile = GetFile(txtOpenFile.Text);
                string nuovoNome = System.IO.Path.GetFileName(txtOpenFile.Text);
                var selection = gridStampanti.SelectedRows;
                int r = 0;
                foreach (DataGridViewRow s in selection)
                {
                    if (s.Cells["Tipo"].Value.ToString() == "TESTUALE")
                    {
                        String nome = s.Cells["Nome"].Value.ToString();

                        SqlUpdate("UPDATE Stampante SET nomeLayoutTestuale = @param0, layoutTestuale = @param1, dataUltimaModifica = GETDATE() where nome = @param2", new object[] { nuovoNome, xmlFile, nome });
                        r++;
                    }
                }
                Button2_Click(null, null);
                MessageBox.Show(String.Format("Aggiornate {0} Stampanti", r),"", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static byte[] GetFile(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] xmlFile = GetFile(txtOpenFile.Text);
                string nuovoNome = System.IO.Path.GetFileName(txtOpenFile.Text);
                var selection = gridStampanti.Rows;
                int r = 0;
                foreach (DataGridViewRow s in selection)
                {
                    if (s.Cells["Tipo"].Value.ToString() == "TESTUALE" && s.Cells["NomeFile"].Value.ToString() == nuovoNome)
                    {
                        String nome = s.Cells["Nome"].Value.ToString();

                        SqlUpdate("UPDATE Stampante SET nomeLayoutTestuale = @param0, layoutTestuale = @param1, dataUltimaModifica = GETDATE() where nome = @param2", new object[] { nuovoNome, xmlFile, nome });
                        r++;
                    }
                }
                Button2_Click(null, null);
                MessageBox.Show(String.Format("Aggiornate {0} Stampanti", r), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
