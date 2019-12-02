using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace Exam
{
    public class StarWarsPeopleService
    {
        private string url = "https://swapi.co/api/people/?page=";

        public HeroesList GetPage(int pageNumber = 1)
        {
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(url + pageNumber);
                var heroesList = JsonConvert.DeserializeObject<HeroesList> (json);
                foreach(var hero in heroesList.Heroes)
                {
                    hero.SetHomeworld();
                }
                return heroesList;
            }
        }
    }
}
