namespace BlazorYoutubePlayerViewer.InterfaceApadters.Gateways
{
    public class DBContext : StoreContext<DBContext>
    {
        #region properties
        public StoreSet<BusinessObjects.Entities.Models.PlayList> VideoList { get; set; }
        #endregion

        #region constructor
        public DBContext(IJSRuntime js) : base(js, new Settings { DBName = "MyDBName", Version = 1 }) { Settings.EnableDebug = true; }
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
