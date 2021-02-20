using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment_3___MusikAPI.Models
{
    public class Musik
    {
        public int Id { get; set; }

        public string Artist { get; set; }

        public string Titel { get; set; }

        public int Duration { get; set; }

        public string Kategori { get; set; }
    }
}
