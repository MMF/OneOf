using OneOf.Models;
using OneOf.Services;

var product = new Product
{
    Name = "Cheese",
    Price = 10
};

new ProductService()
    .Add(product)
    .Match(
        prod => new GenericResponse(prod.Id, true),
        errors => new GenericResponse($"could not add product ({errors.First().Error})", false)
    );

Console.ReadLine();