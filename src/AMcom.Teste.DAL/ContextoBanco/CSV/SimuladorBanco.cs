using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AMcom.Teste.DAL
{
    public class SimuladorBanco<T> where T : class
    {
        public IEnumerable<T> Selecionar(string dadosCsv)
        {
            if (dadosCsv == null)
                return null;

            var configuracaoCsv = new Configuration() { Delimiter = ",", HasHeaderRecord = true, MissingFieldFound = null };
            configuracaoCsv.AutoMap<T>();
            var csvReader = new CsvReader(new StringReader(dadosCsv), configuracaoCsv);

            return csvReader.GetRecords<T>().ToList();
        }
    }
}
