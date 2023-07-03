namespace MediaPlayer.src.Domain.Core
{
    public class PlayList
    {
        private static int _nextId = 1;
        private readonly int _playlistId;
        private readonly List<MediaFile> _files = new();
        private readonly int _userId;

        public string ListName { get; set; }

        public PlayList(string name, int userId)
        {
            ListName = name;
            _userId = userId;
            _playlistId = _nextId++;
        }

        public int GetId => _playlistId;
        public int GetUserId => _userId;
        public void AddNewFile(MediaFile file, int userId)
        {
            if (CheckUserId(userId))
                _files.Add(file);
        }

        public void RemoveFile(MediaFile file, int userId)
        {
            if (CheckUserId(userId))
                _files.Remove(file);
        }

        public bool EmptyList(int userId)
        {
            if (CheckUserId(userId))
            {
                _files.Clear();
                return true;
            }
            else return false;

        }

        private bool CheckUserId(int userId)
        {
            if (userId == _userId) return true;
            return false;
        }
    }
}