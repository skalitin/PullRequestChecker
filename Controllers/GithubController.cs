using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PRs.Controllers
{
    [Route("github")]
    public class GithubController : Controller
    {
        [HttpPost]
        public string Post()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                var body = reader.ReadToEnd();
                var data = (JObject)JsonConvert.DeserializeObject(body);
                
                var pr_description = data["pull_request"]["body"];
                var sha = data["pull_request"]["head"]["sha"];
                var repo = data["pull_request"]["head"]["repo"]["full_name"];
                 
                //Console.WriteLine(body);
                Console.WriteLine(pr_description);
                Console.WriteLine($"Repo {repo}, {sha}");

                return body;
            }
        }
    }
}
