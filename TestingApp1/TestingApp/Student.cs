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
    public partial class Student : Form
    {
        string[] Quest = new string[46];
        int sh1, sh2, sh3, sh4, sh5, sh6, sh7, sh8, sh9, sh10;
        string answer;
        int i, n;
        
        public Student()
        {
            InitializeComponent();
            connect();
        }

        string CS = "";
        string Result = "SELECT Result2.IDTesting2 AS [№тестирования], Testing2.TestingDate AS Дата, Result2.NQuest AS [№ вопроса], Result2.ReactionTime AS [Время реакции], Result2.Answer AS Ответ "+
       " FROM Result2 INNER JOIN "+
       " Testing2 ON Result2.IDTesting2 = Testing2.IDTesting2";

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer2.Enabled = false;
            timer3.Enabled = false;
            bStart.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtDatetest.Text = lblDate.Text;
            NowTime= DateTime.Now;
            txtTimeStartTest.Text = NowTime.ToLongTimeString();
            timer2.Enabled = true;

        }
        DateTime NowTime;
        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan TikTime;
            TikTime = DateTime.Now - NowTime;
            txtTimeTest.Text = TikTime.ToString("hh\\:mm\\:ss");
            timer2.Start();


        }
        public void connect()
        {
            Login frm = new Login();
            CS = frm.ConnectionString;

        }
        int IDTesting = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            sh1 = 0; sh2 = 0; sh3 = 0; sh4 = 0; sh5 = 0; sh6 = 0; sh7 = 0; sh8 = 0; sh9 = 0; sh10=0;
            //richTextBox2.Text = "Нажмите далее чтобы начать тестирование!";
            bStart.Enabled = false;
            NowTimeTest = DateTime.Now;
            timer3.Enabled = true;
            //Запись в БД
            string Testing = "INSERT INTO TESTING2 (IDStudent,TestingDate,TestingTime,Status) VALUES(" +
                lblID.Text + ", '" + txtDatetest.Text + "'," + "'" + DateTime.Now.ToLongTimeString() + "'" +
                "," + "'" + "не обработан" + "'" + ")";
            // MessageBox.Show(AddTesting);
            SqlConnection conn = new SqlConnection(CS);
            conn.Open();
            SqlCommand myCommand = new SqlCommand(Testing, conn);
            myCommand.CommandText = Testing;
            myCommand.ExecuteNonQuery();
            conn.Close();
            //возврат ID тестирования
            string max = "select MAX(IDTesting2) from Testing2";
            SqlDataAdapter A = new SqlDataAdapter(max, CS);
            DataSet ds = new DataSet();
            A.Fill(ds, "Table");
            IDTesting =int.Parse( ds.Tables[0].Rows[0][0].ToString());
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            i = 0;
            n = 1;
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;

            if (radioButton1.Checked == true)
            {
                if (i == 1 || i == 3 || i == 11 || i == 13 || i == 20 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh1 = sh1 + 3;
                }
                else if (i==38 || i==42 || i==46)
                {
                    sh1 = sh1 + 0;
                }
                else if (i==9 || i==15 || i==17 || i==24 || i==36)
                {
                    sh2 = sh2 + 3;
                }
                else if (i==2 || i==5 || i==30|| i==40|| i==44)
                {
                    sh2 = sh2 + 0;
                }
                else if (i==7 || i==14 || i==26)
                {
                    sh3 = sh3 + 3;
                }
                else if (i==8 || i==18 || i==22 || i==31 || i==35 || i==41 || i==45)
                {
                    sh3 = sh3 + 0;
                }
                else if (i==4 || i==25 || i==28 || i==37)
                {
                    sh4 = sh4 + 3;
                }
                else if (i==12 || i==33 || i==43)
                {
                    sh4 = sh4 + 0;
                }
                else if (i==19 || i==21 || i==23)
                {
                    sh5 = sh5 + 3;
                }
                else if (i==6 || i==10 || i==16 || i==39)
                {
                    sh5 = sh5 + 0;
                }
                else if (i==1 || i==3 || i==9 || i==11 || i==13 || i==15 || i==17 || i==20 || i==24 || i==27 || i==29 || i==32 || i==34 || i==36)
                {
                    sh6 = sh6 + 3;
                }
                else if (i==2 || i==5 || i==30 || i==38 || i==40 || i==42 || i==44 || i==46)
                {
                    sh6 = sh6 + 0;
                }
                else if (i==4 || i==7 || i==14 || i==19 || i==21 || i==23 || i==25 || i==26 || i==28 || i==37)
                {
                    sh7 = sh7 + 3;
                }
                else if (i==6 || i==8 || i==10 || i==12 || i==16 || i==18 || i==22 || i==31 || i==33 || i==39 || i==41 || i==43 || i==45)
                {
                    sh7 = sh7 + 0;
                }
                else if (i==1 || i==3 || i==7 || i==11 || i==13 || i==14 || i==20 || i==26 || i==27 || i==29|| i==32 || i==34)
                {
                    sh8 = sh8 + 3;
                }
                else if (i==8 || i==18 || i==22 || i==31 || i==35 || i==38 || i==41 || i==42 || i==45 || i==46)
                {
                    sh8 = sh8 + 0;
                }
                else if (i==4 || i==9 || i==15 || i==17 || i==19 || i==21 || i==23 || i==24 || i==25 || i==28 || i==36 || i==37)
                {
                    sh9 = sh9 + 3;
                }
                else if (i==2 || i==5 || i==6 || i==10 || i==12 || i==16 || i==30 || i==33 || i==39 || i==40 || i==43 || i==44)
                {
                    sh9 = sh9 + 0;
                }
                else if (i==1 || i==3 || i==4 || i==7 || i==9 || i==11 || i==13 || i==14 || i==15 || i==17 || i==19 || i==20 || i==21 || i==23 || i==24 || i==25 || i==26 || i==27 || i==28 || i==29 || i==32 || i==34 || i==36 || i==37)
                {
                    sh10 = sh10 + 3;
                }
                else if (i==2 || i==5 || i==6 || i==8 || i==10 || i==12 || i==16 || i==18 || i==22 || i==30 || i==31 || i==33 || i==35 || i==38 || i==39 || i==40 || i==41 || i==42 || i==43 || i==44 || i==45 || i==46)
                {
                    sh10 = sh10 + 0;
                }

                answer = "Совершенно согласен";

            }
            else if (radioButton2.Checked == true)
            {
                if (i == 1 || i == 3 || i == 11 || i == 13 || i == 20 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh1 = sh1 + 2;
                }
                else if (i == 38 || i == 42 || i == 46)
                {
                    sh1 = sh1 + 1;
                }
                else if (i == 9 || i == 15 || i == 17 || i == 24 || i == 36)
                {
                    sh2 = sh2 + 2;
                }
                else if (i == 2 || i == 5 || i == 30 || i == 40 || i == 44)
                {
                    sh2 = sh2 + 1;
                }
                else if (i == 7 || i == 14 || i == 26)
                {
                    sh3 = sh3 + 2;
                }
                else if (i == 8 || i == 18 || i == 22 || i == 31 || i == 35 || i == 41 || i == 45)
                {
                    sh3 = sh3 + 1;
                }
                else if (i == 4 || i == 25 || i == 28 || i == 37)
                {
                    sh4 = sh4 + 2;
                }
                else if (i == 12 || i == 33 || i == 43)
                {
                    sh4 = sh4 + 1;
                }
                else if (i == 19 || i == 21 || i == 23)
                {
                    sh5 = sh5 + 2;
                }
                else if (i == 6 || i == 10 || i == 16 || i == 39)
                {
                    sh5 = sh5 + 1;
                }
                else if (i == 1 || i == 3 || i == 9 || i == 11 || i == 13 || i == 15 || i == 17 || i == 20 || i == 24 || i == 27 || i == 29 || i == 32 || i == 34 || i == 36)
                {
                    sh6 = sh6 + 2;
                }
                else if (i == 2 || i == 5 || i == 30 || i == 38 || i == 40 || i == 42 || i == 44 || i == 46)
                {
                    sh6 = sh6 + 1;
                }
                else if (i == 4 || i == 7 || i == 14 || i == 19 || i == 21 || i == 23 || i == 25 || i == 26 || i == 28 || i == 37)
                {
                    sh7 = sh7 + 2;
                }
                else if (i == 6 || i == 8 || i == 10 || i == 12 || i == 16 || i == 18 || i == 22 || i == 31 || i == 33 || i == 39 || i == 41 || i == 43 || i == 45)
                {
                    sh7 = sh7 + 1;
                }
                else if (i == 1 || i == 3 || i == 7 || i == 11 || i == 13 || i == 14 || i == 20 || i == 26 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh8 = sh8 + 2;
                }
                else if (i == 8 || i == 18 || i == 22 || i == 31 || i == 35 || i == 38 || i == 41 || i == 42 || i == 45 || i == 46)
                {
                    sh8 = sh8 + 1;
                }
                else if (i == 4 || i == 9 || i == 15 || i == 17 || i == 19 || i == 21 || i == 23 || i == 24 || i == 25 || i == 28 || i == 36 || i == 37)
                {
                    sh9 = sh9 + 2;
                }
                else if (i == 2 || i == 5 || i == 6 || i == 10 || i == 12 || i == 16 || i == 30 || i == 33 || i == 39 || i == 40 || i == 43 || i == 44)
                {
                    sh9 = sh9 + 1;
                }
                else if (i == 1 || i == 3 || i == 4 || i == 7 || i == 9 || i == 11 || i == 13 || i == 14 || i == 15 || i == 17 || i == 19 || i == 20 || i == 21 || i == 23 || i == 24 || i == 25 || i == 26 || i == 27 || i == 28 || i == 29 || i == 32 || i == 34 || i == 36 || i == 37)
                {
                    sh10 = sh10 + 2;
                }
                else if (i == 2 || i == 5 || i == 6 || i == 8 || i == 10 || i == 12 || i == 16 || i == 18 || i == 22 || i == 30 || i == 31 || i == 33 || i == 35 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46)
                {
                    sh10 = sh10 + 1;
                }

                answer = "Скорее согласен";
            }
            else if (radioButton3.Checked == true)
            {
                if (i == 1 || i == 3 || i == 11 || i == 13 || i == 20 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh1 = sh1 + 1;
                }
                else if (i == 38 || i == 42 || i == 46)
                {
                    sh1 = sh1 + 2;
                }
                else if (i == 9 || i == 15 || i == 17 || i == 24 || i == 36)
                {
                    sh2 = sh2 + 1;
                }
                else if (i == 2 || i == 5 || i == 30 || i == 40 || i == 44)
                {
                    sh2 = sh2 + 2;
                }
                else if (i == 7 || i == 14 || i == 26)
                {
                    sh3 = sh3 + 1;
                }
                else if (i == 8 || i == 18 || i == 22 || i == 31 || i == 35 || i == 41 || i == 45)
                {
                    sh3 = sh3 + 2;
                }
                else if (i == 4 || i == 25 || i == 28 || i == 37)
                {
                    sh4 = sh4 + 1;
                }
                else if (i == 12 || i == 33 || i == 43)
                {
                    sh4 = sh4 + 2;
                }
                else if (i == 19 || i == 21 || i == 23)
                {
                    sh5 = sh5 + 1;
                }
                else if (i == 6 || i == 10 || i == 16 || i == 39)
                {
                    sh5 = sh5 + 2;
                }
                else if (i == 1 || i == 3 || i == 9 || i == 11 || i == 13 || i == 15 || i == 17 || i == 20 || i == 24 || i == 27 || i == 29 || i == 32 || i == 34 || i == 36)
                {
                    sh6 = sh6 + 1;
                }
                else if (i == 2 || i == 5 || i == 30 || i == 38 || i == 40 || i == 42 || i == 44 || i == 46)
                {
                    sh6 = sh6 + 2;
                }
                else if (i == 4 || i == 7 || i == 14 || i == 19 || i == 21 || i == 23 || i == 25 || i == 26 || i == 28 || i == 37)
                {
                    sh7 = sh7 + 1;
                }
                else if (i == 6 || i == 8 || i == 10 || i == 12 || i == 16 || i == 18 || i == 22 || i == 31 || i == 33 || i == 39 || i == 41 || i == 43 || i == 45)
                {
                    sh7 = sh7 + 2;
                }
                else if (i == 1 || i == 3 || i == 7 || i == 11 || i == 13 || i == 14 || i == 20 || i == 26 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh8 = sh8 + 1;
                }
                else if (i == 8 || i == 18 || i == 22 || i == 31 || i == 35 || i == 38 || i == 41 || i == 42 || i == 45 || i == 46)
                {
                    sh8 = sh8 + 2;
                }
                else if (i == 4 || i == 9 || i == 15 || i == 17 || i == 19 || i == 21 || i == 23 || i == 24 || i == 25 || i == 28 || i == 36 || i == 37)
                {
                    sh9 = sh9 + 1;
                }
                else if (i == 2 || i == 5 || i == 6 || i == 10 || i == 12 || i == 16 || i == 30 || i == 33 || i == 39 || i == 40 || i == 43 || i == 44)
                {
                    sh9 = sh9 + 2;
                }
                else if (i == 1 || i == 3 || i == 4 || i == 7 || i == 9 || i == 11 || i == 13 || i == 14 || i == 15 || i == 17 || i == 19 || i == 20 || i == 21 || i == 23 || i == 24 || i == 25 || i == 26 || i == 27 || i == 28 || i == 29 || i == 32 || i == 34 || i == 36 || i == 37)
                {
                    sh10 = sh10 + 1;
                }
                else if (i == 2 || i == 5 || i == 6 || i == 8 || i == 10 || i == 12 || i == 16 || i == 18 || i == 22 || i == 30 || i == 31 || i == 33 || i == 35 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46)
                {
                    sh10 = sh10 + 2;
                }

                answer = "Скорее не согласен";
            }
            else if (radioButton4.Checked == true)
            {
                if (i == 1 || i == 3 || i == 11 || i == 13 || i == 20 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh1 = sh1 + 0;
                }
                else if (i == 38 || i == 42 || i == 46)
                {
                    sh1 = sh1 + 3;
                }
                else if (i == 9 || i == 15 || i == 17 || i == 24 || i == 36)
                {
                    sh2 = sh2 + 0;
                }
                else if (i == 2 || i == 5 || i == 30 || i == 40 || i == 44)
                {
                    sh2 = sh2 + 3;
                }
                else if (i == 7 || i == 14 || i == 26)
                {
                    sh3 = sh3 + 0;
                }
                else if (i == 8 || i == 18 || i == 22 || i == 31 || i == 35 || i == 41 || i == 45)
                {
                    sh3 = sh3 + 3;
                }
                else if (i == 4 || i == 25 || i == 28 || i == 37)
                {
                    sh4 = sh4 + 0;
                }
                else if (i == 12 || i == 33 || i == 43)
                {
                    sh4 = sh4 + 3;
                }
                else if (i == 19 || i == 21 || i == 23)
                {
                    sh5 = sh5 + 0;
                }
                else if (i == 6 || i == 10 || i == 16 || i == 39)
                {
                    sh5 = sh5 + 3;
                }
                else if (i == 1 || i == 3 || i == 9 || i == 11 || i == 13 || i == 15 || i == 17 || i == 20 || i == 24 || i == 27 || i == 29 || i == 32 || i == 34 || i == 36)
                {
                    sh6 = sh6 + 0;
                }
                else if (i == 2 || i == 5 || i == 30 || i == 38 || i == 40 || i == 42 || i == 44 || i == 46)
                {
                    sh6 = sh6 + 3;
                }
                else if (i == 4 || i == 7 || i == 14 || i == 19 || i == 21 || i == 23 || i == 25 || i == 26 || i == 28 || i == 37)
                {
                    sh7 = sh7 + 0;
                }
                else if (i == 6 || i == 8 || i == 10 || i == 12 || i == 16 || i == 18 || i == 22 || i == 31 || i == 33 || i == 39 || i == 41 || i == 43 || i == 45)
                {
                    sh7 = sh7 + 3;
                }
                else if (i == 1 || i == 3 || i == 7 || i == 11 || i == 13 || i == 14 || i == 20 || i == 26 || i == 27 || i == 29 || i == 32 || i == 34)
                {
                    sh8 = sh8 + 0;
                }
                else if (i == 8 || i == 18 || i == 22 || i == 31 || i == 35 || i == 38 || i == 41 || i == 42 || i == 45 || i == 46)
                {
                    sh8 = sh8 + 3;
                }
                else if (i == 4 || i == 9 || i == 15 || i == 17 || i == 19 || i == 21 || i == 23 || i == 24 || i == 25 || i == 28 || i == 36 || i == 37)
                {
                    sh9 = sh9 + 0;
                }
                else if (i == 2 || i == 5 || i == 6 || i == 10 || i == 12 || i == 16 || i == 30 || i == 33 || i == 39 || i == 40 || i == 43 || i == 44)
                {
                    sh9 = sh9 + 3;
                }
                else if (i == 1 || i == 3 || i == 4 || i == 7 || i == 9 || i == 11 || i == 13 || i == 14 || i == 15 || i == 17 || i == 19 || i == 20 || i == 21 || i == 23 || i == 24 || i == 25 || i == 26 || i == 27 || i == 28 || i == 29 || i == 32 || i == 34 || i == 36 || i == 37)
                {
                    sh10 = sh10 + 0;
                }
                else if (i == 2 || i == 5 || i == 6 || i == 8 || i == 10 || i == 12 || i == 16 || i == 18 || i == 22 || i == 30 || i == 31 || i == 33 || i == 35 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46)
                {
                    sh10 = sh10 + 3;
                }

                answer = "Совершенно не согласен";
            }

            if (i < 46)
            {
                txtNumZad.Text = n.ToString() + " / 46";
                txtNumZad2.Text = n.ToString();



                Quest[0] = "Я замечаю, когда близкий человек переживает, даже если он (она) пытается это скрыть.";
                Quest[1] = "Если человек на меня обижается, я не знаю, как восстановить с ним хорошие отношения.";
                Quest[2] = "Мне легко догадаться о чувствах человека по выражению его лица.";
                Quest[3] = "Я хорошо знаю, чем заняться, чтобы улучшить себе настроение.";
                Quest[4] = "У меня обычно не получается повлиять на эмоциональное состояние своего собеседника.";
                Quest[5] = "Когда я раздражаюсь, то не могу сдержаться, и говорю всё, что думаю.";
                Quest[6] = "Я хорошо понимаю, почему мне нравятся или не нравятся те или иные люди.";
                Quest[7] = "Я не сразу замечаю, когда начинаю злиться.";
                Quest[8] = "Я умею улучшить настроение окружающих.";
                Quest[9] = "Если я увлекаюсь разговором, то говорю слишком громко и активно жестикулирую.";
                Quest[10] = "Я понимаю душевное состояние некоторых людей без слов.";
                Quest[11] = "В экстремальной ситуации я не могу усилием воли взять себя в руки.";
                Quest[12] = "Я легко понимаю мимику и жесты других людей.";
                Quest[13] = "Когда я злюсь, я знаю, почему.";
                Quest[14] = "Я знаю, как ободрить человека, находящегося в тяжелой ситуации.";
                Quest[15] = "Окружающие считают меня слишком эмоциональным человеком.";
                Quest[16] = "Я способен успокоить близких, когда они находятся в напряжённом состоянии.";
                Quest[17] = "Мне бывает трудно описать, что я чувствую по отношению к другим.";
                Quest[18] = "Если я смущаюсь при общении с незнакомыми людьми, то могу это скрыть.";
                Quest[19] = "Глядя на человека, я легко могу понять его эмоциональное состояние.";
                Quest[20] = "Я контролирую выражение чувств на своем лице.";
                Quest[21] = "Бывает, что я не понимаю, почему испытываю то или иное чувство.";
                Quest[22] = "В критических ситуациях я умею контролировать выражение своих эмоций.";
                Quest[23] = "Если надо, я могу разозлить человека.";
                Quest[24] = "Когда я испытываю положительные эмоции, я знаю, как поддержать это состояние.";
                Quest[25] = "Как правило, я понимаю, какую эмоцию испытываю.";
                Quest[26] = "Если собеседник пытается скрыть свои эмоции, я сразу чувствую это.";
                Quest[27] = "Я знаю как успокоиться, если я разозлился.";
                Quest[28] = "Можно определить, что чувствует человек, просто прислушиваясь к звучанию его голоса.";
                Quest[29] = "Я не умею управлять эмоциями других людей.";
                Quest[30] = "Мне трудно отличить чувство вины от чувства стыда.";
                Quest[31] = "Я умею точно угадывать, что чувствуют мои знакомые.";
                Quest[32] = "Мне трудно справляться с плохим настроением.";
                Quest[33] = "Если внимательно следить за выражением лица человека, то можно понять, какие эмоции он скрывает.";
                Quest[34] = "Я не нахожу слов, чтобы описать свои чувства друзьям.";
                Quest[35] = "Мне удаётся поддержать людей, которые делятся со мной своими переживаниями.";
                Quest[36] = "Я умею контролировать свои эмоции.";
                Quest[37] = "Если мой собеседник начинает раздражаться, я подчас замечаю это слишком поздно.";
                Quest[38] = "По интонациям моего голоса легко догадаться о том, что я чувствую.";
                Quest[39] = "Если близкий человек плачет, я теряюсь.";
                Quest[40] = "Мне бывает весело или грустно без всякой причины.";
                Quest[41] = "Мне трудно предвидеть смену настроения у окружающих меня людей.";
                Quest[42] = "Я не умею преодолевать страх.";
                Quest[43] = "Бывает, что я хочу поддержать человека, а он этого не чувствует, не понимает.";
                Quest[44] = "У меня бывают чувства, которые я не могу точно определить.";
                Quest[45] = "Я не понимаю, почему некоторые люди на меня обижаются.";
                
                richTextBox2.Text = Quest[i];


                string AddAnsver = "INSERT INTO Result2 (IDTesting2,NQuest,ReactionTime,Answer) VALUES(" +
                   IDTesting + "," + i + "," + "'" + txtReactionTime.Text + "'" + "," +
                  "'" + answer + "'" + ")";
                SqlConnection conn = new SqlConnection(CS);
                conn.Open();
                SqlCommand myCommand = new SqlCommand(AddAnsver, conn);
                myCommand.CommandText = AddAnsver;
                myCommand.ExecuteNonQuery();
                conn.Close();
                i++;
                n++;


                txtReactionTime.Clear();
            timer3.Enabled = true;
            NowTimeTest = DateTime.Now;
            timer3.Start();

            //MessageBox.Show("sh1= " + sh1 + "sh2= " + sh2 + "sh3= " + sh3 + "sh4= " + sh4 + "sh5= " + sh5 + "sh6= " + sh6 + "sh7= " + sh7 + "sh8= " + sh8 + "sh9= " + sh9 + "sh10= " + sh10);

                
            }
            else
            {
                //Запись в БД
               
              //MessageBox.Show("Я вышел!");
              

                timer2.Stop();
                txtDateFinal.Text = txtDatetest.Text;
                txtStartTimeFinal.Text = txtTimeStartTest.Text;
                txtTimeTestFinal.Text = txtTimeTest.Text;
                txtCountZadFinal.Text = i.ToString();
                //вывод результатов текущего тестирования из БД

                string ResultTesting = Result + " where Result2.IDTesting2=" + IDTesting;
                    SqlDataAdapter A = new SqlDataAdapter(ResultTesting, CS);
                DataSet ds = new DataSet();
                A.Fill(ds, "Table");
                dgv1.DataSource = ds.Tables[0].DefaultView;
                tabControl1.SelectedIndex = 2;
                string TestingUp = "Update TESTING2 SET Res1 = " + sh1 + ", Res2 = " + sh2 + ", Res3 = " + sh3 + ", Res4 = " + sh4 + ", Res5 = " + sh5 + ", " +
                    "Res6 = (Select SUM("+sh1+"+"+sh2+") From Testing2 Where IDTesting2=" + IDTesting+ "), " +
                    "Res7 = (Select SUM("+sh3+"+"+sh4+"+"+sh5+") From Testing2 Where IDTesting2=" + IDTesting + "), " +
                    "Res8 = (Select SUM("+sh1+"+"+sh3+") From Testing2 Where IDTesting2=" + IDTesting + "), " +
                    "Res9 = (Select SUM("+sh2+"+"+sh4+"+"+sh5+") From Testing2 Where IDTesting2=" + IDTesting + "), " +
                    "Res10 = (Select SUM("+sh1+"+"+sh2+"+"+sh3+"+"+sh4+"+"+sh5+") From Testing2 Where IDTesting2=" + IDTesting + "), Status='Обработан' Where IDTesting2=" + IDTesting;
                SqlConnection conn = new SqlConnection(CS);
                conn.Open();
                SqlCommand myCommand = new SqlCommand(TestingUp, conn);
                myCommand.CommandText = TestingUp;
                myCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        DateTime NowTimeTest;
        private void timer3_Tick(object sender, EventArgs e)
        {
            TimeSpan TikTime;
            TikTime = DateTime.Now - NowTimeTest;
            txtReactionTime.Text = TikTime.ToString("hh\\:mm\\:ss");
            timer3.Start();
        }

        private void txtAnsver1_TextChanged(object sender, EventArgs e)
        {
            timer3.Stop();
            //timer3.Enabled = false;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }
}
