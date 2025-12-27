using ExclusivaAutos.Domain;

namespace ExclusivaAutos.Application;

public class CustomerService : ICustomerService
{
    private readonly IExternalCustomerClient _externalClient;

    public CustomerService(IExternalCustomerClient externalClient)
    {
        _externalClient = externalClient;
    }

    public async Task<Customer?> GetCustomerByIdAsync(string customerId, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(customerId))
            return null;

        var request = new CustomerRequest { CustomerId = customerId };
        return await _externalClient.GetCustomerAsync(request, ct);
    }
}