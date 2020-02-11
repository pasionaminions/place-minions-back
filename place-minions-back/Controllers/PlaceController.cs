using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileIO = System.IO.File;

namespace place_minions_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        // GET: api/Place/map
        [HttpGet("map")]
        public async Task<IEnumerable<MapData>> GetMap()
        {
            string mapstr = await FileIO.ReadAllTextAsync(Program.MapPath);
            byte[] map = mapstr.Split("\n").Select(x => Byte.Parse(x)).ToArray();
            return map.Select((x, ind) => new MapData(ind / 100, ind % 100, HtmlPlaceColors[(int)x]));
        }

        // GET: api/Place/setp/0/1/16
        [HttpGet("setp/{x}/{y}/{color}")]
        public string SetPixel(int x, int y, int c)
        {
            return "value";
        }

        // GET: api/Place/colors
        [HttpGet("colors")]
        public IEnumerable<string> GetColors()
        {
            return HtmlPlaceColors;
        }

        public string [] HtmlPlaceColors
        {
            get
            {
                return RedditPlaceColors.Select(x => ColorTranslator.ToHtml(x)).ToArray();
            }
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

    public class MapData
    {
        public int X;
        public int Y;
        public string Color;

        public MapData(int x, int y, string color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }

}
