using din_flori.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace din_flori
{
    public partial class Form1 : Form
    {
        Bitmap imagine;
        string nume_initial;
        double[,] medie = new double[4,503];
        int latime, inaltime, latimeNoua, inaltimeNoua;
        DirectoryInfo folder_poze_flori = new DirectoryInfo(@"..\..\Resurse\colectie");

        public Form1()
        {
            InitializeComponent();
            progressBar.Visible = false;
            CalculeazaMediaFlori();
        }

        private void b_selectare_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image files (*.jpg, *.png, *.jpeg) | *.jpg; *.png; *jpeg";

            if (DialogResult.OK == ofile.ShowDialog())
            {
                // incarc imaginea
                Image img = Image.FromFile(ofile.FileName);
                imagine = new Bitmap(img);
                this.poza.Image = imagine;
                latime = imagine.Width;
                inaltime = imagine.Height;
                b_salvare.Enabled = false;
                b_conversie.Enabled = true;


                // retin numele initial

                // iau path ul si elimin tot ce e inaintea numelui
                string imagePath = ofile.FileName.ToString();
                nume_initial = imagePath.ToString();
                nume_initial = nume_initial.Substring(nume_initial.LastIndexOf("\\"));
                nume_initial = nume_initial.Remove(0, 1);

                // elimin .jpg de la final
                int poz  =nume_initial.IndexOf(".");
                nume_initial = nume_initial.Remove(poz, 4);
            }
        }

        private void b_conversie_Click(object sender, EventArgs e)
        {
            if (numericUpDown_nrmultiplicare.Value >= 100)
            {
                if(MessageBox.Show("Cu cat numarul de poze cu flori pe latime " +
                    "este mai mare, cu atat mai mult timp va dura conversia.\n" +
                    "Esti sigur ca vrei sa faci conversia cu " + numericUpDown_nrmultiplicare.Value +
                    " flori pe latime?" , "Atentie!" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Redimensionare();

                    InlocuireCuFlori();

                    this.poza.Image = imagine;
                    b_exit.Enabled = true;
                    b_salvare.Enabled = true;
                }
            }
            else
            {
                Redimensionare();

                InlocuireCuFlori();

                this.poza.Image = imagine;
                b_exit.Enabled = true;
                b_salvare.Enabled = true;
            }
            
        }

        private void b_salvare_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image files (*.jpg, *.png, *.jpeg) | *.jpg; *.png; *jpeg";
            dialog.FileName = nume_initial +  "_dinflori";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagine.Save(dialog.FileName, ImageFormat.Jpeg);
                b_salvare.Enabled = false;
            }
        }

        void CalculeazaMediaFlori()
        {
            int k, sumaR, sumaG, sumaB, i, j, latime_curenta, inaltime_curenta, d;
            double nr_pix_floare;
            k = 1;
            
            for(d = 1; d <= 500; d++)
            {
                Image fl = Image.FromFile(folder_poze_flori + @"\" + d + ".png");
                Bitmap floare = new Bitmap(fl);
                latime_curenta = floare.Width;
                inaltime_curenta = floare.Height;
                nr_pix_floare = latime_curenta * inaltime_curenta; // cati pixeli sunt in floarea curenta

                sumaR = sumaG = sumaB = 0;
                for (i = 0; i < latime_curenta; i++)
                    for(j = 0; j < inaltime_curenta; j++)
                    {
                        sumaR += floare.GetPixel(i, j).R;
                        sumaG += floare.GetPixel(i, j).G;
                        sumaB += floare.GetPixel(i, j).B;
                    }

                medie[0, k] = sumaR / nr_pix_floare;
                medie[1, k] = sumaG / nr_pix_floare;
                medie[2, k] = sumaB / nr_pix_floare;
                k++;
            }
        }

        Bitmap ResizeBitmap(Bitmap bmp, int width, int height) // de pe net :D
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        void Redimensionare()
        {
            int numar_multiplicare;
            numar_multiplicare = Convert.ToInt32(Math.Round(numericUpDown_nrmultiplicare.Value, 0));

            // fac regula de 3 simpla:
            // latime   ..........  40 * numar_multiplicare
            // inaltime ..........  x
            latimeNoua = 40 * numar_multiplicare;
            inaltimeNoua = (((inaltime * latimeNoua) / latime) / 28) * 28;
            // fac / 28 * 28 ca sa nu imi ramana spatiu gol, chiar daca modific putin raportul pozei

            imagine = ResizeBitmap(imagine, latimeNoua, inaltimeNoua);

        }

        double Distanta(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double dist;
            double p = 10.0; // teoretic cu cat e mai mare p cu atat mai buna e aproximatia la Minkovski

            // distanta euclidiana:
            dist = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));

            // distanta Manhattan:
            //dist = Math.Abs(x2 - x1) + Math.Abs(y2 - y1) + Math.Abs(z2 - z1);

            // distanta Minkovski
            //dist = Math.Pow(Math.Pow(Math.Abs(x2 - x1), p) + Math.Pow(Math.Abs(y2 - y1), p) + Math.Pow(Math.Abs(z2 - z1), p), 1 / p);

            return dist;
        }

        void InlocuireCuFlori()
        {
            progressBar.Value = 0;
            progressBar.Visible = true;

            int i, j, d, k, poz;
            double medieR, medieG, medieB, dist_minima, dist_curenta, sumaR, sumaG, sumaB;

            //calculez dimensiunile primei flori ca sa am punct de reper pentru fiecare fereastra
            Image fl1 = Image.FromFile(folder_poze_flori + @"\" + 1 + ".png");
            Bitmap floare1 = new Bitmap(fl1);

            int latime_fereastra, inaltime_fereastra, nr_pix_floare;
            latime_fereastra = floare1.Width;//40
            inaltime_fereastra = floare1.Height;//28
            nr_pix_floare = latime_fereastra * inaltime_fereastra; // cati pixeli sunt intr-o floare

            progressBar.Maximum = latimeNoua;

            //inlocuirea efectiva
            for (i = 0; i < latimeNoua; i += latime_fereastra)
            {
                progressBar.Value = i;
                for (j = 0; j < inaltimeNoua; j += inaltime_fereastra)
                {
                    //fac media ferestrei curente
                    sumaR = sumaG = sumaB = 0;
                    for (k = 0; k < latime_fereastra; k++)
                        for (d = 0; d < inaltime_fereastra; d++)
                        {
                            sumaR += imagine.GetPixel(i + k, j + d).R;
                            sumaG += imagine.GetPixel(i + k, j + d).G;
                            sumaB += imagine.GetPixel(i + k, j + d).B;
                        }
                    medieR = sumaR / nr_pix_floare;
                    medieG = sumaG / nr_pix_floare;
                    medieB = sumaB / nr_pix_floare;

                    //gasesc cea mai apropiata floare de fereastra curenta
                    dist_minima = Distanta(medieR, medieG, medieB, medie[0, 1], medie[1, 1], medie[2, 1]);
                    poz = 1;
                    for (k = 2; k <= 500; k++)
                    {
                        dist_curenta = Distanta(medieR, medieG, medieB, medie[0, k], medie[1, k], medie[2, k]);
                        if (dist_curenta < dist_minima)
                        {
                            dist_minima = dist_curenta;
                            poz = k;
                        }
                    }

                    //copiez floarea de la pozitia poz in fereastra curenta
                    Image fl = Image.FromFile(folder_poze_flori + @"\" + poz + ".png");
                    Bitmap floare = new Bitmap(fl);
                    Color culoare = new Color();
                    for (k = 0; k < latime_fereastra; k++)
                        for (d = 0; d < inaltime_fereastra; d++)
                        {
                            culoare = floare.GetPixel(k, d);
                            imagine.SetPixel(i + k, j + d, culoare);
                        }
                }
            }

            progressBar.Visible = false;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
