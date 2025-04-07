using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlertaDengue.Application.UseCases.RegisterDadosDengueUseCase
{
    public class RegisterDadosDengueUseCase : IRegisterDadosDengueUseCase
    {
        private readonly IAlertaDengueService _alertaDengueService;

        public RegisterDadosDengueUseCase(IAlertaDengueService alertaDengueService)
        {
            _alertaDengueService = alertaDengueService;
        }

        public async Task<ResultViewModel<string>> ExecuteAsync()
        {
            var (success, result) = await _alertaDengueService.AtualizaDadosDengueAsync();

            if (!success)
            {
                return ResultViewModel<string>.Error(result);
            }

            return ResultViewModel<string>.Success(result);
        }
    }
}
