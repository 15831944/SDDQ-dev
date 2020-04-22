using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
namespace Infrastructure
{
    public class WorkEnvironment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _fileName = null;
        private FileInfo _fileInfo = null;
        private WorkEnvironment()
        { }
        /// <summary>
        /// 单例
        /// </summary>
        private static WorkEnvironment _instance = null;
        public static WorkEnvironment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WorkEnvironment();
                }
                return _instance;
            }
        }
        public string Title
        {
            get
            {
                return $"OTLD -{_fileName}";
            }
        }
        public string FilePath { get=> _fileInfo.DirectoryName; }
        public string AppPath { get => AppDomain.CurrentDomain.SetupInformation.ApplicationBase; }
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {               
                    _fileName = value;
                if (_fileName != null)
                     _fileInfo = new FileInfo(_fileName);
                 NotifyPropertyChanged();
                 NotifyPropertyChanged(nameof(Title));
                               
            }
        }
     
        public bool HasFileName => !string.IsNullOrWhiteSpace(FileName);

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
