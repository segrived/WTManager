using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace WTManager
{
    public class ServiceCommand
    {
        public string Name { get; set; }
        public string Arguments { get; set; }
        public string Command { get; set; }
    }

    public class ServiceConfigData
    {
        /// <summary>
        /// Название сервиса
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Используемый порт
        /// </summary>
        public int UsedPort { get; set; }

        /// <summary>
        /// Пусть к файлу лога
        /// </summary>
        public List<string> Logs { get; set; }

        /// <summary>
        /// Базовый путь к директории
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Конфигурационные файлы
        /// </summary>
        public IEnumerable<string> ConfFiles { get; set; }

        public IEnumerable<ServiceCommand> Commands { get; set; }

        public bool OpenInBrowser { get; set; }

        public string DataDirectory { get; set; }

        public string Group { get; set; }
    }
}