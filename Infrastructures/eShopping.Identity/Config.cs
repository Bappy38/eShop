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
                new ApiScope("CatalogAPI.Read"),
                new ApiScope("CatalogAPI.Write"),
                new ApiScope("BasketAPI"),
                new ApiScope("eShoppingGateway")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("Catalog", "Catalog.API")
                {
                    Scopes = { "CatalogAPI.Read", "CatalogAPI.Write" }
                },
                new ApiResource("Basket", "Basket.API")
                {
                    Scopes = { "BasketAPI" }
                },
                new ApiResource("EShoppingGateway", "EShopping Gateway")
                {
                    Scopes = { "eShoppingGateway" }
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
                    AllowedScopes = { "CatalogAPI.Read", "CatalogAPI.Write" }
                },
                new Client
                {
                    ClientId = "BasketApiClient",
                    ClientName = "Basket API Client",
                    ClientSecrets = { new Secret("basket-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "BasketAPI" }
                },
                new Client
                {
                    ClientId = "EShoppingGatewayClient",
                    ClientName = "EShopping Gateway Client",
                    ClientSecrets = { new Secret("gateway-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "eShoppingGateway" }
                }
            };
    }
}