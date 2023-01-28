namespace BlazorYoutubePlayerViewer.Helpers
{
    public class Video
    {

        public static string GetYoutubeVideoId(string Video)
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
