variable cpuVar {
    type        = string
    default     = ""
    description ="CPU"
}

variable publisher {
    type        = string
    default     = ""
    description ="Publisher"
}

variable offer {
    type        = string
    default     = ""
    description ="Offer"
}

variable sku {
    type        = string
    default     = ""
    description ="SKU"
}

variable "ubuntu_commands" {
    default = [
    "sudo apt-get update",
    "sudo apt-get install -y apache2",
    "sudo systemctl start apache2",
    "sudo systemctl enable apache2",
    "sudo bash -c 'echo Azure Test Web App! On Ubuntu> /var/www/html/index.html'"
    ]
}

variable "debian_commands" {
    default = [
    "sudo apt-get update",
    "sudo apt-get install -y apache2",
    "sudo systemctl start apache2",
    "sudo systemctl enable apache2",
    "sudo bash -c 'echo Azure Test Web App! On Debian> /var/www/html/index.html'"
    ]
}