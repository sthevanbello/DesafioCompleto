﻿using Desafio.Models;

namespace Desafio_EF.Interfaces
{
    public interface ILoginRepository
    {
        //string Logar(string email, string senha);
        string Logar(Login login);
    }
}
