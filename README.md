# Movies and actors

A simple .NET application with two containerized services.

## Setup

1. Clone repo
2. Run `docker-compose up`
3. Run either `migrations.bat` or `migrations.sh` to run neede migrations.

## Endpoints

The two services run on the following endpoints:

 - `localhost:8080/api/actors/${id?}` 
 - `localhost:8081/api/movies/${id?}` 

Both endpoints support GET, POST, PUT and DELETE requests, and a single GET entry request when providing an optional `id` path parameter.

### Pagination

Both APIs support pagination. Pagination is supported when providing the `pageSize` and `page` query parameters, both should be provided as integers. `pageSize` sets the page size to the provided number and `page` returns the specific page. Both parameters have to be provided for pagination filtering to take effect, otherwise the APIs will return all records.

### Search

The Movies service supports search filtering by title. Search filtering is enabled when providing a `search` query parameter. The filter will filter for movies with titles that contain the provided string. Search is case insensitive.

### Request saving

Each request is saved into the database with a simple schema that could be expanded/edited.