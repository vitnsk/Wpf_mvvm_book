using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf_mvvm_book.Model;
using System.Windows.Documents;
using System.Data.Common;
using Wpf_mvvm_book.Command;
using Wpf_mvvm_book.View;

namespace Wpf_mvvm_book.ViewModel
{    
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        string connectionString = @"Data Source=.\SQLEXPRESS; DataBase=Books; Integrated Security=True;";
        private Book selectedBook;        

      public static ObservableCollection<Book> Books { get; set; }      

        //команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Book book = new Book();
                      Books.Insert(0, book);
                      SelectedBook = book;
                  }));
            }
        }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Book book = obj as Book;
                      if (book != null)
                      {
                          Books.Remove(book);                   

                      }
                  },
                 (obj) => Books.Count > 0));
            }
        }

        // команда сщхранения
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      SaveDb.DeleteData();
                      SaveDb.SaveData();         
                  },
                  (obj) => Books.Count > 0));
            }
        }

        //Команда выбора
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;                
                OnPropertyChanged("SelectedBook");
               
            }
        }           

        //Загрузка данных из БД
        public ApplicationViewModel()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                connection.Open();                          

                SqlCommand command = new SqlCommand("Select Author, Title, Year,TopicCBList from dbo.Book", connection);
                SqlDataReader reader = command.ExecuteReader();

                 Books = new ObservableCollection<Book>();
                while (reader.Read())
                {
                    int ye = 1900;
                    Object val = reader["Year"];
                    if (val != DBNull.Value)
                    {
                        ye = Convert.ToInt32(val);
                    }
                    else
                    {
                        ye = 0;
                    }

                    Books.Add(new Book
                    {
                        Author = Convert.ToString(reader["Author"]),
                        Title = Convert.ToString(reader["Title"]),                                       
                        Year = ye,
                        TopicCBList = Convert.ToString(reader["TopicCBList"]),
                    });
                }
                connection.Close();
            }

        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
