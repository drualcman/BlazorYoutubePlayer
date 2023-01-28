namespace BlazorYoutubePlayerViewer.Entities.Interfaces;

public interface IYoutubePlayerRepository
{
    Task<List<PlayList>> GetVideos();
    Task<PlayList> GetVideoFromId(string id);
    Task<CommandResponse> AddVideo(PlayList video);
    Task<CommandResponse> UpdateVideo(PlayList video);
    Task<CommandResponse> DeleteVideo(string id);
}
