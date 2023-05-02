using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf_mvvm_book.Model;
using Wpf_mvvm_book.View;

namespace Wpf_mvvm_book.ViewModel
{
    //модель представления Книга
    public class BookViewModel : INotifyPropertyChanged
    {
        private Book book;
        public string topicCBList = MainWindow.selectedTopicCB;
        public BookViewModel(Book b)
        {
            book = b;
        }
        public string Author
        {
            get { return book.Author; }
            set
            {
                book.Author = value;
                OnPropertyChanged("Author");
            }
        }
        public string Title
        {
            get { return book.Title; }
            set
            {
                book.Title = value;
                OnPropertyChanged("Title");
            }
        }
              
        public Int32 Year
        {
            get { return book.Year; }
            set
            {
                book.Year = value;
                OnPropertyChanged("Year");
            }
        }
        public string TopicCBList
        {
            get { return book.TopicCBList; }
            set
            {
                  book.TopicCBList = value;
                OnPropertyChanged("TopicCBList"); 
               
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
                
    }
    public class TopicCB
    {
        public string TopicList { get; set; } = "";
        public override string ToString() => $"{TopicList}";
    }
}
