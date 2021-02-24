using FaunaDB.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.ApolloProgram.DB
{
    class Track
    {
        //Define variables related to document fields
        [FaunaField("Name")]
        public string Name { get; set; }

        [FaunaField("Artist")]
        public string Artist { get; set; }

        [FaunaField("Album")]
        public string Album { get; set; }

        [FaunaField("Genre")]
        public string Genre { get; set; }

        [FaunaField("Length")]
        public int Length { get; set; }

        [FaunaField("DateAdded")]
        public string DateAdded { get; set; }

        [FaunaField("Source")]
        public string Source { get; set; }

        [FaunaField("Url")]
        public string Url { get; set; }

        [FaunaField("Playlists")]
        public List<string> Playlists { get; set; }

        //Add Document field data to object
        [FaunaConstructor]
        public Track(string name, string artist, string album, string genre, int length, string dateadded, string source, string url, List<string> playlists)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Genre = genre;
            Length = length;
            DateAdded = dateadded;
            Source = source;
            Url = url;
            Playlists = playlists;

        }
    }
}
