namespace BlazorYoutubePlayerViewer.Shared
{
    public partial class YoutubePlayer: IDisposable, IAsyncDisposable
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public string PlayerId { get; set; }

        [Parameter]
        public string VideoId { get; set; }


        private static Action ActionApi;
        private static Action ActionPlayer;

        bool IsApiLoad = false;
        bool IsPlayerReady = false;

        protected override void OnInitialized()
        {
            ActionApi = ApiIsLoaded;
            ActionPlayer = PlayerIsReady;
        }

        private void ApiIsLoaded()
        {
            IsApiLoad = true;
        }

        private async void PlayerIsReady()
        {
            if (IsPlayerReady)
            {
                if (VideoId is not null)
                    await JsRuntime.InvokeVoidAsync("youtubeApi.payVideo", VideoId);
            }
            else
            {
                IsPlayerReady = true;
            }
            await InvokeAsync(StateHasChanged);
        }

        [JSInvokable]
        public static void ApiLoaded()
        {
            ActionApi.Invoke();
        }

        [JSInvokable]
        public static void PlayerReady()
        {
            ActionPlayer.Invoke();
        }

        public Task<PlayList> AddToPlayListAsync(string Video)
        {
            string id;
            string title;
            id = Helpers.Video.GetYoutubeVideoId(Video);

            title = id;

            PlayList playVideo = new PlayList
            {
                Id = id,
                Title = title,
                Url = Video
            };
            return Task.FromResult(playVideo);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                string assembly = typeof(YoutubePlayer).Assembly.GetName().Name;
                await JsRuntime.InvokeVoidAsync("youtubeApi.loadIFramePlayer", typeof(YoutubePlayer).Assembly.GetName().Name);
            }
        }

        public async Task PlayVideo()
        {
            await JsRuntime.InvokeVoidAsync("youtubeApi.payVideo", VideoId);
        }

        public async Task StopVideo()
        {
            await JsRuntime.InvokeVoidAsync("youtubeApi.stopVideo");
        }

        public void Dispose() 
        {
            IsApiLoad = false;
            IsPlayerReady = false;
        }

        public async ValueTask DisposeAsync() 
        {
            await JsRuntime.InvokeVoidAsync("youtubeApi.dispose");
            Dispose();
        }

    }
}
