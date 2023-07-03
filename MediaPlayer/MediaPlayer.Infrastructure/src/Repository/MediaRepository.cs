
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;

namespace MediaPlayer.src.Infrastructure.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private List<MediaFile> _mediaFiles;
        
        public MediaRepository()
        {
            _mediaFiles = new List<MediaFile>();
        }
        public MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
             bool isAudioFile = IsAudioFileType(filePath);
            MediaFile newFile = isAudioFile
                ? (MediaFile)new Audio(fileName, filePath, duration)
                : (MediaFile)new Video(fileName, filePath, duration);

            _mediaFiles.Add(newFile);
            return newFile;
           
        }
            private bool IsAudioFileType(string filePath)
        {
            return filePath.EndsWith(".mp3") || filePath.EndsWith(".wav");
        }

        public bool DeleteFileById(int fileId)
        {
         MediaFile fileToDelete = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);
            if (fileToDelete != null)
            {
                _mediaFiles.Remove(fileToDelete);
                return true;
            }
            return false;
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaFiles;
        }

        public MediaFile GetFileById(int fileId)
        {
             return _mediaFiles.FirstOrDefault(m => m.GetId == fileId);
        }

        public bool Pause(int fileId)
        {
           MediaFile mediaFile= _mediaFiles.FirstOrDefault(m => m.GetId == fileId);
            if(mediaFile!=null){
               Console.WriteLine("paused");
            return true;
            }
            return false;
        }

        public bool Play(int fileId)
        {
        MediaFile mediaFile= _mediaFiles.FirstOrDefault(m => m.GetId == fileId);
            if(mediaFile!=null){
               Console.WriteLine("played");
               return true;
            }
            return false;
        }

        public bool Stop(int fileId)
        {          
             MediaFile mediaFile= _mediaFiles.FirstOrDefault(m => m.GetId == fileId);
            if(mediaFile!=null){
               Console.WriteLine("stopped");
            return true;
            }
            return false;
        }
    }
}