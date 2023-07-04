using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.src.Domain.Core
{
    public class Audio : MediaFile
    {
        private int v1;
        private string v2;

        public Audio(string fileName, string filePath, TimeSpan duration, double speed) : base(fileName, filePath, duration, speed)
        {
        }
    public Audio(string fileName, string filePath, TimeSpan duration) : base(fileName, filePath, duration)
        {
        }

    }
}