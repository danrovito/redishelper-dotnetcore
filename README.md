# RedisHelper - .Net Core

### Introduction

Redis Helper is a simple way to handle caching items in Redis.


### Documentation

#### Installation / Setup

##### appsettings.json

In your appsettings.json you'll need to include the following entry to connect to your redis installation

```
"Redis": {
    "Host": "127.0.0.1:6379",
    "Instance":  "RedisInstanceName" 
}
```

##### Startup.cs

Add `services.SetRedisHelperServices();` to your `ConfigureServices` method:

```
public void ConfigureServices(IServiceCollection services)
{
    // Other Code

    services.SetRedisHelperServices();

    // Other Code
}
```

