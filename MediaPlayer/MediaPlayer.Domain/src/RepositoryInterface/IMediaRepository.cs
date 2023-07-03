using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Domain.RepositoryInterface
{
    public interface IMediaRepository
    {
        bool Play(int fileId);
        bool Pause(int fileId);
        bool Stop(int fileId);
        MediaFile CreateNewFile(string fileName, string filePath, TimeSpan duration);
        bool DeleteFileById(int fileId);
        IEnumerable<MediaFile> GetAllFiles();
        MediaFile GetFileById(int fileId);
    }
}