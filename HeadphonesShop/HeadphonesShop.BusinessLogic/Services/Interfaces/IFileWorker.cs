using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Interfaces
{
    public interface IFileWorker
    {
        public void SaveToDisc(MemoryStream file, string path);
        public void SaveToDiscInFolder(MemoryStream file, string path, string folder);
    }
}
