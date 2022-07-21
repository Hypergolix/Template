using Microsoft.AspNetCore.Mvc;
using WebAPITemplate.Api.Models;

namespace WebAPITemplate.Api.Services
{
    public interface IWebAPIClient
    {
        Task<List<WebAPIClass>> Get();

        Task<WebAPIClass> Get(int id);

        Task<int> Post(InputWebAPIClass model);

        Task<bool> Delete(int id);

        Task<bool> Update(int id, InputWebAPIClass model);
    }
}
