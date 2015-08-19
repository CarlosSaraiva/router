﻿using System.ServiceProcess;
using System.Text.RegularExpressions;

namespace AgilusLogger
{
    public class LoggerService
    {        
        public string EntityName { get; private set; }
        public string Status { get; set; }
        public ServiceController Service { get; set; }
        public string Port { get; private set; }
        public LoggerService(ServiceController serviceController)
        {
            Service = serviceController;            
            Status = Service.Status.ToString();            
            DisplayNameParser(Service.DisplayName);
        }
        private void DisplayNameParser(string displayName)
        {
            Regex regex = new Regex(@"(?:Agilus\sLogger\s)(?:-\s)(\w*\s)(?:\(porta:\s)(\d*)");
            Match match = regex.Match(displayName);
            EntityName = match.Groups[1].Value;
            Port = match.Groups[2].Value;
        }
    }
}