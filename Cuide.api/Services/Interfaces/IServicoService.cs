using Cuide.api.Domain.Models;

namespace Cuide.api.Services.Interfaces
{
    public interface IServicoService
    {
        public Task PostServicoAsync(Servico servico);
        public Task<List<Servico>> GetServicosAsync();
        public Task<Servico> FindServicoAsync(int id);
        public Task UpdateServicoAsync(int id, Servico body);
        public Task DeleteServicoAsync(int id);
    }
}
