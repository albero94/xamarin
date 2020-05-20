using Microsoft.Azure.Mobile.Server;
using System;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class Note : EntityData
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}