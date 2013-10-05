using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Proyecto1LFP
{
    class Lectura
    {
        private ArrayList linea = new ArrayList();
        private String lineaLeida = "";
        private String ruta;

        public void setRuta(String ruta)
        {
            this.ruta = ruta;
        }

        public void leer()
        {
            StreamReader lector = new StreamReader(ruta);
            while (lineaLeida != null)
            {
                lineaLeida = lector.ReadLine();
                if (lineaLeida != null)
                    linea.Add(lineaLeida);
            }
            lector.Close();

        }

        public ArrayList getArray()
        {
            return linea;
        }
    }
}
