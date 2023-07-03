
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Business.ServiceInterface
{
    public interface IMediaService
    {
        MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration);
        bool DeleteFileById(int id);
        IEnumerable<MediaFile> GetAllFiles();
        MediaFile GetFileById(int id);
    }
}