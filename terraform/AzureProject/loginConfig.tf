terraform {
    cloud {
    organization = "jamesvango-dev"

    workspaces {
        name = "dev"
    }
    }
}