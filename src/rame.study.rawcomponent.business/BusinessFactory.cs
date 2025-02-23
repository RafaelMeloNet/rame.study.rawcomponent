// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using Microsoft.Extensions.Configuration;
using rame.study.rawcomponent.business.Internal;
using rame.study.rawcomponent.datastore;

namespace rame.study.rawcomponent.business
{
    public class BusinessFactory(IConfiguration configuration) : IBusinessFactory
    {
        public IBusinessDomain BusinessDomain
        {
            get
            {
                var datastoreFactory = new DatastoreFactory(configuration);

                var businessDomain = new BusinessDomain(datastoreFactory);

                return businessDomain;
            }
        }
    }
}