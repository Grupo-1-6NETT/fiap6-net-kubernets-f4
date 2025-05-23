﻿using Application.Exceptions;
using Application.Validators;
using MediatR;

namespace Application.Contato;

public class AdicionarContatoCommand : IRequest<Guid>
{
    public string Nome { get; set; } = String.Empty;
    public string Telefone { get; set; } = String.Empty;
    public string DDD { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;

    public void Validate()
    {
        var validator = new ModelContatoValidator();
        var result = validator.Validate(this);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ContatoValidationException(errors);
        }
    }

}
