using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_mvvm_book.Model;
using Wpf_mvvm_book.ViewModel;

namespace Wpf_mvvm_book.View
{
    
    public partial class MainWindow : Window
    {        
        public static string selectedTopicCB;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();

            //Добавление тематик
            topicComboBox.ItemsSource = new TopicCB[] 
            {
            new TopicCB { TopicList = "Тема_1"},
            new TopicCB { TopicList = "Тема_2"},
            new TopicCB {TopicList = "Тема_3"},
            new TopicCB {TopicList = "Тема_4"},
            new TopicCB {TopicList = "Тема_5"}
            };         
        }
        private void topicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            selectedTopicCB = topicComboBox.SelectedValue?.ToString();         
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}
