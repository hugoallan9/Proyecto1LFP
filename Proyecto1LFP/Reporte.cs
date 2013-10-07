using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1LFP
{
    class Reporte
    {
        private List<int> token = new List<int>();
        private List<String> lexema = new List<String>();
        private String ruta;
        private AnalizadorLexico anaTmp = new AnalizadorLexico("");
        private List<int> posFila = new List<int>();
        private List<int> posColumna = new List<int>();
        public Reporte(List<int> token, List<String> lexema, List<int> posFila, List<int> posColumna,  String ruta)
        {
            this.token = token;
            this.lexema = lexema;
            this.ruta = ruta;
            this.posColumna = posColumna;
            this.posFila = posFila;
        }


        public void escribirCabecera(String titulo)
        {
            try
            {
                StreamWriter impresora = new StreamWriter(@ruta);
                //Imprimiedo la cabecera
                impresora.Write("<HTML lang = \" es \" >" + "\n");
                impresora.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" + "\n");
                impresora.Write("\t <HEAD>" + "\n");
                impresora.Write("\t\t <TITLE> " + titulo + "</TITLE> \n");
                impresora.Write("<style type=\"text/css\">\n" +
                "<!--\n" +
                "@import url(\"style.css\");\n" +
                "-->\n" +
                "</style>");
                impresora.Write("\t </HEAD> \n");
                impresora.Write("\t <BODY> \n");
                impresora.Write("<div align = \"center\"> \n");
                impresora.Write("\t <b>" + "<font size = 7>" + titulo + "</font>" + "</b> \n");
                impresora.Write("</div> \n");
                impresora.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void escribirLexemas()
        {
            try
            {
            StreamWriter impresora = new StreamWriter(@ruta, true);
            impresora.Write( "<div align = \"center\"> \n");
            impresora.Write("      <table id=\"newspaper-b\" width=\"100\" cellspacing=\"2\" cellpadding=\"25\" border=\"0\">");
            impresora.Write("<thead>\n" +
            "<tr>\n" +
            "<th scope=\"col\"> No. Palabra </th>\n" +
            "<th scope=\"col\"> Token</th>\n" +
            "<th scope=\"col\"> Tipo</th>\n" +
            "<th scope=\"col\"> Lexema</th>\n" +
            "<th scope=\"col\"> Linea </th>\n" +
            "<th scope=\"col\">  Columna </th>\n" +
            "<th scope=\"col\">  Palabra Reservada </th>\n" +
            "</tr>\n" +
            "</thead>");
            
            impresora.Write("<tbody>");
            for ( int i = 0 ; i < lexema.Count  ; i++){
                if (token[i] != 999)
                {
                    impresora.Write("<tr>\n" +
               "    <td >\n" +
               "   <font face=\"verdana, arial, helvetica\" size=2>\n"
               + (i + 1) + "\n" +
               "   </font>\n" +
               "   </td>\n");
                    impresora.Write(
                   "    <td >\n" +
                   "   <font face=\"verdana, arial, helvetica\" size=2>\n"
                   + token[i] + "\n" +
                   "   </font>\n" +
                   "   </td>\n");
                    impresora.Write(
                  "    <td >\n" +
                  "   <font face=\"verdana, arial, helvetica\" size=2>\n"
                  + anaTmp.getTipo(token[i]) + "\n" +
                  "   </font>\n" +
                  "   </td>\n");
                    impresora.Write(
                  "    <td >\n" +
                  "   <font face=\"verdana, arial, helvetica\" size=2>\n"
                  + lexema[i] + "\n" +
                  "   </font>\n" +
                  "   </td>\n");
                    impresora.Write(
                  "    <td >\n" +
                  "   <font face=\"verdana, arial, helvetica\" size=2>\n"
                  + posFila[i] + "\n" +
                  "   </font>\n" +
                  "   </td>\n");
                    impresora.Write(
                  "    <td >\n" +
                  "   <font face=\"verdana, arial, helvetica\" size=2>\n"
                  + posColumna[i] + "\n" +
                  "   </font>\n" +
                  "   </td>\n");
                    impresora.Write(
                    "    <td >\n" +
                    "   <font face=\"verdana, arial, helvetica\" size=2>\n"
                    + esReservada(token[i]) + "\n" +
                    "   </font>\n" +
                    "   </td>\n" + "</tr>");
                }
               
                
               
            }
            
            
                impresora.Write("</table>\n " + "</div> \n" + "</tbody>" + "</BODY> \n" + "</HTML>");
                impresora.Close();
        }
            catch(IOException e){
            Console.WriteLine("Error: " + e.Message);
            
        }
        }

        private String esReservada(int get)
        {
            if (get >= 8 && get <= 22)
            {
                return "SI";
            }
            else
            {
                return "NO";
            }
        }


        }
    }

