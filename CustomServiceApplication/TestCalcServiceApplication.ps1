function LoadSharePointPowerShellEnvironment
{
	write-host 
	write-host "Setting up PowerShell environment for SharePoint" -foregroundcolor Yellow
	write-host 
	Add-PSSnapin "Microsoft.SharePoint.PowerShell" -ErrorAction SilentlyContinue
	write-host "SharePoint PowerShell Snapin loaded." -foregroundcolor Green
}

#
# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
# Test the custom service application
# +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
#

write-host 
LoadSharePointPowerShellEnvironment


write-host "Testing Wingtip Calculation Service Application..." -foregroundcolor Gray

$siteUri = 'http://intranet.wingtip.com'
write-host "   Using service context of site $siteUri..." -foregroundcolor Gray

write-host

write-host "Testing the service application..." -foregroundcolor Yellow
write-host "Adding 1+1..." -foregroundcolor Gray
$result = Invoke-CalcService -ServiceContext $siteUri -Add 1,1
write-host "Result of 1+1 = $result" -foregroundcolor Gray
write-host "Add method on Wingtip Calculation Service Application working." -foregroundcolor Green