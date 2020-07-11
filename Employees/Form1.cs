using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;


namespace Employees
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public void toDateFormat()
        {
            dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("Resources/Employees.txt");
            string[] values;
            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split(',');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }

                toDateFormat();
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d1;
            DateTime d2;


            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.Equals("NULL"))

                {
                    d1 = DateTime.Today;
                    this.dataGridView1.Rows[i].Cells[3].Value = DateTime.Today;
                }
                else

                    d1 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);

                d2 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);


            }
        }

        private void button3_Click(object sender, EventArgs e)

        {
            {
                DataTable dt = new DataTable("Employees");
                dt.Columns.Add("EmpID", typeof(int));
                dt.Columns["EmpID"].Caption = "EmpID";
                dt.Columns.Add("ProjectID", typeof(int));
                dt.Columns["ProjectID"].Caption = "ProjectID";
                dt.Columns.Add("DateFrom", typeof(DateTime));
                dt.Columns["DateFrom"].Caption = "DateFrom";
                dt.Columns.Add("DateTo", typeof(DateTime));
                dt.Columns["DateTo"].Caption = "DateTo";
                string[] columns = null;

                var lines = File.ReadAllLines("Resources/Employees.txt");

                if (lines.Count() > 0)
                {
                    columns = lines[0].Split(new char[] { ',' });

                    foreach (var column in columns)
                        dt.Columns.Add(column);
                }

                for (int i = 0; i < lines.Count(); i++)
                {
                    DataRow dr = dt.NewRow();
                    string[] values = lines[i].Split(new char[] { ',' });

                    for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                    {
                        if (values[j] == "NULL")
                        {
                            values[j] = DateTime.Today.ToString();
                        }
                        dr[j] = values[j];

                    }
                    dt.Rows.Add(dr);
                }
                dataGridView2.DataSource = dt;


                string firstProjectID = dataGridView2.Rows[0].Cells[1].Value.ToString();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() != firstProjectID)
                    {
                        dataGridView2.Rows[i].Selected = true;

                    }
                    else

                    { firstProjectID = dataGridView2.Rows[i].Cells[1].Value.ToString(); }
                    dataGridView2.Rows[0].Cells[0].Selected = false;
                   
                }
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.RemoveAt(row.Index);
                }
               

                    DateTime dateFromOne = new DateTime();
                                DateTime dateFromTwo = new DateTime();
                                DateTime dateToOne = new DateTime();
                                DateTime dateToTwo = new DateTime();
                                DateTime dateFrom = new DateTime();
                                DateTime dateTo = new DateTime();
                dateFromOne = DateTime.Parse(dataGridView2.Rows[0].Cells[2].Value.ToString());
                dateFromTwo = DateTime.Parse(dataGridView2.Rows[1].Cells[2].Value.ToString());
                dateToOne = DateTime.Parse(dataGridView2.Rows[0].Cells[3].Value.ToString());
                dateToTwo = DateTime.Parse(dataGridView2.Rows[1].Cells[3].Value.ToString());
                if (dateFromOne > dateFromTwo)
                                 {
                                     dateFrom = dateFromOne;
                                 }
                                 else { dateFrom = dateFromTwo;
                             }
                             if (dateToOne > dateToTwo)
                             {
                                     dateTo = dateToTwo;
                             }
                             else { dateTo = dateToOne; }
                                 TimeSpan period = dateTo - dateFrom;
               
                textBox1.Text = period.ToString();

                            }
            }
        }
    }

       
   