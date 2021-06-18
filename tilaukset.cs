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

namespace RavintolaTilausOhjelma
{
    public partial class tilaukset2 : Form
    {
        private string tilauksetTiedosto = @"./tilaukset.txt";
        private string valmiitTiedosto = @"./valmiit_tilaukset.txt";

        public tilaukset2()
        {
            InitializeComponent();
        }

        private void tilaukset2_Load(object sender, EventArgs e)
        {
            keskenEraiset_listView.FullRowSelect = true;
            valmiit_listView.FullRowSelect = true;

            // Lukee tilaukset tilaukset.txt tiedostosta ListView -komponenttiin.
            foreach (string line in File.ReadAllLines(tilauksetTiedosto))
            {
                string[] osat = line.Split('.');
                try
                {
                    keskenEraiset_listView.View = View.Details;
                    ListViewItem lvwItem = keskenEraiset_listView.Items.Add(osat[0]);
                    lvwItem.SubItems.Add(osat[1]);
                    lvwItem.SubItems.Add(osat[2]);
                    lvwItem.SubItems.Add(osat[3]);
                } catch
                {

                }
            }
            foreach (string line in File.ReadAllLines(valmiitTiedosto))
            {
                string[] osat = line.Split('.');
                try
                {
                    valmiit_listView.View = View.Details;
                    ListViewItem lvwItem = valmiit_listView.Items.Add(osat[0]);
                    lvwItem.SubItems.Add(osat[1]);
                    lvwItem.SubItems.Add(osat[2]);
                    lvwItem.SubItems.Add(osat[3]);
                } catch
                {

                }
            }
        }

        private void siirraTilaus_nappi_Click(object sender, EventArgs e)
        {
            //Poistaa siirretyn tilauksen tilaukset.txt tiedostosta
            List<string> lines = File.ReadAllLines(tilauksetTiedosto).ToList();
            foreach (ListViewItem selectedItem in keskenEraiset_listView.SelectedItems)
            {
                if (lines.Contains(selectedItem.Text + "." + selectedItem.SubItems[1].Text + "." + selectedItem.SubItems[2].Text + "." + selectedItem.SubItems[3].Text))
                    lines.Remove(selectedItem.Text + "." + selectedItem.SubItems[1].Text + "." + selectedItem.SubItems[2].Text + "." + selectedItem.SubItems[3].Text);
                File.WriteAllLines(tilauksetTiedosto, lines);
            }
            // Kopioi keskeneräisen tilauksen valmiisiin tilauksiin ja poistaa tilauksen keskeneräisistä.
            foreach (ListViewItem item in keskenEraiset_listView.SelectedItems)
            {
                valmiit_listView.Items.Add((ListViewItem)item.Clone());
                keskenEraiset_listView.Items.Remove(keskenEraiset_listView.SelectedItems[0]);

                //Lisää tilauksen valmiit_tilaukset.txt tiedostoon.
                TextWriter kirjoita = new StreamWriter(valmiitTiedosto, true);
                kirjoita.WriteLine(item.Text + "." + item.SubItems[1].Text + "." + item.SubItems[2].Text + "." + item.SubItems[3].Text);
                kirjoita.Close();
            }
        }

        private void poistaTilaus_nappi_Click(object sender, EventArgs e)
        {
            try
            {
                // Poistaa tilauksen valmiit_tilaukset.txt tiedostosta ja valmiista tilauksista
                List<string> lines = File.ReadAllLines(valmiitTiedosto).ToList();
                foreach (ListViewItem selectedItem in valmiit_listView.SelectedItems)
                {
                    if (lines.Contains(selectedItem.Text + "." + selectedItem.SubItems[1].Text + "." + selectedItem.SubItems[2].Text + "." + selectedItem.SubItems[3].Text))
                        lines.Remove(selectedItem.Text + "." + selectedItem.SubItems[1].Text + "." + selectedItem.SubItems[2].Text + "." + selectedItem.SubItems[3].Text);
                    File.WriteAllLines(valmiitTiedosto, lines);

                    valmiit_listView.Items.Remove(valmiit_listView.SelectedItems[0]);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                try
                {
                    // Poistaa tilauksen tilaukset.txt tiedostosta ja keskeneräisistä tilauksista. 
                    List<string> lines = File.ReadAllLines(tilauksetTiedosto).ToList();
                    foreach (ListViewItem selectedItem in keskenEraiset_listView.SelectedItems)
                    {
                        if (lines.Contains(selectedItem.Text + "." + selectedItem.SubItems[1].Text + "." + selectedItem.SubItems[2].Text + "." + selectedItem.SubItems[3].Text))
                            lines.Remove(selectedItem.Text + "." + selectedItem.SubItems[1].Text + "." + selectedItem.SubItems[2].Text + "." + selectedItem.SubItems[3].Text);
                        File.WriteAllLines(tilauksetTiedosto, lines);

                        keskenEraiset_listView.Items.Remove(keskenEraiset_listView.SelectedItems[0]);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Valitse tilaus, jonka haluat poistaa", "Tilaukset", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void takaisinAloitusikkunaan_nappi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var tilaukset = new aloitusikkuna();
            tilaukset.Closed += (s, args) => this.Close();
            tilaukset.Show();
        }
    }
}

// Tekstitiedostojen käyttö http://stackoverflow.com/questions/6416564/how-to-read-a-text-file-in-projects-root-directory
