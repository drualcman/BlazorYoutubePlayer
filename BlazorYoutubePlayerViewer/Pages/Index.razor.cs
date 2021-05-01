using BlazorYoutubePlayerViewer.DataBase;
using BlazorYoutubePlayerViewer.DataBase.Entities;
using BlazorYoutubePlayerViewer.DataBase.Services;
using BlazorYoutubePlayerViewer.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        YoutubePlayer miReproductor;

        string UserName = $"Gest-{Guid.NewGuid()}";

        List<PlayList> PlayList;

        string Playing = "qeMFqkcPYcg";
        string Video;

        DBContext dBContext;

        protected override void OnInitialized()
        {
            dBContext = new DBContext(JsRuntime);            
        }

        protected override async Task OnInitializedAsync()
        {
            PlayList = await dBContext.PlayList.GetAsync();
        }

        void PlayVideo()
        {
            Playing = Helpers.Video.ExtraerId(Video);
        }

        async void AddVideo()
        {
            PlayList video = await miReproductor.AddToPlayListAsync(Video);
            video.Ownner = UserName;

            await dBContext.PlayList.AddAsync(video);

            PlayList.Add(video);

            StateHasChanged();
        }
    }
}
