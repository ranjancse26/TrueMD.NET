using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TrueMedLib
{
    public class TrueMedAPI
    {
        private string trueMedAPI;
        private string apiKey;
        private WebRequestHelper webRequestHelper;

        public TrueMedAPI(string key)
        {
            apiKey = key;
            webRequestHelper = new WebRequestHelper();
        }
        
        public List<Medicine> GetMedicine(string brand)
        {
            try
            {
                trueMedAPI = "http://oaayush-aayush.rhcloud.com/old_api/medicine.json?key=";
                string url = trueMedAPI + apiKey + "&id=" + brand;
                string response = webRequestHelper.Request(url);
                JToken medicineRoot = JObject.Parse(response);
                JToken medicine = medicineRoot["medicine"];
                return JsonConvert.DeserializeObject<List<Medicine>>(medicine.ToString());              
            }
            catch
            {
                throw;
            }
        }

        public MedicineDetail GetMedicineDetail(string brand)
        {
            try
            {
                trueMedAPI = "http://www.truemd.in/api/medicine_details?key=";
                string url = trueMedAPI + apiKey + "&id=" + brand;
                string response = webRequestHelper.Request(url);
                JToken medicineRoot = JObject.Parse(response);
                JToken responseObj = medicineRoot["response"];
                JToken medicineObj = responseObj["medicine"];
                var medicine = JsonConvert.DeserializeObject<Medicine>(medicineObj.ToString());
                JToken constituentObj = responseObj["constituents"];
                var constituents = JsonConvert.DeserializeObject<List<Constituents>>(constituentObj.ToString());
                return new MedicineDetail
                {
                    medicine = medicine,
                    constituents = constituents
                };
            }
            catch
            {
                throw;
            }
        }

        public List<Medicine> GetMedicineAlternatives(string brand)
        {
            try
            {
                trueMedAPI = "http://www.truemd.in/api/medicine_alternatives?key=";
                string url = trueMedAPI + apiKey + "&id=" + brand;
                string response = webRequestHelper.Request(url);
                var medAlternativesJObject = JObject.Parse(response);

                JToken medicineAlternativeRoot = JObject.Parse(response);
                JToken responseObj = medicineAlternativeRoot["response"];
                JToken medicineAlternatives = responseObj["medicine_alternatives"];
                return JsonConvert.DeserializeObject<List<Medicine>>(medicineAlternatives.ToString());
            }
            catch
            {
                throw;
            }
        }

        public List<Suggestion> GetMedicineSuggestions(string find)
        {
            try
            {
                trueMedAPI = "http://www.truemd.in/api/medicine_suggestions?key=" + apiKey + "&id=" + find;
                string response = webRequestHelper.Request(trueMedAPI);
                var suggestionsJObject = JObject.Parse(response);
                JToken responseObj = suggestionsJObject["response"];
                JToken medicineAlternatives = responseObj["suggestions"];
                return JsonConvert.DeserializeObject<List<Suggestion>>(medicineAlternatives.ToString());
            }
            catch
            {
                throw;
            }
        }

        public List<Suggestion> GetMedicineSuggestions(string find, int limit)
        {
            try
            {
                trueMedAPI = "http://www.truemd.in/api/medicine_suggestions?key=" + apiKey + "&id=" + find + "&limit=" + limit;
                string response = webRequestHelper.Request(trueMedAPI);
                var suggestionsJObject = JObject.Parse(response);
                JToken responseObj = suggestionsJObject["response"];
                JToken medicineAlternatives = responseObj["suggestions"];
                return JsonConvert.DeserializeObject<List<Suggestion>>(medicineAlternatives.ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}
