using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHSV
{
    public partial class Form1 : Form
    {
        int r, g, b;
        Double h, s, v;
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            degistir2();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            degistir2();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            degistir2();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            degistir();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            degistir();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            degistir();
        }

        private void degistir()
        {
            
            h = (trackBar4.Value/1.0);
            s = trackBar5.Value / 360.0;
            v = trackBar6.Value / 360.0;

            
            

            panel1.BackColor = ColorFromHSV(h, s, v, out r, out g , out b);
            textBox1.Text = h.ToString();
            trackBar1.Value = r;
            trackBar2.Value = g;
            trackBar3.Value = b;


        }

        private void degistir2()
        {
            r = trackBar1.Value;
            g = trackBar2.Value;    
            b = trackBar3.Value;
            Color newcol = Color.FromArgb(r, g, b);
            panel1.BackColor = newcol;
            ColorToHSV(newcol, out h, out s, out v);

            int aa = Convert.ToInt32(h);
            int bb = Convert.ToInt32(s * 360.0);
            int cc = Convert.ToInt32(v * 360.0);

            
            
            trackBar4.Value = aa;
            trackBar5.Value = bb;
            trackBar6.Value = cc;
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }



        public static Color ColorFromHSV(double hue, double saturation, double value, out  int a, out int b, out int c)
        {

            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);

            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
            {
                a = v; b = t; c = p;
                return Color.FromArgb(255, v, t, p);
            }


            else if (hi == 1)
            {
                a = q; b = v; c = p;
                return Color.FromArgb(255, q, v, p);
            }
            else if (hi == 2)
            {
                a = p; b = v; c = t;
                return Color.FromArgb(255, p, v, t);
            }
                
            else if (hi == 3)
            {
                a = p; b = q; c = v;
                return Color.FromArgb(255, p, q, v);
            }
                
            else if (hi == 4)
            {
                a = t; b = p; c = v;
                return Color.FromArgb(255, t, p, v);
            }
                
            else
            {
                a = v; b = p; c = q;
                return Color.FromArgb(255, v, p, q);
            }
                
        }
    }
}
