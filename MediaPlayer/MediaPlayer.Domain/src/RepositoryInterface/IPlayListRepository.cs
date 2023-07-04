using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Domain.RepositoryInterface
{
    public interface IPlayListRepository
    {
        bool AddNewFile(int playListId, int fileId, int userId);
        bool RemoveFile(int playListId, int fileId, int userId);
        bool EmptyList(int playListId, int userId);
    }
}