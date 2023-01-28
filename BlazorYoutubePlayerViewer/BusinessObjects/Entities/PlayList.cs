namespace BlazorYoutubePlayerViewer.BusinessObjects.Entities.Models
{
    public class PlayList
    {
        [Field(IsKeyPath = true, IsAutoIncremental = true, IsUnique = true)]
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Ownner { get; set; }
    }
}