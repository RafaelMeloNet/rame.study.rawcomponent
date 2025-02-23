// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using Microsoft.AspNetCore.Mvc;
using rame.study.rawcomponent.business;
using rame.study.rawcomponent.datastore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rame.study.rawcomponent.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessDomainController(IBusinessFactory businessFactory) : ControllerBase
    {
        // GET: api/<ExpedienteController>
        [HttpGet]
        public IEnumerable<Despacho> Get()
        {
            List<Despacho> despachos = businessFactory.BusinessDomain.DoBusinessFlow_A(DateTime.Now);

            return despachos;
        }
    }
}
