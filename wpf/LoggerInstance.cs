﻿using System;
using System.ServiceProcess;
using System.Text.RegularExpressions;

namespace AgilusLogger
{
    class LoggerInstance:ServiceController
    {
        //private ServiceController _service;
        private ServiceController _service;
        public ServiceController Service
        {
            get
            {
                return _service;
            }

            private set
            {
                ServiceNamePortParser(value.DisplayName);
                _service = value;
            }
        }
        public ServiceController Logger;
        private string _serviceFolderPath;
        public string ServiceFolderPath
        {
            get
            {
                return _serviceFolderPath;
            }

            private set
            {
                
                _serviceFolderPath = value;
            }
        }
        private string EntityName { get;  set; }
        private int Port { get;  set; }
        

        public LoggerInstance(ServiceController service)
        {
            Service = service;
        }

        public LoggerInstance()
        {
        }

        private void ServiceNamePortParser(string displayName)
        {
            var regex = new Regex(@"(?:Agilus\sLogger\s)(?:-\s)(\w*\s)(?:\(porta:\s)(\d*)");
            var match = regex.Match(displayName);
            EntityName = match.Groups[1].Value;
            Port = int.Parse(match.Groups[2].Value);
            ServiceFolderPath = EntityName;
        }

        override public string ToString()
        {
            return $"{EntityName} - {Port}";
        }

    }

}