using ExclusivaAutos.Application;
using Microsoft.AspNetCore.Mvc;

namespace ExclusivaAutos.CrmApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Obtiene un cliente por su ID (número de documento)
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Domain.Customer?>> GetCustomer(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest("El ID del cliente es requerido.");

        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
}