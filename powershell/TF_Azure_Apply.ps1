$cpuVar = $args[0]
$publisher = $args[1]
$offer = $args[2]
$sku = $args[3]


set-Location "C:\FYP_CLOUD_APP\terraform\AzureWebserver" 
terraform apply -auto-approve -var "cpuVar=$cpuVar" -var "publisher=$publisher" -var "offer=$offer" -var "sku=$sku"
Pause