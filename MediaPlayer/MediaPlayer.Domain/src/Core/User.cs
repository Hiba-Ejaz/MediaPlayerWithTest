namespace MediaPlayer.src.Domain.Core
{
    public class User : BaseEntity
    {
        private readonly List<PlayList> _lists = new();
        private static readonly Lazy<User> lazyInstance = new(() => new User());

        public string Name { get; set; } = string.Empty;

        private User() { }

        public static User Instance => lazyInstance.Value;

        public IReadOnlyList<PlayList> PlayLists
        {
            get { return _lists; }
        }
        public PlayList AddNewList(PlayList list)
        {
            _lists.Add(list);
            return list;
        }

        public bool RemoveOneList(PlayList list, int userId)
        {
            if (userId == GetId)
                if (_lists.Contains(list))
                {
                    _lists.Remove(list);
                    return true;
                }
                else
                    return false;
            throw new ArgumentNullException("Playlist is not found");

        }

        public bool RemoveAllLists(int userId)
        {
            if (userId == GetId)
            {
                _lists.Clear();
                return true;
            }
            else
            {
                throw new ArgumentException("User not found");
            }

        }

        public bool EmptyOneList(PlayList list)
        {
            if (_lists.Contains(list))
                return list.EmptyList(GetId);
            else
                throw new ArgumentNullException("Playlist is not found");
        }
    }
}