﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class AddEvaluation : Form
    {
        SqlConnection conn = DatabaseConnection.getInstance().getConnection();
        public AddEvaluation()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Nametxt.Text = " ";
            TotalmarksTxt.Text = " ";
            totalweightagetxt.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
            
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //conn.Open();
            Evaluation C1 = new Evaluation();
            C1.set_Name(Nametxt.Text);
            C1.set_Total_Marks(TotalmarksTxt.Text);
            C1.set_Total_Weitage(totalweightagetxt.Text);
            if ((C1.Get_Name() != null) && (C1.Get_Total_Marks() != 0) && (C1.Get_Total_Weitage()!= 0))
            {
                try
                {
                    String cmd1 = String.Format("INSERT INTO Evaluation(Name, TotalMarks, TotalWeightage ) values('{0}', '{1}', '{2}')", C1.Get_Name(), C1.Get_Total_Marks(), C1.Get_Total_Weitage());
                    int rows = DatabaseConnection.getInstance().exectuteQuery(cmd1);
                    if (rows != 0)
                    {
                        MessageBox.Show("Data Recorded Succesfully");
                        Cancel_Click(sender, e);
                    }
                    

                    if (MessageBox.Show("Do you Want to Add Another Student's Data?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                        Eval_Dashboards t = new Eval_Dashboards();
                        t.Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
            else
            {

                MessageBox.Show("Invalid Data!." +
                    "Please Enter Valid Data");
                conn.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddEvaluation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
