using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.src.Business.ServiceInterface
{
    public interface IPlayListService
    {
        bool AddNewFile(int playListId, int fileId, int userId);
        bool RemoveFile(int playListId, int fileId, int userId);
        bool EmptyList(int playListId, int userId);
    }
}