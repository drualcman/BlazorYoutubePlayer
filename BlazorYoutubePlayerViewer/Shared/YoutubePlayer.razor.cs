using BlazorYoutubePlayerViewer.DataBase.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.Shared
{
    public partial class YoutubePlayer
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public string PlayerId { get; set; }

        [Parameter]
        public string VideoId { get; set; }

        public Task<PlayList> AddToPlayListAsync(string Video)
        {
            string id;
            string title;
            id = Helpers.Video.ExtraerId(Video);

            title = id;

            PlayList playVideo = new PlayList
            {
                Id = id,
                Title = title,
                Url = Video
            };
            return Task.FromResult(playVideo);
        }


        protected override async Task OnParametersSetAsync()
        {
            if (VideoId is not null)
                await JsRuntime.InvokeVoidAsync("youtubeApi.payVideo", VideoId);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsRuntime.InvokeVoidAsync("youtubeApi.loadIFramePlayer");
            }
        }

        async void PlayVideo()
        {
            await JsRuntime.InvokeVoidAsync("youtubeApi.payVideo", VideoId);
        }
    }
}
