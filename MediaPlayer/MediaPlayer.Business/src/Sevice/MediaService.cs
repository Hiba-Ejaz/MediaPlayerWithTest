using MediaPlayer.src.Business.ServiceInterface;
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;

namespace MediaPlayer.src.Business.Sevice
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository; 
        }

        public MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {

           return _mediaRepository.CreateNewFile(fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
          return  _mediaRepository.DeleteFileById(id);
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaRepository.GetAllFiles();
        }

        public MediaFile GetFileById(int id)
        {
           return _mediaRepository.GetFileById(id);
        }
    }
}