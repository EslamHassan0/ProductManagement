# Vertical Slice Architecture in ASP.NET Core

## About This Project

This project is part of my journey to better understand software architecture and how to structure ASP.NET Core applications.

Rather than focusing only on implementing CRUD operations, I wanted to explore how **Vertical Slice Architecture** organizes code around individual features and use cases.

## Technologies Used

- ASP.NET Core Web API (.NET 9)
- C#
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- xUnit

## What I'm Learning

- Organizing application code by feature instead of technical layer.
- Using MediatR to dispatch commands and queries to their handlers.
- Implementing the CQRS pattern for separating commands and queries.
- Applying FluentValidation through a MediatR pipeline behavior.
- Handling validation errors and not-found responses consistently.
- Testing validators and handlers independently.

## Implemented Features

- Create Product
- Get All Products
- Get Product by ID
- Update Product
- Delete Product

## Main Goal

The main goal is to understand the reasoning behind Vertical Slice Architecture, the problems it aims to address, and the trade-offs compared with traditional layered architectures.

This is a learning project, and I'm using it to strengthen my understanding of software design and architecture through practical implementation.

## Key Takeaway

I'm interested not only in making code work, but also in understanding **why it is structured a certain way, what problems that structure solves, and when it makes sense to use it.**
