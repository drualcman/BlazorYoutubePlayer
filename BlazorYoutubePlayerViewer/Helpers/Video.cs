using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BlazorYoutubePlayerViewer.Helpers
{
    public class Video
    {

        public static string ExtraerId(string Video)
        {
            string id;
            if (Video.ToLower().Contains("http") || Video.ToLower().Contains("youtu"))
            {
                try
                {
                    Uri uri = new Uri(Video);
                    id = ExtraerId(uri);
                }
                catch
                {
                    id = Video;
                }
            }
            else id = Video;
            return id;
        }

        public static string ExtraerId(Uri uri)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
            return query["v"];
        }
    }
}
