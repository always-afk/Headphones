using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphonesShop.BusinessLogic.Services.Implementation
{
    public class FileWorker : Interfaces.IFileWorker
    {
        public void SaveToDisc(MemoryStream file, string path)
        {
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                file.Position = 0;
                file.CopyTo(filestream);
            }
        }
    }
}
