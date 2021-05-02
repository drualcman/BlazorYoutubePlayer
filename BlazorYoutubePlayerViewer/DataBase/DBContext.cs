using BlazorIndexedDb;
using BlazorIndexedDb.Models;
using BlazorYoutubePlayerViewer.DataBase.Entities;
using BlazorYoutubePlayerViewer.DataBase.Services;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.DataBase
{
    public class DBContext
    {
        #region properties
        public PlayListService PlayList { get; private set; }
        #endregion

        #region constructor
        public DBContext(IJSRuntime js)
        {
            _ = js.DbInit("BlazorYoutubePlayer", 1, new string[] { "PlayList" }, "BlazorYoutubePlayerViewer", "BlazorYoutubePlayerViewer.DataBase.Entities");
            PlayList = new PlayListService(js);
        }
        #endregion

        #region helpers
        public void ProcessErrors(List<ResponseJsDb> result)
        {
            string errors = string.Empty;
            foreach (ResponseJsDb error in result)
            {
                errors += error.Message + "<br/>";
            }
            Console.WriteLine(errors);
        }
        #endregion
    }
}
