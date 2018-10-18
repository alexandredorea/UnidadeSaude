using AMcom.Teste.DAL.ContextoBanco.Banco;
using AMcom.Teste.DAL.ContextoBanco.CSV;
using AMcom.Teste.DAL.Interfaces;
using AMcom.Teste.DAL.Repositorios.Base;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMcom.Teste.DAL
{
    public class UbsRepository : RepositoryBase<Ubs>, IRespositoryUbs
    {
        public UbsRepository(ContextAmcom context) : base(context)
        {
        }

        // Implemente um método que retorne uma lista/coleção de objetos do tipo Ubs.
        // Caso necessário, crie um parâmetro para filtrar os objetos dessa coleção se a lógica não for 
        // implementada na camada de serviços.

        // TODO: Método simulando a sobreescrita do Selecionar()
        public new IEnumerable<Ubs> Selecionar()
        {
            var dadosObtidos = BancoDadosSimulado.ubs;
            var dadosTratados = new SimuladorBanco<Ubs>().Selecionar(dadosObtidos);
            return dadosTratados;
        }

        // TODO: a forma de obter os dados pelo diretamente pelo csv, pode ser feito pelo banco de dados.
        // TODO: para acessar os dados via banco, deve-se realizar o Migrations e descomentar o código abaixo.
        public IEnumerable<Ubs> Selecionar(double latitude, double longitude)
        {
            var dados = BancoDadosSimulado.ubs;
            var dadosSelecionados = new SimuladorBanco<Ubs>().Selecionar(dados);
            return dadosSelecionados
                   .OrderBy(x => x.Distancia = new GeoCoordinate(Convert.ToDouble(x.Latitude.Replace(".", ",")), Convert.ToDouble(x.Longitude.Replace(".", ",")))
                                  .GetDistanceTo(new GeoCoordinate(latitude, longitude)));

            //return this.Selecionar()
            //        .OrderBy(x => x.Distancia = new GeoCoordinate(Convert.ToDouble(x.Latitude.Replace(".", ",")), Convert.ToDouble(x.Longitude.Replace(".", ",")))
            //                                    .GetDistanceTo(new GeoCoordinate(latitude, longitude)));
        }

        // TODO: a forma de obter os dados pelo diretamente pelo csv, pode ser feito pelo banco de dados.
        // TODO: para acessar os dados via banco, deve-se realizar o Migrations e descomentar o código abaixo.
        public IEnumerable<Ubs> Selecionar(double latitude, double longitude, int quantidadeRetorno = 5)
        {
            var dados = BancoDadosSimulado.ubs;
            var dadosSelecionados = new SimuladorBanco<Ubs>().Selecionar(dados);
            return dadosSelecionados
                   .OrderBy(x => x.Distancia = new GeoCoordinate(Convert.ToDouble(x.Latitude.Replace(".", ",")), Convert.ToDouble(x.Longitude.Replace(".", ",")))
                                  .GetDistanceTo(new GeoCoordinate(latitude, longitude)))
                   .Take(quantidadeRetorno);

            //return this.Selecionar()
            //        .OrderBy(x => x.Distancia = new GeoCoordinate(Convert.ToDouble(x.Latitude.Replace(".", ",")), Convert.ToDouble(x.Longitude.Replace(".", ",")))
            //                                    .GetDistanceTo(new GeoCoordinate(latitude, longitude)))
            //        .Take(quantidadeRetorno);
        }
    }
}
