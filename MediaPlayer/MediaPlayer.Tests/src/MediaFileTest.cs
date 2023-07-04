using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.src.Domain.Core;
using Xunit;

namespace MediaPlayer.Tests.src
{
    public class MediaFileTest
    {
        [Fact]
        public void createAudio_ValidData_ReturnAudio()
        {
            //Arrange and act
            var audio = new Audio("audio.mp3", "path/to/audio.mp3", TimeSpan.FromMinutes(3), 1.5);
            //Assert
            Assert.Equal("audio.mp3", audio.FileName);
            Assert.Equal("path/to/audio.mp3", audio.FilePath);
            Assert.Equal(TimeSpan.FromMinutes(3), audio.Duration);
            Assert.Equal(1.5, audio.Speed);
        }

        [Fact]
        public void createAudio_InValidData_ReturnAudio()
        {
            Assert.Throws<ArgumentException>(() => new Audio("audioFailed.mp3", "path/to/audio.mp3", TimeSpan.FromMinutes(3), 5));
        }

        [Fact]
        public void createVideo_ValidData_ReturnVideo()
        {
            var video = new Video("video.mp4", "path/to/video.mp4", TimeSpan.FromMinutes(5), 1.0);
            Assert.Equal("video.mp4", video.FileName);
            Assert.Equal("path/to/video.mp4", video.FilePath);
            Assert.Equal(TimeSpan.FromMinutes(5), video.Duration);
            Assert.Equal(1.0, video.Speed);
        }
        [Theory]
        [InlineData("video1.mp4", "path/to/video1.mp4", 5, 2.0)]
        [InlineData("video2.mp4", "path/to/video2.mp4", 5, null)]
        public void createVideoFromDifferentConstructors_ValidData_ReturnVideo(string fileName, string filePath, int duration, double? speed)
        {
            //Arrange
            Video video;
            if (speed.HasValue)
            {
                //act
                video = new Video(fileName, filePath, TimeSpan.FromMinutes(duration), speed.Value);
            }
            else
            {
                video = new Video(fileName, filePath, TimeSpan.FromMinutes(duration));
            }
            //Assert
            Assert.Equal(fileName, video.FileName);
            Assert.Equal(filePath, video.FilePath);
            Assert.Equal(TimeSpan.FromMinutes(duration), video.Duration);
            Assert.Equal(speed ?? 1.0, video.Speed);
        }
        // [Fact]

        // public void Play_ShouldStartPlaying()
        // {
        //     // Arrange
        //     var mediaFile = new Audio("media.mp3", "path/to/media.mp3", TimeSpan.FromMinutes(3), 1.5);

        //     // Act
        //     mediaFile.Play();

        //     // Assert
        //     Assert.True(mediaFile.IsPlaying);
        // }
    }
}