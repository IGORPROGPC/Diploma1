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

namespace TestingApp
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
            connect();
        }
        string CS = "";
string ResAll = "SELECT Student.IDStudent as [№ Студента], Student.FullName as [Полное имя], Gruppa.Naimenovanie as Группа, Student.Position as Должность, Student.BirstDate as [Дата рождения],Student.Age as [Возраст], Nosology.Nosology as [Нозология], Testing2.IDTesting2 as [№ тестирования], Testing2.TestingDate as [Дата тестирования], Testing2.TestingTime as [Время тестирования],"+
       " Testing2.Status as [Статус тестирования],Result2.NQuest as [№ Задания], Result2.ReactionTime as [Время реакции], Result2.Answer as [Ответ]"+
        " FROM Nosology, Student, Gruppa, Testing2, Result2 Where Nosology.IDNosology = Student.IDNosology and Student.IDStudent = Testing2.IDStudent and Testing2.IDTesting2 = Result2.IDTesting2 and Gruppa.IDGruppa= Student.IDGruppa";
        public void connect()
        {
            Login frm = new Login();
            CS = frm.ConnectionString;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            string sql = ResAll + " and Testing2.IDTesting2=" + txtIDTesting.Text;
            SqlDataAdapter A = new SqlDataAdapter(sql, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
           dataGridView1.DataSource = ds.Tables[0].DefaultView;
            txtDateTesting.Text = ds.Tables[0].Rows[0][8].ToString();
           txtFullName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBirstDate.Text= ds.Tables[0].Rows[0][4].ToString();
            txtAge.Text= ds.Tables[0].Rows[0][5].ToString();
            txtPos.Text= ds.Tables[0].Rows[0][3].ToString();
            txtGr.Text= ds.Tables[0].Rows[0][2].ToString();
            txtNosology.Text= ds.Tables[0].Rows[0][6].ToString();
            txtTime.Text = ds.Tables[0].Rows[0][9].ToString();
            txtStatus.Text = ds.Tables[0].Rows[0][10].ToString();
        }
    }
}
