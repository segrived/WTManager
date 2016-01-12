using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;

namespace WTManager
{
    public class ServiceCommand
    {
        public string Name { get; set; }
        public string Arguments { get; set; }
        public string Command { get; set; }
    }

    public class Service
    {
        /// <summary>
        /// Название сервиса
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Отображаемое имя
        /// </summary>
        private string _displayName;
        public string DisplayName {
            get { return _displayName ?? ServiceName; }
            set { _displayName = value; }
        }

        /// <summary>
        /// Используемый порт
        /// </summary>
        public int UsedPort { get; set; }

        /// <summary>
        /// Базовый путь к директории
        /// </summary>
        private string _basePath;
        public string BasePath {
            get { return _basePath ?? string.Empty; }
            set { _basePath = value; }
        }


        public IEnumerable<ServiceCommand> Commands { get; set; }

        public bool OpenInBrowser { get; set; }

        /// <summary>
        /// Конфигурационные файлы
        /// </summary>
        private IEnumerable<string> _configFiles;
        public IEnumerable<string> ConfigFiles {
            get { return _configFiles?.Select(f => Path.Combine(BasePath, f)); }
            set { _configFiles = value; }
        }

        /// <summary>
        /// Пусть к файлу лога
        /// </summary>
        private IEnumerable<string> _logFiles;
        public IEnumerable<string> LogFiles {
            get { return _logFiles?.Select(f => Path.Combine(BasePath, f)); }
            set { _logFiles = value; }
        }

        private string _dataDirectory;
        public string DataDirectory {
            get { return Path.Combine(BasePath, _dataDirectory ?? String.Empty); }
            set { _dataDirectory = value; }
        }

        public string Group { get; set; }

        private ServiceController _controller;
        [YamlDotNet.Serialization.YamlIgnore]
        public ServiceController Controller {
            get
            {
                if (_controller == null) {
                    _controller = new ServiceController(ServiceName);
                }
                return _controller;
            }
        }
    }
}