// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using rame.study.rawcomponent.datastore.Models;

namespace rame.study.rawcomponent.datastore.Internal
{
    internal class DataDomain(IConfiguration configuration) : IDataDomain
    {
        public List<Despacho> GetDespachosByDate(DateTime now)
        {
            List<Despacho> despachos = [];

            using (SqlConnection connection = new(configuration.GetConnectionString("DbOrigem")))
            {
                connection.Open();
                string query = @"DECLARE @DataHoje DATE = CAST(GETDATE() AS DATE);
                                    DECLARE @DataLimite DATE = CAST(DATEADD(DAY, 2, GETDATE()) AS DATE);

                                    SELECT TOP 100 *
                                    FROM Despacho
                                    WHERE DataPartida >= @DataHoje
                                    AND DataPartida < @DataLimite
                                    ORDER BY Id DESC;";

                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Despacho despacho = new()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        DataPartida = reader.GetDateTime(reader.GetOrdinal("DataPartida")),
                        DataProcessamento = reader.GetDateTime(reader.GetOrdinal("DataProcessamento")),
                        DataEntrega = reader.GetDateTime(reader.GetOrdinal("DataEntrega")),
                        EnderecoOrigem = reader.GetString(reader.GetOrdinal("EnderecoOrigem")),
                        EnderecoDestino = reader.GetString(reader.GetOrdinal("EnderecoDestino")),
                        CoordenadasOrigem = reader.IsDBNull(reader.GetOrdinal("CoordenadasOrigem")) ? null : reader.GetString(reader.GetOrdinal("CoordenadasOrigem")),
                        CoordenadasDestino = reader.IsDBNull(reader.GetOrdinal("CoordenadasDestino")) ? null : reader.GetString(reader.GetOrdinal("CoordenadasDestino")),
                        Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                        Log = reader.IsDBNull(reader.GetOrdinal("Log")) ? null : reader.GetString(reader.GetOrdinal("Log")),
                        ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                        CargaId = reader.GetInt32(reader.GetOrdinal("CargaId")),
                        VeiculoId = reader.GetInt32(reader.GetOrdinal("VeiculoId")),
                        TransportadoraId = reader.GetInt32(reader.GetOrdinal("TransportadoraId")),
                        ValorFrete = reader.IsDBNull(reader.GetOrdinal("ValorFrete")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ValorFrete")),
                        DistanciaKM = reader.IsDBNull(reader.GetOrdinal("DistanciaKM")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("DistanciaKM")),
                        Rota = reader.IsDBNull(reader.GetOrdinal("Rota")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Rota")),
                        PrevisaoEntrega = reader.IsDBNull(reader.GetOrdinal("PrevisaoEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("PrevisaoEntrega")),
                        Responsavel = reader.IsDBNull(reader.GetOrdinal("Responsavel")) ? null : reader.GetString(reader.GetOrdinal("Responsavel")),
                        Prioridade = reader.IsDBNull(reader.GetOrdinal("Prioridade")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Prioridade")),
                        Observacoes = reader.IsDBNull(reader.GetOrdinal("Observacoes")) ? null : reader.GetString(reader.GetOrdinal("Observacoes")),
                        DataCriacao = reader.IsDBNull(reader.GetOrdinal("DataCriacao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataCriacao")),
                        DataAtualizacao = reader.IsDBNull(reader.GetOrdinal("DataAtualizacao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataAtualizacao")),
                        DataCancelamento = reader.IsDBNull(reader.GetOrdinal("DataCancelamento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataCancelamento"))
                    };

                    despachos.Add(despacho);
                }
            }

            return despachos;
        }
    }
}
