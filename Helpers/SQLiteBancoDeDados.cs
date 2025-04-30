using MedicacaoDiariaApp.Models;
using SQLite;

namespace MedicacaoDiariaApp.Helpers
{
    public class SQLiteBancoDeDados
    {
        readonly SQLiteAsyncConnection _conn;


        public SQLiteBancoDeDados(string path)

        {

            _conn = new SQLiteAsyncConnection(path);
            _conn.ExecuteAsync("PRAGMA foreign_keys = ON;");
            _conn.CreateTableAsync<Medicamento>().Wait();
            _conn.CreateTableAsync<HorarioMedicamento>().Wait();


        }

        // Crate, Update, Delete utilizando a model Medicamento
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

        // Crate, Update, Delete utilizando a model HorarioMedicamento

        public Task<int> CadastrarHorarioMedicamento(HorarioMedicamento horario)
        {
            return _conn.InsertAsync(horario);
        }

        public Task<List<HorarioMedicamento>> EditarHorarioMedicamento(HorarioMedicamento horario)
        {
            string sql = "UPDATE HorarioMedicamento SET Horario=?, Dosagem=? WHERE IdMedicamento=? AND IdHorario=?";
            return _conn.QueryAsync<HorarioMedicamento>(
                sql, horario.Horario, horario.Dosagem, horario.IdMedicamento, horario.IdHorario);
        }


        public Task<int> ExcluirHorarioMedicamento(int Id)
        {
            return _conn.Table<HorarioMedicamento>().DeleteAsync(i => i.IdHorario == Id);

        }

        // Listar Medicamentos e Horários Cadastrados
        public Task<List<ListaMedicamento>> ListarHorarioMedicamento()
        {
            string query = @"
        SELECT m.IdMedicamento AS IdMedicamento, m.Nome AS NomeMedicamento, m.Indicacao AS IndicacaoMedicamento, h.IdHorario As IdHorario, h.Horario AS Horario, h.Dosagem as Dosagem 
        FROM Medicamento m
        INNER JOIN HorarioMedicamento h ON h.IdMedicamento = m.IdMedicamento
        ORDER BY Horario";
            return _conn.QueryAsync<ListaMedicamento>(query);
        }

    }
}