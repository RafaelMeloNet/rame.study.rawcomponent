// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using rame.study.rawcomponent.datastore.Models;

namespace rame.study.rawcomponent.business
{
    public interface IBusinessDomain
    {
        List<Despacho> DoBusinessFlow_A(DateTime now);
        IEnumerable<Despacho> DoBusinessFlow_B();
        IEnumerable<string> DoBusinessFlow_C();
        void DoBusinessFlow_D();
    }
}