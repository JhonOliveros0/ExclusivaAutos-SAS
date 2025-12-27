namespace ExclusivaAutos.Domain;

public interface IExternalCustomerClient
{
    Task<Customer?> GetCustomerAsync(CustomerRequest request, CancellationToken ct = default);
}