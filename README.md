# FYP_CLOUD_APP
Repo for my fyp app.

This app is designed to deploy cloud resources to multiple cloud providers in one interface. 

To run the app the following needs to be done. 

1. Install Terraform CLI - https://developer.hashicorp.com/terraform/tutorials/aws-get-started/install-cli

2. Add Terraform to System PATH

2. Install AWS CLI and add to system PATH - https://docs.aws.amazon.com/cli/latest/userguide/getting-started-install.html

4. Install Azure CLI and add to system PATH - https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli

5. Folder should be stored in the root of c: (c:/FYP_CLOUD_APP)

6. uncomment the access code templates stored at c:/FYP_CLOUD_APP/terraform/*project*/*cloudProvider*_access_code_template and enter your cloud provider access details. This needs to be done for each of the 3 projects - links with more information are below. 

7. For each project open a powershell window and run 'terraform -init' to initialise each project 

8. To be able to connect to the AWS VM a security key needs to be made. In the code it is named 'main-key' so a key with this name can be made or the name can be changed to a key that already exsists. This is in AWSwebserver/main.tf line 135. 


Details on how to get your AWS access codes can be found here - https://registry.terraform.io/providers/hashicorp/aws/latest/docs
and this is for Azure - https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs