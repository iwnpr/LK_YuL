using System.Xml.Linq;

namespace application_lib.Entities.Records
{
    public record Upload
    {
        public long Id { get; set; }

        public DateTime Inserted { get; set; }

        public string Organization { get; set; }

        //public string User { get; set; }

        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Статус запроса
        /// </summary>
        public int? Status { get; set; }

        public Upload(long id, DateTime inserted, string upload, int? status, string org/*, string user*/)
        {
            Id = id;
            Inserted = inserted;
            Organization = org;
            //User = user;
            FileName = GetFileName(upload);
            Status = status;
        }

        private static string GetFileName(string xml) =>
            $"{(XDocument.Parse(xml).Descendants("package-info")?.FirstOrDefault()?.Attribute("source-file-name")?.Value ?? string.Empty)}";

    }
}
