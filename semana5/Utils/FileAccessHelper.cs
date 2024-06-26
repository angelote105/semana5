using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana5.Utils
{
    public class FileAccessHelper
    {

        public static string GetLocalFilePath(string filename)
        {
            //se va a crear la ruta para la bd 

            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }

    }
}
