# Add appcmd.exe to the path

set-itemproperty -path "HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" -name path -value ""%systemroot%;%systemroot%\system32;%systemroot%\system32\WindowsPowerShell\v1.0\;%systemroot%\system32\inetsrv"

