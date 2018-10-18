using AMcom.Teste.DAL.Entidades.Base;
using CsvHelper.Configuration.Attributes;
using Flunt.Validations;

namespace AMcom.Teste.DAL
{
    public class Ubs : EntityBase
    {
        // Esta classe deve conter as seguintes propriedades:
        // vlr_latitude, vlr_longitude, nom_estab, dsc_endereco, dsc_bairro, dsc_cidade, dsc_estrut_fisic_ambiencia
        #region Contrutores

        public Ubs()
        {
        }

        public Ubs(string latitude, string longitude, string nome, string endereco, string bairro, string cidade, string avaliacao)
        {
            SetLatitude(latitude);
            SetLongitude(longitude);
            SetNome(nome);
            SetEndereco(endereco);
            SetBairro(bairro);
            SetCidade(cidade);
            Avaliacao = avaliacao;
        }

        #endregion

        #region Atributos

        [Name("vlr_latitude")]
        public string Latitude { get; private set; }

        [Name("vlr_longitude")]
        public string Longitude { get; private set; }

        [Name("nom_estab")]
        public string Nome { get; private set; }

        [Name("dsc_endereco")]
        public string Endereco { get; private set; }

        [Name("dsc_bairro")]
        public string Bairro { get; private set; }

        [Name("dsc_cidade")]
        public string Cidade { get; private set; }

        [Name("dsc_estrut_fisic_ambiencia")]
        public string Avaliacao { get; private set; }

        [Ignore]
        public double Distancia { get; set; }

        #endregion

        #region Métodos

        public void SetLatitude(string latitude)
        {
            ValidarCoordenadas(latitude);

            if (Valid)
                Latitude = latitude;
        }

        public void SetLongitude(string longitude)
        {
            ValidarCoordenadas(longitude);

            if (Valid)
                Longitude = longitude;
        }

        public void SetNome(string nome)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(string.IsNullOrWhiteSpace(nome) ? string.Empty : nome, 3, "Ubs.Nome", "O nome da Unidade Básica de Saúde deve conter pelo menos 3 caracteres")
                .HasMaxLen(nome ?? string.Empty, 255, "Ubs.Nome", "O nome da Unidade Básica de Saúde deve ter até 255 caracteres"));

            if (Valid)
                Nome = nome;
        }

        public void SetEndereco(string endereco)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(string.IsNullOrWhiteSpace(endereco) ? string.Empty : endereco, 3, "Ubs.Endereco", "O endereço deve conter pelo menos 3 caracteres")
                .HasMaxLen(endereco ?? string.Empty, 255, "Ubs.Endereco", "O endereço deve ter até 255 caracteres"));

            if (Valid)
                Endereco = endereco;
        }

        public void SetBairro(string bairro)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(string.IsNullOrWhiteSpace(bairro) ? string.Empty : bairro, 3, "Ubs.Bairro", "O bairro deve conter pelo menos 3 caracteres")
                .HasMaxLen(bairro ?? string.Empty, 50, "Ubs.Bairro", "O bairro deve ter até 50 caracteres"));

            if (Valid)
                Bairro = bairro;
        }

        public void SetCidade(string cidade)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(string.IsNullOrWhiteSpace(cidade) ? string.Empty : cidade, 3, "Ubs.Cidade", "A cidade deve conter pelo menos 3 caracteres")
                .HasMaxLen(cidade ?? string.Empty, 50, "Ubs.Cidade", "A cidade deve ter até 50 caracteres"));

            if (Valid)
                Cidade = cidade;
        }

        public void SetAvaliacao(string avaliacao)
        {
            Avaliacao = avaliacao;
        }

        public void SetDistancia(double distancia)
        {
            Distancia = distancia;
        }

        private void ValidarCoordenadas(string coordenadas)
        {
            AddNotifications(new Contract()
                .Requires()
                .Matchs(coordenadas, @"^-?[0-9]+\.[0-9]+$", "string", "Coordenada inválida."));
        }

        public override string ToString()
        {
            return $"{Endereco}, bairro: {Bairro}, cidade: {Cidade}";
        }

        #endregion
    }
}