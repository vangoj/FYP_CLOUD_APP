# Configure the AWS Provider
provider "aws" {
    region = "eu-west-2"
    access_key = var.AccessKey
    secret_key = var.SecretKey
}

# Creates a bucket storage referenced bucket_a
resource "aws_s3_bucket" "bucket_a" {
    bucket = var.user_bucket_name # Uses a variable from the form to populate name
}

# sets the access control list (ACL) to be private
resource "aws_s3_bucket_acl" "example" {
    bucket = aws_s3_bucket.bucket_a.id
    acl    = "private"
}