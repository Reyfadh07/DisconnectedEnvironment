using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DisconnectedEnvironment
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataRow dr;
        String code;
        public Form1()
        {
            InitializeComponent();
            //TODO: This line of code loads data into the 'hrDataSet.empdetails' table.
            //You can move, or remove it, as needed.
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            // This line of code loads data into the
            // hRDataSet.empdetails table. this would appear in
            // Form1_Load event
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtaddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartement.Enabled = false;
            cbDesignation.Items.Add("MANAGER");
            cbDesignation.Items.Add("AUTHOR");
            cbDesignation.Items.Add("Designer");
            cbDepartement.Items.Add("MARKETING");
            cbDepartement.Items.Add("FINANCE");
            cbDepartement.Items.Add("IDD");
            cmdSave.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRDataSet.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
            txtName.Enabled = true;
            txtaddress.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            cbDesignation.Enabled = true;
            cbDepartement.Enabled = true;
            txtName.Text = "";
            txtaddress.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            cbDesignation.Text = "";
            cbDepartement.Text = "";
            int ctr, len;
            string codeval;
            dt = hRDataSet.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C" + ctr;
            }

            cmdAdd.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = hRDataSet.Tables["empdetails"];
            dr = dt.NewRow();
            dr[0] = txtCode.Text;
            dr[1] = txtName.Text;
            dr[2] = txtaddress.Text;
            dr[3] = txtState.Text;
            dr[4] = txtCountry.Text;
            dr[5] = cbDesignation.SelectedItem;
            dr[6] = cbDepartement.SelectedItem;
            dt.Rows.Add(dr);
            empdetailsTableAdapter.Update(hRDataSet);
            txtCode.Text = System.Convert.ToString(dr[0]);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtaddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartement.Enabled = false;
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtCode.Text;
            dr = hRDataSet.Tables["empdetails"].Rows.Find(code);
            dr.Delete();
            empdetailsTableAdapter.Update(hRDataSet);
        }
    }
}
