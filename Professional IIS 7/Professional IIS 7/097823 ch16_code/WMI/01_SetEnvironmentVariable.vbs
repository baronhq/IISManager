'Add AppCmd.exe to system path

Const HKLM = &H80000002
strComputer = "."

Set objRegistry = GetObject("winmgmts:\\" & strComputer & _
	"\root\default:StdRegProv")

strKeyPath = "System\CurrentControlSet\Control\Session Manager\Environment"
strValueName = WScript.Arguments.Item(0)
strValue = WScript.Arguments.Item(1)

objRegistry.SetStringValue HKLM, strKeyPath, strValueName, strValue
