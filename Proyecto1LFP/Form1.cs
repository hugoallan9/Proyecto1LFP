using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Proyecto1LFP
{
    public partial class Form1 : Form
    {
        private AnalizadorLexico ana;
        private String ruta = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirFicheroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog selector = new OpenFileDialog();
            selector.Filter = "Archivos lfp | *.lfp";
            selector.FileName = "Selecciona un archivo";
            selector.Title = "Sistema de Generación de Noticias";
            selector.InitialDirectory = "C:\\";
            if (selector.ShowDialog() == DialogResult.OK)
            {
                ana = new AnalizadorLexico(selector.FileName);
                ruta = Path.GetDirectoryName(selector.FileName) + "\\" +Path.GetFileNameWithoutExtension(selector.FileName);
                Console.WriteLine(ruta);
                
                Lectura lec = new Lectura(selector.FileName);
                lec.leer();
                foreach (Object obj in lec.getArray())
                {
                    ingresoRb.AppendText(obj.ToString());
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void analizarBt_Click(object sender, EventArgs e)
        {
            ana.analizarCompletamente();
            ingresoRb.Clear();
            for (int i = 0; i < ana.getArrayLexema().Count; i++ )
            {
                ingresoRb.SelectionColor = cambiarColor(ana.getArrayToken()[i]);
                ingresoRb.AppendText(ana.getArrayLexema()[i] + " ");
            }
            //limpiando los arrays
            ana.limpiarArrays();

        }

        private Color cambiarColor(int p)
        {
            Color color = Color.Black;
            if (p >= 8 && p <= 22)
            {
                color = Color.Blue;
            }
            else if (p >= 23 && p <= 27)
            {
                color = Color.BurlyWood;
            }
            else if (p >= 28 && p <= 30)
            {
                color = Color.DarkGreen;
            }
            else if (p == 5)
            {
                color = Color.DarkCyan;
            }
            else if (p == 999)
            {
                color = Color.Red;
            }
            return color;
        }

        private void tablaSimbolosBt_Click(object sender, EventArgs e)
        {
            
                Reporte reporte = new Reporte(ana.getArrayToken(), ana.getArrayLexema(), ana.getArrayPosFila(), ana.getArrayPosColumna(), ruta + ".lex" );
                reporte.escribirCabecera("Tabla de Símbolos");
                reporte.escribirLexemas();
                Process.Start(ruta + ".lex");
            
        }

        private void tablaErroresBt_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte(ana.getArrayToken(), ana.getArrayLexema(), ana.getArrayPosFila(), ana.getArrayPosColumna(), ruta + ".error");
            reporte.escribirCabecera("Tabla de Errores");
            reporte.escribirErrores(ana.getArrayMensajeError());

            Process.Start(ruta + ".error");
        }
        
    }
}
