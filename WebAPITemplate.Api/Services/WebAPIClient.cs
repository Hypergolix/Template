using Microsoft.EntityFrameworkCore;
using WebAPITemplate.Api.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPITemplate.Api.Models;

namespace WebAPITemplate.Api.Services
{
    public class WebAPIClient : IWebAPIClient
    {
        private readonly WebAPIContext _context;

        public WebAPIClient(WebAPIContext context)
        {
            _context = context;
        }

        public async Task<List<WebAPIClass>> Get()
        {
            return await _context.WebAPIClasses.ToListAsync();
        }

        public async Task<WebAPIClass> Get(int id)
        {
            return await _context.WebAPIClasses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Post(InputWebAPIClass model)
        {
            if (model is null) throw new Exception("temporary exception");
            WebAPIClass newModel = new()
            {
                Content = model.Content
            };
            await _context.WebAPIClasses.AddAsync(newModel);
            await _context.SaveChangesAsync();
            return newModel.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var foundModel = await _context.WebAPIClasses.FirstOrDefaultAsync(x => x.Id == id);
            if (foundModel is null) return false;

            _context.Remove(foundModel);
            return true;
        }

        public async Task<bool> Update(int id, InputWebAPIClass model)
        {
            if (model is null) return false;
            var foundModel = await _context.WebAPIClasses.FirstOrDefaultAsync(x => x.Id == id);
            if (foundModel is null) return false;

            foundModel.Content = model.Content;
            _context.WebAPIClasses.Update(foundModel);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
