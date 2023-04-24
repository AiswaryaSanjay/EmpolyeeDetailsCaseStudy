using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace EmpolyeeDetailsCaseStudy.Models
{
    public class EmpolyeeService
    {
        public async Task<ObservableCollection<Empolyee>> GetAll()
        {
            ObservableCollection<Empolyee> empolyees = new ObservableCollection<Empolyee>();
            var url = "https://gorest.co.in/public-api/users";

            using (HttpClient client = new HttpClient())
            {

                var response = await client.GetAsync(url);
                //if (response.IsSuccessStatusCode)
                //{
                var content = await response.Content.ReadAsStringAsync();


                //JObject Empolyee = JsonConvert.DeserializeObject<JObject>(content);
                JObject jo = JObject.Parse(content);
                var result = jo.SelectToken("data");
                foreach (var item in result)
                {
                    Empolyee employee = new Empolyee();
                    employee.id = Convert.ToInt32(item["id"]);
                    employee.name = Convert.ToString(item["name"]);
                    employee.email = Convert.ToString(item["email"]);
                    employee.gender = Convert.ToString(item["gender"]);
                    employee.status = Convert.ToString(item["status"]);
                    empolyees.Add(employee);
                }
                return empolyees;
            }
        }
    public  HttpResponseMessage ClientDeleteRequest(int id)
        {
            var url = "https://gorest.co.in/public-api/users";
           var APIToken = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";
            HttpClient client = new HttpClient();
           // client.BaseAddress = new Uri( + id);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + APIToken);
            HttpResponseMessage response = client.DeleteAsync(url+id).Result;
            return response;
        }

        public object ClientDeleteRequest()
        {
            throw new NotImplementedException();
        }
    }
}
