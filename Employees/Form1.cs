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

            DateTime endDate = DateTime.MinValue;
            DateTime begDate = DateTime.MinValue;
            int rowCount = dataGridView1.RowCount;
            int colCount = dataGridView1.ColumnCount;
            List<Employees> Empl = new List<Employees>();
            for (int i = 0; i < rowCount-1; i++)
            { if (dataGridView1.Rows[i].Cells[1].Value == dataGridView1.Rows[i + 1].Cells[1].Value)
                {
                   for(int j = 0; j < colCount; j++)
                    {
                  Empl.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                            toDateFormat();

            

                   
                    DateTime endDateOne = Convert.ToDateTime(dataGridView2.Rows[i].Cells[3].Value);
                    DateTime endDateTwo = Convert.ToDateTime(dataGridView2.Rows[1 + i].Cells[3].Value);
                    DateTime begDateOne = Convert.ToDateTime(dataGridView2.Rows[i].Cells[2].Value);
                    DateTime begDateTwo = Convert.ToDateTime(dataGridView2.Rows[1 + i].Cells[2].Value);
                    if (dataGridView2.Rows[i].Cells[1].Value == dataGridView1.Rows[i + 1].Cells[1].Value)
                    {

                        if (endDateOne > endDateTwo)
                        {
                            endDate = endDateTwo;
                        }
                        else
                        { endDate = endDateOne; }
                        if (begDateOne > begDateTwo)
                        {
                            begDate = begDateOne;
                        }
                        else
                        { begDate = begDateTwo; }
                    }
                TimeSpan period = endDate - begDate;
                textBox1.Text = endDate.ToString();
                   
           
                            
                        }
                    }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }

            }

       
   