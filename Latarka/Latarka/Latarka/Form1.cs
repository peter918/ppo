using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latarka
{


    public partial class Form1 : Form
    {
        Latarka latarka = new Latarka();
        int index;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (latarka.getJest() == true)
            {
                latarka.wlacz();
                if (latarka.getCzySwieci() == true)
                {
                    pictureBox1.Image = new Bitmap(@"C:\Users\Hesu\Desktop\Latarka\Latarka\Latarka\Latarka_Olight_S30_Baton_XML2_[82916]_1200.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pictureBox1.Image = new Bitmap(@"C:\Users\Hesu\Desktop\Latarka\Latarka\Latarka\latarka-taktyczna-fenix_146.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pictureBox1.Image = new Bitmap(@"C:\Users\Hesu\Desktop\Latarka\Latarka\Latarka\latarka-taktyczna-fenix_146.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            latarka.setCzySwieci();
            pictureBox1.Image = new Bitmap(@"C:\Users\Hesu\Desktop\Latarka\Latarka\Latarka\latarka-taktyczna-fenix_146.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            latarka.dodajBaterie(new Bateria(rnd.Next(0, 101)));
            if (latarka.getRozmiar() <= 4)
            {
                listBox1.Items.Add(latarka.getBateriaLatarka().ElementAt(latarka.getRozmiar() - 1));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = 0;
            Random rnd = new Random();
            latarka.dodajZarowke(new Zarowka(rnd.Next(1, 11)));
            label1.Text = latarka.getZarowkaLatarka().ElementAt(index).getJasnosc().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*index = listBox1.SelectedIndex;
            latarka.usunBaterie(index);
            listBox1.Items.RemoveAt(index);
            index--;*/
            if (latarka.getCzySwieci() == false)
            {
                listBox1.Items.Clear();
                index = 0;
                for (int i = 0; i < latarka.getRozmiar(); i++)
                {
                    latarka.usunBaterie(index);
                }
                latarka.setRozmiar();
                label2.Text = null;
                label4.Text = null;
            }
            else
            {
                label4.Text = "Prosze najpierw \nwyłaczyc latarke";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;
            label2.Text = latarka.getBateriaLatarka().ElementAt(index).getMoc()+" V".ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            latarka.usunZarowke();
            label1.Text = null;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if((latarka.getJest() == true) && latarka.getCzySwieci() == false)
            {
                index = 0;
                latarka.usunZarowke();
                label1.Text = null;
                Random rnd = new Random();
                latarka.dodajZarowke(new Zarowka(rnd.Next(1, 11)));
                label1.Text = latarka.getZarowkaLatarka().ElementAt(index).getJasnosc().ToString();
                label4.Text = null;
            }
            else
            {
                label4.Text = "Można wymeinić tylko gdy latarka ma \nwsadzona żarówke i nie jest właczona";
            }
        }
    }

    class Latarka
    {
        private List<Bateria> bateriaLatarka = new List<Bateria>();
        private List<Zarowka> zarowkaLatarka = new List<Zarowka>();

        public List<Bateria> getBateriaLatarka()
        {
            return bateriaLatarka;
        }

        public List<Zarowka> getZarowkaLatarka()
        {
            return zarowkaLatarka;
        }


        private int rozmiar=0;

        public void setRozmiar()
        {
            this.rozmiar = 0;
        }

        public int getRozmiar()
        {
            return rozmiar;
        }

        private Boolean jest = false;

        public Boolean getJest()
        {
            return jest;
        }

        //private Boolean czyWlaczona = false; //czy przycisk

        private Boolean czySwieci = false; //czy swieci

        public Boolean getCzySwieci()
        {
            return czySwieci;
        }

        public Boolean setCzySwieci()
        {
            return czySwieci = false;
        }

        /*public void wlacz()
        {
            if (czyWlaczona == false)
            {
                int zmienna=0;
                czyWlaczona = true;

                for (int i = 0; i < rozmiar; i++)
                {
                    if (bateriaLatarka.ElementAt(i).getMoc() > 15)
                    {
                        zmienna++;
                    }
                }
                if (zmienna >= 2)
                {
                    czySwieci = true;
                }
            }
        }*/

        public void wlacz()
        {
                if ((rozmiar == 2) && (bateriaLatarka.ElementAt(0).getMoc() > 15 && bateriaLatarka.ElementAt(1).getMoc() > 15))
                {
                    czySwieci = true;
                for (int i = 0; i < 2; i++)
                    bateriaLatarka.ElementAt(i).setMoc(bateriaLatarka.ElementAt(i).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                /*bateriaLatarka.ElementAt(0).setMoc(bateriaLatarka.ElementAt(0).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                bateriaLatarka.ElementAt(1).setMoc(bateriaLatarka.ElementAt(1).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());*/
            }
                else if (rozmiar == 3 && (bateriaLatarka.ElementAt(0).getMoc() > 15 && (bateriaLatarka.ElementAt(1).getMoc() > 15 && bateriaLatarka.ElementAt(2).getMoc() > 15)))
                {
                    czySwieci = true;
                for (int i = 0; i < 3; i++)
                    bateriaLatarka.ElementAt(i).setMoc(bateriaLatarka.ElementAt(i).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                /*bateriaLatarka.ElementAt(0).setMoc(bateriaLatarka.ElementAt(0).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                bateriaLatarka.ElementAt(1).setMoc(bateriaLatarka.ElementAt(1).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                bateriaLatarka.ElementAt(2).setMoc(bateriaLatarka.ElementAt(2).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());*/
            }
                else if (rozmiar == 4 && (bateriaLatarka.ElementAt(0).getMoc() > 15 && ((bateriaLatarka.ElementAt(1).getMoc() > 15) && (bateriaLatarka.ElementAt(2).getMoc() > 15 && bateriaLatarka.ElementAt(3).getMoc() > 15))))
                {
                    czySwieci = true;
                for(int i=0; i < 4; i++)
                    bateriaLatarka.ElementAt(i).setMoc(bateriaLatarka.ElementAt(i).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                /*bateriaLatarka.ElementAt(0).setMoc(bateriaLatarka.ElementAt(0).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                bateriaLatarka.ElementAt(1).setMoc(bateriaLatarka.ElementAt(1).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                bateriaLatarka.ElementAt(2).setMoc(bateriaLatarka.ElementAt(2).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());
                bateriaLatarka.ElementAt(3).setMoc(bateriaLatarka.ElementAt(3).getMoc() - zarowkaLatarka.ElementAt(0).getJasnosc());*/
            }
                else czySwieci = false;
        }

        /*public void wlaczLatarke()
        {
            this.czyWlaczona = true;
        }*/

        /*public void wylaczLatarke()
        {
            this.czyWlaczona = false;
        }*/

        public void dodajBaterie(Bateria bateria)
        {
            if(rozmiar < 5)
            {
                bateriaLatarka.Add(bateria);
                rozmiar++;
                //Console.WriteLine("Dodano "+rozmiar+" baterie");
            }
        }

        public void usunBaterie(int index)
        {
            bateriaLatarka.RemoveAt(index);
            rozmiar--;
            /*for (int i = 0; i < rozmiar; i++)
            {
                if (bateriaLatarka.ElementAt(i).getMoc() < 15)
                {
                    bateriaLatarka.RemoveAt(i);
                    rozmiar--;
                }
            }*/
        }

        public void dodajZarowke(Zarowka zarowka)
        {
            if ( jest == false)
            {
                zarowkaLatarka.Add(zarowka);
                Console.WriteLine("Dodano żarówke");
                jest = true;
            }
            else
            {
                Console.WriteLine("Latarka może mieć tylko 1 żarówke");
            }
        }

        public void usunZarowke()
        {
            zarowkaLatarka.RemoveAt(0);
            jest = false;
        }
    }

    class Bateria
    {
        private int moc;

        public Bateria(int moc)
        {
            this.moc = moc;
        }

        public void setMoc(int moc)
        {
            this.moc = moc;
        }

        public int getMoc()
        {
            return moc;
        }
    }

    class Zarowka
    {
        private int jasnosc;

        public Zarowka(int jasnosc)
        {
            this.jasnosc = jasnosc;
        }

        public void setJasnosc(int jasnosc)
        {
            this.jasnosc = jasnosc;
        }

        public int getJasnosc()
        {
            return jasnosc;
        }
    }
}
