using FluentValidation;
using LiteBus.Commands.Abstractions;

namespace Store.Shared.Behaviors
{
    public class GlobalCommandValidator<TCommand>(IEnumerable<IValidator<TCommand>> _validators) : ICommandValidator<TCommand>
   where TCommand : ICommand
    {
        public async Task ValidateAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            if (!_validators.Any())
                return;

            var context = new ValidationContext<TCommand>(command);

            var validationResults = await Task.WhenAll(
               _validators.Select(v => v.ValidateAsync(context, cancellationToken))
             );

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f is not null)
                .ToList();

            if (failures.Count > 0)
                throw new ValidationException(failures);

        }
    }
}