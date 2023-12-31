﻿using CrudTest.Domain.CustomerAggregate;
using CrudTest.Domain.CustomerAggregate.ValueObjects;
namespace CrudTest.Application.Common.Interfaces.Persistence;
public interface ICustomerRepository
{
    /// <summary>
    ///     Gets the Customer by Id.
    /// </summary>
    /// <param name="customerId">CustomerId.</param>
    /// <returns>Customer.</returns>
    Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken);

    /// <summary>
    ///     Gets the list of customers from db.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Customers List</returns>
    Task<List<Customer>> GetListAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Adds the Customer.
    /// </summary>
    /// <param name="customer">Customer object.</param>
    /// <returns>Task.</returns>
    Task Add(Customer customer);

    /// <summary>
    ///     Updates the Customer.
    /// </summary>
    /// <param name="customer">Customer object.</param>
    /// <returns>Task.</returns>
    Task Update(Customer customer);

    /// <summary>
    ///     Deletes the Customer by Id.
    /// </summary>
    /// <param name="customerId">CustomerId.</param>
    /// <returns>Task.</returns>
    Task Delete(CustomerId customerId);
}
