using MediatR;
using Microsoft.EntityFrameworkCore;
using VOLXYSEAT.DOMAIN.Exceptions;
using VOLXYSEAT.DOMAIN.Repositories;

namespace VOLXYSEAT.API.Application.Commands.Subscription.Close
{
    public class CloseSubscriptionCommandHandler : IRequestHandler<CloseSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository _repository;

        public CloseSubscriptionCommandHandler(ISubscriptionRepository repository)
        {
            _repository = repository ?? throw new VolxyseatDomainException(nameof(repository));
        }
        public async Task<bool> Handle(CloseSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new VolxyseatDomainException(nameof(request));

            var subscription = await _repository.GetByIdAsync(request.Id);
            if (subscription == null) throw new VolxyseatDomainException("Subscription does not exist");

            subscription.Close(request.Comment);

            _repository.Update(subscription);

            try
            {
                var result = await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return result > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Recuperar as entradas que causaram o conflito
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is DOMAIN.Models.Subscription)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        if (databaseValues == null)
                        {
                            throw new VolxyseatDomainException("The subscription was deleted by another user.");
                        }

                        // Exemplo: resolve os conflitos aceitando os valores do banco de dados
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }

                // Tente salvar novamente as alterações
                await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return true;
            }

        }
    }
}
