using MiskolciIngatlanKliens.Models;
using MiskolcIngatlanKliens.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiskolcIngatlanKliens.SubWindows
{
    /// <summary>
    /// Interaction logic for IngatlanokWindow.xaml
    /// </summary>
    public partial class IngatlanokWindow : Window
    {
        private HttpClient sajatKliens = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };
        private List<Ingatlan> ingatlanok = new List<Ingatlan>();
        public IngatlanokWindow()
        {
            InitializeComponent();
            ingatlanok = IngatlanService.GetAll(sajatKliens).Result;
            dgrIngatlanok.ItemsSource = ingatlanok;
            Feltolt();
        }

        private async void BtnUj_Click(object sender, RoutedEventArgs e)
        {
            Ingatlan ujIngatlan = new Ingatlan()
            {
                Telepules = tbxTelepules.Text,
                Cim = tbxCim.Text,
                Ar = int.Parse(tbxAr.Text),
                Tipus = tbxTipus.Text,
                KepNev = tbxKepNev.Text,
                UgyintezoId = 1,
                Ugyintezo = null
            };
            string uzenet = await IngatlanService.InsterNew(sajatKliens, ujIngatlan);
            MessageBox.Show(uzenet);
        }

        private void BtnModositas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTorol_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Feltolt()
        {
            ingatlanok = await IngatlanService.GetAll(sajatKliens);
            Task.Delay(1000).Wait();
            dgrIngatlanok.ItemsSource = ingatlanok;
        }
    }
}
