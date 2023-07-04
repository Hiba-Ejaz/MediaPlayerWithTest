using MediaPlayer.src.Business.Sevice;
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;

namespace MediaPlayer.Tests.src
{
    public class UserServiceTest
    {
        [Fact]
        public void AddNewList_ValidData_ReturnNewPlayList()
        {
            string listName = "Classic";
            int userId = 1;
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);
            PlayList newList = userService.AddNewList(listName, userId);
            Assert.NotNull(newList);
        }

        [Fact]
        public void EmptyOneList_ValidData_ReturnBoolean()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);
            var playlist = fakeRepository.AddNewList("Classic", 1);
            bool result = userService.EmptyOneList(playlist.GetId, 1);
            Assert.True(result);
        }
        [Fact]
        public void RemoveAllLists_ValidData_ReturnBoolean()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);
            bool result = userService.RemoveAllLists(1);
            Assert.True(result);
            IEnumerable<PlayList> result2 = userService.GetAllList(1);
            //Assert.Null(result2);
            Assert.Empty(result2);
        }
        [Fact]
        public void GetAllLists_ValidData_ReturnList()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);
            IEnumerable<PlayList> result = userService.GetAllList(1);
            Assert.NotNull(result);
        }
        [Fact]
        public void RemoveOneList_ValidData_ReturnTrue()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);
            var playlist = fakeRepository.AddNewList("Classic", 1);
            //bool result = userService.EmptyOneList(playlist.GetId, 1);
            bool result = userService.RemoveOneList(playlist.GetId, playlist.GetUserId);
            Assert.True(result);
        }
        [Fact]
        public void GetListById_ValidData_ReturnList()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);
            userService.GetListById(1);
        }
    }

    public class FakeUserRepository : IUserRepository
    {
        private List<PlayList> _playLists = new List<PlayList>();
        public PlayList AddNewList(string name, int userId)
        {
            var playlist = new PlayList(name, userId);
            _playLists.Add(playlist);
            return playlist;
        }

        public bool EmptyOneList(int listId, int userId)
        {
            var playlist = _playLists.FirstOrDefault(p => p.GetId == listId && p.GetUserId == userId);
            if (playlist != null)
            {
                bool result = playlist.EmptyList(userId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAllLists(int userId)
        {
            var playlistsToRemove = _playLists.Where(p => p.GetUserId == userId).ToList();
            foreach (var playlist in playlistsToRemove)
            {
                _playLists.Remove(playlist);
            }

            return true;
        }

        public bool RemoveOneList(int listId, int userId)
        {
            var playlistToRemove = _playLists.FirstOrDefault(p => p.GetUserId == userId && p.GetId == listId);
            if (playlistToRemove != null)
            {
                _playLists.Remove(playlistToRemove);
                return true;
            }
            return false;
        }

        public IEnumerable<PlayList> GetAllList(int userId)
        {
            var playlists = _playLists.Where(p => p.GetUserId == userId).ToList();
            return playlists;
        }

        public PlayList GetListById(int listId)
        {
            var playList = _playLists.FirstOrDefault(p => p.GetId == listId);
            return playList;
        }
    }
}