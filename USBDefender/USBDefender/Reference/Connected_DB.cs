using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace USBDefender
{
    class Connected_DB
    {
        public string[] Search()
        {
            string[] result = null;

            // Debug 출력
            Debug.WriteLine("\t\t\t------------------------ ConnectedDB ------------------------");

            try
            {
                string connection = "Server=14.50.144.200;uid=root;pwd=portero2304;database=Capstone;";
                //DB 접속
                MySqlConnection conn = new MySqlConnection(connection);

                conn.Open();

                string SQL = "SELECT Department FROM Admin;";

                MySqlCommand command = new MySqlCommand(SQL, conn);
                MySqlDataReader rdr = command.ExecuteReader();

                string temp = string.Empty;
                if (rdr == null)
                    temp = "No return";
                else
                {
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (i != rdr.FieldCount - 1)
                            {
                                temp += rdr[i] + "/";
                            }
                            else if (i == rdr.FieldCount - 1)
                            {
                                temp += rdr[i] + "/";
                            }
                        }
                    }

                    // Debug 출력
                    Debug.WriteLine("\t\t\tConnected_DB // Search // temp: " + temp);

                    int len = temp.Length;
                    temp = temp.Substring(0, len - 1);
                }
                conn.Close();

                result = temp.Split('/');
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                Application.Exit();
            }

            return result;
        }

        public bool Search(string ip)
        {
            // Debug 출력
            Debug.WriteLine("\t\t\t------------------------ ConnectedDB ------------------------");

            //DB 접속
            MySqlConnection conn = new MySqlConnection();

            //quary
            MySqlCommand sqlComm = new MySqlCommand();

            string SQL = "SELECT COUNT(*) FROM `User` WHERE IP LIKE '" + ip + "';";

            try
            {
                string connection = "Server=14.50.144.200;uid=root;pwd=portero2304;database=Capstone;";

                conn.ConnectionString = connection;
                sqlComm.Connection = conn;
                sqlComm.CommandText = SQL;
                conn.Open();
                int count = Convert.ToInt32(sqlComm.ExecuteScalar());
                conn.Close();

                // Debug 출력
                Debug.WriteLine("\t\t\tConnected_DB // Connection // Get result: " + count);

                if (count != 0)
                {
                    // Debug 출력
                    Debug.WriteLine("\t\t\tConnected_DB // Connection // ConnectedDB >>> State Form");

                    return true;
                }
                else
                {
                    // Debug 출력
                    Debug.WriteLine("\t\t\tConnected_DB // Connection // ConnectedDB >>> State Form");

                    return false;
                }
            }
            catch
            {
                MessageBox.Show("DB에 연결되지 않았습니다.");
                Application.Exit();
                return true;
            }
        }

        public bool Search(string Device_info, string ip)
        {
            // Debug 출력
            Debug.WriteLine("\t\t\t------------------------ ConnectedDB ------------------------");

            //DB 접속
            MySqlConnection conn = new MySqlConnection();

            //quary
            MySqlCommand sqlComm = new MySqlCommand();

            string SQL = "SELECT COUNT(*) FROM `Device` WHERE Device_info LIKE '" + Device_info + "'" + "AND IP LIKE '" + ip + "';";

            try
            {
                string connection = "Server=14.50.144.200;uid=root;pwd=portero2304;database=Capstone;";

                conn.ConnectionString = connection;
                sqlComm.Connection = conn;
                sqlComm.CommandText = SQL;
                conn.Open();
                int count = Convert.ToInt32(sqlComm.ExecuteScalar());
                conn.Close();

                // Debug 출력
                Debug.WriteLine("\t\t\tConnected_DB // Connection // Get result: " + count);

                if (count != 0)
                {
                    // Debug 출력
                    Debug.WriteLine("\t\t\tConnected_DB // Connection // ConnectedDB >>> State Form");

                    return true;
                }
                else
                {
                    // Debug 출력
                    Debug.WriteLine("\t\t\tConnected_DB // Connection // ConnectedDB >>> State Form");

                    return false;
                }
            }
            catch
            {
                MessageBox.Show("DB에 연결되지 않았습니다.");
                Application.Exit();
                return true;
            }
        }

        public bool recode(string Department, string Position, string Name, string ip)
        {
            try
            {
                string connection = "Server=14.50.144.200;uid=root;pwd=portero2304;database=Capstone;";
                //DB 접속
                MySqlConnection conn = new MySqlConnection(connection);

                conn.Open();

                string SQL = "INSERT INTO User_request VALUES ('" + ip + "', '" + Department + "', '" + Position + "', '" + Name + "');";

                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.ExecuteNonQuery();


                conn.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("이미 등록이 요청된 계정입니다.\r처리를 기다려 주세요");
                return false;
            }
        }

        public void recode(string device_info, string ip, string drive_letter)
        {
            try
            {
                string connection = "Server=14.50.144.200;uid=root;pwd=portero2304;database=Capstone;";
                //DB 접속
                MySqlConnection conn = new MySqlConnection(connection);

                conn.Open();

                string SQL = "INSERT INTO Device_Request VALUES ('" + device_info + "', '" + ip +"','"+drive_letter +"');";

                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.ExecuteNonQuery();


                conn.Close();
            }
            catch
            {
                MessageBox.Show("이미 등록을 요청한 장치입니다.");
            }
        }
        public void recode(string device_info, string ip)
        {
            try
            {
                string connection = "Server=14.50.144.200;uid=root;pwd=portero2304;database=Capstone;";
                //DB 접속
                MySqlConnection conn = new MySqlConnection(connection);

                conn.Open();

                string SQL = "INSERT INTO Device_Delete VALUES ('" + device_info + "', '" + ip + "');";

                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.ExecuteNonQuery();


                conn.Close();
            }
            catch
            {
                MessageBox.Show("이미 등록삭제를 요청한 장치입니다.");
            }
        }
    }
}
