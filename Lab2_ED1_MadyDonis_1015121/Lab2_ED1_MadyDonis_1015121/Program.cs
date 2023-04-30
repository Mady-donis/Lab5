using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Program
{
    public class House
    {
        public string zoneDangerous { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Apartment
    {
        public bool isPetFriendly { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Premise
    {
        public string[] commercialActivities { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Builds
    {
        public Premise[]? Premises { get; set; }
        public Apartment[]? Apartments { get; set; }
        public House[]? Houses { get; set; }
    }
    public class Input1
    {
        public Dictionary<string, bool> services { get; set; }
        public Builds builds { get; set; }

    }
    public class Input2
    {
        public double budget { get; set; }
        public string typeBuilder { get; set; }
        public string[] requiredServices { get; set; }
        public string? commercialActivity { get; set; }
        public bool? wannaPetFriendly { get; set; }
        public string? minDanger { get; set; }
    }
    public class InputLab
    {
        public Input1[] input1 { get; set; }
        public Input2 input2 { get; set; }
    }

    static void Main(string[] args)
    {
        for (int r = 0; r < 100; r++)
        {
            string jsonText = File.ReadAllText(@"C: \Users\Usuario\Downloads\input_challenge_lab_2.jsonl");
            string[] jsonObjects = jsonText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            InputLab input = JsonSerializer.Deserialize<InputLab>(jsonObjects[r])!;

            bool[] TypeBuilders = { false, false, false };
            string CAA = "";
            int Request = 0;
            string ZDR_S = "";
            int ZDR_I = 0;
            bool PetFriendR;
            string respuestas = "";
            int CantidadRespuestas = 0;
            string[] IDsRespuesta = new string[200];
            double[] PriceRespuesta = new double[200];



            //Se revisa lo que desea el cliente//
            double BudgetR = input.input2.budget;
            if (input.input2.typeBuilder == "Apartments") { Request = 0; }
            if (input.input2.typeBuilder == "Houses")
            {
                Request = 1; ZDR_S = input.input2.minDanger;
                //Se asigna valor numérico a ZoneDanger//
                if (ZDR_S == "Green") { ZDR_I = 3; }
                if (ZDR_S == "Yellow") { ZDR_I = 2; }
                if (ZDR_S == "Orange") { ZDR_I = 1; }
                if (ZDR_S == "Red") { ZDR_I = 0; }
            }
            if (input.input2.typeBuilder == "Premises") { Request = 2; }
            //Se revisa lo que desea el cliente//



            //Se introducen budget, PF, ZD o CA en un vector//
            switch (Request)
            {
                case 0: //Se están pidiendo apartamentos//
                    {
                        for (int Iteracion = 0; Iteracion < input.input1.Length; Iteracion++)
                        {
                            if (input.input1[Iteracion].builds.Apartments != null) { TypeBuilders[0] = true; }

                            if (TypeBuilders[0] == true)
                            {
                                string[] IDs = new string[input.input1[Iteracion].builds.Apartments.Length];
                                bool[] PFs = new bool[input.input1[Iteracion].builds.Apartments.Length];
                                double[] Budgets = new double[input.input1[Iteracion].builds.Apartments.Length];

                                for (int BuildSearch = 0; BuildSearch < input.input1[Iteracion].builds.Apartments.Length; BuildSearch++)
                                {
                                    IDs[BuildSearch] = input.input1[Iteracion].builds.Apartments[BuildSearch].id;
                                    PFs[BuildSearch] = input.input1[Iteracion].builds.Apartments[BuildSearch].isPetFriendly;
                                    Budgets[BuildSearch] = input.input1[Iteracion].builds.Apartments[BuildSearch].price;
                                }
                                // Se evalua Budget y Pet//
                                for (int BuildContains = 0; BuildContains < input.input1[Iteracion].builds.Apartments.Length; BuildContains++)
                                {
                                    if (PFs[BuildContains] == input.input2.wannaPetFriendly && Budgets[BuildContains] <= input.input2.budget)
                                    {
                                        IDsRespuesta[CantidadRespuestas] = IDs[BuildContains];
                                        PriceRespuesta[CantidadRespuestas] = Budgets[BuildContains];
                                        CantidadRespuestas++;
                                    }
                                }
                                TypeBuilders[0] = false;
                            }
                        }
                        break;
                    }
                case 1: //Pide houses//
                    {
                        for (int Iteracion = 0; Iteracion < input.input1.Length; Iteracion++)
                        {
                            if (input.input1[Iteracion].builds.Houses != null) { TypeBuilders[1] = true; }

                            if (TypeBuilders[1] == true)
                            {
                                string[] IDs = new string[input.input1[Iteracion].builds.Houses.Length];
                                double[] Budgets = new double[input.input1[Iteracion].builds.Houses.Length];
                                int[] ZDsI = new int[input.input1[Iteracion].builds.Houses.Length];
                                string ZDs = "";
                                int ZDR_II = 0;

                                for (int BuildSearch = 0; BuildSearch < input.input1[Iteracion].builds.Houses.Length; BuildSearch++)
                                {
                                    IDs[BuildSearch] = input.input1[Iteracion].builds.Houses[BuildSearch].id;
                                    Budgets[BuildSearch] = input.input1[Iteracion].builds.Houses[BuildSearch].price;
                                    ZDs = input.input1[Iteracion].builds.Houses[BuildSearch].zoneDangerous;
                                    // Se asigna el número dependiendo del color de zona de riesgo//
                                    if (ZDs == "Green") { ZDR_II = 3; }
                                    if (ZDs == "Yellow") { ZDR_II = 2; }
                                    if (ZDs == "Orange") { ZDR_II = 1; }
                                    if (ZDs == "Red") { ZDR_II = 0; }
                                    ZDsI[BuildSearch] = ZDR_II;
                                    // Se asigna en número dependiendo del color de zona de riesgo//
                                }
                                for (int BuildContains = 0; BuildContains < input.input1[Iteracion].builds.Houses.Length; BuildContains++)
                                {
                                    if (ZDsI[BuildContains] <= ZDR_I && Budgets[BuildContains] <= input.input2.budget)
                                    {
                                        IDsRespuesta[CantidadRespuestas] = IDs[BuildContains];
                                        PriceRespuesta[CantidadRespuestas] = Budgets[BuildContains];
                                        CantidadRespuestas++;
                                    }
                                }
                            }
                            TypeBuilders[1] = false;
                        }
                        break;
                    }
                case 2:
                    {
                        for (int Iteracion = 0; Iteracion < input.input1.Length; Iteracion++)
                        {
                            if (input.input1[Iteracion].builds.Premises != null) { TypeBuilders[2] = true; }

                            if (TypeBuilders[2] == true)
                            {
                                string[] IDs = new string[input.input1[Iteracion].builds.Premises.Length];
                                bool[] CAs = new bool[input.input1[Iteracion].builds.Premises.Length];
                                double[] Budgets = new double[input.input1[Iteracion].builds.Premises.Length];
                                for (int BuildSearch = 0; BuildSearch < input.input1[Iteracion].builds.Premises.Length; BuildSearch++)
                                {
                                    IDs[BuildSearch] = input.input1[Iteracion].builds.Premises[BuildSearch].id;
                                    Budgets[BuildSearch] = input.input1[Iteracion].builds.Premises[BuildSearch].price;
                                    for (int i = 0; i < input.input1[Iteracion].builds.Premises[BuildSearch].commercialActivities.Length; i++)
                                    {
                                        if (input.input1[Iteracion].builds.Premises[BuildSearch].commercialActivities[i] == input.input2.commercialActivity)
                                        {
                                            CAs[BuildSearch] = true;
                                        }

                                    }
                                }

                                //Se evaluan las condiciones de Budget y Commercial Activities//
                                for (int BuildContains = 0; BuildContains < input.input1[Iteracion].builds.Premises.Length; BuildContains++)
                                {
                                    if (CAs[BuildContains] == true && Budgets[BuildContains] <= input.input2.budget)
                                    {
                                        IDsRespuesta[CantidadRespuestas] = IDs[BuildContains];
                                        PriceRespuesta[CantidadRespuestas] = Budgets[BuildContains];
                                        CantidadRespuestas++;
                                    }
                                }
                            }
                            TypeBuilders[2] = false;
                        }
                        break;


                    }
            }
            // Ordenamiento//
            double temporalD = 0;
            string temporalS = "";
            for (int i = 0; i < CantidadRespuestas; i++) // i = current//
            {
                int pivote = i;
                for (int j = 0; j < CantidadRespuestas; j++)
                {
                    if (PriceRespuesta[pivote] <= PriceRespuesta[j])
                    {
                        pivote = j;
                    }
                    temporalD = PriceRespuesta[i];
                    temporalS = IDsRespuesta[i];
                    IDsRespuesta[i] = IDsRespuesta[pivote];
                    PriceRespuesta[i] = PriceRespuesta[pivote];
                    IDsRespuesta[pivote] = temporalS;
                    PriceRespuesta[pivote] = temporalD;
                }

            }
            string RespuestaFinal = "[";
            for (int i = 0; i < CantidadRespuestas; i++)
            {
                if (i < CantidadRespuestas - 1)
                {
                    RespuestaFinal = RespuestaFinal + "\"" + IDsRespuesta[i] + "\"" + ",";
                }
                else
                {
                    RespuestaFinal = RespuestaFinal + "\"" + IDsRespuesta[i] + "\"";
                }

            }
            RespuestaFinal = RespuestaFinal + "]";

            Console.WriteLine(RespuestaFinal);
        }
    }
}