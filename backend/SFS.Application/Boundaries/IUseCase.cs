using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Boundaries
{
    public interface IUseCase<in TIn>
    {
        Task ExecuteAsync(TIn input);
    }
}
