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
using System.Collections.ObjectModel;


namespace programm
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();    

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;

            //textausgabe.Text = "Dies ist die Liste von den Hausaufgaben die du noch machen muss.\nFalls du die Aufgabe erledigt hat kreuze si an und sie verschwindet wieder ";
            //textausgabeTitel.Text = "Ausstehende Husi\n";
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
            MessageBox.Show("Die Eingabe wurde in die Datenbank geldaden.");
            string fach = txtBox_fach.Text;
            string deinehusi = txtBox_deinehusi.Text;
            DateTime date = Convert.ToDateTime(datepicker.Text);
            Boolean erledigt = false;

            Lable1.Content = fach + "\n" + deinehusi + "\n" + date;

            vm.AddHusi(fach, deinehusi, date, erledigt);

            txtBox_fach.Clear();
            txtBox_deinehusi.Clear();
            datepicker.SelectedDate = null;
            vm.Refresh();
        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
           if (dataGrid.CurrentCell.Column.DisplayIndex == 4)
           { 
                Husiplaner changed = (Husiplaner)dataGrid.CurrentCell.Item;
                vm.DeleteHusi(changed);
           }
        }
       
    }
}
