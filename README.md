# RedisHelper - .Net Core

![Nuget](https://img.shields.io/nuget/dt/RedisHelper)

### Introduction

Redis Helper is a simple way to handle caching items in Redis.  It utilizes `IDistributedCache` to help handle caching of items.


### Documentation

#### Installation / Setup

You can install RedisHelper through Nuget package manager by running the following:

```csharp
Install-Package RedisHelper -Version 1.0.0
```

If you use the dotnet CLI you can use the following:

```csharp
dotnet add package RedisHelper
```

##### appsettings.json

In your appsettings.json you'll need to include the following entry to connect to your redis installation

```csharp
"Redis": {
    "Host": "127.0.0.1:6379",
    "Instance":  "RedisInstanceName" 
}
```

##### Startup.cs

Add `services.SetRedisHelperServices();` to your `ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Other Code

    services.SetRedisHelperServices();

    // Other Code
}
```

#### Usage

#### Dependency Injection

You can utilize depency injection to bring the RedisHelper into your controller.  An example when using RedisHelper in your HomeController can be seen here:

```csharp
private readonly RedisHelper.Cache.RedisHelper _redisHelper;

public HomeController(RedisHelper.Cache.RedisHelper redisHelper)
{
    _redisHelper = redisHelper;
}
```

#### Storing Items In The Cache

You may use the `Put` method to store items in the cache.  The `Put` method requires you to set an expiration in seconds.

When using RedisHelper in the DI container you can use the following:

```csharp
var seconds = 10;
_redisHelper.Put("key", "value", seconds);
```

To store an item that does not expire you can use the `Forever` method.  This will store an item in cache until it is removed manually

```csharp
_redisHelper.Forever("key", "value");
```

#### Retrieving Items From The Cache

The `Get` method is used to retrieve items from the cache.  If the item does not exist in the cache, `null` will be returned.

```csharp
_redisHelper.Get("key");
```

#### Removing Items From The Cache

You may remove items from the cache using the `forget` method:

```csharp
_redisHelper.Forget("key")
```

#### Checking For Item Existence

The `Exists` method can be used to determine if an item exists in the cache.  If the value is `null` this method will return `false`

```csharp
_redisHelper.Exists("key");
```

### License

RedisHelper is open-sourced software licensed under the [MIT License](https://opensource.org/licenses/MIT)