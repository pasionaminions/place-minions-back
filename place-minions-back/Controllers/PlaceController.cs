using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace place_minions_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        // GET: api/Place
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Place/5
        [HttpGet("{x}/{y}/{color}", Name = "setp")]
        public string Get(int x, int y, int c)
        {
            return "value";
        }

        // POST: api/Place
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Place/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        static Color[] RedditPlaceColors = new Color[]
        {
            ColorTranslator.FromHtml("#FFFFFF"),
            ColorTranslator.FromHtml("#E4E4E4"),
            ColorTranslator.FromHtml("#888888"),
            ColorTranslator.FromHtml("#222222"),
            ColorTranslator.FromHtml("#FFA7D1"),
            ColorTranslator.FromHtml("#E50000"),
            ColorTranslator.FromHtml("#E59500"),
            ColorTranslator.FromHtml("#A06A42"),
            ColorTranslator.FromHtml("#E5D900"),
            ColorTranslator.FromHtml("#94E044"),
            ColorTranslator.FromHtml("#02BE01"),
            ColorTranslator.FromHtml("#00E5F0"),
            ColorTranslator.FromHtml("#0083C7"),
            ColorTranslator.FromHtml("#0000EA"),
            ColorTranslator.FromHtml("#E04AFF"),
            ColorTranslator.FromHtml("#820080"),
        };
    }


}
