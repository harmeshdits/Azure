using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeakSys.Kiosk.AzureFileManager
{
    public enum ShareType
    {
        Directory,
        File
    }
    public class DirectoryOrFile
    {
        [JsonProperty(PropertyName = "id")]
        public string Path { get; set; }
        public string ParentPath { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Title { get; set; }
        public ShareType Type { get; set; }
        [JsonProperty(PropertyName = "children")]

        public bool CanDelete { get; set; }

        public string Description { get; set; }
        public List<DirectoryOrFile> Children { get; set; }

        public DirectoryOrFile()
        {
            Children = new List<DirectoryOrFile>();
        }
    }
    public interface IAzureFileManager
    {
        void Upload(string folder, string file, byte[] fileData, string description = "");
        List<DirectoryOrFile> GetShareContents(string sharepath);

        List<DirectoryOrFile> GetShareContentsFlat(string sharepath);

        void Delete(string path);

        byte[] GetFile(string path);
    }
}
