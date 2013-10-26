using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Proyecto1LFP
{
    class AnalizadorLexico
    {
        private String ruta;
        private List<String> mensajeError;
        private Lectura lector;
        private String valorLexema;
        private List<int> token;
        private List<int> posFila;
        private List<int> posColumna;
        private List<String> lexema;
        private int stringAbierto, estado;
        private Boolean aceptaTodo;
        private int tokenLlaveAbierta;
        private int tokenLlaveCerrada;
        private int tokenVariable;
        private int tokenComa;
        private int tokenString;
        private int tokenReal;
        private int tokenEntero;
        private int tokenEncabezado;
        private int tokenTitulo;
        private int tokenSubTitulo;
        private int tokenAutor;
        private int tokenRef;
        private int tokenSalto;
        private int tokenDocumento;
        private int tokenVar;
        private int tokenAsigna;
        private int tokenSum;
        private int tokenAvg;
        private int tokenMax;
        private int tokenMin;
        private int tokenCont;
        private int tokenEscribir;
        private int tokenAzul;
        private int tokenRojo;
        private int tokenVerde;
        private int tokenAmarillo;
        private int tokenNegro;
        private int tokenIzquierda;
        private int tokenDerecha;
        private int tokenCentro;
        private int tokenSaltoLinea;
        private int tokenError;

        public AnalizadorLexico(String ruta)
        {
            this.ruta = ruta;
            initComponents();
            definirTokens();
        }

        private void definirTokens()
        {
            tokenLlaveAbierta = 1;
            tokenLlaveCerrada = 2;
            tokenVariable = 3;
            tokenComa = 4;
            tokenString = 5;
            tokenReal = 6;
            tokenEntero = 7;
            tokenEncabezado = 8;
            tokenTitulo = 9;
            tokenSubTitulo = 10;
            tokenAutor = 11;
            tokenRef = 12;
            tokenSalto = 13;
            tokenDocumento = 14;
            tokenVar = 15;
            tokenAsigna = 16;
            tokenSum = 17;
            tokenAvg = 18;
            tokenMax = 19;
            tokenMin = 20;
            tokenCont = 21;
            tokenEscribir = 22;
            tokenAzul = 23;
            tokenRojo = 24;
            tokenVerde = 25;
            tokenAmarillo = 26;
            tokenNegro = 27;
            tokenIzquierda = 28;
            tokenCentro = 29;
            tokenDerecha = 30;
            tokenSaltoLinea = 998;
            tokenError = 999;
        }

        private void initComponents()
        {
            valorLexema = "";
            token = new List<int>();
            lexema = new List<String>();
            mensajeError = new List<String>();
            posFila = new List<int>();
            posColumna = new List<int>();
            stringAbierto = 0;
            aceptaTodo = false;
            estado = 0;
            lector = new Lectura(ruta);
        }

        public int esReservada(String palabra)
        {
            int token = 300;
            if (String.Compare(palabra, "encabezado", true) == 0) token = tokenEncabezado;
            if (String.Compare(palabra, "titulo", true) == 0) token = tokenTitulo;
            if (String.Compare(palabra, "subtitulo", true) == 0) token = tokenSubTitulo;
            if (String.Compare(palabra, "autor", true) == 0) token = tokenAutor;
            if (String.Compare(palabra, "ref", true) == 0) token = tokenRef;
            if (String.Compare(palabra, "salto", true) == 0) token = tokenSalto;
            if (String.Compare(palabra, "documento", true) == 0) token = tokenDocumento;
            if (String.Compare(palabra, "var", true) == 0) token = tokenVar;
            if (String.Compare(palabra, "asigna", true) == 0) token = tokenAsigna;
            if (String.Compare(palabra, "sum", true) == 0) token = tokenSum;
            if (String.Compare(palabra, "avg", true) == 0) token = tokenAvg;
            if (String.Compare(palabra, "max", true) == 0) token = tokenMax;
            if (String.Compare(palabra, "min", true) == 0) token = tokenMin;
            if (String.Compare(palabra, "cont", true) == 0) token = tokenCont;
            if (String.Compare(palabra, "escribir", true) == 0) token = tokenEscribir;
            return token;
        }

        private int esColor(String palabra)
        {
            int token = 600;
            palabra = palabra.Substring(1, palabra.Length - 2);
            palabra = palabra.Trim();
            if (String.Compare(palabra, "azul", true) == 0) token = tokenAzul;
            if (String.Compare(palabra, "rojo", true) == 0) token = tokenRojo;
            if (String.Compare(palabra, "verde", true) == 0) token = tokenVerde;
            if (String.Compare(palabra, "amarillo", true) == 0) token = tokenAmarillo;
            if (String.Compare(palabra, "negro", true) == 0) token = tokenNegro;
            return token;
        }

        private int esPosicion(String palabra)
        {
            int token = 900;
            palabra = palabra.Substring(1, palabra.Length - 2);
            palabra = palabra.Trim();
            if (String.Compare(palabra, "i", true) == 0) token = tokenIzquierda;
            if (String.Compare(palabra, "c", true) == 0) token = tokenCentro;
            if (String.Compare(palabra, "d", true) == 0) token = tokenDerecha;
            return token;
        }

        private Boolean perteneceATodo(Char silaba)
        {
            Boolean respuesta = true;
            if (silaba.CompareTo('\'') == 0 || silaba.CompareTo('{') == 0)
                respuesta = false;
            return respuesta;
        }

        public void analizarSilaba(Char silaba, Boolean EOF)
        {
            switch (estado)
            {
                case 0:
                    if (aceptaTodo)
                    {
                        if (perteneceATodo(silaba))
                        {
                            estado = 6;
                            valorLexema = valorLexema + silaba;
                        }
                        else if (silaba.CompareTo('\'') == 0)
                        {
                            //Tener cuidado con esto, otra posiblidad es aceptarlo de un solo.
                            estado = 5;
                        }
                        else
                        {
                            rutinaError("No puedes empezar una etiqueta, porque hay una cadena abierta.");
                        }
                    }
                    else if (silaba.CompareTo('{') == 0)
                    {
                        estado = 1;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('}') == 0)
                    {
                        estado = 2;
                        valorLexema += silaba;
                    }
                    else if (Char.IsLetter(silaba))
                    {
                        estado = 3;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo(',') == 0)
                    {
                        estado = 4;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('\'') == 0)
                    {
                        estado = 5;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('+') == 0 || silaba.CompareTo('-') == 0)
                    {
                        estado = 7;
                        valorLexema += silaba;
                    }
                    else if (Char.IsDigit(silaba))
                    {
                        estado = 8;
                        valorLexema += silaba;
                    }
                    else if (esSeparador(silaba))
                    {
                        estado = 0;
                    }
                    else
                    {
                        valorLexema = "" +silaba;
                        rutinaError("El símbolo no comienza ninguna ER");
                        lector.avanzar();
                    }
                    break;
                case 1:
                    lector.retroceder();
                    rutinaAceptación(tokenLlaveAbierta);
                    break;
                case 2:
                    lector.retroceder();
                    rutinaAceptación(tokenLlaveCerrada);
                    if (stringAbierto > 0)
                        aceptaTodo = true;
                    break;
                case 3:
                    if (Char.IsLetter(silaba))
                    {
                        estado = 3;
                        valorLexema += silaba;
                    }
                    else if (char.IsDigit(silaba))
                    {
                        estado = 3;
                        valorLexema += silaba;
                    }
                    else
                    {
                        lector.retroceder();
                        int tokenRTmp = esReservada(valorLexema);
                        if (tokenRTmp != 300)
                        {
                            rutinaAceptación(tokenRTmp);
                        }
                        else
                        {
                            rutinaAceptación(tokenVariable);
                        }

                    }
                    break;
                case 4:
                    lector.retroceder();
                    rutinaAceptación(tokenComa);
                    break;
                case 5:
                    if (perteneceATodo(silaba))
                    {
                        estado = 9;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('\'') == 0)
                    {
                        estado = 10;

                    }
                    else
                    {
                        rutinaError("Debes escribir algo antes de iniciar otra ER");
                    }
                    break;
                case 6:
                    if (perteneceATodo(silaba))
                    {
                        estado = 6;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('\'') == 0)
                    {
                        estado = 11;
                        valorLexema += silaba;
                    }
                    else
                    {
                        aceptaTodo = false;
                        lector.retroceder();
                        rutinaAceptación(tokenString);
                    }
                    break;
                case 7:
                    if (Char.IsDigit(silaba))
                    {
                        estado = 8;
                        valorLexema += silaba;
                    }
                    else
                    {
                        rutinaError("Esperaba un dígito pero vino:" + silaba);
                    }
                    break;
                case 8:
                    if (Char.IsDigit(silaba))
                    {
                        estado = 8;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('.') == 0)
                    {
                        estado = 12;
                        valorLexema += silaba;
                    }
                    else
                    {
                        lector.retroceder();
                        rutinaAceptación(tokenEntero);
                    }
                    break;
                case 9:
                     if (EOF)
                    {
                        lector.retroceder();
                        rutinaAceptación(tokenString);
                    }
                    else if (perteneceATodo(silaba))
                    {
                        estado = 9;
                        valorLexema += silaba;
                    }
                    else if (silaba.CompareTo('\'') == 0)
                    {
                        estado = 10;
                        valorLexema += silaba;
                    }
                    else
                    {
                        lector.retroceder();
                        rutinaAceptación(tokenString);
                        stringAbierto++;
                    }
                    break;
                case 10:
                    lector.retroceder();
                    int tokenCTmp = esColor(valorLexema);
                    int tokenPTmp = esPosicion(valorLexema);

                    if (tokenCTmp != 600)
                    {
                        rutinaAceptación(tokenCTmp);
                    }
                    else if (tokenPTmp != 900)
                    {
                        rutinaAceptación(tokenPTmp);
                    }
                    else
                    {
                        rutinaAceptación(tokenString);
                    }
                    break;
                case 11:
                    lector.retroceder();
                    rutinaAceptación(tokenString);
                    aceptaTodo = false;
                    stringAbierto--;
                    break;
                case 12:
                    if (Char.IsDigit(silaba))
                    {
                        estado = 13;
                        valorLexema += silaba;
                    }
                    else
                    {
                        rutinaError("Esperaba un dígito pero vino: " + silaba);
                    }
                    break;
                case 13:
                    if (Char.IsDigit(silaba))
                    {
                        estado = 13;
                        valorLexema += silaba;
                    }
                    else
                    {
                        lector.retroceder();
                        rutinaAceptación(tokenReal);
                    }
                    break;


            }
        }

        private bool esSeparador(char silaba)
        {
            Boolean respuesta = false;
            switch (silaba)
            {
                case '\t':
                    respuesta = true;
                    break;
                case '\r':
                    respuesta = true;
                    break;
                case '\n':
                    respuesta = true;
                    lexema.Add("\n");
                    token.Add(tokenSaltoLinea);
                    break;
                case '\b':
                    respuesta = true;
                    break;
                case ' ':
                    respuesta = true;
                    break;
                default:
                    respuesta = false;
                    break;
            }
            return respuesta;
        }

        private void rutinaError(string p)
        {
            lector.retroceder();
            estado = 0;
            lexema.Add(valorLexema);
            token.Add(tokenError);
            posFila.Add(calcularFila());
            posColumna.Add(calcularColumna());
            mensajeError.Add(p);
            Console.WriteLine(valorLexema + "  con Token:  " + tokenError);
            valorLexema = "";
            
        }

        public List<String> getArrayMensajeError()
        {
            return mensajeError;
        }

        private void rutinaAceptación(int tokenTmp)
        {
            estado = 0;
            lexema.Add(valorLexema);
            token.Add(tokenTmp);
            posFila.Add(calcularFila());
            posColumna.Add(calcularColumna());
            Console.WriteLine(valorLexema + "  con Token:  " + tokenTmp);
            valorLexema = "";
        }

        private int calcularFila()
        {
            int fila = lector.getFila();
            if (valorLexema.Length > lector.getColumna() + 1)
            {
                fila--;
            }
            fila++;
            return fila;

        }

        private int calcularColumna()
        {
            int columna = lector.getColumna() + 1;
            if (valorLexema.Length > columna)
            {
                //ArrayList tmp = new ArrayList();
                //tmp = lector.getArray();
                //columna = tmp[lector.getFila()].ToString().Length - (valorLexema.Length - columna);
            }
            else
            {
                columna = columna - valorLexema.Length;
            }
            return columna;

        }

        public void analizarCompletamente()
        {
            lector.leer();
            Char entrada = ' ';
            String silaba = lector.avanzar();
            Console.WriteLine("*****************Inicio del Analisis***************");
            while (silaba.CompareTo("EOF") != 0)
            {
                entrada = silaba[0];
                analizarSilaba(entrada, false);
                silaba = lector.avanzar();
            }
            //lector.avanzar();
            analizarSilaba(entrada, true);
            Console.WriteLine("*****************Fin del Analisis***************");
            Console.WriteLine("Capacidad de error: " + mensajeError.Count);
        
        }

        public List<int> getArrayToken()
        {
            return token;
        }

        public List<String> getArrayLexema()
        {
            return lexema;
        }

        public String getTipo(int token)
        {
            String tipo = "";
            switch (token)
            {
                case 1:
                    tipo = "Llave de apertura";
                    break;

                case 2:
                    tipo = "Llave de cierre";
                    break;

                case 3:
                    tipo = "variable";
                    break;

                case 4:
                    tipo = "coma";
                    break;

                case 5:
                    tipo = "Cadena";
                    break;

                case 6:
                    tipo = "Número Real";
                    break;

                case 7:
                    tipo = "Número Entero";
                    break;

                case 8:
                    tipo = "Palabra Reservada";
                    break;

                case 9:
                    tipo = "Palabra Reservada";
                    break;

                case 10:
                    tipo = "Palabra Reservada";
                    break;

                case 11:
                    tipo = "Palabra Reservada";
                    break;

                case 12:
                    tipo = "Palabra Reservada";
                    break;

                case 13:
                    tipo = "Palabra Reservada";
                    break;

                case 14:
                    tipo = "Palabra Reservada";
                    break;

                case 15:
                    tipo = "Palabra Reservada";
                    break;

                case 16:
                    tipo = "Palabra Reservada";
                    break;

                case 17:
                    tipo = "Palabra Reservada";
                    break;

                case 18:
                    tipo = "Palabra Reservada";
                    break;

                case 19:
                    tipo = "Palabra Reservada";
                    break;

                case 20:
                    tipo = "Palabra Reservada";
                    break;

                case 21:
                    tipo = "Palabra Reservada";
                    break;

                case 22:
                    tipo = "Palabra Reservada";
                    break;

                case 23:
                    tipo = "Color";
                    break;

                case 24:
                    tipo = "Color";
                    break;

                case 25:
                    tipo = "Color";
                    break;

                case 26:
                    tipo = "Color";
                    break;

                case 27:
                    tipo = "Color";
                    break;

                case 28:
                    tipo = "Posición";
                    break;

                case 29:
                    tipo = "Posición";
                    break;

                case 30:
                    tipo = "Posición";
                    break;
            }
            return tipo;
        }

        public void limpiarArrays()
        {
            lexema.RemoveAll(item => item == "\n");
            token.RemoveAll(item => item == 998);

        }

      


        public List<int> getArrayPosFila()
        {
            return posFila;
        }

        public List<int> getArrayPosColumna()
        {
            return posColumna;
        }


    }     
}
