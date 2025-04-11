using MedicacaoDiariaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicacaoDiariaApp.Helpers

{

    public class SQLite

    {
      
        readonly SQLiteAsyncConnection _conn;

        public SQLite(string path)

        {

            _conn = new SQLiteAsyncConnection(path);

            _conn.CreateTableAsync<Medicamento>().Wait();

        }

        public Task<int> CadastrarMedicamento(Medicamento med)

        {

            return _conn.InsertAsync(med);

        }

        public Task<List<Medicamento>> EditarMedicamento(Medicamento med)

        {

            string sql = "UPDATE Medicamento SET Nome=?, Indicacao=? WHERE IdMedicamento=?";

            return _conn.QueryAsync<Medicamento>(

                sql, med.Nome, med.Indicacao, med.IdMedicamento

            );

        }

        public Task<int> ExcluirMedicamento(int id)

        {

            return _conn.Table<Medicamento>().DeleteAsync(i => i.IdMedicamento == id);

        }

        public Task<List<Medicamento>> ListarMedicamento()

        {

            return _conn.Table<Medicamento>().ToListAsync();

        }



        
    }

}
