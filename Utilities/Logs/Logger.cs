﻿using System;
using Bot_Dofus_1._29._1.Utilities.Config;

namespace Bot_Dofus_1._29._1.Utilities.Logs
{
    public class Logger
    {
        public event Action<LogMessage, string> log_event;

        private void log_Final(string reference, string message, string color, Exception ex = null)
        {
            try
            {
                LogMessage log_Message = new LogMessage(reference, message, ex);
                log_event?.Invoke(log_Message, color);
            }
            catch (Exception e)
            {
                log_Final("LOGGER", "An error occured while registering the event", LogTypes.ERROR, e);
            }
        }

        private void log_Final(string reference, string message, LogTypes color, Exception ex = null)
        {
            if (color == LogTypes.DEBUG && !GlobalConfig.show_debug_messages)
                return;
            log_Final(reference, message, ((int)color).ToString("X"), ex);
        }

        public void log_Error(string reference, string message) => log_Final(reference, message, LogTypes.ERROR);
        public void log_Peligro(string reference, string message) => log_Final(reference, message, LogTypes.WARNING);
        public void log_informacion(string reference, string message) => log_Final(reference, message, LogTypes.INFORMATION);
        public void log_normal(string reference, string message) => log_Final(reference, message, LogTypes.NORMAL);
        public void log_privado(string reference, string message) => log_Final(reference, message, LogTypes.PRIVATE);
    }
}
