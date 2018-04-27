using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopShelfWindowsService.Domain;

namespace TopShelfWindowsService.Services
{
    public class FileService
    {
        public void CreateFile(string filePath, IEnumerable<Movie> movies)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(movies));
        }
    }
}
