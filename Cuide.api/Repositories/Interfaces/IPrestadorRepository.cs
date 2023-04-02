using Cuide.api.Domain.Models;

namespace Cuide.api.Repositories.Interfaces
{
    public interface IPrestadorRepository
    {
        public Task PostPrestadorAsync(Prestador prestador);
        public Task<List<Prestador>> GetPrestadoresAsync();
        public Task<Prestador> FindPrestadorAsync(int id);
        public Task UpdatePrestadorAsync(int id, Prestador body);
        public Task DeletePrestadorAsync(int id);
    }
}
