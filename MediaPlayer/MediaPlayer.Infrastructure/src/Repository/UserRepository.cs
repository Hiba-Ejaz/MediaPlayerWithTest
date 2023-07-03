
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;

namespace MediaPlayer.src.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
         private readonly User _user;

         public UserRepository()
         {
        _user = User.Instance;
            }

        public PlayList AddNewList(string name, int userId)
        {
           
                PlayList playlist = new PlayList(name, userId);
                PlayList addedPlaylist=_user.AddNewList(playlist);
                return addedPlaylist;
            
    
        }

        public bool EmptyOneList(int listId, int userId)
        {
                PlayList playlist = _user.PlayLists.FirstOrDefault(p => p.GetId == listId);
                if (playlist != null)
                {
                    {
                       return _user.EmptyOneList(playlist);
                    }
                }
                else
                {
                    throw new ArgumentException("Playlist not found");
                }
            }
        

        public IEnumerable<PlayList> GetAllList(int userId)
    {
 
            return _user.PlayLists;
   
    }

        public PlayList GetListById(int listId)
        {
            PlayList playList=_user.PlayLists.FirstOrDefault(l=>l.GetId==listId);
            return playList;
        }

        public bool RemoveAllLists(int userId)
        {
           return _user.RemoveAllLists(userId);
        }

        public bool RemoveOneList(int listId, int userId)
        {
             PlayList playList=_user.PlayLists.FirstOrDefault(l=>l.GetId==listId);
           return _user.RemoveOneList(playList,userId);
        }

    }
}