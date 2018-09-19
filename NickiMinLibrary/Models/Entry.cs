using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NickiMinLibrary.Models
{
    class Entry
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public string Lyrics { get; set; }
    }
}
