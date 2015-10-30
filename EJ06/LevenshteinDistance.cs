using System;

namespace EJ06
{
    public class CalculadorDistanciaLevenshtein
    {
        private int[,] d;
        private string cadena1;
        private string cadena2;

        public CalculadorDistanciaLevenshtein (string pBusqueda, string nombreCompleto)
        {
            // d es una tabla con m+1 renglones y n+1 columnas
            cadena1 = pBusqueda;
            cadena2 = nombreCompleto;
            d = new int[cadena1.Length + 1, cadena2.Length + 1];
        }
            
        public double Calcular()
        {
            double porcentaje = 0;
            int costo = 0;
            int m = cadena1.Length;
            int n = cadena2.Length;
            

            // Verifica que exista algo que comparar
            if (n == 0) return m;
            if (m == 0) return n;

            // Llena la primera columna y la primera fila.
            for (int i = 0; i <= m; d[i, 0] = i++) ;
            for (int j = 0; j <= n; d[0, j] = j++) ;


            /// recorre la matriz llenando cada unos de los pesos.
            /// i columnas, j renglones
            for (int i = 1; i <= m; i++)
            {
                // recorre para j
                for (int j = 1; j <= n; j++)
                {
                    // si son iguales en posiciones equidistantes el peso es 0
                    // de lo contrario el peso suma a uno.
                    costo = (cadena1[i - 1] == cadena2[j - 1]) ? 0 : 1;
                    d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1,  //Eliminacion
                                  d[i, j - 1] + 1),                             //Inserccion 
                                  d[i - 1, j - 1] + costo);                     //Sustitucion
                }
            }

            // Calculamos el porcentaje de cambios en la palabra.
            if (cadena1.Length > cadena2.Length)
                porcentaje = ((double)d[m, n] / (double)cadena1.Length);
            else
                porcentaje = ((double)d[m, n] / (double)cadena2.Length);
            return porcentaje;
        }
    }
}