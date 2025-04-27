using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Simulacion.Vistas
{
    public partial class MenuPrincipal : Form
    {
        private static MenuPrincipal _instance;
        public static MenuPrincipal Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new MenuPrincipal();
                }
                return _instance;
            }
        }

        private const int espacioEntreBotones = 10;
        private Point _centroVentana;
        public MenuPrincipal()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath+@"\img\fondo.png");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            _centroVentana = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);


            Image imagenOriginal = Image.FromFile(Application.StartupPath + @"\img\play4.png");
            Image imagenRedimensionada = RedimensionarImagen(imagenOriginal, 25, 25);
            this.button1.Image = imagenRedimensionada;

            Image imagenOriginal2 = Image.FromFile(Application.StartupPath + @"\img\info1.png");
            Image imagenRedimensionada2 = RedimensionarImagen(imagenOriginal2, 25, 25);
            this.button2.Image = imagenRedimensionada2;

            this.Resize += Form_Resize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sim = new SimuladorView(this);
            sim.Show();
            this.Hide();

        }
        public static Image RedimensionarImagen(Image imagen, int ancho, int alto)
        {
            // Crear un nuevo bitmap del tamaño deseado
            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            // Crear un objeto Graphics para dibujar en el nuevo bitmap
            Graphics g = Graphics.FromImage(nuevoBitmap);
            // Establecer la calidad de la interpolación
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Dibujar la imagen original en el nuevo bitmap, redimensionándola
            g.DrawImage(imagen, 0, 0, ancho, alto);
            // Liberar el objeto Graphics
            g.Dispose();

            // Retornar el nuevo bitmap redimensionado
            return nuevoBitmap;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            CentrarBotones();
        }

        private void CentrarBotones()
        {
            int nuevoCentroX = this.ClientSize.Width / 2;
            int nuevoCentroY = this.ClientSize.Height / 2;

            button1.Left = nuevoCentroX - button1.Width / 2;
            button1.Top = nuevoCentroY - button1.Height - (espacioEntreBotones / 2); // Ajusta la posición vertical

            // Centra el botón "Consideraciones previas" debajo del primero
            button2.Left = nuevoCentroX - button1.Width / 2;
            button2.Top = nuevoCentroY + (espacioEntreBotones / 2); // Ajusta la posición vertical
        }


        

    }


}
