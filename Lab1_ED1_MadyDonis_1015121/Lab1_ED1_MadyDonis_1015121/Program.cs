
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    class Test
    {

        private static string _path = @"C:\Users\Usuario\Documents\Lab1_ED1_MadyDonis\Lab1_ED1_MadyDonis\tsconfig1.json";

        public static string GetUsuarios()
        {

            string usu;
            using (var reader = new StreamReader(_path))
            {
                usu = reader.ReadToEnd();

            }


            return usu;
        }
        static void Main(string[] args)
        {


            int contador = 0;
            int con = 0;

            string[] arreglo = new string[1000];
            string[] arreglo2 = new string[1000];
            int conT = 0;
            int conP = 1;
            Console.Title = "LabMady";

            //string decode = arbolHH.Decodificacion(encode);

            var infodd = "";
            var info1 = "";
            var infoN = "";
            var infoD = "";
            var infoG = "";
            string[] informacion1 = { };
            string[] informacionP3 = { };
            string[] informacionP2 = { };
            string[] separI22 = { };
            int c = 0, b = 0, a = 0;



            if (GetUsuarios() != null && contador == con)
            {
                try
                {

                    string allFileData = File.ReadAllText(_path); //Abre el archivo
                    foreach (string lineaActual in allFileData.Split('\n')) //Lee línea por línea
                    {

                        if (!string.IsNullOrEmpty(lineaActual) && contador == con)
                        {
                            conT = 0;
                            //Para reconocer el input 1
                            string[] informacion = lineaActual.Split("input1" + '"');
                            var u = (informacion[1]);
                            string[] comp = u.Split('"');
                            var comp1 = comp[0];
                            var comp2 = comp[0];

                            //Para reconocer el input 2
                            string[] informacion_ = lineaActual.Split("input2" + '"');
                            var u_ = (informacion[1]);
                            string[] comp_ = u.Split('"');
                            var comp1_ = comp[0];
                            var comp2_ = comp[0];


                            //INPUT 1
                            if (comp[0] == ":[{")
                            {
                                info1 = informacion[1];
                                informacion1 = info1.Split(':' + "[{");
                                infoN = informacion1[1];
                                infoD = informacion1[1];
                            }
                            else
                            {
                                info1 = informacion[1];
                                informacion1 = info1.Split(':' + "[{}" + ',');
                                infoN = informacion1[1];
                                infoD = informacion1[1];
                            }


                            /*INPUT 2
                            if (comp[0] == ":[{")
                            {
                                info1 = informacion_[1];
                                informacion1 = info1.Split(':' + "[{");
                                infoN = informacion1[1];
                                infoD = informacion1[1];
                            }
                            else
                            {
                                info1 = informacion[1];
                                informacion1 = info1.Split(':' + "[{}" + ',');
                                infoN = informacion1[1];
                                infoD = informacion1[1];
                            }
                            */




                            string[] informacionN = infoN.Split('{');
                            var infonn = informacionN[1];


                            string[] informacionD = infoD.Split("],");
                            infodd = informacionD[1];
                            var info3 = informacionD[0];

                            string[] informacionP = info3.Split("," + '"');

                            informacionP2 = info3.Split("},{");


                            string[] separI2 = infodd.Split('[');
                            var info4 = separI2[1];

                            string[] separI21 = info4.Split(']');
                            var info5 = separI21[0];

                            separI22 = info5.Split(',');
                            for (c = 0; c < informacionP2.Length; c++)
                            {
                                infoG = informacionP2[c];
                                informacionP3 = infoG.Split(',');
                                while (b < informacionP3.Length)
                                {
                                    while (a < separI22.Length)
                                    {
                                        if (informacionP3[b].Contains(separI22[a] + ":true") && informacionP3[b].Contains(separI22[a]) && separI22[a] != null)
                                        {
                                            conT++;

                                        }

                                        a++;
                                    }
                                    b++;
                                    a = 0;
                                }
                                b = 0;

                            }




                            //for (int b = 0; b < informacionP.Length; b++)
                            //{
                            //    for (int a = 0; a < separI22.Length; a++)
                            //    {
                            //        if (informacionP[b].Contains(separI22[a]+":true") && informacionP[b].Contains(separI22[a]) && separI22[a] != null)
                            //        {
                            //            conT++;
                            //        }


                            //    }
                            //}

                            /*Console.WriteLine("Apartamento número " + conT );*/
                            Console.WriteLine("Apartamento número " + conP + " fue de: " + info5);
                            conP++;
                            b = 0;
                            a = 0;

                        }

                        /*info1 muestra todo
                         info5 input dos 
                         infoD muetra todo 
                         */

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error" + ex);
                }

            }


        }


    }
}