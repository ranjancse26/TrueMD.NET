using System;
using TrueMedLib;
using System.Configuration;

namespace TrueMedConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            string key = ConfigurationManager.AppSettings["ApiKey"];
            TrueMedAPI trueMedAPI = new TrueMedAPI(key);

            Console.WriteLine("1. Get Suggestions");
            Console.WriteLine("2. Get Medicine Info");
            Console.WriteLine("3. Get Medicine Alternatives");
            Console.WriteLine("4. Get Medicine Details");

            Console.WriteLine("Please enter option: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    GetSuggestions(trueMedAPI, "croc");
                    break;
                case 2:
                    GetMedicineInfo(trueMedAPI, "Cetri (10 mg)");
                    break;
                case 3:
                    GetMedicineAlternatives(trueMedAPI, "Cetri (10 mg)");
                    break;
                case 4:
                    GetMedicineDetails(trueMedAPI, "Cetri (10 mg)");
                    break;
            }

            Console.WriteLine("Press any key to exit ");
            Console.ReadLine();
        }

        private static void GetMedicineDetails(TrueMedAPI trueMedAPI, string brandName)
        {
            var medicineDetail = trueMedAPI.GetMedicineDetail(brandName);
            DisplayMedicineInfo(medicineDetail.medicine);

            Console.WriteLine("\nDisplaying Constituents");
            Console.WriteLine("***************************************");
            foreach (var cons in medicineDetail.constituents)
            {
                Console.WriteLine("Id:"+cons.id);
                Console.WriteLine("Name:" + cons.name);
                Console.WriteLine("Quantity:" + cons.qty);
                Console.WriteLine("Strength:" + cons.strength);
                Console.WriteLine("Generic Id:" + cons.generic_id);
            }
            Console.WriteLine("***************************************");
        }

        private static void GetMedicineAlternatives(TrueMedAPI trueMedAPI, string brandName)
        {
            var alternatives = trueMedAPI.GetMedicineAlternatives(brandName);
            foreach(var alternative in alternatives)
            {
                DisplayMedicineInfo(alternative);
            }
        }
        
        private static void DisplayMedicineInfo(Medicine medicine)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("ID: " + medicine.id);
            Console.WriteLine("Brand: " + medicine.brand);
            Console.WriteLine("Category: " + medicine.category);
            Console.WriteLine("Category: " + medicine.category);
            Console.WriteLine("D Class: " + medicine.d_class);
            Console.WriteLine("Generic ID: " + medicine.generic_id);
            Console.WriteLine("Manufacturer: " + medicine.manufacturer);
            Console.WriteLine("Price: " + medicine.package_price);
            Console.WriteLine("Quantity: " + medicine.package_qty);
            Console.WriteLine("Type: " + medicine.package_type);
            Console.WriteLine("Unit Price: " + medicine.unit_price);
            Console.WriteLine("Unit Qty: " + medicine.unit_qty);
            Console.WriteLine("Unit Type: " + medicine.unit_type);
            Console.WriteLine("***************************************");
        }

        private static void GetMedicineInfo(TrueMedAPI trueMedAPI, string brandName)
        {
            var medicineInfo = trueMedAPI.GetMedicine(brandName);
            foreach(var med in medicineInfo)
            {
                DisplayMedicineInfo(med);
            }
        }

        private static void GetSuggestions(TrueMedAPI trueMedAPI, string suggestionText)
        {
            var suggestions = trueMedAPI.GetMedicineSuggestions(suggestionText);
            Console.WriteLine("***************************************");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine(suggestion.suggestion);
            }
            Console.WriteLine("***************************************");
        }
    }
}
