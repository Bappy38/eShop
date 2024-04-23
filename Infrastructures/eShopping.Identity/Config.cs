﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace eShopping.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogAPI"),
                new ApiScope("BasketAPI")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("Catalog", "Catalog.API")
                {
                    Scopes = { "CatalogAPI" }
                },
                new ApiResource("Basket", "Basket.API")
                {
                    Scopes = { "BasketAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "CatalogApiClient",
                    ClientName = "Catalog API Client",
                    ClientSecrets = { new Secret("catalog-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "CatalogAPI" }
                },
                new Client
                {
                    ClientId = "BasketApiClient",
                    ClientName = "Basket API Client",
                    ClientSecrets = { new Secret("basket-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "BasketAPI" }
                }
            };
    }
}