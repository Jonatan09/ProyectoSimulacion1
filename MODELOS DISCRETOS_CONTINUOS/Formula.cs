using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODELOS_DISCRETOS_CONTINUOS
{
    class Formula
    {
        class A : Formula
        {
            public void MethodB() { Console.WriteLine("A.MethodB()"); }
        }
        //Factorial
        public double Factorial(int numero)
        {
            if (numero == 0 || numero == 1)
                return 1;
            return (numero) * Factorial(numero - 1);

        }

        public double Factorial1(int numero)
        {
            int i = 2;
            double fac = 1;
            while (i<=numero)
            {
                fac *= i;
                i++;
            }
            return fac;
        }

        //Combinatoria
        public double Combinatoria(int n, int x)
        {
            double resultado = 0;
            int restanx = n - x;

            double X = Factorial(x);
            double N = Factorial(n);
            double restaNX = Factorial(restanx);

            resultado = ((N) / ((X) * (restaNX)));

            return resultado;
        }

        /// <summary>
        /// Distribucion 
        /// </summary>
        
     
        public double[] DistribucionBinomial(decimal p, int n, int x)
        {
            double value;
            double[] resultados = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                value = ((Combinatoria(n, i)) * (Potencia((double)p, i)) * (Potencia((double)(1 - p), (n - i))));
                resultados[i] = (Math.Truncate(value*10000)/10000);
            }
            return resultados;
        }

        //Elevar numero
        public double Potencia(double numero, int potencia)
        {
            double resultado;
            resultado = Math.Pow((double)numero, potencia);
            return resultado;
        }

        //Desviacion Estandar
        public double DesviacionEstandar(int n, decimal p)
        {
            double result = 0;

            result = Math.Sqrt((double)(n*p*(1-p)));
            return result;
        }


        //Media
        public double Media(int n, decimal p)
        {
            double resul;
            resul = (double)(n * p);
            return resul;

        }


        //Varianza
        public double Varianza(int n, decimal p)
        {
            double result;
            result = (double)(n * p * (1 - p));
            return result;
        }

      
        //------Distribucion Bonomial Poblacion infinita---------------

        //Factor de Correccion para poblaciones finitas
        public double FactorCorreccion(int N, int n)
        {
            double resultado;
            resultado = Math.Sqrt(((double)(N-n)/(double)(N-1)));
            return resultado;
        }
           
        //Deviacion para la pobalcion Finita
        public double DesviacionPFinita(int N, int n, decimal p)
        {
            double resultado;
            double FC;
            FC = FactorCorreccion(N,n);
            resultado = FC*(Math.Sqrt((double)(n*p*(1-p))));
            return resultado;
        }




        //Sesgo
        public double Sesgo(int n, decimal p)
        {
            double resultado;
            resultado = (((double)((1 - p)-p))/(Math.Sqrt((double)(n*p*(1-p)))));
            return resultado;
        }
        //Curtosis
        public double Curtosis(int n, decimal p)
        {
            double resultado;
            resultado = (double)3+((double)(1-(6*p*(1-p))) / (Math.Sqrt((double)(n*p*(1-p)))));
            return resultado;
        }


        //Resultados sin rangos
        public Resultados resultados(double[] resultados, string opcionRes,int X )
        {
            List<int> datos = new List<int>();
            Resultados resultados1 = new Resultados();
            double result = 0;
            double mediana = 0;
            switch (opcionRes)
            {
                case "igual":
                    for(int i=0; i < resultados.Length; i++)
                    {
                        if (i==X)
                        {
                            datos.Add(i);
                           // mediana = Mediana(datos);
                            resultados1.result = resultados[i];
                            resultados1.mediana = i;
                            return resultados1;
                        }
                        
                    }
                    break;

                case "mayor":
                        for (int j = X + 1; j < resultados.Length; j++)
                        {
                            result = result + resultados[j];
                        datos.Add(j);
                        }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                    //return result;
                    break;

                case "menor":
                    for (int j = 0; j < X; j++)
                    {
                        result = result + resultados[j];
                        datos.Add(j);
                    }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                 //   return resultados1;
                    //return result;
                    break;
                case "mayorigual":
                    for (int j = X; j < resultados.Length; j++)
                    {
                        result = result + resultados[j];
                        datos.Add(j);
                    }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                    //return resultados1;
                    //return result;
                    break;
                case "menorigual":
                    for (int j = 0; j <= X; j++)
                    {
                        result = result + resultados[j];
                        datos.Add(j);
                    }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                    //return resultados1;
                    break;
                // return result;

                default:
                    break;


            }

            return resultados1;
        }

        //Resultado para los rangos
        public Resultados Resultado2(double[] resultados, int x1, int x2, string opcion)
        {
            List<int> datos = new List<int>();
            Resultados resultados1 = new Resultados();
            double result = 0;
            double mediana = 0;
            switch (opcion)
            {
                case "entre":
                    if (x1 > x2)
                    {
                        for (int i = x2; i <= resultados.Length; i++)
                        {
                            if (i <= x1)
                            {
                                result = result + resultados[i];
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }

                    }
                    else
                    {
                        for (int i = x1; i <= resultados.Length; i++)
                        {
                            if (i <= x2)
                            {
                                result = result + resultados[i];
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }
                    }
                    break;

                case "menorigualsinigual":
                    if (x1 > x2)
                    {
                        for (int i = x2 + 1; i <= resultados.Length; i++)
                        {
                            if (i < x1)
                            {
                                result = result + resultados[i];
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }
                    }
                    else
                    {
                        for (int i = x1 + 1; i <= resultados.Length; i++)
                        {
                            if (i < x2)
                            {
                                result = result + resultados[i];
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }
                    }
                    break;
            }

            mediana = Mediana(datos);
            resultados1.result = result;
            resultados1.mediana = mediana;
            return resultados1;
          //  return result;

        }

        
        public double Mediana(List<int> datos)
        {
            double resultado;
            //resultado = datos.Count;
            if ((datos.Count%2)==0)
            {
                resultado = Par(datos);
              //  MessageBox.Show("La mediana es: "+resultado);
            }
            else
            {
                resultado = Impar(datos);
              //  MessageBox.Show("La mediana es: " + resultado);
            }

            return resultado;
        }

        //Encontrar la mitad de una lista
        public double Par(List<int> datos)
        {
            double resultado;
            int mitad = 0;
            mitad = ((datos.Count)/2);
            resultado = ((double)(datos[mitad]+datos[mitad-1]) / (2));
            return resultado;
        }

        public double Impar(List<int> datos)
        {
            double resultado;
            int mitad = 0;
            mitad = ((datos.Count-1)/2);
            resultado = (double)datos[mitad];
            return resultado;
        }


        //Respuestas del Sesgo
        public string TipoSesgo(double media, double mediana)
        {
            string respuesta="";
            if (media<mediana)
            {
                respuesta = "Sesgo Negativo";
            }else if (media==mediana)
            {
                respuesta = "Sesgo Nulo";
            }
            else if(media>mediana)
            {
                respuesta = "Sesgo Positivo";
            }

            return respuesta;

        }


        //Hipergeometrica
        //La que x esta por si acaso
        public double[] DistribucionHipergeometrica(int n, int K, int N, int x)
        {
            double value;
            double dividendo = 0;
            double divisor = 0;
            double[] resultados = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dividendo = ((double)(Factorial1(N-K))*(Factorial1(K))*(Factorial1(n))*(Factorial1(N-n)));
                divisor = ((double)(Factorial1(n-i))*(Factorial1(N-K-n+i))*Factorial1(i)*(Factorial1(K-i))*Factorial1(N));
                value = ((double)(dividendo/divisor));
                resultados[i] = (Math.Truncate(value*10000)/10000);
                // resultados[i] = ((Combinatoria(n, i)) * (Potencia((double)p, i)) * (Potencia((double)(1 - p), (n - i))));
            }
            return resultados;
        }


        //Media 
        public double MediaHipergeometrica(int n, int K, int N)
        {
            double resultado = 0;
            resultado = (double)((n*K)/(N));
            return resultado;
        }

        //Devuelve la Probabilidad de exito
        public double ProbabilidadExito(int K, int N)
        {
            double resultado = 0;
            resultado = ((double)(K/N));
            return resultado;
        }

        public double DEHconP(int n, int p, int N)
        {
            double resultado = 0;
            resultado = ((double)(Math.Sqrt(n*p*(1-p)))*(double)(Math.Sqrt((N-n)/(N-1))));
            return resultado;
        }

        public double DEHsinP(int n, int K, int N)
        {
            double resultado = 0;
            resultado = ((Math.Sqrt((double)(n*K)/(N)))*((1-((double)K / (double)N)))*(Math.Sqrt((double)(N-n)/(N-1))));
            return resultado;
        }

        //Poisson
        public double[] DistribucionPoisson(int n, int Mayor, int Menor, decimal p)
        {
            int auxiliar = 0;
            double[] resultados = new double[(Mayor-Menor)+1];
            if (Mayor != 0 && Menor != 0)
            {
                for (int i = Menor; i <= Mayor; i++)
                {
                    resultados[auxiliar] = (((double)Math.Pow(Math.E, (double)-(n * p))) * ((double)Math.Pow((double)(n * p),i) / (Factorial1(i))));
                    auxiliar++;
                }
            }
            else
            {
                if (Mayor!=0)
                {
                    for (int i = 0; i <= Mayor; i++)
                    {
                        resultados[i] = (((double)Math.Pow(Math.E, (double)-(n * p))) * (((double)Math.Pow((double)(n * p), i) / (Factorial1(i)))));
                    }
                }
            }
            
            return resultados;
        }


        //Teoria de Colas
        public double LS(double lambda, double mu)
        {
            double resultado = 0;
            resultado = (double)(lambda) / ((double)(mu)-(double)(lambda));
            return resultado;
        }

        public double WS(double lambda, double mu)
        {
            double resultado = 0;
            resultado = (double)(1) / ((double)(mu) - (double)(lambda));
            return resultado;
        }

        public double Lq(double lambda, double mu)
        {
            double resultado = 0;
            resultado = (double)(Math.Pow(lambda,2)) / (((double)mu)*((double)(mu) - (double)(lambda)));
            return resultado;
        }

        public double Wq(double lambda, double mu)
        {
            double resultado = 0;
            resultado = (double)(lambda) / (((double)mu) * ((double)(mu) - (double)(lambda)));
            return resultado;
        }

        public double Porcentaje(double lambda, double mu)
        {
            double resultado = 0;
            resultado = (double)(lambda) / ((double)(mu));
            return resultado;
        }

        public double ProbabilidadDesocupado(double porcentaje)
        {
            double resultado = 0;
            resultado = (double)(1- (double)porcentaje);
            return resultado;
        }

        public double[] probabilidaN(double lambda, double mu, int N)
        {
            double[] resultados = new double[N+1];
            for (int i=0; i<=N; i++)
            {
                resultados[i] = ((1 - ((double)(lambda / mu))) * (Math.Pow((double)(lambda / mu), (double)i)));
            }
            return resultados;
        }

        public double esperarCola(double mu, double porcentaje,int tiempo)
        {
            double resultado = 0;

            resultado = ((porcentaje)*(Math.Pow((Math.E),(-mu*(1-porcentaje)*tiempo))));

            return resultado;

        }

        public double esperarSistema(double mu, double porcentaje, int tiempo)
        {
            double resultado = 0;

            resultado = ((Math.Pow((Math.E), (-mu * (1 - porcentaje) * tiempo))));

            return resultado;

        }


         
        public double resultadoN(string opcion, double[] resultados, int n, double CxH)
        {
            double resultado = 0;
            if (opcion=="n")
            {
                for (int i = 0; i < resultados.Length; i++)
                {
                    if (i == n)
                    {
                        resultado = resultado + resultados[i];
                    }
                }
            }

            if (opcion == "n>")
            {
                for (int i=0; i<resultados.Length; i++)
                {
                    if (i<=n)
                    {
                        resultado = resultado + resultados[i];
                    }
                    
                }
                resultado = 1 - resultado;
            }
            else if (opcion == "n<")
            {
                for (int i=0; i<resultados.Length;i++)
                {
                    if (i<n)
                    {
                        resultado = resultado + resultados[i];
                    }
                    
                }

            }else if (opcion == "n≥")
            {
                for (int i = 0; i < resultados.Length; i++)
                {
                    if (i<=n)
                    {
                        resultado = resultado + resultados[i];
                    }
                    
                }
                resultado = 1 - resultado;
            }
            else if (opcion == "n≤")
            {
                for (int i = 0; i < resultados.Length; i++)
                {
                    if (i<=n)
                    {
                        resultado = resultado + resultados[i];
                    }
                    
                }
            }

            return resultado;
        }


        //Formulas de la Regresion Lineal
        public double[] XY(List<double> datosX, List<double> datosY)
        {
            double[] resultados = new double[datosX.Count];
            for (int i=0; i<datosX.Count; i++)
            {

                resultados[i] = datosX[i] * datosY[i];

            }
            return resultados;
        }

        public double[] XCuadrado(List<double> datosX)
        {
            double[] resultados = new double[datosX.Count];
            for (int i = 0; i < datosX.Count; i++)
            {

                resultados[i] = Math.Pow(datosX[i],2);

            }
            return resultados;
        }

        public double Sumatorias(List<double> datosXY)
        {
            double resultado=0;
            for (int i=0; i<datosXY.Count; i++)
            {
                resultado = resultado + datosXY[i];
            }
            return resultado;
            
        }

        public double SumatoriasXY(double[] datosXY)
        {
            double resultado = 0;
            for (int i = 0; i < datosXY.Length; i++)
            {
                resultado = resultado + datosXY[i];
            }
            return resultado;

        }

        public double pendienteRecta(double totalMuestras, double sumXY, double sumX, double sumY, double sumxCuadrado)
        {
            double resultado = 0;

            resultado = (((totalMuestras*sumXY)-(sumX*sumY))/((totalMuestras*sumxCuadrado)-(Math.Pow(sumX,2))));
            return resultado;
        }

        public double coeficientePosicion(double totalMuestras, double sumXY, double sumX, double sumY, double sumxCuadrado)
        {
            double resultado = 0;
            resultado = (((sumxCuadrado*sumY)-(sumX*sumXY)) / ((totalMuestras * sumxCuadrado) - (Math.Pow(sumX, 2))));
            return resultado;
        }

        public double coeficienteCorrelacion(double totalMuestras, double sumXY, double sumX, double sumY, double sumxCuadrado, double sumyCuadrado)
        {
            double resultado = 0;

            resultado = (((totalMuestras*sumXY)-(sumX*sumY))/(Math.Sqrt(((totalMuestras*sumxCuadrado)-(Math.Pow(sumX,2)))*((totalMuestras* sumyCuadrado) -(Math.Pow(sumY,2))))));

            return resultado;

        }


        //y = mx+b;
        public double[] NuevosDatos(List<double> datosX, double m, double b)
        {
            double[] resultados = new double[datosX.Count];
            for (int i = 0; i < datosX.Count; i++)
            {

                resultados[i] = (m * datosX[i]) + b;

            }
            return resultados;
        }

        public double[] restaNuevosDatos(List<double> datosY, double[] nuevosDatos)
        {
            double[] resultados = new double[datosY.Count];
            for (int i = 0; i < datosY.Count; i++)
            {

                resultados[i] = datosY[i]-nuevosDatos[i];

            }
            return resultados;
        }

        public double[] restaNuevosDatosCuadrado(double[] nuevosDatos)
        {
            double[] resultados = new double[nuevosDatos.Length];
            for (int i = 0; i < nuevosDatos.Length; i++)
            {

                resultados[i] = Math.Pow(nuevosDatos[i],2);

            }
            return resultados;
        }

        public double errorEstandar(double[] nuevosDatos)
        {
            double resultado = 0;
            double temp = 0;
            for (int i=0; i<nuevosDatos.Length; i++)
            {
                temp = temp + nuevosDatos[i];
            }

            resultado = Math.Sqrt((temp)/((nuevosDatos.Length-2)));

            return resultado;

        }

    }
}
