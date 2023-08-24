using Consumer.Services.Model;
using Core.Dtos;
using Core.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Services.Services
{
    public class HelperServis
    {

        public async Task UpdateReport(ReportUpdate  reportUpdate)
        {
            var json= JsonConvert.SerializeObject(reportUpdate);
            await HttpRequestHelper.HttpPost(HelperConstants.ReportUrl, json, "PUT");

        } 
        
        public async Task<GetAllByLocationModel> GetReport(string location)
        {
            
            var result =await HttpRequestHelper.HttpGet(HelperConstants.GetAllByLocationUrl+location.Trim(), "");


            var obj = JsonConvert.DeserializeObject<GetAllByLocationModel>(result.Result);

            return obj; 
        }




    }
}
