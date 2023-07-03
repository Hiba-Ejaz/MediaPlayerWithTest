using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Business.ServiceInterface
{
    public interface IUserService
    {
        PlayList AddNewList(string name, int userId);
        bool RemoveOneList(int listId, int userId);
        bool RemoveAllLists(int userId);
        bool EmptyOneList(int listId, int userId);
        IEnumerable<PlayList> GetAllList(int userId);
        PlayList GetListById(int listId);
    }
}