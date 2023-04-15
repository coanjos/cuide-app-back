namespace Cuide.api.Domain.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public User? User { get; set; }
        public Prestador Prestador { get; set; }
        public Servico? Servico { get; set; }
    }
}
