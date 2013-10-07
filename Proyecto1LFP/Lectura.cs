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
        private int fila = 0;
        private int columna = 0;

        public Lectura(String ruta)
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
                    linea.Add(lineaLeida + "\n");
            }
            lector.Close();

        }

        public ArrayList getArray()
        {
            return linea;
        }

        public String avanzar()
        {
            String lectura = "";
            if (columna >= linea[fila].ToString().Length)
            {
                fila++;
                columna = 0;
            }

            if (fila == linea.Count)
            {
                lectura = "EOF";
            }
            else
            {
                lectura = linea[fila].ToString().Substring(columna,1);
                columna++;
            }
            return lectura;
        }

        public void retroceder()
        {
                columna--;     
        }

        public  void imprimirLectura()
        {
            IEnumerable myList = linea;
            foreach(Object elemento in myList)
                Console.WriteLine("   {0}", elemento);
            Console.WriteLine(linea[0].ToString().Substring( 0 , linea[0].ToString().Length -1));
        }

        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }
    }
}
