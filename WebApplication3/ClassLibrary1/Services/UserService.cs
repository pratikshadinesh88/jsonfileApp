using Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IFileLoader _fileLoader;

        public UserService(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }
        public bool UserGetAsync(UserRequestDTO userRequestDTO,
            CancellationToken cancellationToken = default)
        {
            var fileData = _fileLoader.LoadAsync(userRequestDTO, cancellationToken);
            return true;
        }
    }
}

