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
using System.Data.SqlClient;
using System.Data;


namespace programm
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbConnector connector = new DbConnector();

        private void LoadData()
        {

            DataTable data = connector.GetDataFromDb("select * from tbHusiplaner");

        }
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
           // textausgabe.Text = "Dies ist die Liste von den Hausaufgaben die du noch machen muss.\nFalls du die Aufgabe erledigt hat kreuze si an und sie verschwindet wieder ";
        }   
        public class Husiplaner
        {
            public string Fach { get; set; }
            public string Husi { get; set; }
            public string Datum { get; set; }
            public string Erledigt { get; set; }


        }
            

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedIndex = 1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedIndex = 2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedIndex = 3;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Finish wurde gedrückt.");
            string fach = txtBox_fach.Text;
            string deinehusi = txtBox_deinehusi.Text;
            DateTime date = datepicker.DisplayDate;

            Lable1.Content = fach + "\n" + deinehusi + "\n" + date;

            connector.InsertHusi(fach, deinehusi, date);
          
            txtBox_fach.Clear();
            txtBox_deinehusi.Clear();
            datepicker.SelectedDate = null;
        }
    }
}
