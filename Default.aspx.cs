using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DatabaseQuery
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigurationManager.AppSettings["databaseconnectionpath"]);
                ListItemCollection items = new ListItemCollection();
                XmlNode idNodes = doc.SelectSingleNode("database-connections");
                foreach (XmlNode node1 in idNodes.ChildNodes)
                    items.Add(new ListItem(node1.Attributes["name"].InnerText, node1.InnerText.ToString()));


                ddlDataBaseConenctions.DataSource = items;
                ddlDataBaseConenctions.DataValueField = "Value";
                ddlDataBaseConenctions.DataTextField = "Text";
                ddlDataBaseConenctions.DataBind();
            }


        }

        protected void btnExecute_ServerClick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.ForeColor = Color.Black;
            gvResults.DataSource = null;
            gvResults.DataBind();
            var con = new SqlConnection(ddlDataBaseConenctions.SelectedValue);
            var cmd = new SqlCommand(txtQuery.InnerText, con);

            if(string.IsNullOrEmpty(txtQuery.InnerText))
            {
                lblError.Text = "Please enter a valid query";
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                return;
            }
            try
            {
                con.Open();
                SqlDataReader result = cmd.ExecuteReader();
                if (result.HasRows)
                {

                    DataTable dt = new DataTable();
                    dt.Load(result);

                    gvResults.DataSource = dt;
                    gvResults.DataBind();
                    result.Close();

                }
                else if (result.RecordsAffected > 0)
                {
                    lblError.Text = $"updated { result.RecordsAffected} rows";
                    lblError.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
            finally
            {

                // result.Close();
                con.Close();
            }


        }
    }
}