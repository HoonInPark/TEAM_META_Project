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
                // SQL ������ ����
                // Server = localhost (�� ��ǻ�� ����), dbtest = ��Ű�� �̸�, Uid = DB �α��� ���̵�, Pwd = DB �α��� ���


                conn.Open(); 
                //SQL ���� ����

                int login_status = 0;
                // �α��� ���� ���� ����, ��α��� ���´� 0

                string loginid = txtbox_id.Text; 
                //���ڿ� loginid ������ txtbox_id�� �ؽ�Ʈ��
                string loginpwd = txtbox_pwd.Text;
                //���ڿ� loginid ������ txtbox_pwd�� �ؽ�Ʈ��

                string selectQuery = "SELECT * FROM account_info WHERE id = \\'" + loginid + "\\' ";
                // MySQL�� ������ ��ɾ� �Է�, ���� ���۵� ��ɾ�� "" ���� ��
                // dbtest ��Ű���� account_info ���̺� ���� �б� ���� ���ڿ� selectQuery ���� ����

                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, conn);
                // MySqlCommand�� MySQL�� ��ɾ �����ϱ� ���� Ŭ����
                // MySQL�� SelectQuery ���� ������, conn ���� ���� ���� �õ���
                // �ش� ������ Selectcommand ������ �����Ѵ�.

                MySqlDataReader userAccount = Selectcommand.ExecuteReader();
                // MySqlDataReader�� �Է°��� �ޱ� ����
                // Selectcommand ������ ExecuteReader() ��ü�� ���� �Է°��� �ް�, �ش� ������ userAccount ������ ����

                while(userAccount.Read()) 
                    // userAccount�� Read �ǰ� ���� ����
                {
                    if(loginid == (string)userAccount["id"] && loginpwd == (string)userAccount["pwd"])
                        // ���� loginid ���� ���� loginpw ���� ���� account_info ���̺� ���� id, pwd ������ ��ġ�Ѵٸ� 
                    {
                        login_status = 1;  
                        // �ش� ���� ���¸� 1�� �ٲ۴�
                    }
                }
                conn.Close();
                //MySQL�� ������ ���´�

                if(login_status== 1)
                    // �ش� ���� ���°� 1�̶�� 
                {
                    MessageBox.Show("�α��� �Ϸ�");
                    // �α��� �Ϸ� �޽����ڽ��� ����
                }
                else
                {
                    MessageBox.Show("ȸ�� ������ Ȯ�����ּ���.");
                    // ���� �޽��� �ڽ��� ����
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                // ���ܰ� �߻��� �ش� ������ ���õ� �޽����ڽ��� ����.
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