// az deployment sub create --name AzureCacheForRedisIntro --location eastus2 --template-file main.bicep
// az group delete --name rg-cache-prod-eastus2

// Scope
targetScope = 'subscription'

// Shared variables
var location = deployment().location
var rgName = 'rg-cache-prod-eastus2'

// AppService variables
var appServiceName = 'apps-cache-prod-eastus2'
var appServicePlanName = 'appsp-cache-prod-eastus2'
var appServicePlanSku = 'B1'
var appServiceRuntime = 'DOTNETCORE|6.0'

// Azure Cache for Redis variables
var redisCacheName = 'redis-cache-prod-eastus2'
var redisCacheSKU = 'Basic'
var redisCacheFamily = 'C'
var redisCacheCapacity = 0
var enableNonSslPort = false

resource rg 'Microsoft.Resources/resourceGroups@2020-10-01' = {
  location: location
  name: rgName
}

module appServiceModule './Modules/AzureWebAppModule.bicep' = {
  name: 'webAppModule'
  scope: rg
  params: {
    name: appServiceName
    servicePlanName: appServicePlanName
    sku: appServicePlanSku
    linuxFxVersion: appServiceRuntime
  }
}

module cacheRedisModule './Modules/AzureCacheForRedisModule.bicep' = {
  name: 'cacheRedisModule'
  scope: rg
  params: {
    redisCacheName: redisCacheName
    redisCacheSKU: redisCacheSKU
    redisCacheFamily: redisCacheFamily
    redisCacheCapacity: redisCacheCapacity
    enableNonSslPort: enableNonSslPort
  }
}
