using OneOf.Models;
namespace OneOf.Services;

public class ProductService
{
    public OneOf<Product, IEnumerable<FieldError>> Add(Product product)
    {
        var errors = _Validate(product);
        if (errors.Any())
            return errors;

        product.Id = Guid.NewGuid();
        product.CreatedAt = DateTime.Now;

        return product;
    }

    private List<FieldError> _Validate(Product product)
    {
        var errors = new List<FieldError>();

        if (product.Price <= 0)
            errors.Add(new FieldError { Field = "Price", Error = "Invalid Price" });

        if (product.Name.Length <= 3)
            errors.Add(new FieldError { Field = "Name", Error = "Name length should be > 3" });

        return errors;
    }
}
