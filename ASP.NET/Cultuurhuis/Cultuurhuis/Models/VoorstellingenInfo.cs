using System.Collections.Generic;

namespace Cultuurhuis.Models
{
    public class VoorstellingenInfo
    {
        public Genre Genre { get; set; }
        public List<Genre> GenreList { get; set; }
        public List<Voorstelling> VoorstellingList { get; set; }
    }
}