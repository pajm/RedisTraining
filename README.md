# Redis Training Project

A minimal .NET Redis learning project that demonstrates:
- Basic Redis CRUD operations with asynchronous access
- Simple caching strategy implementation using StackExchange.Redis
- Dependency injection setup with Redis integration

## Component Breakdown
- **RedisTraining.API**: Exposes REST endpoints for product CRUD operations with Redis caching
- **RedisTraining.Application**: Contains business logic and cache service interfaces
- **RedisTraining.Infrastructure**: Provides Redis client configuration and DI registrations

*Note: Configuration files (.dll, bin/objolders, and appsettings.json) are omitted in this repository per development practice*