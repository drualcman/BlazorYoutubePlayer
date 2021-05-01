using BlasorIndexedDb;
using BlasorIndexedDb.Models;
using BlazorYoutubePlayerViewer.DataBase.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorYoutubePlayerViewer.DataBase.Services
{
    public class PlayListService
    {
        private readonly IJSRuntime DBConn;
        public PlayListService(IJSRuntime js)
        {
            DBConn = js;
            Init();
        }

        public async Task<List<PlayList>> GetAsync() =>
            await DBConn.DbSelect<PlayList>();

        public async Task<List<ResponseJsDb>> AddAsync(PlayList toAdd)
            => await DBConn.DbInsert(toAdd);

        public async Task<List<ResponseJsDb>> UpdateAsync(PlayList toAdd)
            => await DBConn.DbUpdate(toAdd);

        #region helpers
        private async void Init()
        {
            List<PlayList> PlayLists = await DBConn.DbSelect<PlayList>();
            string UserName = "Init";
            if (PlayLists is null || PlayLists.Count < 1)
            {
                //feed a default data
                PlayLists = new List<PlayList>
                {
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "qeMFqkcPYcg",
                        Url = "https://youtu.be/qeMFqkcPYcg",
                        Title = "Eurythmics, Annie Lennox, Dave Stewart - Sweet Dreams (Are Made Of This) (Official Video)"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "StKVS0eI85I",
                        Url = "https://youtu.be/StKVS0eI85I",
                        Title = "Blondie - Call Me"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "pHCdS7O248g",
                        Url = "https://youtu.be/pHCdS7O248g",
                        Title = "Blondie - Rapture"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "Gg9cNGHl-bg",
                        Url = "https://youtu.be/Gg9cNGHl-bg",
                        Title = "ZZ Top - La Grange"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "eUDcTLaWJuo",
                        Url = "https://youtu.be/eUDcTLaWJuo",
                        Title = "ZZ Top - Legs"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "eVlRQn6AMYs",
                        Url = "https://youtu.be/eVlRQn6AMYs",
                        Title = "AC/DC - The Jack (Live At River Plate, December 2009)"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "9wPHxQMgdKs",
                        Url = "https://youtu.be/9wPHxQMgdKs",
                        Title = "Mötley Crüe - Looks That Kill (Official Music Video)"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "jC0kHsTtzCA",
                        Url = "https://youtu.be/jC0kHsTtzCA",
                        Title = "Motley Crue - Shout At The Devil"
                    },
                    new PlayList
                    {
                        Ownner = UserName,
                        Id = "QUvVdTlA23w",
                        Url = "https://youtu.be/QUvVdTlA23w",
                        Title = "Marilyn Manson - Sweet Dreams (Are Made Of This) (Alt. Version)"
                    }
                };
                await DBConn.DbInsert(PlayLists);
            }
        }
        #endregion
    }
}
