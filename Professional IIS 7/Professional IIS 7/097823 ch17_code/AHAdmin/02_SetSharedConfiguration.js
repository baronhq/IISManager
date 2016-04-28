try{

var configPath = "c:\\SharedConfig";
var username = "User1";
var password = "User1";

var config =
	WScript.CreateObject(
	"Microsoft.ApplicationHost.WritableAdminManager" );

config.CommitPath = "MACHINE/REDIRECTION";

var section = config.GetAdminSection(
	"configurationRedirection",
	config.CommitPath);

section.Properties.Item( "enabled" ).Value = true;
section.Properties.Item( "path" ).Value = configPath;
section.Properties.Item( "userName" ).Value = username;
section.Properties.Item( "password" ).Value = password;

//comment the changes
config.CommitChanges();
}

//catch and output any error
catch(e)
{
WScript.Echo(e.number);
WScript.Echo(e.description);
}