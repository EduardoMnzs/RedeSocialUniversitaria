public class EventoDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Local { get; set; }
    public string Descricao { get; set; }
    public DateTime DataHora { get; set; }
    public bool ExigeInscricao { get; set; }
    public int TotalInscritos { get; set; }
    public bool UsuarioInscrito { get; set; }
}