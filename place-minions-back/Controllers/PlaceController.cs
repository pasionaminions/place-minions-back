using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public async Task<byte[,]> GetMap()
        {
            /*{
             *  x: int,
             *  y: int,
             *  Color: string (#FFFFFF)
             * }
             */
            string mapstr = await FileIO.ReadAllTextAsync(Program.MapPath);
            byte[] map = mapstr.Split("\n").Select(x => Byte.Parse(x)).ToArray();
            //var res = map.Select((x, ind) => new MapData(ind / 100, ind % 100, HtmlPlaceColors[(int)x])).ToList();
            byte[,] res = new byte[100, 100];
            for (int i = 0; i < map.Length; i++)
            {
                res[i / 100, i % 100] = map[i];
            }   
            
            return res;
        }

        // POST: api/Place/setp/0/1/16
        [HttpPost("setp")]
        public async Task<ActionResult<MapData>> SetPixel(MapData data)
        {
            int c = data.Color;
            int x = data.X;
            int y = data.Y;
            if (c < 0 || c >= 16) return BadRequest();
            if (x > 99 || x < 0 || y > 99 || y < 0) return BadRequest();
            string mapstr = await FileIO.ReadAllTextAsync(Program.MapPath);
            byte[] map = mapstr.Split("\n").Select(x => Byte.Parse(x)).ToArray();
            map[y*100 + x] = (byte)c;
            FileIO.WriteAllText(Program.MapPath, String.Join('\n', map));            
            StreamWriter sw = FileIO.AppendText(Program.HistoryPath);
            DateTime dt = new DateTime().Date;
            await sw.WriteLineAsync($"{dt.Ticks},{x},{y},{c}").ContinueWith((_) => sw.Close());
            return Ok(data);
        }

        // GET: api/Place/colors
        [HttpGet("colors")]
        public ActionResult GetColors()
        {
            return Ok(HtmlPlaceColors);
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

    public struct MapData
    {
        public int X;
        public int Y;
        public int Color;

        public MapData(int x, int y, int color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }

}
