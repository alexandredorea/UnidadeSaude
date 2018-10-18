using AMcom.Teste.DAL;
using AMcom.Teste.DAL.Interfaces;
using AMcom.Teste.Service.AutoMapper.Base;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace AMcom.Teste.Service.Tests
{
    public class UbsServiceTest
    {
        // Implemente os testes unitários para o método criado no UbsService. Faça quantos testes achar
        // pertinente para validar a sua lógica de aplicação.

        private readonly IRespositoryUbs _repositorio;
        private readonly IMapper _mapper;

        public UbsServiceTest()
        {
            _repositorio = Substitute.For<IRespositoryUbs>();
            _mapper = new Mapper(AutoMapperConfiguration.Configure());
        }

        [Fact]
        public void GetUbsOrderByAvaliation()
        {
            //Arrange
            var listaUbs = new List<Ubs>()
            {
                new Ubs("-10.9112370014188", "-37.0620775222768", "US OSWALDO DE SOUZA"                         , "TV ADALTO BOTELHO"            , "GETULIO VARGAS"    , "Aracaju"                   , "A"),
                new Ubs("-9.48594331741306", "-35.8575725555409", "USF ENFERMEIRO PEDRO JACINTO AREA 09"        , "R 15 DE AGOSTO"               , "CENTRO"            , "Rio Largo"                 , "A"),
                new Ubs("-23.896"          , "-53.41"           , "UNIDADE DE ATENCAO PRIMARIA SAUDE DA FAMILIA", "RUA GUILHERME BRUXEL"         , "CENTRO"            , "Perobal"                   , "B"),
                new Ubs("-16.447874307632 ", "-41.0098600387561", "POSTO DE SAUDE DE BOM JESUS DA ALDEIA"       , "RUA TEOFILO OTONI"            , "ALDEIA"            , "Jequitinhonha"             , "B"),
                new Ubs("-6.57331109046917", "-35.1076054573049", "POSTO ANCORA URUBA"                          , "RODOVIA PB N 065"             , "SITIO "            , "Mataraca"                  , "C"),
                new Ubs("-7.03715085983256", "-37.2887992858876", "UNIDADE DE SAUDE DA FAMILIA ANA RAQUEL"      , "RUA SEVERINO SOARES"          , "JD GUANABARA"      , "Patos"                     , "C"),
                new Ubs("-5.99885702133161", "-40.2936887741077", "PSF ODILON AGUIAR"                           , "RUA DOMINGAS GOMES"           , "CENTRO"            , "Tauá"                      , "D"),
                new Ubs("-24.5821130275719", "-49.435493946074 ", "UAPSF PROF HETTY ROSA DE MOURA E COSTA"      , "AVENIDA EZIDIO NEVES"         , "CERRADO"           , "Doutor Ulysses"            , "D"),
                new Ubs("-5.89795231819136", "-44.8160004615771", "UNIDADE BASICA DE SAUDE JOSE BIBI"           , "POVOADO SAO JOAQUIM DOS MELOS", "ZONA RURAL"        , "Tuntum"                    , "E"),
                new Ubs("-9.55789089202853", "-37.3832130432118", "USF NOSSA SENHORA DO BOM PARTO"              , "RUA AFONSO SOARES VIEIRA"     , "CENTRO"            , "São José da Tapera"        , "E"),
                new Ubs("-3.09060215950003", "-59.9864888191206", "UBS L 29"                                    , "RUA FLAVIO COSTA"             , "COROADO I"         , "Manaus"                    , "A"),
                new Ubs("-15.6327939033504", "-58.1737661361677", "UNIDADE DE SAUDE DA FAMILIA ZEFERINO II"     , "RUA RUI BARBOSA"              , "JARDIM ZEFERINO II", "São José dos Quatro Marcos", "B"),
                new Ubs("-14.5426476001735", "-52.7972888946518", "CENTRO DE SAUDE MUNICIPAL DE CAPINAPOLIS"    , "AV XV DE NOVEMBRO"            , "CENTRO"            , "Campinápolis"              , "C"),
                new Ubs("-16.0691678524013", "-47.9820585250841", "UNIDADE BASICA DE SAUDE VALPARAISO"          , "CENTRO COMERCIAL QUADRA 07"   , "VALPARAISO I"      , "Valparaíso de Goiá"        , "D"),
                new Ubs("-27.029885"       , "-48.668039"       , "UNIDADE SAUDE DA FAMILIA SANTA REGINA"       , "MANAGUA"                      , "SANTA REGINA"      , "Camboriú"                  , "E"),
                new Ubs("-29.6088624000541", "-51.1745309829697", "POSTO MORADA DO SOL IVOTI"                   , "RUA CAXIAS DO SUL"            , "JARDIM BUHLER"     , "Ivoti"                     , "A"),
            };

            var latitude = -5.123;
            var longitude = -40.123;

            _repositorio.Selecionar(latitude, longitude, 5).Returns(listaUbs);
            var servico = new UbsService(_repositorio, _mapper);

            //Act
            var ubsListaRetorno = servico.Selecionar(latitude, longitude, 5);
            //Assert
            ubsListaRetorno.Should().HaveCount(5);
        }
    }
}