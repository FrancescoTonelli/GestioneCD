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
using System.IO;

namespace GestioneCD
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AggiornaListaBrani();
            AggiornaLstBrani();
            listaCD = new List<CD>();
        }

        private List<Brano> listaBrani;
        private List<CD> listaCD;

        private void AggiornaListaBrani()
        {
            try
            {
                listaBrani = new List<Brano>();
                using (StreamReader sr = new StreamReader("listaBrani.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) //i brani sono scritti nel txt come NOME/AUTORE/DURATA
                    {
                        string[] line2 = line.Split('/');
                        Brano p = new Brano(line2[0], line2[1], int.Parse(line2[2]));
                        listaBrani.Add(p);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Ricontrollare il file txt: " + ex.Message);
            }
        }

        private void AggiornaTxt()
        {
            using(StreamWriter sw = new StreamWriter("listaBrani.txt"))
            {
                for(int i = 0; i < listaBrani.Count; i++)
                {
                    sw.WriteLine(listaBrani[i].GetNome() + "/" + listaBrani[i].GetAutore() + "/" + listaBrani[i].GetDurata());
                }
            }
        }

        private void AggiornaLstBrani()
        {
            lstBrani.Items.Clear();
            for (int i = 0; i < listaBrani.Count; i++)
            {
                lstBrani.Items.Add(listaBrani[i].ToString());
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Brano p = new Brano(txtNome.Text, txtAutore.Text, int.Parse(txtDurata.Text));
                listaBrani.Add(p);
                AggiornaLstBrani();
                AggiornaTxt();
                txtNome.Text = "";
                txtAutore.Text = "";
                txtDurata.Text = "";
            }catch(Exception ex)
            {
                MessageBox.Show("Reinserire l'input: " + ex.Message);
            }
        }

        private void btnCreaCd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Brano> braniCD = new List<Brano>();
                string[] line = txtListaBrani.Text.Split(',');
                for(int i = 0; i < line.Length; i++)
                {
                    braniCD.Add(listaBrani[int.Parse(line[i]) - 1]);
                }
                CD nuovoCd = new CD(txtNome_CD.Text, txtAutore_CD.Text, braniCD);
                listaCD.Add(nuovoCd);
                AggiornaLstCd();
                txtNome_CD.Text = "";
                txtAutore_CD.Text = "";
                txtListaBrani.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AggiornaLstCd()
        {
            lstCD.Items.Clear();
            for (int i = 0; i < listaCD.Count; i++)
            {
                lstCD.Items.Add(listaCD[i].ToString()+" (Durata totale: "+ listaCD[i].Durata() + "sec)");
            }
        }
    }
}
