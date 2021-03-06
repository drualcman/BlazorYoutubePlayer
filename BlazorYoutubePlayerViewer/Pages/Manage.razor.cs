using BlazorIndexedDb.Models;
using BlazorYoutubePlayerViewer.DataBase.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (id != Helpers.Video.ExtraerId(VideoEdit.Url))
            {
                //video modificado, eliminar el anterior de la base de datos y agregar el nuevo
                result = await _DBContext.VideoList.DeleteAsync(id);
                if (result.Result)
                {
                    VideoEdit.Id = Helpers.Video.ExtraerId(VideoEdit.Url);
                    result = await _DBContext.VideoList.AddAsync(VideoEdit);
                }
            }
            else  result = await _DBContext.VideoList.UpdateAsync(VideoEdit);
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

        async void EditVideo(string id)
        {
            VideoEdit = await _DBContext.VideoList.SelectAsync(id);
            ShowingDialog = true;
            StateHasChanged();
        }
    }
}
