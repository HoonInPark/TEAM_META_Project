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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_newmember_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server = localhost;Database=dbtest;Uid=root;Pwd=12345678;");
                // SQL 서버와 연결
                // Server = localhost (내 컴퓨터 서버), dbtest = 스키마 이름, Uid = DB 로그인 아이디, Pwd = DB 로그인 비번

                conn.Open();
                // SQL 서버 연결

                string insertQuery = "INSERT INTO account_info (name, id, pwd) VALUES('" + txtbox_name.Text + "', '" + txtbox_id.Text
                    + "', '" + txtbox_pwd.Text + "');";
                // 문자열 insertQuery 변수 선언
                // MySQL에 전송할 명령어를 입력한다. MySQL에 전송될 명령어는 "" 사이의 값
                // dbtest 스키마의 account_info 테이블에 값을 추가하기 위한 변수

                MySqlCommand command = new MySqlCommand(insertQuery, conn);
                // MySqlCommand는 MySQL로 명령어를 전송하기 위한 클래스
                // MySQL에 insertQuery 값을 보내고, conn 값을 보내 연결 시도
                // 해당 정보를 command 변수에 저장한다

                if(command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtbox_name.Text + "님 회원가입 완료, 사용할 아이디는 " + txtbox_id.Text + "입니다.");
                    // 회원가입 안내 메시지박스

                    conn.Close();
                    // SQL 연결을 끊는다

                    Close();
                    // Form2를 닫는다 (Form1 로그인 창으로 돌아감)
                }
                else
                {
                    MessageBox.Show("정보를 다시 입력해주세요");
                    // 오류 메시지 박스를 띄운다
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                // 예외값 발생시 해당 정보와 관련된 메시지박스를 띄운다.
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
