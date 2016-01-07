# TrueMD.NET
TrueMD Restful .NET API

## Synopsis

A .NET Library for TrueMD (http://www.truemd.in/)

Built to consume TrueMD API. This library depends on JSON.NET (http://www.newtonsoft.com/json) for deserializing the JSON object.

Please read this blog for more info - https://www.quora.com/profile/Aayush-Jain-3/Posts/Let-me-show-you-a-magic-trick?srid=527C&share=1
http://www.truemd.in/api/documentation

## Code Example

Here's the code sample. Before you do anything, make sure to create TrueMD API Key. You can register the same at http://www.truemd.in/api/new

Creating an instance of TrueMD API wrapper and make a call to the respective methods.

        TrueMedAPI trueMedAPI = new TrueMedAPI(key);
        
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
 
 
## Motivation

The main motivation behind this project is, as of today the .NET Library for TrueMD does not exist. Although it's not so challenging to create one, I would rather consider it as a fun project :)

## Installation

Just build the "TrueMDLib" library and then include the reference in your application.

## API Reference

Please take a look into the below link to understand more about the TrueMD Restful API

http://www.truemd.in/api/documentation

## Tests

Don't have a unit test project but the console application should do it's job.

## Contributors

The following are the list of contributors

1) Ranjan Dailata

## License

Apache
