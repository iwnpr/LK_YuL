namespace user_interface_private_web.Entities
{
    public class Documentation
    {
        public string PlatformPath { get; set; } = string.Empty;
        
        /// <summary>
        /// Maжорные версии платформ
        /// </summary>
        public Dictionary<string, string> MajorPlatforms = new();

        /// <summary>
        /// Выбранная мажорная версия платформы
        /// </summary>
        public string CurrentMajorPlatform = string.Empty;

        /// <summary>
        /// Минорные версии
        /// </summary>
        public Dictionary<string, string> MinorPlatforms = new();

        /// <summary>
        /// Выбранная минорная версия платформы
        /// </summary>
        public string CurrentMinorPlatform = string.Empty;

        public string UploadPath { get; set; } = string.Empty;

        /// <summary>
        /// Maжорные версии загрузок
        /// </summary>
        public Dictionary<string, string> MajorUploads = new();

        /// <summary>
        /// Выбранная мажорная версия загрузки
        /// </summary>
        public string CurrentMajorUpload = string.Empty;

        /// <summary>
        /// Минорные версии загрузок
        /// </summary>
        public Dictionary<string, string> MinorUploads = new();

        /// <summary>
        /// Выбранная минорная версия загрузки
        /// </summary>
        public string CurrentMinorUpload = string.Empty;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_path">Путь до документации разработчика</param>
        public Documentation(string _path)
        {
             PlatformPath = $"{_path}\\platform";

            // Формируем словарь из списка платформ
            var _dir = Directory.Exists(PlatformPath) ? Directory.GetDirectories(PlatformPath).ToList() : new();
            
            MajorPlatforms = _dir.Any()
                ? _dir.ToDictionary(x => _dir.IndexOf(x).ToString(), x => x.Replace(PlatformPath, "").Replace("\\", "")) 
                : new Dictionary<string, string>();
            

            // Текущая платформа - последняя из словаря
            CurrentMajorPlatform = MajorPlatforms.Any() ? MajorPlatforms.Values.Last() : string.Empty;

            // Получаем список версий текущей платформы
            _dir = Directory.Exists($"{PlatformPath}\\{CurrentMajorPlatform}") 
                ? Directory.GetDirectories($"{PlatformPath}\\{CurrentMajorPlatform}").ToList() 
                : new();

            MinorPlatforms = _dir.Any()
                ? _dir.ToDictionary(x => _dir.IndexOf(x).ToString(), x => x.Replace($"{PlatformPath}\\{CurrentMajorPlatform}", "").Replace("\\", ""))
                : new();

            // Текущая версия платформы - последняя из словаря
            CurrentMinorPlatform = MinorPlatforms.Any() ? MinorPlatforms.Values.Last() : string.Empty;

            UploadPath = $"{_path}\\upload";

            // Получаем список загрузок
            _dir = Directory.Exists(UploadPath) ? Directory.GetDirectories(UploadPath).ToList() : new();

            // Формируем словарь из списка загрузок
            MajorUploads = _dir.Any()
                ? _dir.ToDictionary(x => _dir.IndexOf(x).ToString(), x => x.Replace(UploadPath, "").Replace("\\", ""))
                : new Dictionary<string, string>();

            // Текущая платформа - последняя из словаря
            CurrentMajorUpload = MajorUploads.Any() ? MajorUploads.Values.Last() : string.Empty;

            // Получаем список версий текущей платформы
            _dir = Directory.Exists($"{UploadPath}\\{CurrentMajorUpload}") ? Directory.GetDirectories($"{UploadPath}\\{CurrentMajorUpload}").ToList() : new();
            MinorUploads = _dir.Any()
                ? _dir.ToDictionary(x => _dir.IndexOf(x).ToString(), x => x.Replace($"{UploadPath}\\{CurrentMajorUpload}", "").Replace("\\", ""))
                : new ();

            // Текущая версия платформы - последняя из словаря
            CurrentMinorUpload = MinorUploads.Any() ? MinorUploads.Values.Last() : string.Empty;

        }

        public void Update(string _majorPlatform, string _minorPlatform, string _majorUpload, string _minorUpload)
        {
            var _dir = new List<string>();

            // Изменилась мажорная версия платформы
            if (!CurrentMajorPlatform.Equals(_majorPlatform))
            {
                CurrentMajorPlatform = _majorPlatform;

                _dir = Directory.Exists($"{PlatformPath}\\{CurrentMajorPlatform}") ? Directory.GetDirectories($"{PlatformPath}\\{CurrentMajorPlatform}").ToList() : new();

                MinorPlatforms = _dir.Any()
                    ? _dir.ToDictionary(x => _dir.IndexOf(x).ToString(), x => x.Replace($"{PlatformPath}\\{CurrentMajorPlatform}", "").Replace("\\", ""))
                    : new();

                CurrentMinorPlatform = MinorPlatforms.Any() ? MinorPlatforms.Values.Last() : string.Empty;
            }

            // Изменилась минорная версия платформы
            else if (!CurrentMinorPlatform.Equals(_minorPlatform))
            {
                CurrentMinorPlatform = _minorPlatform;
            }

            // Изменилась мажорная версия загрузки
            if (!CurrentMajorUpload.Equals(_majorUpload))
            {
                CurrentMajorUpload = _majorUpload;

                _dir = Directory.Exists($"{UploadPath}\\{CurrentMajorPlatform}") ? Directory.GetDirectories($"{UploadPath}\\{CurrentMajorUpload}").ToList() : new();

                MajorUploads = _dir.Any()
                    ? _dir.ToDictionary(x => _dir.IndexOf(x).ToString(), x => x.Replace($"{UploadPath}\\{CurrentMajorUpload}", "").Replace("\\", ""))
                    : new();

                CurrentMinorUpload = MinorUploads.Any() ? MinorUploads.Values.Last() : string.Empty;
            }

            // Изменилась минорная версия загрузки
            else if (!CurrentMinorUpload.Equals(_minorUpload))
            {
                CurrentMinorUpload = _minorUpload;
            }
        }


    }
}
