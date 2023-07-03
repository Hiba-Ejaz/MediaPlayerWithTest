using System;
using MediaPlayer.src.Business.Sevice;
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Domain.RepositoryInterface;

namespace MediaPlayer.Tests.src
{
    public class MediaFileServiceTest
    {
        [Fact]
        public void CreateNewFile_ValidData_returnNewMediaFile()
        {
            var mediaRepo = new FakeMediaRepository();
            var mediaService = new MediaService(mediaRepo);
            MediaFile result = mediaService.CreateNewFile("video.mp4", "path/to/video.mp4", TimeSpan.FromMinutes(5));
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteFileById_ValidData_returnBoolean()
        {
            // Arrange
            var mediaRepo = new FakeMediaRepository();
            var mediaService = new MediaService(mediaRepo);
            var mediaFile = mediaService.CreateNewFile("video.mp4", "path/to/video.mp4", TimeSpan.FromMinutes(5));

            // Act
            bool isDeleted = mediaService.DeleteFileById(mediaFile.GetId);

            // Assert
            Assert.True(isDeleted);
        }

        [Fact]
        public void GetAllFiles_ValidData_returnAllFiles()
        {
            // Arrange
            var mediaRepo = new FakeMediaRepository();
            var mediaService = new MediaService(mediaRepo);
            var mediaFile1 = mediaService.CreateNewFile("video.mp4", "path/to/video.mp4", TimeSpan.FromMinutes(5));
            var mediaFile2 = mediaService.CreateNewFile("audio.mp3", "path/to/audio.mp3", TimeSpan.FromMinutes(5));
            // Act
            IEnumerable<MediaFile> allFiles = mediaService.GetAllFiles();

            // Assert
            Assert.Contains(mediaFile1, allFiles);
            Assert.Contains(mediaFile2, allFiles);

        }

        public void GetFileByID_ValidData_returnSingleFile()
        {
            // Arrange
            var mediaRepo = new FakeMediaRepository();
            var mediaService = new MediaService(mediaRepo);
            // Act
            MediaFile file = mediaService.GetFileById(1);

            // Assert
            Assert.NotNull(file);
        }
    }

    public class FakeMediaRepository : IMediaRepository
    {
        private List<MediaFile> _mediaFiles;


        public FakeMediaRepository()
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
            else
                return false;
        }

        public IEnumerable<MediaFile> GetAllFiles()
        {
            return _mediaFiles;
        }

        public MediaFile GetFileById(int fileId)
        {
            MediaFile file = _mediaFiles.FirstOrDefault(file => file.GetId == fileId);
            return file;

        }

        public bool Pause(int fileId)
        {
            throw new NotImplementedException();
        }

        public bool Play(int fileId)
        {
            throw new NotImplementedException();
        }

        public bool Stop(int fileId)
        {
            throw new NotImplementedException();
        }
    }
}