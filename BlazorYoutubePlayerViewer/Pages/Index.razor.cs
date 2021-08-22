using BlazorYoutubePlayerViewer.DataBase;
using BlazorYoutubePlayerViewer.DataBase.Entities;
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

        string Playing = "qeMFqkcPYcg";

        void PlayVideo()
        {
            Playing = Helpers.Video.ExtraerId(Video);
        }
    }
}
