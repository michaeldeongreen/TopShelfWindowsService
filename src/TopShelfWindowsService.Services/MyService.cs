using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TopShelfWindowsService.Domain;

namespace TopShelfWindowsService.Services
{
    public class MyService
    {
        private readonly Timer _timer;
        private readonly string _path;
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }

        public MyService()
        {
            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += OnTimedEvent;
            _path = ConfigurationManager.AppSettings["TopShelfWindowsServiceFilePath"];
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            IList<Movie> movies = new List<Movie>() { new Movie() { Name = "The Mack", ReleaseDate = DateTime.Now }, new Movie() { Name = "Hell Up in Harlem", ReleaseDate = DateTime.Now } };
            FileService fileService = new FileService();
            for (int i = 1; i <= 5; i++)
            {
                string filePath = $@"{_path}\{Guid.NewGuid()}.json";
                fileService.CreateFile(filePath, movies);
            }
        }
    }
}
