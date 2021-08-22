using BlazorIndexedDb;
using BlazorIndexedDb.Configuration;
using BlazorIndexedDb.Models;
using BlazorIndexedDb.Store;
using BlazorYoutubePlayerViewer.DataBase.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.DataBase
{
    public class DBContext : StoreContext
    {
        #region properties
        public StoreSet<PlayList> VideoList { get; set; }
        #endregion

        #region constructor
        public DBContext(IJSRuntime js) : base(js, new Settings { DBName = "MyDBName", Version = 1 }) { }

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
