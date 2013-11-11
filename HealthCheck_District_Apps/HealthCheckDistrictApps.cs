using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HealthCheck_District_Apps
{
    [Binding]
    public class HealthCheckSteps
    {
        private string _theUrl;
        private string _theResponse;
        private string _search;
        private string _name;
        private string _theapiresponse;

        [Given(@"the alteryx service is running at ""(.*)""")]
        public void GivenTheAlteryxServiceIsRunningAt(string alteryxUrl)
        {
            _theUrl = alteryxUrl;
        }
        
        [When(@"I invoke the GET at ""(.*)""")]
        public void WhenIInvokeTheGETAt(string apiUrl)
        {
            string fullUrl = _theUrl + "/" + apiUrl;
            WebRequest request = WebRequest.Create(fullUrl);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
           _theResponse = responseFromServer;
        }
                
        [Then(@"I see the version binaryVersionsserviceLayer is (.*) and binaryVersionscloud is (.*)")]
        public void ThenISeeTheVersionBinaryVersionsserviceLayerIsAndBinaryVersionscloudIs(string expectedservicelayerVersion, string expectedcloudVersion)
        {
            var dict =new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(_theResponse);         
            Assert.AreEqual(expectedcloudVersion, dict["binaryVersions"]["cloud"]);
        }

        [Then(@"I see at least (.*) active districts")]
        public void ThenISeeAtLeastActiveDistricts(int expectedDistrictCount)
        {

            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<ArrayList>(_theResponse);            
            int count = json.Count;
            Assert.That(count, Is.AtLeast(expectedDistrictCount));
        }

        [When(@"I invoke GET at ""(.*)"" for ""(.*)""")]
        public void WhenIInvokeGETAtFor(string apiURL, string expecteddistrict)
        {
          string fullUrl = _theUrl + "/" + apiURL;
           WebRequest request = WebRequest.Create(fullUrl);
      //      request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            _theResponse = responseFromServer; 

            var DistrictObj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(_theResponse);
            int count = DistrictObj.Length;

            int i = 0;
            for (i = 0; i <= count - 1; i++)
            {
                if (DistrictObj[i]["title"] == expecteddistrict)
                {
                    break;
                }
            }

            string id = DistrictObj[i]["id"];
            string apiUrl = fullUrl + "/" + id;
            WebRequest apirequest = WebRequest.Create(apiUrl);
         //   apirequest.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse apiresponse = (HttpWebResponse)apirequest.GetResponse();
            Stream apidataStream = apiresponse.GetResponseStream();
            StreamReader apireader = new StreamReader(apidataStream);
            string apiresponseFromServer = apireader.ReadToEnd();
            _theapiresponse = apiresponseFromServer;
        }

        [Then(@"I see that district description contains the text ""(.*)""")]
        public void ThenISeeThatDistrictDescriptionContainsTheText(string expecteddescription)
        {
            var dict = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(_theapiresponse);
            Console.Write(dict["description"]);
            StringAssert.Contains(expecteddescription, dict["description"]);
        }

        [When(@"I search for application at ""(.*)"" with search term ""(.*)""")]
        public void WhenISearchForApplicationAtWithSearchTerm(string apiurl, string searchterm)
        {
            string search = Regex.Replace(searchterm, @"\s+", "+");
            string Url = _theUrl + "/" + apiurl + "?search=" + search;
            WebRequest webRequest = System.Net.WebRequest.Create(Url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new System.IO.StreamReader(responseStream);
            string responseFromServer = reader.ReadToEnd();
            _theResponse = responseFromServer;
            
        }
     
        [Then(@"I see primaryapplication\.metainfo\.name contains ""(.*)""")]
        public void ThenISeePrimaryapplication_Metainfo_NameContains(string expectedname)
        {
            
            var dict =
                new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(
                    _theResponse);
            int count = dict["recordCount"];
            if (count == 1)
            {
                _name = dict["records"][0]["primaryApplication"]["metaInfo"]["name"];
            }
            else
            {
                int i = 0;
                for (i = 0; i <= count - 1; i++)
                {
                    if (dict["records"][i]["primaryApplication"]["metaInfo"]["name"] == expectedname)
                    {
                        _name = dict["records"][i]["primaryApplication"]["metaInfo"]["name"];
                        break;
                    }

                }
            }
            Assert.AreEqual(expectedname, _name);
        }

        [When(@"I search for application at ""(.*)"" with search multiple term ""(.*)""")]
        public void WhenISearchForApplicationAtWithSearchMultipleTerm(string apiurl, string searchterm)
        {
            string term = searchterm.TrimStart();
            string[] split = term.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            if (split.Length > 0)
            {
                _search = split[0];
            }
            string Url = _theUrl + "/" + apiurl + "?search=" + _search;
            WebRequest webRequest = System.Net.WebRequest.Create(Url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new System.IO.StreamReader(responseStream);
            string responseFromServer = reader.ReadToEnd();
            _theResponse = responseFromServer;

        }

        [Then(@"I see record-count is (.*)")]
        public void ThenISeeRecord_CountIs(int expectedcount)
        {
            var dict = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(_theResponse);
            int count = dict["recordCount"];
            Assert.AreEqual(count, expectedcount);

        }  
    }
}
