namespace BlazorYoutubePlayerViewer.InterfaceApadters.Gateways.Repositories;

public class YoutubePlayerRepository : IYoutubePlayerRepository
{
    DBContext _DBContext;

    public YoutubePlayerRepository(DBContext dBContext) => _DBContext = dBContext;

    public Task<CommandResponse> AddVideo(PlayList video) => _DBContext.VideoList.AddAsync(video.FromPlayListModel());

    public async Task<CommandResponse> UpdateVideo(PlayList video)
    {                                                                                          
        BusinessObjects.Entities.Models.PlayList fromDb = await GetVideoByVideoId(video.Id);        
        CommandResponse response;
        if(fromDb != null)
        {
            int id = fromDb.Id;
            fromDb = video.FromPlayListModel();
            fromDb.Id = id;
            response = await _DBContext.VideoList.UpdateAsync(fromDb);
        }
        else 
            response = await AddVideo(video);
        return response;
    }

    public async Task<CommandResponse> DeleteVideo(string id)
    {
        BusinessObjects.Entities.Models.PlayList toDelete = await GetVideoByVideoId(id);
        CommandResponse response = new CommandResponse(false, "Not found", new List<ResponseJsDb>() { new ResponseJsDb { Message = $"Video Id {id} not found", Result = false } });
        if (toDelete != null)
            response = await _DBContext.VideoList.DeleteAsync(toDelete.Id);
        return response;
    }

    private async Task<BusinessObjects.Entities.Models.PlayList> GetVideoByVideoId(string id)
    {           
        List<BusinessObjects.Entities.Models.PlayList> videos = await _DBContext.VideoList.SelectAsync();
        return videos.First(v=> v.VideoId == id);
    }

    public async Task<List<PlayList>> GetVideos()
    {
        List<BusinessObjects.Entities.Models.PlayList> list = await _DBContext.VideoList.SelectAsync();
        return list.Select(p=> p.ToPlayListModel()).ToList();
    }

    public async Task<PlayList> GetVideoFromId(string id)
    {
        BusinessObjects.Entities.Models.PlayList video = await _DBContext.VideoList.SelectAsync(id);
        return video.ToPlayListModel();
    }
}
