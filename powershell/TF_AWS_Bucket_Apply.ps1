$user_bucket_name = $args[0]

set-Location "C:\FYP_CLOUD_APP\terraform\AWSstorage" 
terraform apply -auto-approve -var "user_bucket_name=$user_bucket_name"
Pause