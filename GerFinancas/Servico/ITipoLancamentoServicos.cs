﻿using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public interface ITipoLancamentoServicos
    {
        TipoLancamento Adicionar(TipoLancamento tipoLancamento);
    }
}