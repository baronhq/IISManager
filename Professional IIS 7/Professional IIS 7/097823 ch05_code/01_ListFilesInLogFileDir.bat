# List log files in logfile directory using For and Appcmd

FOR /F %f IN ('AppCmd.exe list site "default web site" /text:logfile.directory') DO DIR %f