// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rame.study.rawcomponent.datastore.Models;

public partial class Despacho
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataPartida { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataProcessamento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataEntrega { get; set; }

    [StringLength(255)]
    public string EnderecoOrigem { get; set; } = null!;

    [StringLength(255)]
    public string EnderecoDestino { get; set; } = null!;

    [StringLength(255)]
    public string? CoordenadasOrigem { get; set; }

    [StringLength(255)]
    public string? CoordenadasDestino { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Log { get; set; }

    public int ClienteId { get; set; }

    public int CargaId { get; set; }

    public int VeiculoId { get; set; }

    public int TransportadoraId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ValorFrete { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DistanciaKM { get; set; }

    public int? Rota { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PrevisaoEntrega { get; set; }

    [StringLength(255)]

    public string? Responsavel { get; set; }

    public int? Prioridade { get; set; }

    public string? Observacoes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCriacao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataAtualizacao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCancelamento { get; set; }
}
