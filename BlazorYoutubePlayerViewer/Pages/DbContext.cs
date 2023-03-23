using BlazorYoutubePlayerViewer.Helpers;

namespace BlazorYoutubePlayerViewer.Pages
{
    public partial class DbContext : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public IYoutubePlayerRepository _DBContext { get; set; }

        protected YoutubePlayer Reproductor = new YoutubePlayer();
        public List<PlayList> ListaReproduccion;
        public string UserName = "Gest";
        public string Video;
        private bool Clicked;

        protected override async Task OnInitializedAsync()
        {
            await LoadList();
        }

        public async Task LoadList()
        {
            await Task.Delay(50);
            ListaReproduccion = await _DBContext.GetVideos();
        }

        public async Task AddVideo()
        {
            if (!Clicked)
            {
                Clicked = true;
                PlayList video = await Reproductor.AddToPlayListAsync(Video);
                video.Ownner = UserName;
                CommandResponse result = await _DBContext.AddVideo(video);
                if (result.Result) ListaReproduccion.Add(video);
                else await JsRuntime.InvokeVoidAsync("alert", $"No se ha podido agregar el video. {result.Message}");
                Video = string.Empty;
                Clicked = false;
            }
        }

        public async Task DeleteVideo(string id)
        {
            if (!Clicked)
            {
                Clicked = true;
                CommandResponse result = await _DBContext.DeleteVideo(id);
                if (result.Result)
                {
                    PlayList video = ListaReproduccion.Where(v => v.Id == id).FirstOrDefault();
                    if (!ListaReproduccion.Remove(video)) await JsRuntime.InvokeVoidAsync("location.reload");
                }
                else await JsRuntime.InvokeVoidAsync("alert", "No se ha podido borrar el video");
                Clicked = false;
            }
        }
    }
}
