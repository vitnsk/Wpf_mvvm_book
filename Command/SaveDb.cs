using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_mvvm_book.Model;
using Wpf_mvvm_book.View;
using Wpf_mvvm_book.ViewModel;

namespace Wpf_mvvm_book.Command
{
    public class SaveDb:ApplicationViewModel   
    {
        //Выгрузка данных
        public static string[] UnLoad(int i)
        {                       
            Book fb = Books[i];
            string[] names;
            names = new String[] { fb.Author, fb.Title, Convert.ToString(fb.Year), fb.TopicCBList };
            return names;
        }

        // Запись в БД
        public static void SaveData()
        {          
            string[] fn;
            string cmd_t;
            string connectionString = @"Data Source=.\SQLEXPRESS; DataBase=Books; Integrated Security=True;";            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // открыть соединение

                for (int i = 0; i < Books.Count; i++)
                {
                    fn = UnLoad(i);
                    cmd_t = String.Format("INSERT INTO [Book](Author,Title,Year,TopicCBList) VALUES ('{0}','{1}','{2}','{3}')", fn[0], fn[1], fn[2], fn[3]);

                    // создать команду на языке SQL
                    SqlCommand sql_comm = new SqlCommand(cmd_t, connection);
                    sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                }
                connection.Close(); // закрыть соединение         
            }
        }

        //Стирание данных в БД
        public static void DeleteData()
        {         
            string cmd_t;
            string connectionString = @"Data Source=.\SQLEXPRESS; DataBase=Books; Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // открыть соединение               

                    cmd_t = "DELETE FROM [Book]";
                    // создать команду на языке SQL
                    SqlCommand sql_comm = new SqlCommand(cmd_t, connection);
                    sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
               
                connection.Close(); // закрыть соединение         
            }
        }

    }
}
