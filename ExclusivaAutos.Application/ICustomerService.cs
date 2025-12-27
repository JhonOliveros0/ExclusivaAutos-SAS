using ExclusivaAutos.Domain;

namespace ExclusivaAutos.Application;

public interface ICustomerService
{
    Task<Customer?> GetCustomerByIdAsync(string customerId, CancellationToken ct = default);
}