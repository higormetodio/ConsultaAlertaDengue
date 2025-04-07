using ConsultaAlertaDengue.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlertaDengue.Application.UseCases.RegisterDadosDengueUseCase
{
    public interface IRegisterDadosDengueUseCase
    {
        public Task<ResultViewModel<string>> ExecuteAsync();
    }
}
