terraform {
  required_providers {
    azurerm = {
        source  = "hashicorp/azurerm"
        version = "=3.0.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}

  client_id       = var.client_id
  client_secret   = var.client_secret
  tenant_id       = var.tenant_id
  subscription_id = var.subscription_id
}

#Creating an Azure resource group to deploy to the resource in
resource "azurerm_resource_group" "example" {
  name     = "example-resource-group"
  location = "eastus"
}

#Creating a virtual network for the VM to be part of
resource "azurerm_virtual_network" "example" {
  name                = "example-vnet"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
}

#Creating a subnet
resource "azurerm_subnet" "example" {
  name                 = "example-subnet"
  address_prefixes     = ["10.0.1.0/24"]
  resource_group_name  = azurerm_resource_group.example.name
  virtual_network_name = azurerm_virtual_network.example.name
}

#Setting a public ip address that will be assigned to the vm 
resource "azurerm_public_ip" "example" {
  name                = "example-public-ip"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name

  allocation_method = "Static"
}

#createing a nic that can be assigned to the vm
resource "azurerm_network_interface" "example" {
  name                = "example-nic"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.example.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.example.id
  }
}

#Creating and configuring the vm 
resource "azurerm_virtual_machine" "example" {
  name                = "example-vm"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  vm_size             = "Standard_B1s"

  storage_image_reference {
    publisher = "Canonical"
    offer     = "UbuntuServer"
    sku       = "18.04-LTS"
    version   = "latest"
  }

  storage_os_disk {
    name              = "example-os-disk"
    caching           = "ReadWrite"
    create_option     = "FromImage"
    managed_disk_type = "Standard_LRS"
  }

  os_profile {
    computer_name  = "example-vm"
    admin_username = "adminuser"
    admin_password = "P@ssword!"
  }

  os_profile_linux_config {
    disable_password_authentication = false
  }

  network_interface_ids = [
    azurerm_network_interface.example.id
  ]
}

  resource "null_resource" "example_remote_exec" {
    connection {
        type      = "ssh"
        user      = "adminuser"
        password  = "P@ssword!"
        host      = "${azurerm_public_ip.example.ip_address}"
      }

    provisioner "remote-exec" {
      inline = [
        "sudo apt-get update",
        "sudo apt-get install -y apache2",
        "sudo systemctl start apache2",
        "sudo systemctl enable apache2",
        "sudo bash -c 'echo Azure Test Web App!> /var/www/html/index.html'"
      ]   
    }
}

# Prints the public IP addres to the console
output "server_public_ip" {
    value = "${azurerm_public_ip.example.ip_address}"
}
