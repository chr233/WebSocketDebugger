using System.Text;
using System.Text.Json;

using WebSocketDebugger.Storage;

namespace WebSocketDebugger
{
    public static class Utils
    {
        internal static Config GlobalConfig { get; private set; } = new();

        /// <summary>
        /// 读取配置路径
        /// </summary>
        /// <returns></returns>
        public static string GetConfigFilePath()
        {
            string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string configFolder = Path.Combine(appFolder, nameof(WebSocketDebugger));

            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            string filePath = Path.Combine(configFolder, "config.json");
            return filePath;
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public static void SaveConfig()
        {
            string filePath = GetConfigFilePath();
            SaveConfig(filePath);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="filePath"></param>
        public static void SaveConfig(string filePath)
        {
#if DEBUG
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
#else
            JsonSerializerOptions options = new();
#endif

            string strConfig = JsonSerializer.Serialize(GlobalConfig, options);

            File.WriteAllText(filePath, strConfig, Encoding.UTF8);
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        public static void LoadConfig()
        {
            string filePath = GetConfigFilePath();

            LoadConfig(filePath);
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="filePath"></param>
        public static void LoadConfig(string filePath)
        {
            if (File.Exists(filePath))
            {
                string strConfig = File.ReadAllText(filePath, Encoding.UTF8);
                GlobalConfig = JsonSerializer.Deserialize<Config>(strConfig ?? "") ?? new();
            }
            else
            {
                GlobalConfig = new();
                SaveConfig(filePath);
            }
        }
    }
}
