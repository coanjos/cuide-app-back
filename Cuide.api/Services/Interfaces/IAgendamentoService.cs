namespace Cuide.api.Services.Interfaces
{
    public interface IAgendamentoService
    {
        public Task CriarAgendamentoAsync(int idPrestador, DateTime data);

    }
}
