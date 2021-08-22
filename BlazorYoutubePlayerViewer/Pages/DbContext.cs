using BlazorIndexedDb.Models;
using BlazorYoutubePlayerViewer.DataBase;
using BlazorYoutubePlayerViewer.DataBase.Entities;
using BlazorYoutubePlayerViewer.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.Pages
{
    public partial class DbContext : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public DBContext _DBContext { get; set; }


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
            ListaReproduccion = await _DBContext.VideoList.SelectAsync();
            StateHasChanged();
        }

        public async void AddVideo()
        {
            if (!Clicked)
            {
                Clicked = true;
                PlayList video = await Reproductor.AddToPlayListAsync(Video);
                video.Ownner = UserName;
                CommandResponse result = await _DBContext.VideoList.AddAsync(video);
                if (result.Result) ListaReproduccion.Add(video);
                else await JsRuntime.InvokeVoidAsync("alert", "No se ha podido agregar el video");
                Clicked = false;
                StateHasChanged();
            }
        }

        public async void DeleteVideo(string id)
        {
            if (!Clicked)
            {
                Clicked = true;
                CommandResponse result = await _DBContext.VideoList.DeleteAsync(id);
                if (result.Result)
                {
                    PlayList video = ListaReproduccion.Where(v => v.Id == id).FirstOrDefault();
                    if (!ListaReproduccion.Remove(video)) await JsRuntime.InvokeVoidAsync("location.reload");
                }
                else await JsRuntime.InvokeVoidAsync("alert", "No se ha podido borrar el video");
                Clicked = false;
                StateHasChanged();
            }
        }
    }
}
