
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;

namespace MediaPlayer.src.Infrastructure.Repository
{

    public class PlayListRepository : IPlayListRepository
    {
        //private readonly List<PlayList> _playLists = new();
        private readonly IMediaRepository _mediaRepository;
        private readonly User _user;
        private readonly List<PlayList> _playLists;
        public PlayListRepository(User user, IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
            _user = user;
            _playLists = _user.PlayLists.ToList();
        }

        public bool AddNewFile(int playListId, int fileId, int userId)
        {
            PlayList playlist = _playLists.FirstOrDefault(p => p.GetId == playListId && p.GetUserId == userId);
            if (playlist != null)
            {
                MediaFile file = _mediaRepository.GetFileById(fileId);
                if (file != null)
                {
                    return playlist.AddNewFile(file, userId);

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

        public bool RemoveFile(int playListId, int fileId, int userId)
        {
            PlayList playlist = _playLists.FirstOrDefault(p => p.GetId == playListId && p.GetUserId == userId);
            if (playlist != null)
            {
                MediaFile file = _mediaRepository.GetFileById(fileId);
                if (file != null)
                {
                    return playlist.RemoveFile(file, userId);
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
            PlayList playlist = _playLists.FirstOrDefault(p => p.GetId == playListId && p.GetUserId == userId);
            if (playlist != null)
            {
                return playlist.EmptyList(userId);
            }
            else
            {
                throw new ArgumentException("Playlist not found");
            }
        }
    }
}