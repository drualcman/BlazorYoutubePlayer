namespace BlazorYoutubePlayerViewer.Pages
{
    public partial class Index
    {

        string Playing = "qeMFqkcPYcg";

        void PlayVideo()
        {
            Playing = Helpers.Video.GetYoutubeVideoId(Video);
        }
    }
}
