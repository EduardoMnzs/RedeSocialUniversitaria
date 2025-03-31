public class Evento : EntityBase
{
    public string Nome { get; private set; }
    public string Local { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataHora { get; private set; }
    public bool ExigeInscricao { get; private set; }
    public virtual ICollection<InscricaoEvento> Inscricoes { get; private set; } = new List<InscricaoEvento>();

    protected Evento() { }

    public Evento(string nome, string local, string descricao, DateTime dataHora, bool exigeInscricao)
    {
        Nome = nome;
        Local = local;
        Descricao = descricao;
        DataHora = dataHora;
        ExigeInscricao = exigeInscricao;
    }

    public void AdicionarInscricao(InscricaoEvento inscricao)
    {
        if (inscricao == null)
            throw new ArgumentNullException(nameof(inscricao));

        Inscricoes.Add(inscricao);
    }
}
