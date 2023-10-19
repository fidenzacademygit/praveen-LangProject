using Customer_Data_API.Models.Domain;
using Newtonsoft.Json;

namespace Customer_Data_API.Data
{
    public static class TagsDataSeeder
    {
        public static List<Tags> TagsData()
        {
            var customerData = new List<Customer>();

            using (StreamReader r = new(@"UserData.json"))
            {
                string json = r.ReadToEnd();
                customerData = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
            var tagsSeedData = new List<Tags>();

            if (customerData != null)
            {
                foreach (var customer in customerData)
                {
                    if (customer.Tags != null)
                    {
                        foreach (var item in customer.Tags)
                        {
                            var addTag = new Tags
                            {
                                Id = customer.Id,
                                Tag = item.Tag
                            };
                            tagsSeedData.Add(addTag);
                        }
                    }
                }
            }
            return tagsSeedData;
        }
    }
}
