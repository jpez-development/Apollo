using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Apollo.Spotify
{
    class SpotifyUser
    {
        private PrivateUser RawProfile;
        private readonly IList<SimplePlaylist> RawPlaylists;

        //Object properties
        public BitmapImage ProfilePicture;
        public string Name;
        public string Email;
        public string Country;

        //Define raw API output on initialisation
        public SpotifyUser(PrivateUser profile, IList<SimplePlaylist> playlists)
        {
            RawProfile = profile;
            RawPlaylists = playlists;
            Init();
        }

        //Define object properties
        private void Init()
        {
            GetProfilePicture();
            Name = RawProfile.DisplayName;
            Email = RawProfile.Email;
            Country = RawProfile.Country;

        }

        //Generate a Bitmap of profile image from source
        private void GetProfilePicture()
        {
            ProfilePicture = new BitmapImage();
            ProfilePicture.BeginInit();
            ProfilePicture.UriSource = new Uri(RawProfile.Images[0].Url);
            ProfilePicture.EndInit();
        }
    }
}
