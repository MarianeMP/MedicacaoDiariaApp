using MedicacaoDiariaApp.Models;
using SQLite;
using System;
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

            // Habilita o uso de chaves estrangeiras no SQLite
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

        public Task<int> EditarMedicamento(Medicamento med)
        {
            string sql = "UPDATE Medicamento SET Nome = ?, Indicacao = ? WHERE IdMedicamento = ?";
            return _conn.ExecuteAsync(sql, med.Nome, med.Indicacao, med.IdMedicamento);
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
            return _conn.InsertAsync(horario);  // Insere o horário na tabela
        }

        public Task<int> EditarHorarioMedicamento(HorarioMedicamento horario)
        {
            string sql = "UPDATE HorarioMedicamento SET Horario = ?, Dosagem = ? WHERE IdHorario = ?";
            return _conn.ExecuteAsync(sql, horario.Horario, horario.Dosagem, horario.IdHorario);
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
                       h.IdHorario AS IdHorario, 
                       h.Horario AS Horario, 
                       h.Dosagem AS Dosagem 
                FROM Medicamento m
                INNER JOIN HorarioMedicamento h 
                    ON h.IdMedicamento = m.IdMedicamento
                ORDER BY Horario";

            return _conn.QueryAsync<ListaMedicamento>(query);
        }

        // Listar Horários de um Medicamento específico (extra)
        public Task<List<HorarioMedicamento>> ListarHorariosPorMedicamento(int idMedicamento)
        {
            return _conn.Table<HorarioMedicamento>()
                        .Where(h => h.IdMedicamento == idMedicamento)
                        .ToListAsync();
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

        // MÉTODO TEMPORÁRIO PARA DEBUG: Verificar medicamentos no console
        public async Task VerificarMedicamentosNoConsole()
        {
            var lista = await _conn.Table<Medicamento>().ToListAsync();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum medicamento cadastrado.");
            }
            else
            {
                Console.WriteLine("Medicamentos cadastrados:");
                foreach (var med in lista)
                {
                    Console.WriteLine($"ID: {med.IdMedicamento} | Nome: {med.Nome} | Indicação: {med.Indicacao}");
                }
            }
        }
    }
}
