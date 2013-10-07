using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1LFP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Lectura prueba = new Lectura(@"D:\Dropbox\Sistemas\2Semestre2013\Lenguajes\Laboratorio\Proyectos\Proyecto1\Proyecto1LFP\prueba.txt");
            prueba.leer();
            prueba.imprimirLectura();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
