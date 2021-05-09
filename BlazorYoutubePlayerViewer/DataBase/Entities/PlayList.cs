using BlazorIndexedDb.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.DataBase.Entities
{
    public class PlayList
    {
        [IndexDb(IsKeyPath = true, IsAutoIncremental = false, IsUnique = true)]
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Ownner { get; set; }
    }
}
