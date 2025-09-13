using LocalUp.Application.DTOs;
using LocalUp.Application.Interfaces.Repository.Read.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalUp.Application.Interfaces.Repository.Read;

public interface IProductReadRepository : IReadRepository<ProductDto> { }
