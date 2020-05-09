namespace TabloidCLI.UserInterfaceManagers
{
    internal class NoteManager : IUserInterfaceManager
    {
        private PostDetailManager postDetailManager;
        private string _connectionString;
        private int id;

        public NoteManager(PostDetailManager postDetailManager, string connectionString, int id)
        {
            this.postDetailManager = postDetailManager;
            _connectionString = connectionString;
            this.id = id;
        }

        public IUserInterfaceManager Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}