using MediaPlayer.src.Business.Sevice;
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;
using Xunit;

namespace MediaPlayer.Tests.src
{
    public class PlayListServiceTest
    {
        [Fact]
        public void AddNewFile_ValidData_ReturnsBoolean()
        {
            var playListRepo = new FakePlayListRepository();
            var playListService = new PlayListService(playListRepo);
            bool result = playListService.AddNewFile(2, 1, 1);
            Assert.True(result);
        }

        [Fact]
        public void EmptyList_ValidData_ReturnsBoolean()
        {
            var playListRepo = new FakePlayListRepository();
            var playListService = new PlayListService(playListRepo);
            bool result = playListService.EmptyList(2, 1);
            Assert.True(result);
        }
    }
    public class FakePlayListRepository : IPlayListRepository
    {
        private readonly List<PlayList> _playLists;
        private readonly List<MediaFile> _mediaFiles;

        public FakePlayListRepository()
        {
            _playLists = new List<PlayList>();
            _mediaFiles = new List<MediaFile>();

            PlayList playlist1 = new PlayList("Playlist 1", 1);
            PlayList playlist2 = new PlayList("Playlist 2", 1);

            _playLists.Add(playlist1);
            _playLists.Add(playlist2);

            var audioFile = new Audio("audio.mp3", "path/to/audio.mp3", TimeSpan.FromMinutes(3), 1.5);
            var videoFile = new Video("video.mp4", "path/to/video.mp4", TimeSpan.FromMinutes(5), 1.0);

            playlist1.AddNewFile(audioFile, 1);
            playlist2.AddNewFile(videoFile, 1);

            _mediaFiles.Add(audioFile);
            _mediaFiles.Add(videoFile);
        }
        public bool AddNewFile(int playListId, int fileId, int userId)
        {
            PlayList playlist = _playLists.FirstOrDefault(p => p.GetId == playListId && p.GetUserId == userId);
            if (playlist != null)
            {
                MediaFile file = _mediaFiles.FirstOrDefault(m => m.GetId == fileId);
                if (file != null)
                {
                    Console.WriteLine("Simulated operation: Adding new file to playlist");
                    return true;
                }
                else
                {
                    throw new ArgumentException("Media file not found");
                }
            }
            else
            {
                throw new ArgumentException("Playlist not found");
            }
        }

        public bool EmptyList(int playListId, int userId)
        {
            Console.WriteLine($"playListId: {playListId}, userId: {userId}");
            PlayList playList2 = _playLists.FirstOrDefault(p => 2 == playListId && p.GetUserId == userId);
            if (playList2 != null)
            {
                Console.WriteLine("Simulated operation: Emptying playlist");
                return true;
            }
            else
            {
                throw new ArgumentException("Playlist not found");
            }
        }

        public bool RemoveFile(int playListId, int fileId, int userId)
        {
            PlayList playlist = _playLists.FirstOrDefault(p => p.GetId == playListId && p.GetUserId == userId);
            if (playlist != null)
            {
                MediaFile file = _mediaFiles.FirstOrDefault(m => m.GetId == fileId);
                if (file != null)
                {
                    Console.WriteLine("Simulated operation: Removing file from playlist");
                    return true;
                }
                else
                {
                    throw new ArgumentException("Media file not found");
                }
            }
            else
            {
                throw new ArgumentException("Playlist not found");
            }
        }
    }

}