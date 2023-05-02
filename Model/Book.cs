using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf_mvvm_book.View;

namespace Wpf_mvvm_book.Model
{
    // Модель Книга
    public class Book : INotifyPropertyChanged
    {
        private string author;
        private string title;      
        private int year;
        public string topicCBList= MainWindow.selectedTopicCB;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }       
        
            public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public string TopicCBList
        {
            get { return topicCBList; }
            set
            {
                topicCBList = value;
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
}
