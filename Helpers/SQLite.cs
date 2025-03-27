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
        /*
        readonly SQLiteAsyncConnection _conn;

        public SQLite(string path)

        {

            _conn = new SQLiteAsyncConnection(path);

            _conn.CreateTableAsync<Medicamento>().Wait();

        }

        public Task<int> Insert(Medicamento m)

        {

            return _conn.InsertAsync(m);

        }

        public Task<List<Medicamento>> Update(Medicamento m)

        {

            string sql = "UPDATE Medicamento SET Nome=?, Concentracao=?, Indicacao=? WHERE Id=?";

            return _conn.QueryAsync<Medicamento>(

                sql, m.Nome, m.Concentracao, m.Indicaco, m.Id

            );

        }

        public Task<int> Delete(int id)

        {

            return _conn.Table<Medicamento>().DeleteAsync(i => i.Id == id);

        }

        public Task<List<Medicamento>> GetAll()

        {

            return _conn.Table<Medicamento>().ToListAsync();

        }

        public Task<List<Medicamento>> Search(string q)

        {

            string sql = "SELECT * Medicamento WHERE Nome LIKE %" + q + "%";

            return _conn.QueryAsync<Medicamento>(sql);

        }

        */
    }

}
