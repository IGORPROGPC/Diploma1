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
using Excel = Microsoft.Office.Interop.Excel;

namespace TestingApp
{
    public partial class Psycholog : Form
    {
        int zn1, zn2, zn3, zn4, zn5, zn6, zn7, zn8, zn9, zn10;
        string Zn1, Zn2, Zn3, Zn4, Zn5, Zn6, Zn7, Zn8, Zn9, Zn10;
        string n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;

        private void bResNos_Click(object sender, EventArgs e)
        {
            string OtchNz = "select Nosology.Nosology as [Наименование нозологии], " +
                "COUNT(Student.IDStudent) as [Кол - во], " +
                "AVG(Testing2.Res1) as [МП], A" +
                "VG(Testing2.Res2) as [МУ], " +
                "AVG(Testing2.Res3) as [ВП], " +
                "AVG(Testing2.Res4) as [ВУ], " +
                "AVG(Testing2.Res5) as [ВЭ], " +
                "AVG(Testing2.Res6) as [МЭИ], " +
                "AVG(Testing2.Res7) as [ВЭИ], " +
                "AVG(Testing2.Res8) as [ПЭ], " +
                "AVG(Testing2.Res9) as [УЭ], " +
                "AVG(Testing2.Res10) as [ОЭИ] " +
" From Nosology, Student, Testing2 " +
" Where Student.IDStudent = Testing2.IDStudent and Nosology.IDNosology=Student.IDNosology and Testing2.TestingDate >=" + "'" + dateTimePicker9.Value + "'" +
               " and Testing2.TestingDate <=" + "'" + dateTimePicker10.Value + "'" +
" Group by Nosology.Nosology ";
            SqlDataAdapter A = new SqlDataAdapter(OtchNz, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dataGridView5.DataSource = ds.Tables[0].DefaultView;
        }

        private void bResGr_Click(object sender, EventArgs e)
        {
            string OtchGR = "select Gruppa.Naimenovanie as [Наименование группы], " +
                "COUNT(Student.IDStudent) as [Кол - во], " +
                "AVG(Testing2.Res1) as [МП], A" +
                "VG(Testing2.Res2) as [МУ], " +
                "AVG(Testing2.Res3) as [ВП], " +
                "AVG(Testing2.Res4) as [ВУ], " +
                "AVG(Testing2.Res5) as [ВЭ], " +
                "AVG(Testing2.Res6) as [МЭИ], " +
                "AVG(Testing2.Res7) as [ВЭИ], " +
                "AVG(Testing2.Res8) as [ПЭ], " +
                "AVG(Testing2.Res9) as [УЭ], " +
                "AVG(Testing2.Res10) as [ОЭИ] "+
" From Gruppa, Student, Testing2 "+
" Where Student.IDStudent = Testing2.IDStudent and Gruppa.IDGruppa = Student.IDGruppa and Testing2.TestingDate >=" + "'" + dateTimePicker11.Value + "'" +
               " and Testing2.TestingDate <=" + "'" + dateTimePicker12.Value + "'"+
" Group by Gruppa.Naimenovanie ";
            SqlDataAdapter A = new SqlDataAdapter(OtchGR, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dataGridView6.DataSource = ds.Tables[0].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string d1 = dateTimePicker3.Value.Day.ToString() + "." + dateTimePicker3.Value.Month.ToString() + "." +
                 dateTimePicker3.Value.Year.ToString();
            string d2 = dateTimePicker13.Value.Hour.ToString() + "." + dateTimePicker13.Value.Minute.ToString() + "." +
                 dateTimePicker13.Value.Second.ToString();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelCells;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Статистика тестирования испытуемого " + cbStaStud.Text + " дата тестирования " + d1 + " время " + d2;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                ExcelApp.Cells[2, i + 1] = dataGridView1.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                }
            }
            int istr = dataGridView1.Rows.Count + 1;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[2], ExcelWorkSheet.Columns[3]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[1], ExcelWorkSheet.Columns[3]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Cells[2, 1], ExcelWorkSheet.Cells[istr, 3]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string d3 = dateTimePicker4.Value.Day.ToString() + "." + dateTimePicker4.Value.Month.ToString() + "." +
                dateTimePicker4.Value.Year.ToString();
            string d4 = dateTimePicker5.Value.Day.ToString() + "." + dateTimePicker5.Value.Month.ToString() + "." +
                 dateTimePicker5.Value.Year.ToString();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelCells;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Отчет о тестировании студентов группы " + cbTestGr.Text + " за период с " + d3 + " по " + d4;
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                ExcelApp.Cells[2, i + 1] = dataGridView2.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 3, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();

                }
            }
            int istr = dataGridView2.Rows.Count + 1;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[2], ExcelWorkSheet.Columns[6]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[1], ExcelWorkSheet.Columns[6]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Cells[2, 1], ExcelWorkSheet.Cells[istr, 6]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string d5 = dateTimePicker6.Value.Day.ToString() + "." + dateTimePicker6.Value.Month.ToString() + "." +
                dateTimePicker6.Value.Year.ToString();
            string d6 = dateTimePicker7.Value.Day.ToString() + "." + dateTimePicker7.Value.Month.ToString() + "." +
                 dateTimePicker7.Value.Year.ToString();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelCells;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Отчет о тестировании испытуемых нозологии " + cbTestNos.Text + " за период с " + d5 + " по " + d6;
            for (int i = 0; i < dataGridView3.ColumnCount; i++)
            {
                ExcelApp.Cells[2, i + 1] = dataGridView3.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 3, j + 1] = dataGridView3.Rows[i].Cells[j].Value.ToString();

                }
            }
            int istr = dataGridView3.Rows.Count + 1;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[2], ExcelWorkSheet.Columns[6]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[1], ExcelWorkSheet.Columns[6]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Cells[2, 1], ExcelWorkSheet.Cells[istr, 6]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string d7 = dateTimePicker8.Value.Day.ToString() + "." + dateTimePicker8.Value.Month.ToString() + "." +
                dateTimePicker8.Value.Year.ToString();


            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelCells;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Результаты тестирования испытуемого " +cbResStud.Text+ " дата тестирования " + d7;
            for (int i = 0; i < dataGridView4.ColumnCount; i++)
            {
                ExcelApp.Cells[2, i + 1] = dataGridView4.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 3, j + 1] = dataGridView4.Rows[i].Cells[j].Value.ToString();

                }
            }
            int istr = dataGridView4.Rows.Count + 1;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[2], ExcelWorkSheet.Columns[3]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[1], ExcelWorkSheet.Columns[3]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Cells[2, 1], ExcelWorkSheet.Cells[istr, 3]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string d8 = dateTimePicker9.Value.Day.ToString() + "." + dateTimePicker9.Value.Month.ToString() + "." +
                dateTimePicker9.Value.Year.ToString();
            string d9 = dateTimePicker10.Value.Day.ToString() + "." + dateTimePicker10.Value.Month.ToString() + "." +
                 dateTimePicker10.Value.Year.ToString();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelCells;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Сводный отчет о результатах тестирования по нозологии за период С " + d8 + " По " + d9;
            for (int i = 0; i < dataGridView5.ColumnCount; i++)
            {
                ExcelApp.Cells[2, i + 1] = dataGridView5.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView5.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 3, j + 1] = dataGridView5.Rows[i].Cells[j].Value.ToString();

                }
            }
            int istr = dataGridView5.Rows.Count + 1;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[2], ExcelWorkSheet.Columns[12]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[1], ExcelWorkSheet.Columns[12]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Cells[2, 1], ExcelWorkSheet.Cells[istr, 12]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string d10 = dateTimePicker11.Value.Day.ToString() + "." + dateTimePicker11.Value.Month.ToString() + "." +
                dateTimePicker11.Value.Year.ToString();
            string d11 = dateTimePicker12.Value.Day.ToString() + "." + dateTimePicker12.Value.Month.ToString() + "." +
                 dateTimePicker12.Value.Year.ToString();

            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            Microsoft.Office.Interop.Excel.Range ExcelCells;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Сводный отчет о результатах тестирования по группе за период С " + d10 + " По " + d11;
            for (int i = 0; i < dataGridView6.ColumnCount; i++)
            {
                ExcelApp.Cells[2, i + 1] = dataGridView6.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView6.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 3, j + 1] = dataGridView6.Rows[i].Cells[j].Value.ToString();

                }
            }
            int istr = dataGridView6.Rows.Count + 1;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[2], ExcelWorkSheet.Columns[12]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Columns[1], ExcelWorkSheet.Columns[12]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = ExcelApp.Range[ExcelWorkSheet.Cells[2, 1], ExcelWorkSheet.Cells[istr, 12]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        public Psycholog()
        {
            InitializeComponent();
            connect();
            conn(Testing, CS, dgv1);
        }
        string CS = "";
        private string Student = "SELECT IDStudent AS ID, FullName AS [Полное имя] FROM Student";
        private string Gruppa = "SELECT IDGruppa AS ID, Naimenovanie AS Наименование FROM Gruppa";
        private string Nosology = "SELECT IDNosology AS ID, Nosology AS Нозология FROM Nosology";
        string Testing = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
        public void connect()
        {
            Login frm = new Login();
            CS = frm.ConnectionString;

        }

        private void Load_in_CB(string CS, string cmdT, ComboBox CB, string field1, string field2)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(cmdT, CS);
            DataSet ds = new DataSet();
            Adapter.Fill(ds, "Table");
            // привязка ComboBox к таблице БД
            CB.DataSource = ds.Tables["Table"];
            CB.DisplayMember = field1; //установка отображаемого в списке поля
            CB.ValueMember = field2; //установка ключевого поля

        }

        public void conn(string cmdT,string ConnectionString,DataGridView dgv)
        {
            SqlDataAdapter A = new SqlDataAdapter(cmdT, ConnectionString);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv.DataSource = ds.Tables[0].DefaultView;
        }
        private void Psycholog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Psycholog_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            Load_in_CB(CS, Nosology, CBNosologiya, "Нозология", "ID");
            Load_in_CB(CS, Student, cbResStud, "Полное имя", "ID");
            Load_in_CB(CS, Gruppa, cbTestGr, "Наименование", "ID");
            Load_in_CB(CS, Student, cbStaStud, "Полное имя", "ID");
            Load_in_CB(CS, Nosology, cbTestNos, "Нозология", "ID");

            dataGridView4.Columns.Add("Column0", "Шкала");
            dataGridView4.Columns.Add("Column1", "Балл");
            dataGridView4.Columns.Add("Column2", "Интерпретация");
            dataGridView4.Rows.Add("МП", "Row 1");
            dataGridView4.Rows.Add("МУ", "Row 2");
            dataGridView4.Rows.Add("ВП", "Row 3");
            dataGridView4.Rows.Add("ВУ", "Row 4");
            dataGridView4.Rows.Add("ВЭ", "Row 5");
            dataGridView4.Rows.Add("МЭИ", "Row 6");
            dataGridView4.Rows.Add("ВЭИ", "Row 7");
            dataGridView4.Rows.Add("ПЭ", "Row 8");
            dataGridView4.Rows.Add("УЭ", "Row 9");
            dataGridView4.Rows.Add("ОЭИ", "Row 10");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dgv1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // string IDTesting = dgv1[0,dgv1.CurrentRow.Index].Value.ToString();
           // Result frm = new Result();
           // frm.txtIDTesting.Text = IDTesting;
           // frm.ShowDialog();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string Zap = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
                SqlDataAdapter A = new SqlDataAdapter(Zap, CS);
                DataSet ds = new DataSet();
                A.Fill(ds, "Table");
                dgv1.DataSource = ds.Tables[0].DefaultView;
            }
            else
            {
                dgv1.SelectAll();
                dgv1.ClearSelection();
                dgv1.Columns.Clear();

            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string DatTest = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Where Testing2.TestingDate <='" + dateTimePicker2.Value + "' and Testing2.TestingDate >='" + dateTimePicker1.Value + "' " +
 "Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
            SqlDataAdapter A = new SqlDataAdapter(DatTest, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv1.DataSource = ds.Tables[0].DefaultView;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string DatTest = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Where Testing2.TestingDate <='" + dateTimePicker2.Value + "' and Testing2.TestingDate >='" + dateTimePicker1.Value + "' " +
 "Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
            SqlDataAdapter A = new SqlDataAdapter(DatTest, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv1.DataSource = ds.Tables[0].DefaultView;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string Obr = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Where Status = 'Обработан' " +
 "Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
            SqlDataAdapter A = new SqlDataAdapter(Obr, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv1.DataSource = ds.Tables[0].DefaultView;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string Neobr = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Where Status = 'не обработан' " +
 "Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
            SqlDataAdapter A = new SqlDataAdapter(Neobr, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv1.DataSource = ds.Tables[0].DefaultView;
        }

        private void txtTimeTestFinal_TextChanged(object sender, EventArgs e)
        {
            string SearchFIO = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], SUM(Res1+Res2) as [МЭИ], SUM(Res3+Res4+Res5) as [ВЭИ], SUM(Res1+Res3) as [ПЭ], SUM(Res2+Res4+Res5) as [УЭ], SUM(Res1+Res2+Res3+Res4+Res5) as [ОЭИ] " +
 " FROM(Student INNER JOIN Testing2 ON Student.IDStudent = Testing2.IDStudent) Where Student.FullName LIKE " + "'" + TFIOTest.Text + "%" + "' " +
 "Group By Testing2.IDTesting2, Testing2.TestingDate, Testing2.TestingTime, Student.FullName, Testing2.Status, Res1, Res2, Res3, Res4, Res5";
            SqlDataAdapter A = new SqlDataAdapter(SearchFIO, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv1.DataSource = ds.Tables[0].DefaultView;
        }

        
        private void bStat_Click(object sender, EventArgs e)
        {
            string StatStud = "Select Result2.NQuest as [№ вопроса], Result2.ReactionTime as [Время реакции], Result2.Answer as [Ответ] " + 
                "from Student, Testing2, Result2 " + 
                "Where Student.IDStudent=Testing2.IDStudent and Testing2.IDTesting2=Result2.IDTesting2 and Student.IDStudent=" + cbStaStud.SelectedValue + " and Testing2.TestingDate="+"'"+dateTimePicker3.Value+"'"+
                " and Testing2.TestingTime >"+"'"+dateTimePicker13.Value+"'"+"";
            SqlDataAdapter A = new SqlDataAdapter(StatStud, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void bOt_Click(object sender, EventArgs e)
        {
            string StatGrup = "Select Student.FullName as [Ф.И.О Студента], Testing2.TestingDate as [Дата тестирования], Testing2.TestingTime as [Время тестирования], " +
                "COUNT(Result2.NQuest) as [Общее количество ответов], " +
                "CAST(DATEADD(ms, AVG(CAST(DateDiff(ms, '00:00:00', ISNULL(Result2.ReactionTime, '00:00:00')) as bigint)), '00:00:00') as time) as [Среднее время реакции],  SUM(iif(Result2.ReactionTime < '00:00:01', 1, 0)) as [Кл-во недостоверных ответов] " +
                "from Student, Testing2, Result2, Gruppa " + 
                " Where GRuppa.IDGruppa=Student.IDGruppa and Student.IDStudent=Testing2.IDStudent and Testing2.IDTesting2=Result2.IDTesting2 and Gruppa.IDGruppa=" + cbTestGr.SelectedValue + " and Testing2.TestingDate >=" + "'" + dateTimePicker4.Value + "'" +
                " and Testing2.TestingDate <=" + "'" + dateTimePicker5.Value + "'" + " GROUP BY Student.FullName, Testing2.TestingDate, Testing2.TestingTime";
            SqlDataAdapter A = new SqlDataAdapter(StatGrup, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string SearchNos = "SELECT Testing2.IDTesting2 AS [№], Testing2.TestingDate AS Дата, Testing2.TestingTime AS Время, Student.FullName AS [ФИО тестируемого], Testing2.Status AS Статус, Res1 as [МП], Res2 as [МУ], Res3 as [ВП], Res4 as [ВУ], Res5 as [ВЭ], Res6 as [МЭИ], Res7 as [ВЭИ], Res8 as [ПЭ], Res9 as [УЭ], Res10 as [ОЭИ] " +
 " FROM Student, Nosology, Testing2 where Student.IDStudent = Testing2.IDStudent and Student.IDNosology=Nosology.IDNosology and Student.IDNosology=" + CBNosologiya.SelectedValue;
            SqlDataAdapter A = new SqlDataAdapter(SearchNos, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dgv1.DataSource = ds.Tables[0].DefaultView;
        }

        private void bOtNos_Click(object sender, EventArgs e)
        {
            string StatNos = "Select Student.FullName as [Ф.И.О Студента], Testing2.TestingDate as [Дата тестирования], Testing2.TestingTime as [Время тестирования], " +
               "COUNT(Result2.NQuest) as [Общее количество ответов], " +
               "CAST(DATEADD(ms, AVG(CAST(DateDiff(ms, '00:00:00', ISNULL(Result2.ReactionTime, '00:00:00')) as bigint)), '00:00:00') as time) as [Среднее время реакции],  SUM(iif(Result2.ReactionTime < '00:00:01', 1, 0)) as [Кл-во недостоверных ответов] " +
               "from Student, Testing2, Result2, Nosology " +
               " Where Nosology.IDNosology=Student.IDNosology and Student.IDStudent=Testing2.IDStudent and Testing2.IDTesting2=Result2.IDTesting2 and Student.IDNosology=" + cbTestNos.SelectedValue + " and Testing2.TestingDate >=" + "'" + dateTimePicker6.Value + "'" +
               " and Testing2.TestingDate <=" + "'" + dateTimePicker7.Value + "'" + " GROUP BY Student.FullName, Testing2.TestingDate, Testing2.TestingTime";
            SqlDataAdapter A = new SqlDataAdapter(StatNos, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            dataGridView3.DataSource = ds.Tables[0].DefaultView;
        }

        private void bRes_Click(object sender, EventArgs e)
        {
            string ResStud = "Select Res1, Res2, Res3, Res4, Res5, Res6, Res7, Res8, Res9, Res10 " +
                "from Student, Testing2 " +
                "Where Student.IDStudent=Testing2.IDStudent and Student.IDStudent=" + cbResStud.SelectedValue + " and Testing2.TestingDate=" + "'" + dateTimePicker8.Value + "'"+"";
            SqlDataAdapter A = new SqlDataAdapter(ResStud, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");

            n1 = ds.Tables[0].Rows[0][0].ToString();
            n2 = ds.Tables[0].Rows[0][1].ToString();
            n3 = ds.Tables[0].Rows[0][2].ToString();
            n4 = ds.Tables[0].Rows[0][3].ToString();
            n5 = ds.Tables[0].Rows[0][4].ToString();
            n6 = ds.Tables[0].Rows[0][5].ToString();
            n7 = ds.Tables[0].Rows[0][6].ToString();
            n8 = ds.Tables[0].Rows[0][7].ToString();
            n9 = ds.Tables[0].Rows[0][8].ToString();
            n10 = ds.Tables[0].Rows[0][9].ToString();

            int zn1 = Int32.Parse(n1);
            int zn2 = Int32.Parse(n2);
            int zn3 = Int32.Parse(n3);
            int zn4 = Int32.Parse(n4);
            int zn5 = Int32.Parse(n5);
            int zn6 = Int32.Parse(n6);
            int zn7 = Int32.Parse(n7);
            int zn8 = Int32.Parse(n8);
            int zn9 = Int32.Parse(n9);
            int zn10 = Int32.Parse(n10);

            if (zn1>=0 && zn1 <= 19)
            {
                Zn1 = "Очень низкое значение";
            }
            else if (zn1 >=20 && zn1 <=22)
            {
                Zn1 = "Низкое значение";
            }
            else if (zn1 >=23 && zn1 <=26)
            {
                Zn1 = "Среднее значение";
            }
            else if (zn1 >=27 && zn1<=30)
            {
                Zn1 = "Высокое значение";
            }
            else
            {
                Zn1 = "Очень высокое значение";
            }

            if (zn2 >= 0 && zn2 <= 14)
            {
                Zn2 = "Очень низкое значение";
            }
            else if (zn2 >= 15 && zn2 <= 17)
            {
                Zn2 = "Низкое значение";
            }
            else if (zn2 >= 18 && zn2 <= 21)
            {
                Zn2 = "Среднее значение";
            }
            else if (zn2 >= 22 && zn2 <= 24)
            {
                Zn2 = "Высокое значение";
            }
            else
            {
                Zn2 = "Очень высокое значение";
            }

            if (zn3 >= 0 && zn3 <= 13)
            {
                Zn3 = "Очень низкое значение";
            }
            else if (zn3 >= 14 && zn3 <= 16)
            {
                Zn3 = "Низкое значение";
            }
            else if (zn3 >= 17 && zn3 <= 21)
            {
                Zn3 = "Среднее значение";
            }
            else if (zn3 >= 22 && zn3 <= 25)
            {
                Zn3 = "Высокое значение";
            }
            else
            {
                Zn3 = "Очень высокое значение";
            }

            if (zn4 >= 0 && zn4 <= 9)
            {
                Zn4 = "Очень низкое значение";
            }
            else if (zn4 >= 10 && zn4 <= 12)
            {
                Zn4 = "Низкое значение";
            }
            else if (zn4 >= 13 && zn4 <= 15)
            {
                Zn4 = "Среднее значение";
            }
            else if (zn4 >= 16 && zn4 <= 17)
            {
                Zn4 = "Высокое значение";
            }
            else
            {
                Zn4 = "Очень высокое значение";
            }

            if (zn5 >= 0 && zn5 <= 6)
            {
                Zn5 = "Очень низкое значение";
            }
            else if (zn5 >= 7 && zn5 <= 9)
            {
                Zn5 = "Низкое значение";
            }
            else if (zn5 >= 10 && zn5 <= 12)
            {
                Zn5 = "Среднее значение";
            }
            else if (zn5 >= 13 && zn5 <= 15)
            {
                Zn5 = "Высокое значение";
            }
            else
            {
                Zn5 = "Очень высокое значение";
            }

            if (zn6 >= 0 && zn6 <= 34)
            {
                Zn6 = "Очень низкое значение";
            }
            else if (zn6 >= 35 && zn6 <= 39)
            {
                Zn6 = "Низкое значение";
            }
            else if (zn6 >= 40 && zn6 <= 46)
            {
                Zn6 = "Среднее значение";
            }
            else if (zn6 >= 47 && zn6 <= 52)
            {
                Zn6 = "Высокое значение";
            }
            else
            {
                Zn6 = "Очень высокое значение";
            }

            if (zn7 >= 0 && zn7 <= 33)
            {
                Zn7 = "Очень низкое значение";
            }
            else if (zn7 >= 34 && zn7 <= 38)
            {
                Zn7 = "Низкое значение";
            }
            else if (zn7 >= 39 && zn7 <= 47)
            {
                Zn7 = "Среднее значение";
            }
            else if (zn7 >= 48 && zn7 <= 54)
            {
                Zn7 = "Высокое значение";
            }
            else
            {
                Zn7 = "Очень высокое значение";
            }

            if (zn8 >= 0 && zn8 <= 34)
            {
                Zn8 = "Очень низкое значение";
            }
            else if (zn8 >= 35 && zn8 <= 39)
            {
                Zn8 = "Низкое значение";
            }
            else if (zn8 >= 40 && zn8 <= 47)
            {
                Zn8 = "Среднее значение";
            }
            else if (zn8 >= 48 && zn8 <= 53)
            {
                Zn8 = "Высокое значение";
            }
            else
            {
                Zn8 = "Очень высокое значение";
            }

            if (zn9 >= 0 && zn9 <= 33)
            {
                Zn9 = "Очень низкое значение";
            }
            else if (zn9 >= 34 && zn9 <= 39)
            {
                Zn9 = "Низкое значение";
            }
            else if (zn9 >= 40 && zn9 <= 47)
            {
                Zn9 = "Среднее значение";
            }
            else if (zn9 >= 48 && zn9 <= 53)
            {
                Zn9 = "Высокое значение";
            }
            else
            {
                Zn9 = "Очень высокое значение";
            }

            if (zn10 >= 0 && zn10 <= 71)
            {
                Zn10 = "Очень низкое значение";
            }
            else if (zn10 >= 72 && zn10 <= 78)
            {
                Zn10 = "Низкое значение";
            }
            else if (zn10 >= 79 && zn10 <= 92)
            {
                Zn10 = "Среднее значение";
            }
            else if (zn10 >= 93 && zn10 <= 104)
            {
                Zn10 = "Высокое значение";
            }
            else
            {
                Zn10 = "Очень высокое значение";
            }

            dataGridView4[1, 0].Value = ds.Tables[0].Rows[0][0].ToString();
            dataGridView4[1, 1].Value = ds.Tables[0].Rows[0][1].ToString();
            dataGridView4[1, 2].Value = ds.Tables[0].Rows[0][2].ToString();
            dataGridView4[1, 3].Value = ds.Tables[0].Rows[0][3].ToString();
            dataGridView4[1, 4].Value = ds.Tables[0].Rows[0][4].ToString();
            dataGridView4[1, 5].Value = ds.Tables[0].Rows[0][5].ToString();
            dataGridView4[1, 6].Value = ds.Tables[0].Rows[0][6].ToString();
            dataGridView4[1, 7].Value = ds.Tables[0].Rows[0][7].ToString();
            dataGridView4[1, 8].Value = ds.Tables[0].Rows[0][8].ToString();
            dataGridView4[1, 9].Value = ds.Tables[0].Rows[0][9].ToString();

            dataGridView4[2, 0].Value = Zn1;
            dataGridView4[2, 1].Value = Zn2;
            dataGridView4[2, 2].Value = Zn3;
            dataGridView4[2, 3].Value = Zn4;
            dataGridView4[2, 4].Value = Zn5;
            dataGridView4[2, 5].Value = Zn6;
            dataGridView4[2, 6].Value = Zn7;
            dataGridView4[2, 7].Value = Zn8;
            dataGridView4[2, 8].Value = Zn9;
            dataGridView4[2, 9].Value = Zn10;

        }
    }
}
