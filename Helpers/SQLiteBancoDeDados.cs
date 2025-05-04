using MedicacaoDiariaApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Helpers
{
    public class SQLiteBancoDeDados
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteBancoDeDados(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.ExecuteAsync("PRAGMA foreign_keys = ON;").Wait();

            // Criação das tabelas
            _conn.CreateTableAsync<Medicamento>().Wait();
            _conn.CreateTableAsync<HorarioMedicamento>().Wait();
            _conn.CreateTableAsync<Usuario>().Wait(); // <-- ADICIONADA a criação da tabela de usuário
        }

        // Métodos para Medicamento
        public Task<int> CadastrarMedicamento(Medicamento med)
        {
            return _conn.InsertAsync(med);
        }

        public Task<List<Medicamento>> EditarMedicamento(Medicamento med)
        {
            string sql = "UPDATE Medicamento SET Nome=?, Indicacao=? WHERE IdMedicamento=?";
            return _conn.QueryAsync<Medicamento>(sql, med.Nome, med.Indicacao, med.IdMedicamento);
        }

        public Task<int> ExcluirMedicamento(int id)
        {
            return _conn.Table<Medicamento>().DeleteAsync(i => i.IdMedicamento == id);
        }

        public Task<List<Medicamento>> ListarMedicamento()
        {
            return _conn.Table<Medicamento>().ToListAsync();
        }

        // Métodos para HorarioMedicamento
        public Task<int> CadastrarHorarioMedicamento(HorarioMedicamento horario)
        {
            return _conn.InsertAsync(horario);
        }

        public Task<List<HorarioMedicamento>> EditarHorarioMedicamento(HorarioMedicamento horario)
        {
            string sql = "UPDATE HorarioMedicamento SET Horario=?, Dosagem=? WHERE IdMedicamento=? AND IdHorario=?";
            return _conn.QueryAsync<HorarioMedicamento>(sql, horario.Horario, horario.Dosagem, horario.IdMedicamento, horario.IdHorario);
        }

        public Task<int> ExcluirHorarioMedicamento(int id)
        {
            return _conn.Table<HorarioMedicamento>().DeleteAsync(i => i.IdHorario == id);
        }

        // Listar Medicamentos e Horários Cadastrados
        public Task<List<ListaMedicamento>> ListarHorarioMedicamento()
        {
            string query = @"
                SELECT m.IdMedicamento AS IdMedicamento, 
                       m.Nome AS NomeMedicamento, 
                       m.Indicacao AS IndicacaoMedicamento, 
                       h.IdHorario As IdHorario, 
                       h.Horario AS Horario, 
                       h.Dosagem as Dosagem 
                FROM Medicamento m
                INNER JOIN HorarioMedicamento h 
                    ON h.IdMedicamento = m.IdMedicamento
                ORDER BY Horario";

            return _conn.QueryAsync<ListaMedicamento>(query);
        }

        // Métodos para Usuario
        public Task<int> CadastrarUsuario(Usuario usuario)
        {
            return _conn.InsertAsync(usuario);
        }

        public Task<List<Usuario>> ListarUsuarios()
        {
            return _conn.Table<Usuario>().ToListAsync();
        }

        public Task<int> ExcluirUsuario(int id)
        {
            return _conn.Table<Usuario>().DeleteAsync(i => i.Id == id);
        }
    }
}
