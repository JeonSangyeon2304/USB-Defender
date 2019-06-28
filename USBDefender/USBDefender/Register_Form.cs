using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace USBDefender
{
    public partial class Register_Form : Form
    {
        public static string local_IP;

        Connected_DB connected_DB = new Connected_DB();

        public Register_Form()
        {
            InitializeComponent();

            Register_btn.BackColor = Color.FromArgb(50, 0, 0, 0);

            Register_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 0, 0, 0);

            //Debug 출력
            Debug.WriteLine("------------------------Register Form------------------------");
        }
        
        private void Register_Form_Load(object sender, EventArgs e)
        {
            // Debug 출력
            Debug.WriteLine("Register Form // Register_Form_Load // Register Form >>> ConnectedDB");

            // 관리자가 있는 부서만 가져온다.
            string[] Departemnt_list = connected_DB.Search();

            // Debug 출력
            foreach (string list in Departemnt_list)
                Debug.WriteLine("Register Form // Register_btn_Click // Departemnt_list: " + list);

            Department_ComboBox.Items.AddRange(Departemnt_list);

            string[] Position_list = { "사원", "대리", "과장", "부장" };
            Position_ComboBox.Items.AddRange(Position_list);
        }
        
        private void Register_btn_Click(object sender, EventArgs e)
        {
            // 폼에 입력한 값을 가져온다.
            string Department = Department_ComboBox.SelectedItem as String;
            string Position = Position_ComboBox.SelectedItem as String;
            string Name = Name_TextBox.Text;

            // Debug 출력
            Debug.WriteLine("Register Form // Register_btn_Click // 부서: " + Department);
            Debug.WriteLine("Register Form // Register_btn_Click // 직책: " + Position);
            Debug.WriteLine("Register Form // Register_btn_Click // 이름: " + Name);
            Debug.WriteLine("Register Form // Register_btn_Click // IP: " + local_IP);

            // 공백확인
            if (String.IsNullOrEmpty(Department))
                MessageBox.Show("공백인 부분이 있습니다.\n확인해주세요");
            else
            {
                try
                {
                    // Debug 출력
                    Debug.WriteLine("Register Form // Register_btn_Click // Register Form >>> ConnectedDB");

                    //DB에 반영
                    if(connected_DB.recode(Department, Position, Name, local_IP))
                    {
                        MessageBox.Show("등록요청을 성공적으로 수행되었습니다.\r등록이 될때까지 기다려 주시기 바랍니다.");
                        Application.ExitThread();
                    }
                    else
                    {
                        Application.ExitThread();
                    }
                }
                catch
                {
                    MessageBox.Show("등록에 오류가 발생하였습니다.");
                }
            }  
        }
        
        private void Register_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
