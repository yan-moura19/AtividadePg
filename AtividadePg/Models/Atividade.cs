﻿namespace AtividadePg.Models
{
    public class Atividade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime DataFinalizacao { get; set; }

        public Atividade(string nome, string status, DateTime dataFinalizacao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Status = status;
            DataFinalizacao = dataFinalizacao;

        }
    }
}
