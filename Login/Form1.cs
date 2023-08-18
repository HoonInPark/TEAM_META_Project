using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server = localhost;Database=dbtest;Uid=root;Pwd=12345678;");
                // SQL 서버와 연결
                // Server = localhost (내 컴퓨터 서버), dbtest = 스키마 이름, Uid = DB 로그인 아이디, Pwd = DB 로그인 비번


                conn.Open(); 
                //SQL 서버 연결

                int login_status = 0;
                // 로그인 상태 변수 선언, 비로그인 상태는 0

                string loginid = txtbox_id.Text; 
                //문자열 loginid 변수는 txtbox_id의 텍스트값
                string loginpwd = txtbox_pwd.Text;
                //문자열 loginid 변수는 txtbox_pwd의 텍스트값

                string selectQuery = "SELECT * FROM account_info WHERE id = \\'" + loginid + "\\' ";
                // MySQL에 전송할 명령어 입력, 실제 전송될 명령어는 "" 사이 값
                // dbtest 스키마의 account_info 테이블 값을 읽기 위해 문자열 selectQuery 변수 선언

                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, conn);
                // MySqlCommand는 MySQL로 명령어를 전송하기 위한 클래스
                // MySQL에 SelectQuery 값을 보내고, conn 값을 보내 연결 시도함
                // 해당 정보를 Selectcommand 변수에 저장한다.

                MySqlDataReader userAccount = Selectcommand.ExecuteReader();
                // MySqlDataReader은 입력값을 받기 위함
                // Selectcommand 변수에 ExecuteReader() 객체를 통해 입력값을 받고, 해당 정보를 userAccount 변수에 저장

                while(userAccount.Read()) 
                    // userAccount가 Read 되고 있을 동안
                {
                    if(loginid == (string)userAccount["id"] && loginpwd == (string)userAccount["pwd"])
                        // 만약 loginid 변수 값과 loginpw 변수 값이 account_info 테이블 값의 id, pwd 정보와 일치한다면 
                    {
                        login_status = 1;  
                        // 해당 변수 상태를 1로 바꾼다
                    }
                }
                conn.Close();
                //MySQL과 연결을 끊는다

                if(login_status== 1)
                    // 해당 변수 상태가 1이라면 
                {
                    MessageBox.Show("로그인 완료");
                    // 로그인 완료 메시지박스를 띄운다
                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해주세요.");
                    // 오류 메시지 박스를 띄운다
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                // 예외값 발생시 해당 정보와 관련된 메시지박스를 띄운다.
            }

        }

        private void btn_newmember_Click(object sender, EventArgs e)
        {
            Form2 showform2 = new Form2();
            showform2.ShowDialog();
        }

        private void txtbox_pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}