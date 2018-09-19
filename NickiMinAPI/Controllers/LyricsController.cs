using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NickiMinLibrary;

namespace NickiMinAPI.Controllers
{
    [Route("api/[controller]")]
    public class LyricsController : Controller
    {
        private NickiMinMarkov _NickiMinMarkov = new NickiMinMarkov();

        [HttpGet("verse")]
        public string Verse()
        {
            return _NickiMinMarkov.GenerateVerse();
        }

        [HttpGet("line")]
        public string Line(int id)
        {
            return _NickiMinMarkov.GenerateLine();
        }
    }
}
