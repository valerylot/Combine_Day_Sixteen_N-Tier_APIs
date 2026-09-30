### N-Tier API

- Tier means layer, and n means numbers. An N-Tier API splits the work into different layers that each do one job and only talk to the layer next to them.

Controller(Presentation) -> Services(Business) -> Repository(Data Access) -> Database

## Controller

- Speaks HTTP, takes the request, asks the service, picks the status code

## Services

- Holds the rules aka our business logic

## Repository

- Stores and fetches data: get, add, update, delete (the only class that uses AppDbContext)


### DTO Data Transfer Objects

* Data * This holds the fields, no methods, no rules, AND NO DATABASE

* Transfer * It has one job, to carry data across our API

* Object * This is a plain C# Class, just like any other