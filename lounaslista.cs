using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tfs_ohjelmointiprojekti
{
    public partial class lounaslista : Form
    {
        public lounaslista()
        {
            InitializeComponent();

            // tekee arrayn rivi kerrallaan nimet-tiedostosta
                StreamReader objstream1 = new StreamReader(@"./annosnimet.txt");
                string[] lines1 = objstream1.ReadToEnd().Split(new char[] { '\n' });
                annos1_nimi.Text = lines1[0];
                annos2_nimi.Text = lines1[1];
                annos3_nimi.Text = lines1[2];
                annos4_nimi.Text = lines1[3];
                annos5_nimi.Text = lines1[4];
                annos6_nimi.Text = lines1[5];
                annos7_nimi.Text = lines1[6];
                annos8_nimi.Text = lines1[7];
                annos9_nimi.Text = lines1[8];
                annos10_nimi.Text = lines1[9];
                annos11_nimi.Text = lines1[10];
                annos12_nimi.Text = lines1[11];
                objstream1.Close();


            // sama homma kuin yllä hinnoille
            StreamReader objstream2 = new StreamReader(@"./annoshinnat.txt");
            string[] lines2 = objstream2.ReadToEnd().Split(new char[] { '\n' });
            annos1_hinta.Text = lines2[0];
            annos2_hinta.Text = lines2[1];
            annos3_hinta.Text = lines2[2];
            annos4_hinta.Text = lines2[3];
            annos5_hinta.Text = lines2[4];
            annos6_hinta.Text = lines2[5];
            annos7_hinta.Text = lines2[6];
            annos8_hinta.Text = lines2[7];
            annos9_hinta.Text = lines2[8];
            annos10_hinta.Text = lines2[9];
            annos11_hinta.Text = lines2[10];
            annos12_hinta.Text = lines2[11];
            objstream2.Close();

            // näytä alviton hinta
            {
                // tekee uuden hinnat-arrayn ja muuttaa pilkut pisteiksi
                StreamReader objstream3 = new StreamReader(@"./annoshinnat.txt");
                string[] alvlines = objstream3.ReadToEnd().Split(new char[] { '\n' });
                // alvlines = alvlines.Select(x => x.Replace(",", ".")).ToArray();
                objstream3.Close();

                try
                {
                    double conv1 = double.Parse(alvlines[0]) * 0.86;    // kaikkiin hintoihin yksitellen alv0-lasku
                    annos1_alvhinta.Text = conv1.ToString("F2");
                    double conv2 = double.Parse(alvlines[1]) * 0.86;
                    annos2_alvhinta.Text = conv2.ToString("F2");
                    double conv3 = double.Parse(alvlines[2]) * 0.86;
                    annos3_alvhinta.Text = conv3.ToString("F2");
                    double conv4 = double.Parse(alvlines[3]) * 0.86;
                    annos4_alvhinta.Text = conv4.ToString("F2");
                    double conv5 = double.Parse(alvlines[4]) * 0.86;
                    annos5_alvhinta.Text = conv5.ToString("F2");
                    double conv6 = double.Parse(alvlines[5]) * 0.86;
                    annos6_alvhinta.Text = conv6.ToString("F2");
                    double conv7 = double.Parse(alvlines[6]) * 0.86;
                    annos7_alvhinta.Text = conv7.ToString("F2");
                    double conv8 = double.Parse(alvlines[7]) * 0.86;
                    annos8_alvhinta.Text = conv8.ToString("F2");
                    double conv9 = double.Parse(alvlines[8]) * 0.86;
                    annos9_alvhinta.Text = conv9.ToString("F2");
                    double conv10 = double.Parse(alvlines[9]) * 0.86;
                    annos10_alvhinta.Text = conv10.ToString("F2");
                    double conv11 = double.Parse(alvlines[10]) * 0.86;
                    annos11_alvhinta.Text = conv11.ToString("F2");
                    double conv12 = double.Parse(alvlines[11]) * 0.86;
                    annos12_alvhinta.Text = conv12.ToString("F2");
                }
                catch
                {
                   
                }
            }

        }

        // Takaisin-nappi vie aloitusikkunaan
        private void lista_takaisin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lounaslista = new aloitusikkuna();
            lounaslista.Closed += (s, args) => this.Close();
            lounaslista.Show();
        }


        // Päivitysnappi
        private void annos1_nappi_Click(object sender, EventArgs e)
        {
            var lines1 = File.ReadAllLines(@"./annosnimet.txt");
            var lines2 = File.ReadAllLines(@"./annoshinnat.txt");
            lines1[0] = annos1_nimi.Text;
            lines2[0] = annos1_hinta.Text;
            lines1[1] = annos2_nimi.Text;
            lines2[1] = annos2_hinta.Text;
            lines1[2] = annos3_nimi.Text;
            lines2[2] = annos3_hinta.Text;
            lines1[3] = annos4_nimi.Text;
            lines2[3] = annos4_hinta.Text;
            lines1[4] = annos5_nimi.Text;
            lines2[4] = annos5_hinta.Text;
            lines1[5] = annos6_nimi.Text;
            lines2[5] = annos6_hinta.Text;
            lines1[6] = annos7_nimi.Text;
            lines2[6] = annos7_hinta.Text;
            lines1[7] = annos8_nimi.Text;
            lines2[7] = annos8_hinta.Text;
            lines1[8] = annos9_nimi.Text;
            lines2[8] = annos9_hinta.Text;
            lines1[9] = annos10_nimi.Text;
            lines2[9] = annos10_hinta.Text;
            lines1[10] = annos11_nimi.Text;
            lines2[10] = annos11_hinta.Text;
            lines1[11] = annos12_nimi.Text;
            lines2[11] = annos12_hinta.Text;
            File.WriteAllLines(@"./annosnimet.txt", lines1);
            File.WriteAllLines(@"./annoshinnat.txt", lines2);

            MessageBox.Show("Lounaslista päivitetty.");
            lounaslista ss = new lounaslista();
            ss.Show();
            this.Hide();
        }

    }
}
