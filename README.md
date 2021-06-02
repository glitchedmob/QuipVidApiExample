# QuipVidApiExample

This project shows a basic implementation of what an API for [quipvid.com](https://quipvid.com/) could look like using both traditional controllers and the [ApiEndpoints](https://github.com/ardalis/ApiEndpoints) library.

## Project Structure

- QuipVidControllers
    - ASP.NET application containing the example QuipVid API implemented using traditional controllers.
- QuipVidApiEndpoints
    - ASP.NET application containing the example QuipVid API implemented using the ApiEndpoints library
- QuipVid.Core
    - EF Core configuration, including models and a database seeder
    - Simple repository classes to wrap data access

## Resources

- [ApiEndpoints Repository](https://github.com/ardalis/ApiEndpoints)
- [.NET Rocks #1695 - ASP.NET Core API Endpoints with Steve Smith](https://www.dotnetrocks.com/?show=1695)
- [Decoupling Controllers with ApiEndpoints](https://betweentwobrackets.dev/posts/2020/09/decoupling-controllers-with-apiendpoints/)
