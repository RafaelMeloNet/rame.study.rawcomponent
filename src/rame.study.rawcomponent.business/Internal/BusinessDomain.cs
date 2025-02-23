// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using rame.study.rawcomponent.datastore;
using rame.study.rawcomponent.datastore.Models;

namespace rame.study.rawcomponent.business.Internal
{
    internal class BusinessDomain(DatastoreFactory datastoreFactory) : IBusinessDomain
    {
        public List<Despacho> DoBusinessFlow_A(DateTime now)
        {
            var dataDomain = datastoreFactory.DataDomain;

            return dataDomain.GetDespachosByDate(now);
        }
        
        public IEnumerable<Despacho> DoBusinessFlow_B()
        {
            return [];
        }

        public IEnumerable<string> DoBusinessFlow_C()
        {
            return ["Lorem", "Ipsum", "Dolor"];
        }

        public void DoBusinessFlow_D()
        {
            // DB SELECT - From DB

            // PROCESS - Do business logic

            // DB INSERT - To DB

            // DB UPDATE - DB

            // CSV - Post CSV for Big Data

            // SFTP - Save PDF file to client

            // SAP WebApi - Send data

            // MQ - Publish message to observers
        }
    }
}