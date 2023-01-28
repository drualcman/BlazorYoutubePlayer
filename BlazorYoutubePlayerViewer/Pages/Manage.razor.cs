namespace BlazorYoutubePlayerViewer.Pages
{
    public partial class Manage
    {
        bool ShowingDialog;

        PlayList VideoEdit = new PlayList();

        async void Guardar()
        {
            string id = VideoEdit.Id;
            
            CommandResponse result;
            if (id != Helpers.Video.GetYoutubeVideoId(VideoEdit.Url))
            {
                //video modificado, eliminar el anterior de la base de datos y agregar el nuevo
                result = await _DBContext.DeleteVideo(id);
                if (result.Result)
                {
                    VideoEdit.Id = Helpers.Video.GetYoutubeVideoId(VideoEdit.Url);
                    result = await _DBContext.AddVideo(VideoEdit);
                }
            }
            else  result = await _DBContext.UpdateVideo(VideoEdit);
            if (result.Result)
            {
                ShowingDialog = false;
                await LoadList();
            }
            else await JsRuntime.InvokeVoidAsync("alert", "No se ha podido guardar los cambios.");
        }

        void Cancel()
        {
            ShowingDialog = false;
        }

        async Task EditVideo(string id)
        {
            VideoEdit = await _DBContext.GetVideoFromId(id);
            ShowingDialog = true;
            await InvokeAsync(StateHasChanged);
        }
    }
}
