namespace BlazorYoutubePlayerViewer.BusinessObjects.Mappers;

public static class PlayListMapper
{
    public static PlayList ToPlayListModel(this Entities.Models.PlayList playList) =>
        new PlayList
        {
            Id = playList.VideoId,
            Ownner = playList.Ownner,
            Title = playList.Title,
            Url = playList.Url
        };    

    public static Entities.Models.PlayList FromPlayListModel(this PlayList playList) =>
        new Entities.Models.PlayList
        {
            VideoId = playList.Id,
            Ownner = playList.Ownner,
            Title = playList.Title,
            Url = playList.Url
        };
}
