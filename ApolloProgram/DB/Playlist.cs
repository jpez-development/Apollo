using FaunaDB.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.ApolloProgram.DB
{
    class Playlist
    {
        //Define variables related to document fields
        [FaunaField("Name")]
        public string Name { get; set; }

        [FaunaField("Description")]
        public string Description { get; set; }

        [FaunaField("Source")]
        public string Source { get; set; }

        [FaunaField("Url")]
        public string Url { get; set; }

        [FaunaField("Tracks")]
        public List<string> Tracks { get; set; }

        //Add Document field data to object
        [FaunaConstructor]
        public Playlist(string name, string description, string source, string url, List<string> tracks)
        {
            Name = name;
            Description = description;
            Source = source;
            Url = url;
            Tracks = tracks;

        }
    }
}
