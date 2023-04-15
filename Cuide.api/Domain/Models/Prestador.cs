namespace Cuide.api.Domain.Models
{
    public class Prestador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PrestadorServico>? ServicosOferecidos { get; set; }
    }
}
