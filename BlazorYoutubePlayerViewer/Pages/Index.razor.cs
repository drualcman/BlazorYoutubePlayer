namespace BlazorYoutubePlayerViewer.Pages
{
    public partial class Index
    {

        string Playing = "qeMFqkcPYcg";

        async Task PlayVideo()
        {
            Playing = Helpers.Video.GetYoutubeVideoId(Video);
            await InvokeAsync(StateHasChanged);
        }
    }
}
