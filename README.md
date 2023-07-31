# ECommerce

This project is a small e-commerce application that aims to implement Rebus with the Saga pattern. The project allows users to add products, manage users, and create orders. During the order creation process, the Saga pattern is utilized to perform asynchronous operations through the RabbitMQ message queue.

## Tools
- RabbitMq
- PostgreSQL
- Docker

## Technologies
- MediatR
- Rebus 
- Mapster
- Npgsql
- EntityFrameworkCore
- FluentValidation

## Design Patterns
- CQRS Pattern
- Mediator Pattern
- Saga Pattern
- Repository Base Pattern

ECommerce is designed to demonstrate the implementation of various technologies, patterns, and tools to create an efficient and scalable e-commerce platform. By using Rebus with the Saga pattern, the application handles complex distributed transactions asynchronously, providing a more robust and fault-tolerant system.

## Features
**Product Management** 
* Allows administrators to add and manage products with their categories and attributes.

**User Management**
* Provides user authentication and role-based access control for better security.

**Order Processing**
* Users can create orders, and during this process, the application utilizes the Saga pattern to handle various tasks asynchronously, such as payment processing and inventory management, ensuring smooth order fulfillment

## Contributions

Thank you for your interest in the ECommerce project! We hope you find it insightful and valuable in understanding the implementation of Rebus with the Saga pattern in an e-commerce context. If you have any feedback or suggestions, we would love to hear from you. Happy coding!
