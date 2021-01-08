using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programm
{
    public class MainWindowViewModel
    {

        DbConnector connector = new DbConnector();

        public ObservableCollection<Husiplaner> Husis { get; set; } = new ObservableCollection<Husiplaner>();

        public MainWindowViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {

            DataTable data = connector.GetDataFromDb("select * from tbHusiplaner order by ErledigtBis asc");

            foreach (DataRow row in data.Rows)
            {
                Husiplaner a = new Husiplaner();
                a.Id = Convert.ToInt32(row["Id"]);
                a.Fach = row["Fach"].ToString();
                a.Husi = row["DeineHusi"].ToString();
                a.Datum = row["ErledigtBis"].ToString();
                a.Erledigt = Convert.ToBoolean(row["Erledigt"]);
                Husis.Add(a);
            }

        }
        public void Refresh()
        {
            Husis.Clear();
            LoadData();
        }
        public void AddHusi(string fach, string deinehusi, DateTime date, Boolean erledigt)
        {
            connector.InsertHusi(fach, deinehusi, date, erledigt);
        }

        public void DeleteHusi(Husiplaner husi)
        {
            connector.DeleteHusi(husi.Id);
            Refresh();
        }

    }
}
